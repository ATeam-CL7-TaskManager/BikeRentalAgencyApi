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
    public class StoreRepository : IStoreRepository
    {
        string baseUrl = "http://localhost:5000/api/";
        public async Task<bool> AddStore(Store store)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                //Sending request to find web api REST service resource AddPost using HttpClient  
                HttpResponseMessage res = await client.PostAsJsonAsync(
                    "store/Addstore", store);

                //Checking the response is successful or not which is sent using HttpClient  
                return res.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeleteStore(int? storeId)
        {
            bool succeeded = false;
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);
                //Sending request to find web api REST service resource UpdatePost using HttpClient  
                HttpResponseMessage res = await client.DeleteAsync(
                    $"store/Deletestore?storeId={storeId}");
                succeeded = res.IsSuccessStatusCode;
            }
            return succeeded;
        }

        public async Task<List<Store>> GetStores()
        {
            List<Store> posts = new List<Store>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetPosts using HttpClient  
                HttpResponseMessage res = await client.GetAsync("Store/GetStores");

                //Checking the response is successful or not which is sent using HttpClient  
                if (res.IsSuccessStatusCode)
                {
                    //Storing the response details received from web api   
                    var response = res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response received from web api and storing into the Post list  
                    posts = JsonConvert.DeserializeObject<List<Store>>(response);

                }
                //returning the post list to view 
                return posts;
            }
        }


        public async Task<bool> UpdateStore(Store store)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                //Sending request to find web api REST service resource UpdatePost using HttpClient  
                HttpResponseMessage res = await client.PutAsJsonAsync(
                    "store/Updatestore", store);

                //Checking the response is successful or not which is sent using HttpClient  
                return res.IsSuccessStatusCode;

            }
        }


        public async Task<Store> GetStore(int? storeId)
        {
            Store store = new();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetPost using HttpClient  
                HttpResponseMessage res = await client.GetAsync($"Post/GetPost?postId={storeId}");

                //Checking the response is successful or not which is sent using HttpClient  
                if (res.IsSuccessStatusCode)
                {
                    //Storing the response details received from web api   
                    var response = res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response received from web api and storing into the Post object 
                    store = JsonConvert.DeserializeObject<Store>(response);

                }
            }
            //returning the post to view  
            return store;
        }

    }
}