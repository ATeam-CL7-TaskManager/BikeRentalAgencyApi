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
    [Route("Api/Order")]
    [ApiController]
    public class OrderController : Controller
    {
        readonly IOrderRepository _OrderRepository;
        public OrderController(IOrderRepository orderrepository)
        {
            _OrderRepository = orderrepository;
        }

        [HttpPost]
        [Route("AddOrder")]
        public async Task<IActionResult> AddOrder([FromBody] Order Order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var OrderId = await _OrderRepository.AddOrder(Order);
                    if (OrderId > 0)
                    {
                        return Ok(OrderId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("GetOrder/{OrderId}")]
        public async Task<IActionResult> GetOrder(int? OrderId)
        {
            if (OrderId == null) { return BadRequest(); }
            try
            {
                var Order = await _OrderRepository.GetOrder(OrderId);
                if (Order == null)
                {
                    return NotFound();
                }
                return Ok(Order);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("DeleteOrder/{OrderId}")]
        public async Task<IActionResult> DeleteOrder(int? OrderId)
        {
            int result = 0;
            if (OrderId == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _OrderRepository.DeleteOrder(OrderId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetOrders")]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var Orders = await _OrderRepository.GetOrders();
                if (Orders == null)
                {
                    return NotFound();
                }
                return Ok(Orders);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            //try
            //{
            //    List<Order> Orders = await _OrderRepository.GetOrders();
            //    return Orders;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        [HttpPut]
        [Route("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder([FromBody] Order model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _OrderRepository.UpdateOrder(model);
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
