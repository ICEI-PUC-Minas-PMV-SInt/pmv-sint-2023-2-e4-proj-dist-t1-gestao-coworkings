using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItCollabora.Models
{
    
    public class RoomModel
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
        public Guid OwnerUserId { get; set; }
        public Guid? RentedByUserId { get; set; }
        public Guid? UserModelUserId { get; set; }

        public UserModel OwnerUser { get; set; }
        public UserModel RentedByUser { get; set; }
        public UserModel UserModelUser { get; set; }

    }
}