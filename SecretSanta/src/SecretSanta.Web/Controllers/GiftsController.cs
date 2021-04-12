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
        
        [HttpPost]
        public IActionResult Create(GiftViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                MockData.GiftsDictionary[viewModel.User].Add(viewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(string user, int id)
        {
            MockData.GiftsDictionary[user][id].Id = id;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(string user, int id){
            MockData.GiftsDictionary[user].RemoveAt(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
