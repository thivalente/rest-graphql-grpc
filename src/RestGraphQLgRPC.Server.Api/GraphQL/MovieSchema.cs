using GraphQL.Types;

namespace RestGraphQLgRPC.Server.Api.GraphQL
{
    public class MovieSchema : Schema
    {
        public MovieSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<MoviesQuery>();
        }
    }
}
