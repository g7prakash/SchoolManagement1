using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.DataAccess.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember me")]
        public bool Rememberme { get; set; }
        [NotMapped]
        public string ReturnUrl { get; set; }
        [NotMapped]
        public List<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
