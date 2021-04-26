using BikeRentalAgencyApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgencyApi.Repository.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        BikeStoreContext db;
        public CustomerRepository(BikeStoreContext _db)
        {
            db = _db;
        }
        public async Task<int> AddCustomer(Customer customer)
        {
            if (db != null)
            {
                await db.Customers.AddAsync(customer);
                await db.SaveChangesAsync();
                return customer.CustomerId;
            }
            return 0;
        }
        public async Task<Customer> GetCustomer(int? customerId)
        {            //administrative action only

            if (db != null)
            {
                return await (from p in db.Customers
                              where p.CustomerId == customerId
                              select new Customer
                              {
                                  CustomerId = p.CustomerId,
                                  FirstName = p.FirstName,
                                  LastName = p.LastName,
                                  Phone = p.Phone,
                                  Email = p.Email,
                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<List<Customer>> GetCustomers()
        {            //administrative action only

            if (db != null)
            {
                return await db.Customers.ToListAsync();
            }
            return null;
        }

        public async Task<int> DeleteCustomer(int? customerId)
        {            //administrative action only

            int result = 0;
            if (db != null)
            {
                //Find the customer for specific customer id
                var customer = await db.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
                if (customer != null)
                {
                    //Delete that customer
                    db.Customers.Remove(customer);
                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task UpdateCustomer(Customer customer)
        {
            if (db != null)
            {
                //Delete that customer
                db.Customers.Update(customer);
                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
