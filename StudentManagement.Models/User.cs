using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        // The bcrypted JWT Token must match the PasswordHash
        // TEST - 22-04-2024 - Now the List of PasswordHash will be visible
        // [JsonIgnore]
        public string PasswordHash { get; set; }

        // TEST - 19-04-2024 - Now the List of RefreshTokens will be visible
        // [JsonIgnore]
        public virtual List<RefreshToken> RefreshTokens { get; set; }
    }
}
