using GuestExperience.Models;
using Microsoft.EntityFrameworkCore;

namespace GuestExperience.Data
{
    public class GuestExperienceDbContext : DbContext
    {
        public GuestExperienceDbContext(DbContextOptions<GuestExperienceDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
    }
}