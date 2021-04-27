using BikeRentalAgencyApi.Models;
using BikeRentalAgencyApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BikeRentalAgencyApi.Repository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        BikeStoreContext db;
        public OrderRepository(BikeStoreContext _db)
        {
            db = _db;
        }

        public async Task<int> AddOrder(Order order)
        {
            //admin action only
            if (db != null)
            {
                await db.Orders.AddAsync(order);
                await db.SaveChangesAsync();
                return order.OrderID;
            }
            return 0;
        }

        async Task<int> IOrderRepository.DeleteOrder(int? orderID)
        {
            //admin action only
            int result = 0;
            if (db != null)
            {
                //Find the post for specific post id
                var order = await db.Orders.FirstOrDefaultAsync(x => x.OrderID == orderID);
                if (order != null)
                {
                    //Delete that post
                    db.Orders.Remove(order);
                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        async Task<List<Order>> IOrderRepository.GetOrders()
        {
            if (db != null)
            {
                return await db.Orders.ToListAsync();
            }
            return null;
        }

        async Task<Order> IOrderRepository.GetOrder(int? orderID)
        {
            if (db != null)
            {
                return await (from p in db.Orders
                              where p.OrderID == orderID
                              select new Order
                              {
                                  OrderID = p.OrderID,
                                  CustomerID = p.CustomerID,
                                  EmployeeID = p.EmployeeID,

                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        async Task IOrderRepository.UpdateOrder(Order order)
        {
            //admin action only
            if (db != null)
            {
                //Delete that order
                db.Orders.Update(order);
                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
