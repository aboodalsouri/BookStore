using BookStore.Data;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        IGategoryService Cservice;
        public CategoryController(IGategoryService _Cservice)
        {
            Cservice = _Cservice;
        }
        public IActionResult Index()
        {
            VMcategory vm = new VMcategory();
            vm.licategories = Cservice.LoadAll();
            return View("Category",vm);
        }
        public IActionResult Save(VMcategory vm)
        {
            Cservice.Insert(vm.categore);
            vm.licategories= Cservice.LoadAll();
            return View("Category",vm);
        }
       
        public IActionResult Aedit(int id)
        {
            /*VMcategory vm = new VMcategory();
            vm.categore= Cservice.Edit(id);
            vm.licategories = Cservice.LoadAll();*/
            Gategory C = new Gategory();
            C = Cservice.Edit(id);
            return Json(C);
        }
        public IActionResult update(VMcategory vm)
        {
            Cservice.Update(vm.categore);
            vm.licategories = Cservice.LoadAll();
            return View("Category", vm);
        }
        public IActionResult Delete(int id)
        {
            VMcategory vm = new VMcategory();
            Cservice.Delete(id);
            vm.licategories = Cservice.LoadAll();
            return View("Category",vm);
        }
    }
}
