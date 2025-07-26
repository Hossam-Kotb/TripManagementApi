using Microsoft.EntityFrameworkCore;
using TripManagementAPI.Models;

namespace TripManagementAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Trip> Trips { get; set; }
    }
}
