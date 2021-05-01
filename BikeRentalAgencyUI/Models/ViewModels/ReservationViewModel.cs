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
    }
}
