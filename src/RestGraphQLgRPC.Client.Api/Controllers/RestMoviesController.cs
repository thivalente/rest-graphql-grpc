using System.Text.Json;

using Microsoft.AspNetCore.Mvc;

using RestGraphQLgRPC.Client.Api.Models;
using RestGraphQLgRPC.Client.Api.Setup;

namespace RestGraphQLgRPC.Client.Api.Controllers
{
    [ApiController]
    [Route("api/rest/movies")]
    public class RestMoviesController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public RestMoviesController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(RestConfig.MovieApiClientName);
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var response = await _httpClient.GetAsync(String.Empty);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var movies = JsonSerializer.Deserialize<List<Movie>>(json, options);

            return Ok(movies);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(Movie movie)
        {
            var movieJson = new StringContent(JsonSerializer.Serialize(movie), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(String.Empty, movieJson);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return Ok(result);
        }
    }
}
