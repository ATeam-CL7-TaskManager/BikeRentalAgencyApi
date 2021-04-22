using BikeRentalAgencyApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            if (db != null)
            {
                await db.Store.AddAsync(store);
                await db.SaveChangesAsync();
                return store.StoreId;
            }
            return 0;
        }
        public async Task<Store> GetStore(int? storeId)
        {
            if (db != null)
            {
                return await (from p in db.Store
                              where p.StoreId == storeId
                              select new Store
                              {
                                  StoreId = p.StoreId,
                                  AddressLine1 = p.AddressLine1,
                                  AddressLine2 = p.AddressLine2,
                                  City = p.City,
                                  State = p.State,
                                  ZipCode = p.ZipCode,
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
                return await db.Store.ToListAsync();
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
                var store = await db.Store.FirstOrDefaultAsync(x => x.StoreId == storeId);
                if (store != null)
                {
                    //Delete that store
                    db.Store.Remove(store);
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
                db.Store.Update(store);
                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}