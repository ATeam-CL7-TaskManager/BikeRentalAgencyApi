using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgencyUI.Repository.Interfaces;
using BikeRentalAgencyUI.Models;


namespace BikeRentalAgencyUI.Controllers
{
    public class BikeController : Controller
    {
        private string baseUrl = "https://localhost:44305/";
        private IBikeRepository repository;
        public BikeController(IBikeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ActionResult> Index()
        {
           // var model = await repository.GetBikes(int? Bike);
            return View();
        }



        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            var model = new BikeViewModel();
            if (id == null)
            {
                model.Bike = new Bike();
                model.Bikes = await repository.GetBikes(model?.Bike?.BikeID);
                return View(model);
            }

            model.Bike = await repository.GetBike(id);
            model.Bikes = await repository.GetBikes(model?.Bike?.BikeID);
            return View(model);
        }



        [HttpPost]
        public async Task<ActionResult> Edit(Bike post)
        {
            TempData["message"] = string.Empty;
            string message;

            if (post == null) return View(new Bike());

            bool succeeded;
            //add new post
            if (post.PostId == 0)
            {
                succeeded = await repository.AddPost(post);
                message = $"{post.Title} has not been added";

                //Checking the response is successful or not   
                if (succeeded)
                {
                    message = $"{post.Title} has been added";
                }
            }
            else
            {
                //update existing post
                succeeded = await repository.UpdatePost(post);
                message = $"{post.Title} has not been saved";
                //Checking the response is successful or not   
                if (succeeded)
                {
                    message = $"{post.Title} has been saved";
                }
            }
            TempData["message"] = message;

            if (succeeded) return RedirectToAction("Index");

            var model = new PostViewModel
            {
                Post = post
            };
            model.Categories = await repository.GetCategories(post.CategoryId);
            return View(model);
        }




        public async Task<ActionResult> Details(int id)
        {
            var model = new PostViewModel
            {
                Post = await repository.GetPost(id)
            };
            model.Categories = await repository.GetCategories(model?.Post?.CategoryId);

            return View(model);
        }





        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            TempData["message"] = string.Empty;
            bool succeeded = await repository.DeletePost(id);
            TempData["message"] = $"Post not deleted";
            if (succeeded)
            {
                TempData["message"] = $"Post deleted";
            }
            //returning to view  
            return RedirectToAction("Index");
        }
    }
}
