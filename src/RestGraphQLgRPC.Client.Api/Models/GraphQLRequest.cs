namespace RestGraphQLgRPC.Client.Api.Models
{
    public record GraphQLRequest(string Query, object? Variables = null);
}
