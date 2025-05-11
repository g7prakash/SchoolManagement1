using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccess.ViewModels
{
    public class EditRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
        public string Id { get; set; }
        public List<string> Users { get; set; }
    }
}
