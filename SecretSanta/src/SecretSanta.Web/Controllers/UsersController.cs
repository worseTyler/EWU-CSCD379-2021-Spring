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
            if (MockData.Groups.Count() == 1)
            {
                MockData.Groups.RemoveAll(item => item.Users.Select(item => item.GroupName).ToString() == MockData.Users[id].GroupName);
            }
            else
            {
                MockData.Groups.RemoveAll(item => item.Users.All(item => item == MockData.Users[id]));
            }

            return View(MockData.Users[id]);
        }

        [HttpPost]
        public IActionResult Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Id = (MockData.Users.Select(item => item.Id).Last() + 1);
                MockData.Users.Add(viewModel);
                System.Console.WriteLine(MockData.Users.Count());

                if (MockData.Groups
                       .Select(item => item.GroupName)
                        .Contains(viewModel.GroupName))
                {
                    foreach (GroupViewModel group in MockData.Groups)
                    {
                        if (group.GroupName == viewModel.GroupName)
                            group.Users.Add(viewModel);
                    }
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
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                MockData.Users[viewModel.Id] = viewModel;


                if (MockData.Groups
                    .Select(item => item.GroupName)
                    .Equals(MockData.Users[viewModel.Id].GroupName))
                {
                    foreach (GroupViewModel group in MockData.Groups)
                    {
                        if (group.GroupName == viewModel.GroupName)
                            group.Users.Add(viewModel);
                    }
                }
                else
                {
                    foreach (GroupViewModel group in MockData.Groups)
                    {
                        if (group.GroupName == viewModel.GroupName)
                            group.Users.Remove(viewModel);
                    }
                    GroupViewModel groupViewModel = new GroupViewModel
                    {
                        GroupName = viewModel.GroupName,
                        Users = new List<UserViewModel> { viewModel }
                    };
                    MockData.Groups.Add(groupViewModel);
                }
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            foreach (GroupViewModel group in MockData.Groups)
            {
                group.Users.RemoveAll(item => item.Id == id);
            }

            MockData.Users.RemoveAt(id);
            for (int i = 0; i < MockData.Users.Count; i++)
            {
                for (int j = 0; i < MockData.Users[i].Gifts.Count; i++)
                {
                    MockData.Users[i].Gifts[j].Id = i;
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
