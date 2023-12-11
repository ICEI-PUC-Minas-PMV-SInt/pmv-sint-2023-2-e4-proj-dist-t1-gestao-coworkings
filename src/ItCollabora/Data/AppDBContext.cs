using Microsoft.EntityFrameworkCore;
using ItCollabora.Models;

namespace ItCollabora.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<UserModel> User { get; set; }
        public DbSet<RoomModel> Room { get; set; }
        public DbSet<Rent> Rents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}