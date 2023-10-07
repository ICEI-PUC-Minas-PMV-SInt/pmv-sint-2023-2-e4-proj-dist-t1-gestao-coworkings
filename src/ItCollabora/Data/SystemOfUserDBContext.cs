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

            modelBuilder.Entity<RentModel>()
                .HasKey(r => r.RentId);

            modelBuilder.Entity<RentModel>()
                .HasOne(r => r.User)
                .WithMany(u => u.Rents)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RentModel>()
                .HasOne(r => r.Room)
                .WithMany()
                .HasForeignKey(r => r.RoomId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RoomModel>()
                .HasOne(r => r.OwnerUser)            
                .WithMany(u => u.OwnedRooms)        
                .HasForeignKey(r => r.OwnerUserId)    
                .OnDelete(DeleteBehavior.Cascade);   

            modelBuilder.Entity<RoomModel>()
                .HasOne(r => r.RentedByUser)         
                .WithMany(u => u.RentedRooms)       
                .HasForeignKey(r => r.RentedByUserId)
                .OnDelete(DeleteBehavior.SetNull);    

            base.OnModelCreating(modelBuilder);
        }
    }
}