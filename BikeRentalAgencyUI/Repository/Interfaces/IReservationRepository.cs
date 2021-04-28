using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using BikeRentalAgencyUI.Models;

namespace BikeRentalAgencyUI.Repository.Interfaces
{
    public interface IReservationRepository
    {
        Task<Reservation> GetReservation(int? reservationId);
        Task<bool> AddReservation(Reservation reservation);
        Task<bool> UpdateReservation(Reservation reservation);

        //admin action only
        Task<List<Reservation>> GetReservations();
        Task<bool> DeleteReservation(int? reservationId);

    }
}
