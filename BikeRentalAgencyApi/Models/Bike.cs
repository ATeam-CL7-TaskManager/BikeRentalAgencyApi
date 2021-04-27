using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace BikeRentalAgencyApi.Models
{
    public class Bike
    {
        public int BikeID { get; set; }
        [Required]
        public int StoreID { get; set; }
        [Required]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Please enter a positive price")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal HourlyRate { get; set; }
        [Required]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Please enter a positive price")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        [Required]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Please enter a positive price")]
        [Column(TypeName = "decimal(18, 0)")]
        public decimal FrameSize { get; set; }
        public bool IsRented { get; set; }
        public bool Motorized { get; set; }
        public bool MTBSuspension {get;set;}
        public bool AllTerrainTires { get; set; }
        public string BikeStyle { get; set; }

    }
}
