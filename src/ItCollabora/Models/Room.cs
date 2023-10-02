using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItCollabora.Models
{
    
    public class Room
    {
        [Key]
        public Guid RoomId { get; set; } = Guid.NewGuid();

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int TotalCapacity { get; set; }

        [ForeignKey("OwnerUserId")]
        public Guid OwnerUserId { get; set; }

        public User OwnerUser { get; set; }

        public ICollection<User> ReservedByUsers { get; set; } = new List<User>();
    }
}