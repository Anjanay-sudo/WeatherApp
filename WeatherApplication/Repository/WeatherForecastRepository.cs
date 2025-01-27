
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using WeatherApp.Models;
using WeatherApplication.Domain;

namespace WeatherApp.Data
{
    public class WeatherDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<City> City { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<WeatherForecast> WeatherForecast { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<SearchLog> SearchLog { get; set; } 

        public Microsoft.EntityFrameworkCore.DbSet<User> User { get; set; }
    }
}
