using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using BikeRentalAgencyApi.Models;


namespace BikeRentalAgencyApi.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrders();
        Task<Order> GetOrder(int? orderID);
        //admin actions only
        Task<int> AddOrder(Order order);
        Task<int> DeleteOrder(int? orderID);
        Task UpdateOrder(Order order);
    }
}
