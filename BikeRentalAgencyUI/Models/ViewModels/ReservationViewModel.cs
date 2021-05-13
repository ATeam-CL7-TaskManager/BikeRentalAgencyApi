using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgencyUI.Models
{
    public class ReservationViewModel
    {
        public Reservation Reservation { get; set; }
        public List<Reservation> Reservations { get; set; }
        public SelectList BikeStores { get; set; }
        public string SelectedStore { get; set; }
        public string HomeStore { get; set; }
        public string DropOffStore { get; set; }
    }
}
