using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.DataAccess.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailinUse", controller: "Account")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display (Name ="Confirm Password")]
        [Compare ("Password",ErrorMessage = "Password and Confirm Password did not matched")]
        public string ConfirmPassword { get; set; }
    }
}
