using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using BikeRentalAgencyUI.Models;

namespace BikeRentalAgencyUI.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> AddCustomer(Customer customer);
        Task<bool> UpdateCustomer(Customer customer);

        //admin actions only
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomer(int? customerId);
        Task<bool> DeleteCustomer(int? customerId);
    }

}

