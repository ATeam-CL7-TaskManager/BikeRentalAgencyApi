using BikeRentalAgencyApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgencyApi.Repository.Repositories
{
    public class ReservationRepository : IReservationRepository
{
    BikeStoreContext db;
    public ReservationRepository(BikeStoreContext _db)
    {
        db = _db;
    }
    public async Task<int> AddReservation(Reservation reservation)
    {
        if (db != null)
        {
            await db.Reservations.AddAsync(reservation);
            await db.SaveChangesAsync();
            return reservation.ReservationId;
        }
        return 0;
    }
    public async Task<Reservation> GetReservation(int? reservationId)
    {
        if (db != null)
        {
            return await (from p in db.Reservations
                          where p.ReservationId == reservationId
                          select new Reservation
                          {
                              ReservationId = p.ReservationId,
                              CustomerId = p.CustomerId,
                              BikeId = p.BikeId,
                              PaymentId = p.PaymentId,
                              StartDate = p.StartDate,
                              EndDate = p.EndDate,
                              IsComplete = p.IsComplete,
                              EmployeeId = p.EmployeeId,
                              HomeStoreId = p.HomeStoreId,
                              RentedStoreId = p.RentedStoreId,
                              ReservationTotal = p.ReservationTotal,
                              AccessoriesTotal = p.AccessoriesTotal,
                              OrderTotal = p.OrderTotal,
                              OrderDetails = p.OrderDetails,
                              IsStarted = p.IsStarted,
                          }).FirstOrDefaultAsync();
        }
        return null;
    }

    public async Task<List<Reservation>> GetReservations()
    {
            //administrative action only

            if (db != null)
        {
            return await db.Reservations.ToListAsync();
        }
        return null;
    }

    public async Task<int> DeleteReservation(int? reservationId)
    {
            //administrative action only

            int result = 0;
        if (db != null)
        {
            //Find the reservation for specific reservation id
            var reservation = await db.Reservations.FirstOrDefaultAsync(x => x.ReservationId == reservationId);
            if (reservation != null)
            {
                //Delete that reservation
                db.Reservations.Remove(reservation);
                //Commit the transaction
                result = await db.SaveChangesAsync();
            }
            return result;
        }
        return result;
    }

    public async Task UpdateReservation(Reservation reservation)
    {
        if (db != null)
        {
            //Delete that reservation
            db.Reservations.Update(reservation);
            //Commit the transaction
            await db.SaveChangesAsync();
        }
    }
}
}