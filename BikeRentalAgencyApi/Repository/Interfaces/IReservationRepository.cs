using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using BikeRentalAgencyApi.Models;

namespace BikeRentalAgencyApi.Repository.Interfaces
{
    public interface IReservationRepository
    {
        Task<Reservation> GetReservation(int? reservationId);
        Task<int> AddReservation(Reservation reservation);
        Task UpdateReservation(Reservation reservation);

        //admin action only
        Task<List<Reservation>> GetReservations();
        Task<int> DeleteReservation(int? reservationId);

    }
}
