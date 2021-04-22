using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgencyApi.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int BikeId { get; set; }
                public int PaymentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsComplete { get; set; }
        public int EmployeeId { get; set; }
        public int HomeStoreId {get;set;} 
        public int RentedStoreId { get; set; }
        public decimal ReservationTotal { get; set; }
        public decimal AccessoriesTotal { get; set; }
        public decimal OrderTotal { get; set; }
        public string OrderDetails { get; set; }
        public bool IsStarted { get; set; }
    }
}
