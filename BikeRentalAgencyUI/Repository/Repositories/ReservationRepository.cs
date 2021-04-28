using BikeRentalAgencyUI.Repository.Interfaces;
using BikeRentalAgencyUI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgencyUI.Repository.Repositories
{
    public class ReservationRepository : IReservationRepository
{
    BikeStoreContext db;
    public ReservationRepository(BikeStoreContext _db)
    {
        db = _db;
    }

        public Task<bool> AddReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteReservation(int? reservationId)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> GetReservation(int? reservationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Reservation>> GetReservations()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}