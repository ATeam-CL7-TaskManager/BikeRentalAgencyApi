using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using BikeRentalAgencyUI.Models;


namespace BikeRentalAgencyUI.Repository.Interfaces
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
