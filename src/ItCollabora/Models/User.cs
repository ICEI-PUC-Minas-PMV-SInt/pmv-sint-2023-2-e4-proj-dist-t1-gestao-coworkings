using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Numerics;
using System.Text.Json.Serialization;
using ItCollabora.Models;

namespace ItCollabora.Models
{
    public class UserModel
    {

        [Key]
        public Guid UserId { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        [Required, MaxLength(50), JsonIgnore]
        public string EncryptedPassword { get; set; }

        public List<RoomModel> OwnedRooms { get; set; }
        public List<RoomModel> RentedRooms { get; set; }
        public List<RentModel> Rents { get; set; }
    }

}
