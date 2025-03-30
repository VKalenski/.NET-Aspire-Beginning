using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var keycloak = builder.AddKeycloakContainer("keycloak");

var mssql = builder.AddSqlServer("test-mssql");

var redis = builder.AddRedis("test-redis")
    .WithRedisInsight();

var postgres = builder.AddPostgres("test-db")
    .WithPgAdmin();

var rabbitMq = builder.AddRabbitMQ("test-rabbit-mq")
    .WithManagementPlugin();

var grafana = builder.AddContainer("grafana", "grafana/grafana")
    .WithEndpoint(port: 3010, targetPort: 3000, scheme: "http", name: "http");

builder.AddProject<Projects.WebApplication>("webapplication");

builder.AddProject<Projects.WebService>("webservice");

builder.Build().Run();
