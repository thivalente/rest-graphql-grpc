using Microsoft.AspNetCore.Mvc;

using RestGraphQLgRPC.Server.Api.Data;

namespace RestGraphQLgRPC.Server.Api.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
            return MovieData.Movies;
        }

        [HttpPost]
        public ActionResult<Movie> AddMovie(Movie movie)
        {
            movie.Id = MovieData.Movies.Max(m => m.Id) + 1;
            MovieData.Movies.Add(movie);
            return CreatedAtAction(nameof(GetMovies), new { id = movie.Id }, movie);
        }
    }
}
