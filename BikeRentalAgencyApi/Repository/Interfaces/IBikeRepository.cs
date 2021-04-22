using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using BikeRentalAgencyApi.Models;

namespace BikeRentalAgencyApi.Repository
{
    public interface IBikeRepository
    {
        Task<List<Bike>> GetBikes();
        Task<Bike> GetBike(int? bikeId);

        //admin actions only
        Task<int> AddBike(Bike bike);
        Task<int> DeleteBike(int? bikeId);
        Task UpdateBike(Bike bike);
    }
}