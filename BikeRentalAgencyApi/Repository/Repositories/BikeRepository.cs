using BikeRentalAgencyApi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BikeRentalAgencyApi.Repository.Repositories
{
    public class BikeRepository : IBikeRepository
    {
        BikeStoreContext db;
        public BikeRepository(BikeStoreContext _db)
        {
            db = _db;
        }

        public async Task<int> AddBike(Bike bike)
        {
            //admin action only
            if (db != null)
            {
                await db.Bikes.AddAsync(bike);
                await db.SaveChangesAsync();
                return bike.BikeID;
            }
            return 0;
        }

        async Task<int> IBikeRepository.DeleteBike(int? bikeId)
        {
            //admin action only
            int result = 0;
            if (db != null)
            {
                //Find the post for specific post id
                var bike = await db.Bikes.FirstOrDefaultAsync(x => x.BikeID == bikeId);
                if (bike != null)
                {
                    //Delete that post
                    db.Bikes.Remove(bike);
                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

         async Task<List<Bike>> IBikeRepository.GetBikes()
        {
            if (db != null)
            {
                return await db.Bikes.ToListAsync();
            }
            return null;
        }

         async Task<Bike> IBikeRepository.GetBike(int? bikeId)
        {
            if (db != null)
            {
                return await (from p in db.Bikes
                              where p.BikeID == bikeId
                              select new Bike
                              {
                                  BikeID = p.BikeID,
                                  StoreID = p.StoreID,
                                  HourlyRate = p.HourlyRate,
                                  Price = p.Price,
                                  FrameSize = p.FrameSize,
                                  IsRented = p.IsRented,
                                  Motorized = p.Motorized,
                                  MTBSuspension = p.MTBSuspension,
                                  AllTerrainTires = p.AllTerrainTires,
                                  BikeStyle = p.BikeStyle,

                              }).FirstOrDefaultAsync();
            }
            return null;
        }

         async Task IBikeRepository.UpdateBike(Bike bike)
        {
            //admin action only
            if (db != null)
            {
                //Delete that bike
                db.Bikes.Update(bike);
                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
