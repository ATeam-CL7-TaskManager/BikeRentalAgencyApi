using BikeRentalAgencyUI.Models;
using BikeRentalAgencyUI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgencyUI.Controllers
{
    public class CustomerReservationController : Controller
    {
        private readonly BikeStoreContext _context;

        readonly IReservationRepository repository;
        public CustomerReservationController(IReservationRepository repository, BikeStoreContext context)
        {
            this.repository = repository;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id, int? bikeid, int? homeStoreID)
        {
            var storesSelect = await (from s in _context.Stores
                                select s.AddressLine1).ToListAsync();
           
            var reservationVM = new ReservationViewModel();
            reservationVM.BikeStores = new SelectList(storesSelect);
            bool exists;
            //if the reservation doesnt exist, create a new reservation and pull the bike and homestore id from the URL, and set the start datetime to now.
            if (id == 0)
            {
                exists = false;
                reservationVM.Reservation = new Reservation();
                if (bikeid != null)
                { reservationVM.Reservation.BikeID = (int)bikeid; }
                if (homeStoreID != null)
                { reservationVM.Reservation.HomeStoreID = (int)homeStoreID; }
                reservationVM.Reservation.StartDate = System.DateTime.Now;
                reservationVM.HomeStore = await (from s in _context.Stores
                                                 where s.StoreID == homeStoreID
                                                 select s.AddressLine1).FirstOrDefaultAsync();
            }

            //if the resrvation does exist, pull the existing information
            else
            {
                exists = true;
                reservationVM.Reservation = await repository.GetReservation(id);
                reservationVM.HomeStore = await (from s in _context.Stores
                                                 where s.StoreID == reservationVM.Reservation.HomeStoreID
                                                 select s.AddressLine1).FirstOrDefaultAsync();
                reservationVM.DropOffStore = await (from s in _context.Stores
                                                    where s.StoreID == reservationVM.Reservation.RentedStoreID
                                                    select s.AddressLine1).FirstOrDefaultAsync();
            }
            reservationVM.HomeStore = await (from s in _context.Stores
                                             where s.StoreID == reservationVM.Reservation.HomeStoreID
                                             select s.AddressLine1).FirstOrDefaultAsync();
            reservationVM.DropOffStore = await (from s in _context.Stores
                                                where s.StoreID == reservationVM.Reservation.RentedStoreID
                                                select s.AddressLine1).FirstOrDefaultAsync();

            return View(reservationVM);

        }
        [HttpPost]
        public async Task<ActionResult> Edit(ReservationViewModel reservationVM)
        {
            TempData["message"] = string.Empty;
            string message;
            var reservation = reservationVM.Reservation;
            if (reservation == null) return View(new ReservationViewModel());

            bool succeeded;
            //add new reservation
            if (reservation.ReservationID == 0)
            {
                reservation.ReservationTotal = await (from b in _context.Bikes
                                                      where b.BikeID == reservation.BikeID
                                                      select b.HourlyRate).FirstOrDefaultAsync() * (decimal)(reservation.EndDate - reservation.StartDate).TotalHours;
                decimal.Round(reservation.ReservationTotal, 2, MidpointRounding.AwayFromZero);
                reservation.RentedStoreID = await (from s in _context.Stores
                                                         where s.AddressLine1 == reservationVM.SelectedStore
                                                         select s.StoreID).FirstOrDefaultAsync();
                reservation.AccessoriesTotal = 10;
                var res = await repository.AddReservation(reservation);
                string resid = await res.Content.ReadAsStringAsync();
                reservation.ReservationID = Convert.ToInt32(resid);
                succeeded = res.IsSuccessStatusCode;
                message = $"{reservation.ReservationID} has not been added";

                //Checking the response is successful or not   
                if (succeeded)
                {
                    message = $"{reservation.ReservationID} has been added";
                }
            }
            else
            {
                //update existing reservation
                succeeded = await repository.UpdateReservation(reservation);
                message = $"{reservation.ReservationID} has not been saved";
                //Checking the response is successful or not   
                if (succeeded)
                {
                    message = $"{reservation.ReservationID} has been saved";
                }
            }
            TempData["message"] = message;

            return View(reservationVM);
        }
        [HttpGet]
        public async Task<ActionResult> Finalize(int resId)
        {
            var reservationVM = new ReservationViewModel();
            reservationVM.Reservation = await repository.GetReservation(resId);
            reservationVM.HomeStore = await (from s in _context.Stores
                                             where s.StoreID == reservationVM.Reservation.HomeStoreID
                                             select s.AddressLine1).FirstOrDefaultAsync();
            return View(reservationVM);
        }

    }
}
