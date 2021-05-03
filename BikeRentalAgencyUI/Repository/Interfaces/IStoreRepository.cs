using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using BikeRentalAgencyUI.Models;

namespace BikeRentalAgencyUI.Repository
{
    public interface IStoreRepository
    {
        Task<List<Store>> GetStores();
        Task<Store> GetStore(int? storeId);

        //admin action only
        Task<bool> AddStore(Store store);
        Task<bool> DeleteStore(int? storeId);
        Task<bool> UpdateStore(Store store);
    }
}
