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
                await db.Bike.AddAsync(bike);
                await db.SaveChangesAsync();
                return bike.BikeId;
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
                var bike = await db.Bike.FirstOrDefaultAsync(x => x.BikeId == bikeId);
                if (bike != null)
                {
                    //Delete that post
                    db.Bike.Remove(bike);
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
                return await db.Bike.ToListAsync();
            }
            return null;
        }

         async Task<Bike> IBikeRepository.GetBike(int? bikeId)
        {
            if (db != null)
            {
                return await (from p in db.Bike
                              where p.BikeId == bikeId
                              select new Bike
                              {
                                  BikeId = p.BikeId,
                                  StoreId = p.StoreId,
                                  HourlyRate = p.HourlyRate,
                                  BikePrice = p.BikePrice,
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
                db.Bike.Update(bike);
                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
