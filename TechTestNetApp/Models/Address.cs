using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechTestNetApp.Models
{
    public class Address
    {
        public Address()
        {

        }
        [Key]
        public int Id { get; set; }
        public int houseNumber { get; set; }
        public string street { get; set; }
        public string town { get; set; }
        public int zipCode { get; set; }
        public string country { get; set; }
    }
}
