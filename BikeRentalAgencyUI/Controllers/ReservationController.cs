using BikeRentalAgencyUI.Repository;
using BikeRentalAgencyUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BikeRentalAgencyUI.Controllers
{
    public class ReservationController : Controller
    {
        readonly IReservationRepository repository;
        public ReservationController(IReservationRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var model = await repository.GetReservations();
            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            var model = new ReservationViewModel();
            if (id == null)
            {
                model.Reservation = new Reservation();
                return View(model);
            }

            model.Reservation = await repository.GetReservation(id);
            //model.Reservation
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Reservation reservation)
        {
            TempData["message"] = string.Empty;
            string message;

            if (reservation == null) return View(new ReservationViewModel());

            bool succeeded;
            //add new reservation
            if (reservation.ReservationID == 0)
            {
                succeeded = await repository.AddReservation(reservation);
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

            if (succeeded) return RedirectToAction("Index");

            var model = new ReservationViewModel
            {
                Reservation = reservation
            };
            return View(model);
        }

        public async Task<ActionResult> Details(int id)
        {
            var model = new ReservationViewModel
            {
                Reservation = await repository.GetReservation(id)
            };

            return View(model);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            TempData["message"] = string.Empty;
            bool succeeded = await repository.DeleteReservation(id);
            TempData["message"] = $"Reservation not deleted";
            if (succeeded)
            {
                TempData["message"] = $"Reservation deleted";
            }
            //returning to view  
            return RedirectToAction("Index");
        }
    }
}
