using BikeRentalAgencyUI.Models;
using BikeRentalAgencyUI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgencyUI.Repository.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        BikeStoreContext db;
        public EmployeeRepository(BikeStoreContext _db)
        {
            db = _db;
        }

        public Task<bool> AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEmployee(int? employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployee(int? employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
