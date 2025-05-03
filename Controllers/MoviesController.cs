using Microsoft.AspNetCore.Mvc;

namespace JurnalMod10_103022300017.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private static readonly List<Movie> movies = new() {
            new Movie("The Shawshank Redemption", "Frank Darabont", ["Tim Robbins", "Morgan Freeman", "Bob Gunton"], "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."),
            new Movie("The Godfather", "Francis Ford Coppola", ["Marlon Brando", "Al Pacino", "James Caan"], "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son."),
            new Movie("The Dark Knight", "Christopher Nolan", ["Christian Bale", "Heath Ledger", "Aaron Eckhart"], "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.")
        };
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetAllMovie()
        {
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            try
            {
                return Ok(movies[id]);
            }catch (Exception e)
            {
                return NotFound("Tidak Ada");
            }
        }

        [HttpPost]
        public ActionResult<Movie> CreateMovie([FromBody] Movie movie)
        {
            movies.Add(movie);
            return CreatedAtAction(nameof(GetMovieById), new { id = movies.Count - 1 }, movie);
        }

        [HttpPut("{id}")]
        public ActionResult<Movie> UpdateMovie(int id, [FromBody] Movie movie)
        {
            if (id < 0 || id >= movies.Count)
            {
                return NotFound("Tidak Ada");
            }
            movies[id] = movie;
            return Ok(movie);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            if (id < 0 || id >= movies.Count)
            {
                return NotFound("Tidak Ada");
            }
            movies.RemoveAt(id);
            return NoContent();
        }
    }
}
