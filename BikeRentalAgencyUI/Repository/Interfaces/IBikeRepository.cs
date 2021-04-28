using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using BikeRentalAgencyUI.Models;

namespace BikeRentalAgencyUI.Repository.Interfaces
{
    public interface IBikeRepository
    {
        Task<List<Bike>> GetAllBikes();
        Task<Bike> GetBike(int? bikeId);

        //admin actions only
        Task<bool> AddBike(Bike bike);
        Task<bool> DeleteBike(int? bikeId);
        Task<bool> UpdateBike(Bike bike);
    }
}