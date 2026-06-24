#:sdk Aspire.AppHost.Sdk@13.4.6
#:package Aspire.Hosting.Redis@13.4.6
#:package Aspire.Hosting.PostgreSQL@13.4.6
#:package Aspire.Hosting.Python@13.4.6
#:package Aspire.Hosting.JavaScript@13.4.6
#:package Aspire.Hosting.Docker@13.4.6

#pragma warning disable ASPIRECERTIFICATES001
#pragma warning disable ASPIREPIPELINES001

using Aspire.Hosting.Pipelines;

var builder = DistributedApplication.CreateBuilder(args);

builder.Pipeline.DisableBuildOnlyContainerValidation();

var compose = builder.AddDockerComposeEnvironment("compose");

var cache = builder.AddRedis("cache");

var postgres = builder.AddPostgres("postgres");
var conferencedb = postgres.AddDatabase("conferencedb");

var sessionsApi = builder.AddProject("sessions-api", "./SessionsApi/SessionsApi.csproj")
    .WithReference(conferencedb)
    .WaitFor(conferencedb)
    .WithHttpEndpoint()
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health");

var insightsApi = builder.AddUvicornApp("insights-api", "./insights-api", "main:app")
    .WithReference(cache)
    .WaitFor(cache)
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health");

var frontend = builder.AddViteApp("frontend", "./Frontend")
    .WithEnvironment("VITE_SESSIONS_API", sessionsApi.GetEndpoint("http"))
    .WithEnvironment("VITE_INSIGHTS_API", insightsApi.GetEndpoint("http"));

builder.Build().Run();
