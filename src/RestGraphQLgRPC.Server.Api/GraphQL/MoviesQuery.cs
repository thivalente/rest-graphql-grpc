using GraphQL.Types;

using RestGraphQLgRPC.Server.Api.Data;

namespace RestGraphQLgRPC.Server.Api.GraphQL
{
    public class MoviesQuery : ObjectGraphType
    {
        public MoviesQuery()
        {
            Field<ListGraphType<MovieType>>("movies").Resolve(context => MovieData.Movies);
        }
    }
}
