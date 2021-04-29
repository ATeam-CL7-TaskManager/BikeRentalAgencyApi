using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using BikeRentalAgencyApi.Models;

namespace BikeRentalAgencyApi.Repository.Interfaces
{
    public interface IStoreRepository
    {
        Task<List<Store>> GetStores();
        Task<Store> GetStore(int? storeId);

        //admin action only
        Task<int> AddStore(Store store);
        Task<int> DeleteStore(int? storeId);
        Task UpdateStore(Store store);
    }
}
