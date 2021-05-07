using BikeRentalAgencyUI.Repository;
using BikeRentalAgencyUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace BikeRentalAgencyUI.Controllers
{
    public class OrderController : Controller
    {
        readonly IOrderRepository repository;
        public OrderController(IOrderRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var model = await repository.GetOrders();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            var model = new OrderViewModel();
            if (id == null)
            {
                model.Order = new Order();
                return View(model);
            }

            model.Order = await repository.GetOrder(id);
            //model.Order
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> Edit(Order order)
        {
            TempData["message"] = string.Empty;
            string message;

            if (order == null) return View(new OrderViewModel());

            bool succeeded;
            //add new order
            if (order.OrderID == 0)
            {
                succeeded = await repository.AddOrder(order);
                message = $"{order.OrderID} has not been added";

                //Checking the response is successful or not   
                if (succeeded)
                {
                    message = $"{order.OrderID} has been added";
                }
            }
            else
            {
                //update existing order
                succeeded = await repository.UpdateOrder(order);
                message = $"{order.OrderID} has not been saved";
                //Checking the response is successful or not   
                if (succeeded)
                {
                    message = $"{order.OrderID} has been saved";
                }
            }
            TempData["message"] = message;

            if (succeeded) return RedirectToAction("Index");

            var model = new OrderViewModel
            {
                Order = order
            };
            return View(model);
        }


        public async Task<ActionResult> Details(int id)
        {
            var model = new OrderViewModel
            {
                Order = await repository.GetOrder(id)
            };

            return View(model);
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            TempData["message"] = string.Empty;
            bool succeeded = await repository.DeleteOrder(id);
            TempData["message"] = $"Order not deleted";
            if (succeeded)
            {
                TempData["message"] = $"Order deleted";
            }
            //returning to view  
            return RedirectToAction("Index");
        }
    }
}
