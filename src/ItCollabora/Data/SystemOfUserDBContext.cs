using Microsoft.EntityFrameworkCore;
using ItCollabora.Models;

namespace ItCollabora.Data
{
    public class SystemOfUserDBContext : DbContext
    {
        public SystemOfUserDBContext(DbContextOptions<SystemOfUserDBContext> options) : base(options) 
        { 
        }

        public DbSet<UserModel> User { get; set; } 
        public DbSet<RoomModel> Room { get; set; }
        public DbSet<RentModel> Rent { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
