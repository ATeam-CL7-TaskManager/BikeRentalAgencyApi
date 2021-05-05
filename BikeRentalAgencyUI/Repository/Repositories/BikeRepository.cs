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
    public class BikeRepository : IBikeRepository
    {
        string baseUrl = "http://localhost:5000/Api/";
        public async Task<bool> AddBike(Bike bike)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                //Sending request to find web api REST service resource AddPost using HttpClient  
                HttpResponseMessage res = await client.PostAsJsonAsync(
                    "bike/Addbike", bike);

                //Checking the response is successful or not which is sent using HttpClient  
                return res.IsSuccessStatusCode;

            }
        }

        public async Task<bool> DeleteBike(int? bikeId)
        {
            bool succeeded = false;
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);
                //Sending request to find web api REST service resource UpdatePost using HttpClient  
                HttpResponseMessage res = await client.DeleteAsync(
                    $"Bike/DeleteBike/{bikeId}");
                succeeded = res.IsSuccessStatusCode;
            }
            return succeeded;
        }

        public async Task<List<Bike>> GetBikes()
        {
            List<Bike> posts = new List<Bike>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetPosts using HttpClient  
                HttpResponseMessage res = await client.GetAsync("Bike/GetBikes");

                //Checking the response is successful or not which is sent using HttpClient  
                if (res.IsSuccessStatusCode)
                {
                    //Storing the response details received from web api   
                    var response = res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response received from web api and storing into the Post list  
                    posts = JsonConvert.DeserializeObject<List<Bike>>(response);

                }
                //returning the post list to view 
                return posts;
            }
        }


        public async Task<bool> UpdateBike(Bike bike)
        {
            using (var client = new HttpClient())

            {

                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                //Sending request to find web api REST service resource UpdatePost using HttpClient  
                HttpResponseMessage res = await client.PutAsJsonAsync(
                    "Bike/Updatebike", bike);

                //Checking the response is successful or not which is sent using HttpClient  
                return res.IsSuccessStatusCode;
            }
        }

        public async Task<Bike> GetBike(int? bikeId)
        {
            Bike bike = new();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetPost using HttpClient  
                HttpResponseMessage res = await client.GetAsync($"Bike/GetBike/{bikeId}");

                //Checking the response is successful or not which is sent using HttpClient  
                if (res.IsSuccessStatusCode)
                {
                    //Storing the response details received from web api   
                    var response = res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response received from web api and storing into the Post object 
                    bike = JsonConvert.DeserializeObject<Bike>(response);

                }
            }
            //returning the post to view  
            return bike;

        }

    }
}

