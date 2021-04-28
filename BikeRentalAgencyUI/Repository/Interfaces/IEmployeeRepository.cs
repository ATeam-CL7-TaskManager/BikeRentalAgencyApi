using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using BikeRentalAgencyUI.Models;

namespace BikeRentalAgencyUI.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        //all employee actions are admin only.
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int? employeeId);
        Task<bool> AddEmployee(Employee employee);
        Task<bool> DeleteEmployee(int? employeeId);
        Task<bool> UpdateEmployee(Employee employee);
    }
}
