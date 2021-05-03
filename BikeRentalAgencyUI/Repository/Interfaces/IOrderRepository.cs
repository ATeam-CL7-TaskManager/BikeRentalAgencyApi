using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BikeRentalAgencyUI.Models;


namespace BikeRentalAgencyUI.Repository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrders();
        Task<Order> GetOrder(int? orderID);
        //admin actions only
        Task<bool> AddOrder(Order order);
        Task<bool> DeleteOrder(int? orderID);
        Task<bool> UpdateOrder(Order order);
    }
}
