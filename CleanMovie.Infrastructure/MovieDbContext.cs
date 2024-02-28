using CleanMovie.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Infrastructure
{
    // Kelas MovieDbContext adalah kelas yang mewakili konteks database untuk film
    public class MovieDbContext : DbContext
    {
        // Konstruktor untuk menginisialisasi MovieDbContext dengan DbContextOptions<MovieDbContext>
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {

        }

        // DbSet Movies digunakan untuk menghubungkan antara entitas Movie dengan tabel dalam database
        public DbSet<Movie> Movies { get; set; }

        // Metode yang dipanggil saat model untuk konteks ini sedang dibangun
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Panggil metode OnModelCreating dari DbContext

            // Konfigurasi properti Cost dari entitas Movie
            modelBuilder.Entity<Movie>()
                .Property(p => p.Cost) // Pilih properti Cost dari entitas Movie, huruf "p" bisa diganti dengan kata apapun. Yang penting, itu adalah parameter yang mewakili properti dari entitas yang kita tuju.
                .HasColumnType("decimal(18,2)"); // Tetapkan tipe kolom SQL Server sebagai decimal(18,2)
        }
    }
}
