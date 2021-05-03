using BikeRentalAgencyUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BikeRentalAgencyUI.Repository;

namespace BikeRentalAgencyUI.Controllers
{
    public class EmployeeController : Controller
    {
        readonly IEmployeeRepository repository;
        public EmployeeController(IEmployeeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var model = await repository.GetEmployees();
            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            var model = new EmployeeViewModel();
            if (id == null)
            {
                model.Employee = new Employee();
                return View(model);
            }

            model.Employee = await repository.GetEmployee(id);
            //model.Employee
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Employee employee)
        {
            TempData["message"] = string.Empty;
            string message;

            if (employee == null) return View(new EmployeeViewModel());

            bool succeeded;
            //add new employee
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
                //update existing employee
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
            return View(model);
        }


        public async Task<ActionResult> Details(int id)
        {
            var model = new EmployeeViewModel
            {
                Employee = await repository.GetEmployee(id)
            };

            return View(model);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            TempData["message"] = string.Empty;
            bool succeeded = await repository.DeleteEmployee(id);
            TempData["message"] = $"Employee not deleted";
            if (succeeded)
            {
                TempData["message"] = $"Employee deleted";
            }
            //returning to view  
            return RedirectToAction("Index");
        }
    }
}
