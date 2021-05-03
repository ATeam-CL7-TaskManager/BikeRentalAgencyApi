using BikeRentalAgencyUI.Models;
using BikeRentalAgencyUI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BikeRentalAgencyUI.Controllers
{
    public class BikeController : Controller
    {
        readonly IBikeRepository repository;
        public BikeController(IBikeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var model = await repository.GetBikes();
            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            var model = new BikeViewModel();
            if (id == null)
            {
                model.Bike = new Bike();
                return View(model);
            }

            model.Bike = await repository.GetBike(id);
            //model.Bikes
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Bike bike)
        {
            TempData["message"] = string.Empty;
            string message;

            if (bike == null) return View(new BikeViewModel());

            bool succeeded;
            //add new bike
            if (bike.BikeID == 0)
            {
                succeeded = await repository.AddBike(bike);
                message = $"{bike.BikeID} has not been added";

                //Checking the response is successful or not   
                if (succeeded)
                {
                    message = $"{bike.BikeID} has been added";
                }
            }
            else
            {
                //update existing bike
                succeeded = await repository.UpdateBike(bike);
                message = $"{bike.BikeID} has not been saved";
                //Checking the response is successful or not   
                if (succeeded)
                {
                    message = $"{bike.BikeID} has been saved";
                }
            }
            TempData["message"] = message;

            if (succeeded) return RedirectToAction("Index");

            var model = new BikeViewModel
            {
                Bike = bike
            };
            return View(model);
        }


        public async Task<ActionResult> Details(int id)
        {
            var model = new BikeViewModel
            {
                Bike = await repository.GetBike(id)
            };

            return View(model);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            TempData["message"] = string.Empty;
            bool succeeded = await repository.DeleteBike(id);
            TempData["message"] = $"Bike not deleted";
            if (succeeded)
            {
                TempData["message"] = $"Bike deleted";
            }
            //returning to view  
            return RedirectToAction("Index");
        }
    }
}