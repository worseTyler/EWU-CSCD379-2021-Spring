using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Web.ViewModels;
using SecretSanta.Web.Data;

namespace SecretSanta.Web.Controllers
{
    public class GroupsController : Controller
    {
        public IActionResult Index()
        {
            return View(MockData.Groups);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(GroupViewModel viewModel){
            if(ModelState.IsValid){
                MockData.Groups.Add(viewModel);
                return RedirectToAction(nameof(Index));
            }else{
                return View(viewModel);
            }
        }

        public IActionResult Update(int id)
        {
            MockData.Groups[id].Id = id;
            return View(MockData.Groups[id]);
        }
        
        [HttpPost]
        public IActionResult Update(GroupViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                foreach (UserViewModel user in MockData.Users)
                {
                    if (user.GroupName == MockData.Groups[viewModel.Id].GroupName)
                    {
                        user.GroupName = viewModel.GroupName;
                    }
                }
                MockData.Groups[viewModel.Id].GroupName = viewModel.GroupName;
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public IActionResult Delete(int id){
            foreach (UserViewModel user in MockData.Users)
            {
                if (user.GroupName == MockData.Groups[id].GroupName)
                {
                    user.GroupName = "Unamed Group";
                }
            }
            MockData.Groups.RemoveAt(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
