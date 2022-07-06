using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechTestNetApp.Models
{
    public class Customer
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public int addressID { get; set; }
        public DateTime created { get; set; }
        [Key]
        public int Id { get; set; }
    }
}
