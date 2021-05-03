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
    public class CustomerController : Controller
    {
        readonly ICustomerRepository repository;
        public CustomerController(ICustomerRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var model = await repository.GetCustomers();
            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            var model = new CustomerViewModel();
            if (id == null)
            {
                model.Customer = new Customer();
                return View(model);
            }

            model.Customer = await repository.GetCustomer(id);
            //model.Customer
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Customer customer)
        {
            TempData["message"] = string.Empty;
            string message;

            if (customer == null) return View(new CustomerViewModel());

            bool succeeded;
            //add new customer
            if (customer.CustomerID == 0)
            {
                succeeded = await repository.AddCustomer(customer);
                message = $"{customer.CustomerID} has not been added";

                //Checking the response is successful or not   
                if (succeeded)
                {
                    message = $"{customer.CustomerID} has been added";
                }
            }
            else
            {
                //update existing customer
                succeeded = await repository.UpdateCustomer(customer);
                message = $"{customer.CustomerID} has not been saved";
                //Checking the response is successful or not   
                if (succeeded)
                {
                    message = $"{customer.CustomerID} has been saved";
                }
            }
            TempData["message"] = message;

            if (succeeded) return RedirectToAction("Index");

            var model = new CustomerViewModel
            {
                Customer = customer
            };
            return View(model);
        }

        public async Task<ActionResult> Details(int id)
        {
            var model = new CustomerViewModel
            {
                Customer = await repository.GetCustomer(id)
            };

            return View(model);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            TempData["message"] = string.Empty;
            bool succeeded = await repository.DeleteCustomer(id);
            TempData["message"] = $"Customer not deleted";
            if (succeeded)
            {
                TempData["message"] = $"Customer deleted";
            }
            //returning to view  
            return RedirectToAction("Index");
        }
    }
}
