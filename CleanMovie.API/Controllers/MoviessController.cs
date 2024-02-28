using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CleanMovie.Application;
using CleanMovie.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanMovie.API.Controllers
{
    // Attribut [Route("api/[controller]")] menentukan pola routing untuk controller ini
    // Attribut [ApiController] menandakan bahwa controller ini adalah API controller
    [Route("api/[controller]")]
    [ApiController]
    public class MoviessController : ControllerBase
    {
        private readonly IMovieService _service; // Dependensi ke IMovieService

        // Konstruktor untuk menginisialisasi MoviessController dengan sebuah IMovieService
        public MoviessController(IMovieService service)
        {
            _service = service;
        }

        // Endpoint HTTP GET untuk mengambil semua film
        [HttpGet]
        public ActionResult<List<Movie>> Get()
        {
            var moviesFromService = _service.GetAllMovies(); // Memanggil IMovieService untuk mendapatkan semua film
            return Ok(moviesFromService); // Mengembalikan hasil dalam respons HTTP 200 OK
        }

        // Endpoint HTTP GET untuk mengambil film berdasarkan ID
        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovie(int id)
        {
            var movie = _service.GetMovieById(id); // Memanggil IMovieService untuk mendapatkan film berdasarkan ID
            if (movie == null)
            {
                return NotFound(); // Mengembalikan respons HTTP 404 Not Found jika film tidak ditemukan
            }
            return Ok(movie); // Mengembalikan hasil dalam respons HTTP 200 OK
        }

        // Endpoint HTTP POST untuk menambahkan film baru
        [HttpPost]
        public ActionResult<Movie> PostMovie(Movie movie)
        {
            var createdMovie = _service.CreateMovie(movie); // Memanggil IMovieService untuk membuat film baru
            return Ok(createdMovie); // Mengembalikan hasil dalam respons HTTP 200 OK
        }

        // Endpoint HTTP PUT untuk memperbarui film berdasarkan ID
        [HttpPut("{id}")]
        public ActionResult<Movie> PutMovie(int id, Movie movie)
        {
            var updatedMovie = _service.UpdateMovie(id, movie); // Memanggil IMovieService untuk memperbarui film
            if (updatedMovie == null)
            {
                return NotFound(); // Mengembalikan respons HTTP 404 Not Found jika film tidak ditemukan
            }
            return Ok(updatedMovie); // Mengembalikan hasil dalam respons HTTP 200 OK
        }

        // Endpoint HTTP DELETE untuk menghapus film berdasarkan ID
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            _service.DeleteMovie(id); // Memanggil IMovieService untuk menghapus film
            return NoContent(); // Mengembalikan respons HTTP 204 No Content
        }

        [HttpGet]
        [Route("search")]
        public IActionResult MovieSearch([FromQuery] string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return BadRequest("Title cannot be empty");
            }

            var movie = _service.SearchMovie(title);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }
    }
}
