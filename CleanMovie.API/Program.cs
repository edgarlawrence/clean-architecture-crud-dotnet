using CleanMovie.Application;
using CleanMovie.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Registrasi konfigurasi aplikasi
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Menambahkan layanan Database
builder.Services.AddDbContext<MovieDbContext>(opt =>
    opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), // Mengkonfigurasi penggunaan SQL Server sebagai database
        b => b.MigrationsAssembly("CleanMovie.API"))); // Mengatur lokasi assmbly migrasi untuk EF Core

builder.Services.AddScoped<IMovieService, MovieService>(); // Mendaftarkan antarmuka IMovieService dengan implementasinya, MovieService
builder.Services.AddScoped<IMovieRepository, MovieRepository>(); // Mendaftarkan antarmuka IMovieRepository dengan implementasinya, MovieRepository

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
