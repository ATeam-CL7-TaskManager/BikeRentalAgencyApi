using BikeRentalAgencyUI.Models;
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
        public async Task<IActionResult> Index()
        {
            IEnumerable<Bike> bike = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("http://localhost:5000/Api/");

                var responseTask = await client.GetAsync("Bike/GetBikes");
                if (responseTask.IsSuccessStatusCode)
                {
                    var result = responseTask.Content.ReadAsStringAsync().Result;
                    bike = JsonConvert.DeserializeObject<IEnumerable<Bike>>(result);
                }

                else
                {
                    bike = (IEnumerable<Bike>)Enumerable.Empty<Bike>();
                    ModelState.AddModelError(string.Empty, "error");
                }
            }
            return View(bike);
        }
    }
}