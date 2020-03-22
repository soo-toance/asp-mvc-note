using AspMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AspMVC.DataContext
{
    public class AspNoteDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public AspNoteDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DevDb"));
        }

    }
}
