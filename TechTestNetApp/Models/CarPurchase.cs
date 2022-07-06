using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechTestNetApp.Models
{
    public class CarPurchase
    {
        public int customerID { get; set; }
        public int carID { get; set; }
        public DateTime orderDate { get; set; }
        public int pricePaid { get; set; }
        public int salesPersonID { get; set; }
        [Key]
        public int ID { get; set; }
    }
}
