namespace RestGraphQLgRPC.Client.Api.Setup
{
    public static class RestConfig
    {
        public const string MovieApiClientName = "MovieApiClient";

        public static IServiceCollection AddRestConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient(MovieApiClientName, client =>
            {
                var baseUrl = $"{configuration.GetSection("ServerApi:BaseUrl").Value!}/movies";
                client.BaseAddress = new Uri(baseUrl);
            });

            return services;
        }
    }
}
