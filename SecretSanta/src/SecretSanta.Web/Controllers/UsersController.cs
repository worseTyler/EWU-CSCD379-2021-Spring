using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Web.Data;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Controllers
{
    public class UsersController : Controller
    {

        public IActionResult Index()
        {
            return View(MockData.Users);
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            MockData.Users[id].Id = id;
            return View(MockData.Users[id]);
        }

        [HttpPost]
        public IActionResult Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                MockData.Users.Add(viewModel);
               

                if (MockData.Groups
                       .Select(item => item.GroupName)
                        .Contains(viewModel.GroupName))
                {
                    MockData.Groups.Select(item => item.GroupName).All(item => item == viewModel.GroupName)
                }
                else
                {
                    GroupViewModel groupViewModel = new GroupViewModel
                    {
                        GroupName = viewModel.GroupName,
                        Users = new List<UserViewModel> { viewModel }
                    };
                    MockData.Groups.Add(groupViewModel);
                }
                 return RedirectToAction(nameof(Index));
            }
            else

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                if (MockData.Users[viewModel.Id].GroupName != viewModel.GroupName)
                {
                    MockData.Users[viewModel.Id].FirstName = "THIs is afsd fsjlk;tasej";
                }
                MockData.Users[viewModel.Id] = viewModel;
                return RedirectToAction(nameof(Index));

                if (MockData.Groups
                    .Select(item => item.GroupName)
                    .Contains(MockData.Users[viewModel.Id].GroupName))
                {
                    // add user to group
                }
                else
                {
                    // make new group, add user to new group
                }
            }

            return View(viewModel);
        }

    }
}
