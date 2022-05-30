using BookStore.Data;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AutherController : Controller
    {
        IAutherService Aservice;
        ICountryService Cservice;
        public AutherController(IAutherService _Aservice,ICountryService _Cservice)
        {
            Aservice = _Aservice;
            Cservice = _Cservice;
        }
        public IActionResult Index()
        {
            VMAuther vm = new VMAuther();
            vm.Authers = Aservice.LoadAll();
            vm.countries = Cservice.LoadAll();
            return View("Auther",vm);
        }
        public IActionResult Save(VMAuther vm)
        {
            string name = Guid.NewGuid().ToString() + "." + vm.auther.image.FileName.Split('.')[1];
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Images", name);
            vm.auther.image.CopyTo(new FileStream(path, FileMode.Create));
            vm.auther.imagePath = "http://localhost/BookStore/Spath/" + name;
           
            Aservice.Insert(vm.auther);

            vm.Authers = Aservice.LoadAll();
            vm.countries = Cservice.LoadAll();
            return View("Auther",vm);
        }
       
        public IActionResult Aedit(int id)
        {
            /*  VMAuther vm = new VMAuther();
              vm.auther = Aservice.Edit(id);
              vm.Authers = Aservice.LoadAll();
              vm.countries = Cservice.LoadAll();*/
             Auther A = new Auther();
             A= Aservice.Edit(id);
            return Json(A);
        }
        public IActionResult update(VMAuther vm)
        {
            Aservice.Update(vm.auther);
            vm.Authers = Aservice.LoadAll();
            vm.countries = Cservice.LoadAll();
            return View("Auther", vm);
        }
        public IActionResult Delete(int id)
        {
            VMAuther vm = new VMAuther();
            Aservice.Delete(id);
            vm.Authers = Aservice.LoadAll();
            vm.countries = Cservice.LoadAll();
            return View("Auther", vm);
        }
    }
}
