import os
import json
import random
import redis.asyncio as redis
from fastapi import FastAPI, HTTPException
from fastapi.middleware.cors import CORSMiddleware
from opentelemetry import trace
from opentelemetry.sdk.resources import Resource
from opentelemetry.sdk.trace import TracerProvider
from opentelemetry.sdk.trace.export import BatchSpanProcessor
from opentelemetry.exporter.otlp.proto.grpc.trace_exporter import OTLPSpanExporter
from opentelemetry.instrumentation.fastapi import FastAPIInstrumentor
from opentelemetry.instrumentation.redis import RedisInstrumentor
from contextlib import asynccontextmanager

TRENDING_SESSIONS = [
    {"sessionId": 17, "reason": "Most bookmarked session this week"},
    {"sessionId": 28, "reason": "Trending in AI track"},
    {"sessionId": 25, "reason": "Top-rated by attendees"},
    {"sessionId": 11, "reason": "New and gaining traction"},
    {"sessionId": 42, "reason": "Viral in the community"},
    {"sessionId": 52, "reason": "Popular with DevOps teams"},
]

RELATED_SESSIONS = {
    17: [{"sessionId": 11, "reason": "Same theme: Cloud Native Infrastructure"}],
    25: [{"sessionId": 29, "reason": "Related: Modern Frontend Development"}],
    5: [{"sessionId": 16, "reason": "Related: Low-level Systems Programming"}],
    28: [{"sessionId": 26, "reason": "Also features AI + Web integration"}],
    14: [{"sessionId": 53, "reason": "Same track: Data & Observability"}],
    45: [{"sessionId": 35, "reason": "Related: AI Agents & Multi-Agent Systems"}],
    54: [{"sessionId": 3, "reason": "Related: Linux Security & Authentication"}],
    50: [{"sessionId": 55, "reason": "Related: Performance Engineering"}],
    42: [{"sessionId": 23, "reason": "Same theme: Retro Computing"}],
    2: [{"sessionId": 22, "reason": "Related: Digital Security & Privacy"}],
}

redis_client: redis.Redis | None = None


@asynccontextmanager
async def lifespan(app: FastAPI):
    global redis_client
    conn_str = os.environ.get("ConnectionStrings__cache", "localhost:6379")
    host = "localhost"
    port = 6379
    password = None
    for part in conn_str.split(","):
        part = part.strip()
        if ":" in part and not part.startswith("password"):
            host, port_str = part.split(":", 1)
            port = int(port_str)
        elif part.startswith("password="):
            password = part.split("=", 1)[1]
    redis_client = redis.Redis(host=host, port=port, password=password, decode_responses=True)
    try:
        await redis_client.ping()
    except redis.ConnectionError:
        redis_client = None
    yield
    if redis_client:
        await redis_client.aclose()


resource = Resource.create({
    "service.name": os.environ.get("OTEL_SERVICE_NAME", "insights-api")
})
trace_provider = TracerProvider(resource=resource)
otlp_endpoint = os.environ.get("OTEL_EXPORTER_OTLP_ENDPOINT")
if otlp_endpoint:
    trace_provider.add_span_processor(BatchSpanProcessor(OTLPSpanExporter(endpoint=otlp_endpoint)))
trace.set_tracer_provider(trace_provider)

app = FastAPI(title="Conference Insights API", lifespan=lifespan)

app.add_middleware(CORSMiddleware, allow_origins=["*"], allow_methods=["*"], allow_headers=["*"])

FastAPIInstrumentor.instrument_app(app)
RedisInstrumentor().instrument()

tracer = trace.get_tracer(__name__)


@app.get("/health")
async def health():
    return {"status": "healthy"}


@app.get("/api/insights/trending")
async def get_trending():
    with tracer.start_as_current_span("get_trending_sessions") as span:
        if redis_client:
            cached = await redis_client.get("trending")
            if cached:
                span.set_attribute("cache.hit", True)
                return json.loads(cached)
            span.set_attribute("cache.hit", False)
        span.set_attribute("sessions.count", len(TRENDING_SESSIONS))
        result = TRENDING_SESSIONS
        if redis_client:
            await redis_client.setex("trending", 300, json.dumps(result))
        return result


@app.get("/api/insights/related")
async def get_related(sessionId: int):
    with tracer.start_as_current_span("get_related_sessions") as span:
        span.set_attribute("session.id", sessionId)
        if redis_client:
            cached = await redis_client.get(f"related:{sessionId}")
            if cached:
                span.set_attribute("cache.hit", True)
                return json.loads(cached)
            span.set_attribute("cache.hit", False)
        result = RELATED_SESSIONS.get(sessionId, [])
        if redis_client:
            await redis_client.setex(f"related:{sessionId}", 300, json.dumps(result))
        return result


@app.get("/api/insights/recommendations")
async def get_recommendations(userId: str = "default"):
    with tracer.start_as_current_span("get_recommendations") as span:
        span.set_attribute("user.id", userId)
        if redis_client:
            cached = await redis_client.get(f"recs:{userId}")
            if cached:
                span.set_attribute("cache.hit", True)
                return json.loads(cached)
            span.set_attribute("cache.hit", False)
        all_sessions = list(RELATED_SESSIONS.keys())
        picks = random.sample(all_sessions, min(3, len(all_sessions)))
        result = [{"sessionId": sid, "reason": "Recommended for you"} for sid in picks]
        if redis_client:
            await redis_client.setex(f"recs:{userId}", 600, json.dumps(result))
        return result
