using RestGraphQLgRPC.Server.Api.GRPC.Services;

namespace RestGraphQLgRPC.Server.Api.Setup
{
    public static class GRPCConfig
    {
        public static IServiceCollection AddgRPCConfig(this IServiceCollection services)
        {
            services.AddGrpc(options =>
            {
                options.EnableDetailedErrors = true;
            }).AddJsonTranscoding();

            return services;
        }

        public static void UsegRPC(this WebApplication app)
        {
            app.MapGrpcService<MovieService>();

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
        }
    }
}
