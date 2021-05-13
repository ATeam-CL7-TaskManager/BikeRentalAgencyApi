using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BikeRentalAgencyApi.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int BikeID { get; set; }
        [DisplayFormat(DataFormatString = "{0:s}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:s}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public bool IsComplete { get; set; }
        public int HomeStoreID {get;set;} 
        public int RentedStoreID { get; set; }
        [Required]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Please enter a positive price")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal ReservationTotal { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal AccessoriesTotal { get; set; }
        public bool IsStarted { get; set; }
        public int OrderID { get; set; }
    }
}
