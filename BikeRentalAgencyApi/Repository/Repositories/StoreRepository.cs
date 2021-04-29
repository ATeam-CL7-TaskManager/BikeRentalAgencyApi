using BikeRentalAgencyApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgencyApi.Repository.Interfaces;

namespace BikeRentalAgencyApi.Repository.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        BikeStoreContext db;
        public StoreRepository(BikeStoreContext _db)
        {
            db = _db;
        }
        public async Task<int> AddStore(Store store)
        {
            //administrative action only
            try
            {
                if (db != null)
                {
                    await db.Stores.AddAsync(store);
                    await db.SaveChangesAsync();
                    return store.StoreID;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return 0;
        }
        public async Task<Store> GetStore(int? storeId)
        {
            if (db != null)
            {
                return await (from p in db.Stores
                              where p.StoreID == storeId
                              select new Store
                              {
                                  StoreID = p.StoreID,
                                  AddressLine1 = p.AddressLine1,
                                  AddressLine2 = p.AddressLine2,
                                  City = p.City,
                                  State = p.State,
                                  Zip = p.Zip,
                                  Phone = p.Phone,
                                  Email = p.Email,
                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<List<Store>> GetStores()
        {
            if (db != null)
            {
                return await db.Stores.ToListAsync();
            }
            return null;
        }

        public async Task<int> DeleteStore(int? storeId)
        {
            //administrative action only

            int result = 0;
            if (db != null)
            {
                //Find the store for specific store id
                var store = await db.Stores.FirstOrDefaultAsync(x => x.StoreID == storeId);
                if (store != null)
                {
                    //Delete that store
                    db.Stores.Remove(store);
                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task UpdateStore(Store store)
        {
            //administrative action only

            if (db != null)
            {
                //Delete that store
                db.Stores.Update(store);
                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}