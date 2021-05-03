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
    [Route("Api/Bike")]
    [ApiController]
    public class BikeController : Controller
    {
        IBikeRepository _BikeRepository;
        public BikeController(IBikeRepository bikerepository)
        {
            _BikeRepository = bikerepository;
        }

        [HttpPost]
        [Route("AddBike")]
        public async Task<IActionResult> AddBike([FromBody] Bike bike)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bikeId = await _BikeRepository.AddBike(bike);
                    if (bikeId > 0)
                    {
                        return Ok(bikeId);
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
        [Route("GetBike/{bikeId}")]
        public async Task<IActionResult> GetBike(int? bikeId)
        {
            if (bikeId == null) { return BadRequest(); }
            try 
            { 
                var bike = await _BikeRepository.GetBike(bikeId); 
                if(bike == null)
                {
                    return NotFound();
                }
                return Ok(bike);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("DeleteBike/{id}")]
        public async Task<IActionResult> DeleteBike(int? bikeId)
        {
            int result = 0;
            if (bikeId == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _BikeRepository.DeleteBike(bikeId);
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
        [Route("GetBikes")]
        public async Task<IActionResult> GetBikes()
        {
            try
            {
                var bikes = await _BikeRepository.GetBikes();
                if (bikes == null)
                {
                    return NotFound();
                }
                return Ok(bikes);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            //try
            //{
            //    List<Bike> bikes = await _BikeRepository.GetBikes();
            //    return bikes;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        [HttpPut]
        [Route("UpdateBike")]
        public async Task<IActionResult> UpdateBike([FromBody] Bike model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _BikeRepository.UpdateBike(model);
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
