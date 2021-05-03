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
        IEnumerable<Reservation> reservation = null;

        // GET: Reservation
        public async Task<ActionResult> Index()
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("http://localhost:5000/Api/");

                var responseTask = await client.GetAsync("Reservation/GetReservations");
                if (responseTask.IsSuccessStatusCode)
                {
                    var result = responseTask.Content.ReadAsStringAsync().Result;
                    reservation = JsonConvert.DeserializeObject<IEnumerable<Reservation>>(result);
                }

                else
                {
                    reservation = (IEnumerable<Reservation>)Enumerable.Empty<Reservation>();
                    ModelState.AddModelError(string.Empty, "error");
                }

            }
            return View(reservation);

        }

        // GET: Reservation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reservation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservation/Create
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

        // GET: Reservation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reservation/Edit/5
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

        // GET: Reservation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reservation/Delete/5
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
