using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Controllers
{
    public class UsersController : Controller
    {
        static List<UserViewModel> Users = new List<UserViewModel>
        {
            new UserViewModel {FirstName = "Tyler", LastName = "Jones"}
        };
        public IActionResult Index()
        {
            return View(Users);
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            Users[id].Id = id;
            return View(Users[id]);
        }

        [HttpPost]
        public IActionResult Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Users.Add(viewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Users[viewModel.Id] = viewModel;
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

    }
}
