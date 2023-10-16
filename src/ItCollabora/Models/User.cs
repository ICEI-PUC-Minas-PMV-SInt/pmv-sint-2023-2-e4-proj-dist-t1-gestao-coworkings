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

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string EncryptedPassword { get; set; }

        [JsonIgnore]
        public List<RoomModel> OwnedRooms { get; set; }
    }

}
