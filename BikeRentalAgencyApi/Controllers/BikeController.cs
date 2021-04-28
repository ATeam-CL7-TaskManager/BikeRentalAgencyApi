using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgencyApi.Repository;
using BikeRentalAgencyApi.Models;
using BikeRentalAgencyApi.Repository.Repositories;

namespace BikeRentalAgencyApi.Controllers
{
    [Route ("Api/[Controller]")]
    [ApiController]
    public class BikeController : Controller
    {
        public IBikeRepository _BikeRepository;
        public BikeController(IBikeRepository bikerepoistory)
        {
            _BikeRepository = bikerepoistory;
        }

        [HttpPost("AddBike")]
        public async Task<Object> AddBike([FromBody]Bike bike)
        {
            try
            {
                await _BikeRepository.AddBike(bike);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        [HttpGet("GetBike/{bikeId}")]
        public async Task<Object> GetBike(int bikeId)
        {
            try
            {
                Bike bike = await _BikeRepository.GetBike(bikeId);
                return bike;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPost("DeleteBike/{id}")]
        public async Task<Object> DeleteBike([FromBody] int? bikeId)
        {
            try
            {
                await _BikeRepository.DeleteBike(bikeId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPost("GetAllBikes")]
        public async Task<Object> GetAllBikes()
        {
            try
            {
                await _BikeRepository.GetBikes();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
