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
    public class ReservationController : Controller
    {
        public IReservationRepository _ReservationRepository;
        public ReservationController(IReservationRepository reservationrepository)
        {
            _ReservationRepository = reservationrepository;
        }

        [HttpPost("AddReservation")]
        public async Task<Object> AddReservation([FromBody] Reservation reservation)
        {
            try
            {
                await _ReservationRepository.AddReservation(reservation);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPost("DeleteReservation/{id}")]
        public async Task<Object> DeleteReservation([FromBody] int? reservationId)
        {
            try
            {
                await _ReservationRepository.DeleteReservation(reservationId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet("GetReservation/{id}")]
        public async Task<Object> GetReservation([FromBody] int? storeId)
        {
            try
            {
                await _ReservationRepository.GetReservation(storeId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet("GetAllReservations")]
        public async Task<Object> GetReservations()
        {
            try
            {
                await _ReservationRepository.GetReservations();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost("UpdateReservations/{id}")]
        public async Task<Object> UpdateReservation([FromBody]Reservation reservation)
        {
            try
            {
                await _ReservationRepository.UpdateReservation(reservation);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
