using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgencyApi.Repository;
using BikeRentalAgencyApi.Models;
using BikeRentalAgencyApi.Repository.Interfaces;

namespace EmployeeRentalAgencyApi.Controllers
{
    [Route("Api/Employee")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        public EmployeeController(IEmployeeRepository employeeerepository)
        {
            _EmployeeRepository = employeeerepository;
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee Employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var EmployeeId = await _EmployeeRepository.AddEmployee(Employee);
                    if (EmployeeId > 0)
                    {
                        return Ok(EmployeeId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("GetEmployee/{EmployeeId}")]
        public async Task<IActionResult> GetEmployee(int? EmployeeId)
        {
            if (EmployeeId == null) { return BadRequest(); }
            try
            {
                var Employee = await _EmployeeRepository.GetEmployee(EmployeeId);
                if (Employee == null)
                {
                    return NotFound();
                }
                return Ok(Employee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int? EmployeeId)
        {
            int result = 0;
            if (EmployeeId == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _EmployeeRepository.DeleteEmployee(EmployeeId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var Employees = await _EmployeeRepository.GetEmployees();
                if (Employees == null)
                {
                    return NotFound();
                }
                return Ok(Employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            //try
            //{
            //    List<Employee> Employees = await _EmployeeRepository.GetEmployees();
            //    return Employees;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        [HttpPost]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _EmployeeRepository.UpdateEmployee(model);
                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                        "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}
