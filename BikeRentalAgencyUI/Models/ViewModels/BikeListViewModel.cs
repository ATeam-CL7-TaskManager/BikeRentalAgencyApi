using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgencyUI.Models;

namespace BikeRentalAgencyUI.Models.ViewModels
{
    public class BikeListViewModel
    {
        public IEnumerable<Bike> Bikes { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentStore { get; set; }
    }
}
