using Grpc.Core;

using RestGraphQLgRPC.Server.Api.Data;

namespace RestGraphQLgRPC.Server.Api.GRPC.Services
{
    public class MovieService : MovieGrpcService.MovieGrpcServiceBase
    {
        public override async Task GetMovies(Empty request, IServerStreamWriter<Movie> responseStream, ServerCallContext context)
        {
            foreach (var movie in MovieData.Movies)
            {
                await responseStream.WriteAsync(movie);
            }
        }

        public override Task<MovieResponse> AddMovie(Movie request, ServerCallContext context)
        {
            var newMovie = new Movie
            {
                Id = MovieData.Movies.Max(m => m.Id) + 1,
                Title = request.Title,
                Director = request.Director,
                ReleaseYear = request.ReleaseYear
            };

            MovieData.Movies.Add(newMovie);

            return Task.FromResult(new MovieResponse
            {
                Message = "Movie added successfully",
                MovieId = newMovie.Id
            });
        }
    }
}
