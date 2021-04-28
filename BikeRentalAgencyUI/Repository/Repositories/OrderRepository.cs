using BikeRentalAgencyUI.Repository.Interfaces;
using BikeRentalAgencyUI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BikeRentalAgencyUI.Repository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        BikeStoreContext db;
        public OrderRepository(BikeStoreContext _db)
        {
            db = _db;
        }

        public Task<bool> AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrder(int? orderID)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrder(int? orderID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrders()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
