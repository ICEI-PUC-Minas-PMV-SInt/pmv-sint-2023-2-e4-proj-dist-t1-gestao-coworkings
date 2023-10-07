using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItCollabora.Models
{
    public class RentModel
    {
        [Key]
        public Guid RentId { get; set; } = Guid.NewGuid();
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid RoomId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public UserModel User { get; set; }
        public RoomModel Room { get; set; }

        
    }
}