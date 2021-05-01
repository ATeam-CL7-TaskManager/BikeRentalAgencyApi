using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgencyUI.Models
{
    public class Bike
    {
        public int BikeID { get; set; }
        public int StoreID { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal Price { get; set; }
        public decimal FrameSize { get; set; }
        public bool IsRented { get; set; }
        public bool Motorized { get; set; }
        public bool MTBSuspension {get;set;}
        public bool AllTerrainTires { get; set; }
        public string BikeStyle { get; set; }
    }
}
