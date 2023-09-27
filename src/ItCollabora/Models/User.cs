using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Numerics;
using System.Text.Json.Serialization;

namespace ItCollabora.Models
{
    public class User
    {
            [Key]
            public Guid UserId { get; set; } = new Guid();
            [Required, MaxLength(50)]
            public string Name { get; set; }
            [Required, MaxLength(50)]
            public string Email { get; set; }
            [Required, MaxLength(50), JsonIgnore]
            public string EncryptedPassword { get; set; } = Guid.Empty.ToString();
}
}
