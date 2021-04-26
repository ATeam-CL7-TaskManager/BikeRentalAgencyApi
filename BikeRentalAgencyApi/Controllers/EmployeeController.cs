using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgencyApi.Models;
using BikeRentalAgencyApi.Repository;
using BikeRentalAgencyApi.Repository.Repositories;

namespace BikeRentalAgencyApi.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {

        public IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeerepoistory)
        {
            _employeeRepository = employeerepoistory;
        }

        [HttpPost("AddEmployee")]
        public async Task<Object> AddEmployee([FromBody] Employee employee)
        {
            try
            {
                await _employeeRepository.AddEmployee(employee);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost("DeleteEmployee/{id}")]
        public async Task<Object> DeleteEmployee([FromBody] int? id)
        {
            try
            {
                await _employeeRepository.DeleteEmployee(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet("GetEmployee/{id}")]
        public async Task<Object> GetEmployee([FromBody] int? employeeId)
        {
            try
            {
                await _employeeRepository.GetEmployee(employeeId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet("GetEmployees")]
        public async Task<Object> GetEmployees()
        {
            try
            {
                await _employeeRepository.GetEmployees();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet("UpdateEmployee")]
        public async Task<Object> UpdateEmployees([FromBody] Employee employee)
        {
            try
            {
                await _employeeRepository.UpdateEmployee(employee);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
