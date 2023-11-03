using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ItCollabora.Models

{
    [Table("Rents")]
    public class Rent
    {
        [Key]
        public Guid IdRent { get; set; }
        public int IdUser { get; set; }
        public int IdRoom { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}