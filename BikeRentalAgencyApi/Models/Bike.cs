using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgencyApi.Models
{
    public class Bike
    {
        public int Id { get; set; }
        public int StoreID { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal BikePrice { get; set; }
        public decimal FrameSize { get; set; }
        public bool IsRented { get; set; }
        public bool Motorized { get; set; }
        public bool MTBSuspension {get;set;}
        public bool AllTerrainTires { get; set; }
        public string BikeStyle { get; set; }

    }
}
