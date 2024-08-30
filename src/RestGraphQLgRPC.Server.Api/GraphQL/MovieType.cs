using GraphQL.Types;

namespace RestGraphQLgRPC.Server.Api.GraphQL
{
    public class MovieType : ObjectGraphType<Movie>
    {
        public MovieType()
        {
            Field(x => x.Id).Description("Movie ID");
            Field(x => x.Title).Description("Title of the Movie");
            Field(x => x.Director).Description("Director of the Movie");
            Field(x => x.ReleaseYear).Description("Release Year of the Movie");
        }
    }
}
