namespace RestGraphQLgRPC.Client.Api.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Director { get; set; } = String.Empty;
        public int ReleaseYear { get; set; }
    }
}
