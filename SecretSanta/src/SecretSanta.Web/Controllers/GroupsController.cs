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
                MockData.Groups[viewModel.Id] = viewModel;
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public IActionResult Delete(int id){
            MockData.Groups.RemoveAt(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
