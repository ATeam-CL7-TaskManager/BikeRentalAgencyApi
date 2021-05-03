using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgencyApi.Repository;
using BikeRentalAgencyApi.Models;
using BikeRentalAgencyApi.Repository.Interfaces;

namespace BikeRentalAgencyApi.Controllers
{
    [Route("Api/Customer")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _CustomerRepository;
        public CustomerController(ICustomerRepository customerrepository)
        {
            _CustomerRepository = customerrepository;
        }

        [HttpPost]
        [Route("AddCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] Customer Customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var CustomerId = await _CustomerRepository.AddCustomer(Customer);
                    if (CustomerId > 0)
                    {
                        return Ok(CustomerId);
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
        [Route("GetCustomer/{CustomerId}")]
        public async Task<IActionResult> GetCustomer(int? CustomerId)
        {
            if (CustomerId == null) { return BadRequest(); }
            try
            {
                var Customer = await _CustomerRepository.GetCustomer(CustomerId);
                if (Customer == null)
                {
                    return NotFound();
                }
                return Ok(Customer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int? CustomerId)
        {
            int result = 0;
            if (CustomerId == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _CustomerRepository.DeleteCustomer(CustomerId);
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
        [Route("GetCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var Customers = await _CustomerRepository.GetCustomers();
                if (Customers == null)
                {
                    return NotFound();
                }
                return Ok(Customers);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            //try
            //{
            //    List<Customer> Customers = await _CustomerRepository.GetCustomers();
            //    return Customers;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        [HttpPut]
        [Route("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _CustomerRepository.UpdateCustomer(model);
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
