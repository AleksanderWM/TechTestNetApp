using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechTestNetApp.Models
{
    public class SalesPerson
    {
        public string name { get; set; }
        public string jobTitle { get; set; }
        public int addressID { get; set; }
        public int salary { get; set; }
        [Key]
        public int Id { get; set; }
    }
}
