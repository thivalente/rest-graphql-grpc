using GraphQL;
using GraphQL.Client.Http;

using Microsoft.AspNetCore.Mvc;

using RestGraphQLgRPC.Client.Api.Models;

namespace RestGraphQLgRPC.Client.Api.Controllers
{
    [ApiController]
    [Route("api/graphql/movies")]
    public class GraphQLMoviesController : ControllerBase
    {
        private readonly GraphQLHttpClient _client;

        public GraphQLMoviesController(GraphQLHttpClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var request = new GraphQLRequest
            {
                Query = """
                            query {
                                movies {
                                    id
                                    title
                                    director
                                }
                            }
                        """
            };

            var response = await _client.SendQueryAsync<GraphQLResponseData>(request);
            return Ok(response.Data.Movies);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(Movie movie)
        {
            var request = new GraphQLRequest
            {
                Query = """
                            mutation($title: String!, $director: String!, $releaseYear: Int!) {
                                addMovie(movie: {title: $title, director: $director, releaseYear: $releaseYear}) {
                                    id
                                    title
                                    director
                                    releaseYear
                                }
                            }
                        """,
                Variables = new
                {
                    title = movie.Title,
                    director = movie.Director,
                    releaseYear = movie.ReleaseYear
                }
            };

            var response = await _client.SendMutationAsync<GraphQLResponseData>(request);
            return Ok(response.Data.AddMovie);
        }
    }
}
