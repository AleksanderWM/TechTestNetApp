using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TechTestNetApp.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string color { get; set; }
        public string extras { get; set; }
        public int recommendPrice { get; set; }
    }
}
