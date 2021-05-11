using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgencyUI.Models
{
    public class BikeStoreViewModel
    {
        public Bike Bike { get; set; }
        public List<Bike> Bikes { get; set; }
        public Store Store { get; set; }
        public List<Store> Stores { get; set; }
        public SelectList BikeStores { get; set; }
        public string SelectedStore { get; set; }
    }
}
