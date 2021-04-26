using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgencyApi.Models;
using BikeRentalAgencyApi.Repository;

namespace BikeRentalAgencyApi.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class StoreController : Controller
    {
        public IStoreRepository _StoreRepository;
        public StoreController(IStoreRepository storerepository)
        {
            _StoreRepository = storerepository;
        }

        [HttpPost("AddStore")]
        public async Task<Object> Getstore([FromBody] Store store)
        {
            try
            {
                await _StoreRepository.AddStore(store) ;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        [HttpPost("DeleteStore/{id}")]
        public async Task<Object> DeleteStore([FromBody] int? storeId)
        {
            try
            {
                await _StoreRepository.DeleteStore(storeId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet("GetStore/{id}")]
        public async Task<Object> GetStore([FromBody] int? storeId)
        {
            try
            {
                await _StoreRepository.GetStore(storeId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet("GetAllStores")]
        public async Task<Object> GetStores()
        {
            try
            {
                await _StoreRepository.GetStores();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost("UpdateStore")]
        public async Task<Object> UpdateStore([FromBody]Store store)
        {
            try
            {
                await _StoreRepository.UpdateStore(store);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
