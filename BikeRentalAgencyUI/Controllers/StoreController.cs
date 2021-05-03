using BikeRentalAgencyUI.Models;
using BikeRentalAgencyUI.Repository;
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
    public class StoreController : Controller
    {
        readonly IStoreRepository repository;
        public StoreController(IStoreRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var model = await repository.GetStores();
            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            var model = new StoreViewModel();
            if (id == null)
            {
                model.Store = new Store();
                return View(model);
            }

            model.Store = await repository.GetStore(id);
            //model.Store
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Store store)
        {
            TempData["message"] = string.Empty;
            string message;

            if (store == null) return View(new StoreViewModel());

            bool succeeded;
            //add new store
            if (store.StoreID == 0)
            {
                succeeded = await repository.AddStore(store);
                message = $"{store.StoreID} has not been added";

                //Checking the response is successful or not   
                if (succeeded)
                {
                    message = $"{store.StoreID} has been added";
                }
            }
            else
            {
                //update existing store
                succeeded = await repository.UpdateStore(store);
                message = $"{store.StoreID} has not been saved";
                //Checking the response is successful or not   
                if (succeeded)
                {
                    message = $"{store.StoreID} has been saved";
                }
            }
            TempData["message"] = message;

            if (succeeded) return RedirectToAction("Index");

            var model = new StoreViewModel
            {
                Store = store
            };
            return View(model);
        }

        public async Task<ActionResult> Details(int id)
        {
            var model = new StoreViewModel
            {
                Store = await repository.GetStore(id)
            };

            return View(model);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            TempData["message"] = string.Empty;
            bool succeeded = await repository.DeleteStore(id);
            TempData["message"] = $"Store not deleted";
            if (succeeded)
            {
                TempData["message"] = $"Store deleted";
            }
            //returning to view  
            return RedirectToAction("Index");
        }
    }
}
