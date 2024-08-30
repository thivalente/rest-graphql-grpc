using Grpc.Core;

using Microsoft.AspNetCore.Mvc;

namespace RestGraphQLgRPC.Client.Api.Controllers
{
    [ApiController]
    [Route("api/grpc/movies")]
    public class GrpcMoviesController : ControllerBase
    {
        private readonly MovieGrpcService.MovieGrpcServiceClient _client;

        public GrpcMoviesController(MovieGrpcService.MovieGrpcServiceClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            using var call = _client.GetMovies(new Empty());
            var movies = new List<Movie>();

            await foreach (var movie in call.ResponseStream.ReadAllAsync())
            {
                movies.Add(movie);
            }

            return Ok(movies);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(Movie movie)
        {
            var response = await _client.AddMovieAsync(movie);
            return Ok(response);
        }
    }
}
