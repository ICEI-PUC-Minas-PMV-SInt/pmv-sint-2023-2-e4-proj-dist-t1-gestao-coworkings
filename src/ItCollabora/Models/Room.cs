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
        [Column(TypeName = "decimal(18,2")]
        public decimal Price { get; set; }

        [Required]
        public int TotalCapacity { get; set; }

        [ForeignKey("OwnerUser")]
        public Guid OwnerUserId { get; set; }
        
        public UserModel OwnerUser { get; set; }

    }
}