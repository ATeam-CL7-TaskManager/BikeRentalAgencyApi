using BikeRentalAgencyUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BikeRentalAgencyUI.Repository
{
    public class ReservationRepository : IReservationRepository
{
        string baseUrl = "http://localhost:5000/api/";
        public async Task<HttpResponseMessage> AddReservation(Reservation reservation)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                //Sending request to find web api REST service resource AddPost using HttpClient  
                HttpResponseMessage res = await client.PostAsJsonAsync(
                    "reservation/Addreservation", reservation);

                //Checking the response is successful or not which is sent using HttpClient  
                string greggy = await res.Content.ReadAsStringAsync();//.IsSuccessStatusCode;
                return res;
            }
        }

        public async Task<bool> DeleteReservation(int? reservationId)
        {
            bool succeeded = false;
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);
                //Sending request to find web api REST service resource UpdatePost using HttpClient  
                HttpResponseMessage res = await client.DeleteAsync(
                    $"reservation/Deletereservation/{reservationId}");
                succeeded = res.IsSuccessStatusCode;
            }
            return succeeded;
        }

        public async Task<List<Reservation>> GetReservations()
        {
            List<Reservation> resrvations = new List<Reservation>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetPosts using HttpClient  
                HttpResponseMessage res = await client.GetAsync("Reservation/GetReservations");

                //Checking the response is successful or not which is sent using HttpClient  
                if (res.IsSuccessStatusCode)
                {
                    //Storing the response details received from web api   
                    var response = res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response received from web api and storing into the Post list  
                    resrvations = JsonConvert.DeserializeObject<List<Reservation>>(response);

                }
                //returning the post list to view 
                return resrvations;
            }
        }


        public async Task<bool> UpdateReservation(Reservation reservation)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                //Sending request to find web api REST service resource UpdatePost using HttpClient  
                HttpResponseMessage res = await client.PutAsJsonAsync(
                    "reservation/Updatereservation", reservation);

                //Checking the response is successful or not which is sent using HttpClient  
                return res.IsSuccessStatusCode;

            }
        }


        public async Task<Reservation> GetReservation(int? reservationId)
        {
            Reservation reservation = new();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetPost using HttpClient  
                HttpResponseMessage res = await client.GetAsync($"Reservation/GetReservation/{reservationId}");
                string watch = await res.Content.ReadAsStringAsync();
                //Checking the response is successful or not which is sent using HttpClient  
                if (res.IsSuccessStatusCode)
                {
                    //Storing the response details received from web api   
                    var response = res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response received from web api and storing into the Post object 
                    reservation = JsonConvert.DeserializeObject<Reservation>(response);

                }
            }
            //returning the post to view  
            return reservation;
        }

    }
}