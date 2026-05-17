using Microsoft.EntityFrameworkCore;
using CampusConnectMVC.Models.Entities;

namespace CampusConnectMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}