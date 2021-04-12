using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Web.Data;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Controllers
{
    public class GiftsController : Controller
    {
        public IActionResult Index()
        {
            return View(MockData.Users);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update(int userId, int giftId)
        {
            return View(MockData.Users[userId].Gifts[giftId]);
        }

        [HttpPost]
        public IActionResult Create(GiftViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Id = MockData.Users[viewModel.UserId].Gifts.Count();
                MockData.Users[viewModel.UserId].Gifts.Add(viewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(GiftViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                foreach(UserViewModel user in MockData.Users){
                    System.Console.WriteLine(viewModel.Id);
                    System.Console.WriteLine($"{user.Gifts[viewModel.Id].Title} - {viewModel.Title}");
                    if(user.Gifts.Count > viewModel.Id && user.Id == viewModel.UserId){
                        user.Gifts[viewModel.Id] = viewModel;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public IActionResult Delete(int userId, int giftId)
        {

            MockData.Users[userId].Gifts.RemoveAll(item => item.Id == giftId);
            for(int i = 0; i < MockData.Users[userId].Gifts.Count(); i++){
                 MockData.Users[userId].Gifts[i].Id = i;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
