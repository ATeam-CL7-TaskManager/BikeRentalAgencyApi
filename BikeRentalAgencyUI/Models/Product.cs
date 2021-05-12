using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BikeRentalAgencyUI.Models
{
    public class Product
    {

        public int ProductID { get; set; }
        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Please enter a positive price0")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set;}
        
    }
}
