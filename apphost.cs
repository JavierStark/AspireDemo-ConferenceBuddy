#:sdk Aspire.AppHost.Sdk@13.4.6
#:package Aspire.Hosting.Redis@13.4.6
#:package Aspire.Hosting.PostgreSQL@13.4.6
#:package Aspire.Hosting.Python@13.4.6
#:package Aspire.Hosting.JavaScript@13.4.6
#:package Aspire.Hosting.Docker@13.4.6
#:package Aspire.Hosting.Yarp@13.4.6

#pragma warning disable ASPIRECERTIFICATES001
#pragma warning disable ASPIREPIPELINES001
#pragma warning disable ASPIREJAVASCRIPT001

using Aspire.Hosting.Pipelines;
using Aspire.Hosting.Yarp;

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
    .WithReference(sessionsApi)
    .WithReference(insightsApi);

var gateway = builder.AddYarp("gateway")
    .WithConfiguration(yarp =>
    {
        yarp.AddRoute("/api/sessions/{**catch-all}", sessionsApi);
        yarp.AddRoute("/api/insights/{**catch-all}", insightsApi);

        if (builder.ExecutionContext.IsRunMode)
        {
            yarp.AddRoute("{**catch-all}", frontend);
        }
    })
    .WithExternalHttpEndpoints()
    .PublishWithStaticFiles(frontend);

builder.Build().Run();
