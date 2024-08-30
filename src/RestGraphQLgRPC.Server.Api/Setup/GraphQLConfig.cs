using GraphQL;
using GraphQL.Types;

using RestGraphQLgRPC.Server.Api.GraphQL;

namespace RestGraphQLgRPC.Server.Api.Setup
{
    public static class GraphQLConfig
    {
        public static IServiceCollection AddGraphQLConfig(this IServiceCollection services)
        {
            services.AddScoped<MovieType>();
            services.AddScoped<MoviesQuery>();
            services.AddScoped<ISchema, MovieSchema>();

            services.AddGraphQL(options =>
            {
                options.AddSystemTextJson();
                options.ConfigureExecutionOptions(opt => { opt.EnableMetrics = false; });
            });

            return services;
        }

        public static void UseGraphQL(this WebApplication app)
        {
            app.UseGraphQL<ISchema>("/api/graphql");
            app.UseGraphQLPlayground("/ui/playground");
        }
    }
}
