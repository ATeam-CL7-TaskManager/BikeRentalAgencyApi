﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeRentalAgencyUI.Models
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationID { get; set; }
        public int BikeID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsComplete { get; set; }
        public int HomeStoreID {get;set;} 
        public int RentedStoreID { get; set; }
        public decimal ReservationTotal { get; set; }
        public decimal AccessoriesTotal { get; set; }
        public bool IsStarted { get; set; }
        public int OrderID { get; set; }
    }
}
