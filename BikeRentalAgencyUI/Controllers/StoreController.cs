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
    public class StoreController : Controller
    {


        // GET: StoreController
        public async Task<ActionResult> Index()
        {
            IEnumerable<Store> store = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("http://localhost:5000/Api/");

                var responseTask = await client.GetAsync("Store/GetStores");
                if (responseTask.IsSuccessStatusCode)
                {
                    var result = responseTask.Content.ReadAsStringAsync().Result;
                    store = JsonConvert.DeserializeObject<IEnumerable<Store>>(result);
                }

                else
                {
                    store = (IEnumerable<Store>)Enumerable.Empty<Store>();
                    ModelState.AddModelError(string.Empty, "error");
                }

            }
            return View(store);

        }

        // GET: StoreController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StoreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StoreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
