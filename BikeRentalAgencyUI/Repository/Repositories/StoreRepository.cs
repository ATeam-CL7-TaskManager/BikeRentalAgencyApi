using BikeRentalAgencyUI.Repository.Interfaces;
using BikeRentalAgencyUI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgencyUI.Repository.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        BikeStoreContext db;
        public StoreRepository(BikeStoreContext _db)
        {
            db = _db;
        }

        public Task<bool> AddStore(Store store)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStore(int? storeId)
        {
            throw new NotImplementedException();
        }

        public Task<Store> GetStore(int? storeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Store>> GetStores()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStore(Store store)
        {
            throw new NotImplementedException();
        }
    }
}