using BikeRentalAgencyUI.Models;
using BikeRentalAgencyUI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> Index()
        {
            var model = await repository.GetReservations();
            return View(model);
        }


        [HttpGet]
        public async Task<ActionResult> Edit(int? id, int? bikeid, int? homeStoreID)
        {
            var model = new ReservationViewModel();
            if (id == null)
            {
                model.Reservation = new Reservation();
                if (bikeid != null)
                { model.Reservation.BikeID = (int)bikeid; }
                if (homeStoreID != null)
                { model.Reservation.HomeStoreID = (int)homeStoreID; }
                model.Reservation.StartDate = System.DateTime.Now;
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


        [Authorize(Roles = "Admin")]
        [HttpGet]
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
