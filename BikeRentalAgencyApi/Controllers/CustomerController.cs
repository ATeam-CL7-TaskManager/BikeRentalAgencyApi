using BikeRentalAgencyApi.Models;
using BikeRentalAgencyApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgencyApi.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        public ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository cusotmerRepository)
        {
            _customerRepository = cusotmerRepository;
        }

        [HttpPost("AddCustomer")]
        public async Task<Object> AddCustomer([FromBody] Customer customer)
        {
            try
            {
                await _customerRepository.AddCustomer(customer);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost("DeleteCustomer/{id}")]
        public async Task<Object> DeleteCustomer([FromBody] int? id)
        {
            try
            {
                await _customerRepository.DeleteCustomer(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet("GetCustomer/{id}")]
        public async Task<Object> GetCustomer([FromBody] int? id)
        {
            try
            {
                await _customerRepository.GetCustomer(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost("GetAllCustomers")]
        public async Task<Object> GetCustomers()
        {
            try
            {
                await _customerRepository.GetCustomers();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost("UpdateCustomer")]
        public async Task<Object> UpdateCustomer([FromBody] Customer customer)
        {
            try
            {
                await _customerRepository.UpdateCustomer(customer);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
