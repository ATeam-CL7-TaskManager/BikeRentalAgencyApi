using BikeRentalAgencyUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BikeRentalAgencyUI.Repository.Interfaces;
using BikeRentalAgencyUI.Repository.Repositories;

namespace BikeRentalAgencyUI.Controllers
{
    public class EmployeeController : Controller
    {
        readonly IEmployeeRepository repository;
        public EmployeeController(IEmployeeRepository repository)
        {
            this.repository = repository;
        }
        // GET: HomeController1
        public async Task<ActionResult> Index()
        {
            IEnumerable<Employee> employee = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("http://localhost:5000/Api/");

                var responseTask = await client.GetAsync("Employee/GetEmployees");
                if (responseTask.IsSuccessStatusCode)
                {
                    var result = responseTask.Content.ReadAsStringAsync().Result;
                    employee = JsonConvert.DeserializeObject<IEnumerable<Employee>>(result);
                }

                else
                {
                    employee = (IEnumerable<Employee>)Enumerable.Empty<Employee>();
                    ModelState.AddModelError(string.Empty, "error");
                }

            }
            return View(employee);

        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
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

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Employee employee)
        {
            TempData["message"] = string.Empty;
            string message;

            if (employee == null) return View(new EmployeeViewModel());

            bool succeeded;
            //add new post
            if (employee.EmployeeID == 0)
            {
                succeeded = await repository.AddEmployee(employee);
                message = $"{employee.EmployeeID} has not been added";

                //Checking the response is successful or not   
                if (succeeded)
                {
                    message = $"{employee.EmployeeID} has been added";
                }
            }
            else
            {
                //update existing post
                succeeded = await repository.UpdateEmployee(employee);
                message = $"{employee.EmployeeID} has not been saved";
                //Checking the response is successful or not   
                if (succeeded)
                {
                    message = $"{employee.EmployeeID} has been saved";
                }
            }
            TempData["message"] = message;

            if (succeeded) return RedirectToAction("Index");

            var model = new EmployeeViewModel
            {
                Employee = employee
            };
            model.Employee = await repository.GetEmployee(employee.EmployeeID);
            return View(model);
        }

            // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
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
