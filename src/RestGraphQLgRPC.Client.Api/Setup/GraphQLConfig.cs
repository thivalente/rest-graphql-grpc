using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;

namespace RestGraphQLgRPC.Client.Api.Setup
{
    public static class GraphQLConfig
    {
        public static IServiceCollection AddGraphQLConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var baseUrl = $"{configuration.GetSection("ServerApi:BaseUrl").Value!}/graphql";

            services.AddSingleton(s => new GraphQLHttpClient(new GraphQLHttpClientOptions { EndPoint = new Uri(baseUrl!) }, new SystemTextJsonSerializer()));

            return services;
        }
    }
}
