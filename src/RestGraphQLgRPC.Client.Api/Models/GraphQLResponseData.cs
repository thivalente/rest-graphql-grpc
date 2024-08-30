namespace RestGraphQLgRPC.Client.Api.Models
{
    public class GraphQLResponseData
    {
        public List<MovieBase> Movies { get; set; } = [];
        public Movie AddMovie { get; set; } = default!;
    }
}
