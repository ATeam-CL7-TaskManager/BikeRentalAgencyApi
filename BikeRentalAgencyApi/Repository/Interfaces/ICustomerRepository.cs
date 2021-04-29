using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using BikeRentalAgencyApi.Models;

namespace BikeRentalAgencyApi.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<int> AddCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);

        //admin actions only
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomer(int? customerId);
        Task<int> DeleteCustomer(int? customerId);
    }

}

