using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using BikeRentalAgencyUI.Models;
using System.Net.Http;

namespace BikeRentalAgencyUI.Repository
{
    public interface IReservationRepository
    {
        Task<Reservation> GetReservation(int? reservationId);
        Task<HttpResponseMessage> AddReservation(Reservation reservation);
        Task<bool> UpdateReservation(Reservation reservation);

        //admin action only
        Task<List<Reservation>> GetReservations();
        Task<bool> DeleteReservation(int? reservationId);

    }
}
