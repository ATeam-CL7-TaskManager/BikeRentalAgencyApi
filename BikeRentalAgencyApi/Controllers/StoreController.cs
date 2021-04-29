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
    [Route("Api/Store")]
    [ApiController]
    public class StoreController : Controller
    {
        private readonly IStoreRepository _StoreRepository;
        public StoreController(IStoreRepository storerepository)
        {
            _StoreRepository = storerepository;
        }

        [HttpPost]
        [Route("AddStore")]
        public async Task<IActionResult> AddStore([FromBody] Store store)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var storeId = await _StoreRepository.AddStore(store);
                    if (storeId > 0)
                    {
                        return Ok(storeId);
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
        [Route("GetStore/{storeId}")]
        public async Task<IActionResult> GetStore(int? storeId)
        {
            if (storeId == null) { return BadRequest(); }
            try
            {
                var store = await _StoreRepository.GetStore(storeId);
                if (store == null)
                {
                    return NotFound();
                }
                return Ok(store);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("DeleteStore/{id}")]
        public async Task<IActionResult> DeleteStore(int? storeId)
        {
            int result;
            if (storeId == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _StoreRepository.DeleteStore(storeId);
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
        [Route("GetStores")]
        public async Task<IActionResult> GetStores()
        {
            try
            {
                var stores = await _StoreRepository.GetStores();
                if (stores == null)
                {
                    return NotFound();
                }
                return Ok(stores);
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
        [HttpPost]
        [Route("UpdateStore")]
        public async Task<IActionResult> UpdateStore([FromBody] Store model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _StoreRepository.UpdateStore(model);
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
