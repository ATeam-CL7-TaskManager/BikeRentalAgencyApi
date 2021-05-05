using BikeRentalAgencyUI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace BikeRentalAgencyUI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        readonly string baseUrl = "http://localhost:5000/api/";
        public async Task<bool> AddEmployee(Employee employee)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                //Sending request to find web api REST service resource AddPost using HttpClient  
                HttpResponseMessage res = await client.PostAsJsonAsync(
                    "Employee/Addemployee", employee);

                //Checking the response is successful or not which is sent using HttpClient  
                return res.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeleteEmployee(int? employeeId)
        {
            bool succeeded = false;
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);
                //Sending request to find web api REST service resource UpdatePost using HttpClient  
                HttpResponseMessage res = await client.DeleteAsync(
                    $"Employee/Deleteemployee/{employeeId}");
                succeeded = res.IsSuccessStatusCode;
            }
            return succeeded;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            List<Employee> posts = new List<Employee>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetPosts using HttpClient  
                HttpResponseMessage res = await client.GetAsync("Employee/GetEmployees");

                //Checking the response is successful or not which is sent using HttpClient  
                if (res.IsSuccessStatusCode)
                {
                    //Storing the response details received from web api   
                    var response = res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response received from web api and storing into the Post list  
                    posts = JsonConvert.DeserializeObject<List<Employee>>(response);

                }
                //returning the post list to view 
                return posts;
            }
        }


        public async Task<bool> UpdateEmployee(Employee employee)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                //Sending request to find web api REST service resource UpdatePost using HttpClient  
                HttpResponseMessage res = await client.PutAsJsonAsync(
                    "employee/Updateemployee", employee);

                //Checking the response is successful or not which is sent using HttpClient  
                return res.IsSuccessStatusCode;

            }
        }


        public async Task<Employee> GetEmployee(int? employeeId)
        {
            Employee employee = new();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetPost using HttpClient  
                HttpResponseMessage res = await client.GetAsync($"Employee/GetEmployee/{employeeId}");

                //Checking the response is successful or not which is sent using HttpClient  
                if (res.IsSuccessStatusCode)
                {
                    //Storing the response details received from web api   
                    var response = res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response received from web api and storing into the Post object 
                    employee = JsonConvert.DeserializeObject<Employee>(response);

                }
            }
            //returning the post to view  
            return employee;
        }

    }
}