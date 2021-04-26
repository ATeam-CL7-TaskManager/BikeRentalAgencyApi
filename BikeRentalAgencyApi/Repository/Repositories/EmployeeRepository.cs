using BikeRentalAgencyApi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgencyApi.Repository.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        BikeStoreContext db;
        public EmployeeRepository(BikeStoreContext _db)
        {
            db = _db;
        }
        public async Task<int> AddEmployee(Employee employee)
        {            //administrative action only

            if (db != null)
            {
                await db.Employees.AddAsync(employee);
                await db.SaveChangesAsync();
                return employee.EmployeeId;
            }
            return 0;
        }

        public async Task<Employee> GetEmployee(int? employeeId)
        {            //administrative action only

            if (db != null)
            {
                return await (from p in db.Employees
                              where p.EmployeeId == employeeId
                              select new Employee
                              {
                                  EmployeeId = p.EmployeeId,
                                  FirstName = p.FirstName,
                                  LastName = p.LastName,
                                  StoreId = p.StoreId,
                                  Supervisor = p.Supervisor,

                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<List<Employee>> GetEmployees()
        {            //administrative action only

            if (db != null)
            {
                return await db.Employees.ToListAsync();
            }
            return null;
        }

        async Task<int> IEmployeeRepository.DeleteEmployee(int? employeeId)
        {            //administrative action only

            int result = 0;
            if (db != null)
            {
                //Find the post for specific post id
                var employee = await db.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
                if (employee != null)
                {
                    //Delete that post
                    db.Employees.Remove(employee);
                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        async Task IEmployeeRepository.UpdateEmployee(Employee employee)
        {            //administrative action only

            //admin action only
            if (db != null)
            {
                //Delete that employee
                db.Employees.Update(employee);
                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
