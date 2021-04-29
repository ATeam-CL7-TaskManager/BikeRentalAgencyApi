using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using BikeRentalAgencyApi.Models;

namespace BikeRentalAgencyApi.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        //all employee actions are admin only.
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int? employeeId);
        Task<int> AddEmployee(Employee employee);
        Task<int> DeleteEmployee(int? employeeId);
        Task UpdateEmployee(Employee employee);
    }
}
