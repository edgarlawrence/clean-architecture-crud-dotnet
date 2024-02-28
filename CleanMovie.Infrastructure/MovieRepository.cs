using CleanMovie.Application;
using CleanMovie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Infrastructure
{
    // Kelas MovieRepository bertanggung jawab atas akses ke data film dalam database
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _movieDbContext; // Digunakan untuk mengakses konteks database

        // Konstruktor untuk menginisialisasi MovieRepository dengan sebuah MovieDbContext
        public MovieRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        // Metode untuk membuat film baru
        // Menerima objek Movie yang akan dibuat, dan mengembalikan film yang baru dibuat
        public Movie CreateMovie(Movie movie)
        {
            _movieDbContext.Movies.Add(movie); // Menambahkan film ke set entitas Movies di dalam konteks database
            _movieDbContext.SaveChanges(); // Menyimpan perubahan ke database

            return movie; // Mengembalikan film yang baru dibuat
        }

        // Metode untuk mengambil semua film dari database
        // Mengembalikan daftar semua film yang ada
        public List<Movie> GetAllMovies()
        {
            return _movieDbContext.Movies.ToList(); // Mengambil semua film dari database dan mengonversinya menjadi daftar
        }

        // Metode untuk mendapatkan film berdasarkan ID-nya
        // Menerima ID film dan mengembalikan film yang sesuai dengan ID tersebut
        public Movie GetMovieById(int id)
        {
            return _movieDbContext.Movies.FirstOrDefault(m => m.Id == id); // Mengambil film pertama yang memiliki ID yang cocok
        }

        // Metode untuk memperbarui film yang ada dalam database
        // Menerima objek Movie yang telah diperbarui
        public void UpdateMovie(Movie movie)
        {
            _movieDbContext.Movies.Update(movie); // Memperbarui entitas film dalam konteks database
            _movieDbContext.SaveChanges(); // Menyimpan perubahan ke database
        }

        // Metode untuk menghapus film dari database berdasarkan ID-nya
        // Menerima ID film yang akan dihapus
        public void DeleteMovie(int id)
        {
            var movie = _movieDbContext.Movies.FirstOrDefault(m => m.Id == id); // Mengambil film berdasarkan ID
            if (movie != null)
            {
                _movieDbContext.Movies.Remove(movie); // Menghapus film dari set entitas Movies di dalam konteks database
                _movieDbContext.SaveChanges(); // Menyimpan perubahan ke database
            }
        }

        public List<Movie> SearchMovie(string title)
        {
            return _movieDbContext.Movies.Where(x => x.Name.Contains(title)).ToList();
        }
    }
}
