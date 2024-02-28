using CleanMovie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application
{
    // Kelas MovieService bertanggung jawab atas logika bisnis terkait film
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        // Konstruktor untuk menginisialisasi MovieService dengan sebuah IMovieRepository
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // Metode untuk membuat film baru
        // Menerima objek Movie yang akan dibuat, dan mengembalikan film yang baru dibuat
        public Movie CreateMovie(Movie movie)
        {
            _movieRepository.CreateMovie(movie);
            return movie;
        }

        // Metode untuk mengambil semua film
        // Mengembalikan daftar semua film yang ada
        public List<Movie> GetAllMovies()
        {
            var movies = _movieRepository.GetAllMovies();
            return movies;
        }

        // Metode untuk mendapatkan film berdasarkan ID-nya
        // Menerima ID film dan mengembalikan film yang sesuai dengan ID tersebut
        public Movie GetMovieById(int id)
        {
            return _movieRepository.GetMovieById(id);
        }

        // Metode untuk memperbarui film yang ada
        // Menerima ID film yang akan diperbarui dan objek Movie yang telah diperbarui
        // Mengembalikan film yang telah diperbarui
        public Movie UpdateMovie(int id, Movie movie)
        {
            var existingMovie = _movieRepository.GetMovieById(id);
            if (existingMovie == null)
                return null; // Handle kasus ketika Movie tidak ada

            // Update existing movie properties
            existingMovie.Name = movie.Name;
            existingMovie.Cost = movie.Cost;

            _movieRepository.UpdateMovie(existingMovie);
            return existingMovie;
        }

        // Metode untuk menghapus film berdasarkan ID-nya
        // Menerima ID film yang akan dihapus
        public void DeleteMovie(int id)
        {
            _movieRepository.DeleteMovie(id);
        }

        List<Movie> IMovieService.SearchMovie(string title)
        {
           return _movieRepository.SearchMovie(title);
        }
    }
}
