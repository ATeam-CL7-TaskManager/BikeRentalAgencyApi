using BikeRentalAgencyApi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgencyApi.Repository.Interfaces;

namespace BikeRentalAgencyApi.Repository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        BikeStoreContext db;
        public OrderRepository(BikeStoreContext _db)
        {
            db = _db;
        }

        public async Task<int> AddOrder(Order Order)
        {
            //admin action only
            if (db != null)
            {
                await db.Orders.AddAsync(Order);
                await db.SaveChangesAsync();
                return Order.OrderID;
            }
            return 0;
        }

        async Task<int> IOrderRepository.DeleteOrder(int? OrderId)
        {
            //admin action only
            int result = 0;
            if (db != null)
            {
                //Find the post for specific post id
                var Order = await db.Orders.FirstOrDefaultAsync(x => x.OrderID == OrderId);
                if (Order != null)
                {
                    //Delete that post
                    db.Orders.Remove(Order);
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

        async Task<Order> IOrderRepository.GetOrder(int? OrderId)
        {
            if (db != null)
            {
                return await (from p in db.Orders
                              where p.OrderID == OrderId
                              select new Order
                              {
                                  OrderID = p.OrderID,
                                  CustomerID = p.CustomerID,
                                  EmployeeID = p.EmployeeID

                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        async Task IOrderRepository.UpdateOrder(Order Order)
        {
            //admin action only
            if (db != null)
            {
                //Delete that Order
                db.Orders.Update(Order);
                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
