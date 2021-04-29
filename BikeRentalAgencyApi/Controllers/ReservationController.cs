using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgencyApi.Repository;
using BikeRentalAgencyApi.Models;
using BikeRentalAgencyApi.Repository.Repositories;

namespace ReservationRentalAgencyApi.Controllers
{
    [Route("Api/Reservation")]
    [ApiController]
    public class ReservationController : Controller
    {
        private readonly IReservationRepository _ReservationRepository;
        public ReservationController(IReservationRepository reservationrepository)
        {
            _ReservationRepository = reservationrepository;
        }

        [HttpPost]
        [Route("AddReservation")]
        public async Task<IActionResult> AddReservation([FromBody] Reservation Reservation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ReservationId = await _ReservationRepository.AddReservation(Reservation);
                    if (ReservationId > 0)
                    {
                        return Ok(ReservationId);
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
        [Route("GetReservation/{ReservationId}")]
        public async Task<IActionResult> GetReservation(int? ReservationId)
        {
            if (ReservationId == null) { return BadRequest(); }
            try
            {
                var Reservation = await _ReservationRepository.GetReservation(ReservationId);
                if (Reservation == null)
                {
                    return NotFound();
                }
                return Ok(Reservation);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("DeleteReservation/{id}")]
        public async Task<IActionResult> DeleteReservation(int? ReservationId)
        {
            int result = 0;
            if (ReservationId == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _ReservationRepository.DeleteReservation(ReservationId);
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
        [Route("GetReservations")]
        public async Task<IActionResult> GetReservations()
        {
            try
            {
                var Reservations = await _ReservationRepository.GetReservations();
                if (Reservations == null)
                {
                    return NotFound();
                }
                return Ok(Reservations);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            //try
            //{
            //    List<Reservation> Reservations = await _ReservationRepository.GetReservations();
            //    return Reservations;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        [HttpPost]
        [Route("UpdateReservation")]
        public async Task<IActionResult> UpdateReservation([FromBody] Reservation model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _ReservationRepository.UpdateReservation(model);
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
