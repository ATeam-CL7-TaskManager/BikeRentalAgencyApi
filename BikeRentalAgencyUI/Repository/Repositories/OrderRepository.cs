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
    public class OrderRepository : IOrderRepository
    {
        readonly string baseUrl = "http://localhost:5000/api/";
        public async Task<bool> AddOrder(Order order)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                //Sending request to find web api REST service resource AddPost using HttpClient  
                HttpResponseMessage res = await client.PostAsJsonAsync(
                    "order/Addorder", order);

                //Checking the response is successful or not which is sent using HttpClient  
                return res.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeleteOrder(int? orderId)
        {
            bool succeeded = false;
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);
                //Sending request to find web api REST service resource UpdatePost using HttpClient  
                HttpResponseMessage res = await client.DeleteAsync(
                    $"order/Deleteorder?orderId={orderId}");
                succeeded = res.IsSuccessStatusCode;
            }
            return succeeded;
        }

        public async Task<List<Order>> GetOrders()
        {
            List<Order> posts = new List<Order>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetPosts using HttpClient  
                HttpResponseMessage res = await client.GetAsync("Order/GetAllOrders");

                //Checking the response is successful or not which is sent using HttpClient  
                if (res.IsSuccessStatusCode)
                {
                    //Storing the response details received from web api   
                    var response = res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response received from web api and storing into the Post list  
                    posts = JsonConvert.DeserializeObject<List<Order>>(response);

                }
                //returning the post list to view 
                return posts;
            }
        }


        public async Task<bool> UpdateOrder(Order order)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                //Sending request to find web api REST service resource UpdatePost using HttpClient  
                HttpResponseMessage res = await client.PutAsJsonAsync(
                    "order/Updateorder", order);

                //Checking the response is successful or not which is sent using HttpClient  
                return res.IsSuccessStatusCode;

            }
        }


        public async Task<Order> GetOrder(int? orderId)
        {
            Order order = new();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetPost using HttpClient  
                HttpResponseMessage res = await client.GetAsync($"Post/GetPost?postId={orderId}");

                //Checking the response is successful or not which is sent using HttpClient  
                if (res.IsSuccessStatusCode)
                {
                    //Storing the response details received from web api   
                    var response = res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response received from web api and storing into the Post object 
                    order = JsonConvert.DeserializeObject<Order>(response);

                }
            }
            //returning the post to view  
            return order;
        }

    }
}