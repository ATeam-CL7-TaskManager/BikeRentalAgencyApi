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
            return reservation.ReservationID;
        }
        return 0;
    }
    public async Task<Reservation> GetReservation(int? reservationId)
    {
        if (db != null)
        {
            return await (from p in db.Reservations
                          where p.ReservationID == reservationId
                          select new Reservation
                          {
                              ReservationID = p.ReservationID,
                              BikeID = p.BikeID,
                              StartDate = p.StartDate,
                              EndDate = p.EndDate,
                              IsComplete = p.IsComplete,
                              HomeStoreID = p.HomeStoreID,
                              RentedStoreID = p.RentedStoreID,
                              ReservationTotal = p.ReservationTotal,
                              AccessoriesTotal = p.AccessoriesTotal,
                              IsStarted = p.IsStarted,
                              OrderID = p.OrderID
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
            var reservation = await db.Reservations.FirstOrDefaultAsync(x => x.ReservationID == reservationId);
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