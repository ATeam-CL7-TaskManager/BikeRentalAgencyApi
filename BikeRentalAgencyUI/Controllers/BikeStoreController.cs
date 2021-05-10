using BikeRentalAgencyUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgencyUI.Controllers
{
    public class BikeStoreController : Controller
    {
        private readonly BikeStoreContext _context;

        public BikeStoreController(BikeStoreContext context)
        {
            _context = context;
        }
        // GET: HomeController1
        public async Task<ActionResult> Index(string SelectedStore)
        {
            // Use LINQ to get list of stores.
            var stores = (from s in _context.Stores
                          select s);

            // Use LINQ to get list of bikes.
            var bikes = (from b in _context.Bikes
                         select b);

            var storesSelect = (from s in _context.Stores
                          select s.AddressLine1);

            int SelectedStoreID = await (from s in _context.Stores
                                          where s.AddressLine1 == SelectedStore
                                          select s.StoreID).FirstOrDefaultAsync();
            if (SelectedStoreID != 0 )
            {
                bikes = bikes.Where(x => x.StoreID == SelectedStoreID);
            }

            var bikeStoreVM = new BikeStoreViewModel
            {
                Bikes = await bikes.Distinct().ToListAsync(),
                Stores = await stores.ToListAsync(),
                BikeStores = new SelectList(await storesSelect.Distinct().ToListAsync())
            };


            return View(bikeStoreVM);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        
    }
}
