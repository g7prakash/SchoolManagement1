using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string BrandName { get; set; }

        public ICollection<Bike> Bikes { get; set; }
    }

}
