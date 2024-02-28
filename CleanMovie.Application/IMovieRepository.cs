using CleanMovie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application
{
    // Antarmuka IMovieRepository mendefinisikan kontrak untuk repositori film
    public interface IMovieRepository
    {
        // Metode untuk mengambil semua film dari penyimpanan data
        // Mengembalikan daftar semua film yang ada
        List<Movie> GetAllMovies();

        // Metode untuk membuat film baru
        // Menerima objek Movie yang akan dibuat, dan mengembalikan film yang baru dibuat
        Movie CreateMovie(Movie movie);

        // Metode untuk mendapatkan film berdasarkan ID-nya
        // Menerima ID film dan mengembalikan film yang sesuai dengan ID tersebut
        Movie GetMovieById(int id);

        // Metode untuk memperbarui film yang ada
        // Menerima objek Movie yang telah diperbarui
        // 'void' digunakan sebagai tipe kembalian untuk menunjukkan bahwa metode ini tidak mengembalikan nilai
        void UpdateMovie(Movie movie);

        // Metode untuk menghapus film berdasarkan ID-nya
        // Menerima ID film yang akan dihapus
        // 'void' digunakan sebagai tipe kembalian untuk menunjukkan bahwa metode ini tidak mengembalikan nilai
        void DeleteMovie(int id);

        /// search movie by title
        List<Movie> SearchMovie(string title);
    }
}
