namespace RestGraphQLgRPC.Client.Api.Models
{
    public class MovieBase
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Director { get; set; } = String.Empty;
    }
}
