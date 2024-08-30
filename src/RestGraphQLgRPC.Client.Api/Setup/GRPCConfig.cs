namespace RestGraphQLgRPC.Client.Api.Setup
{
    public static class GRPCConfig
    {
        public const string MovieApiClientName = "MovieApiClient";

        public static IServiceCollection AddGRPCConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var baseUrl = configuration.GetSection("ServerApi:BaseUrl").Value!;

            services.AddGrpcClient<MovieGrpcService.MovieGrpcServiceClient>(o => { o.Address = new Uri(baseUrl); });

            return services;
        }
    }
}
