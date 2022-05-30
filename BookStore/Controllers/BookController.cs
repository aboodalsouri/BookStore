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
    public class BookController : Controller
    {
        IBookService Bservice;
        IGategoryService Cservice;
        IAutherService Aservice;
        public BookController(IBookService _Bservice, IGategoryService _Cservice, IAutherService _Aservice)
        {
            Bservice = _Bservice;
            Cservice = _Cservice;
            Aservice = _Aservice;
        }
        public IActionResult Index()
        {
            VMbook vm = new VMbook();
            vm.books = Bservice.LoadAll();
            vm.authers = Aservice.LoadAll();
            vm.gategories = Cservice.LoadAll();
            return View("Book", vm);
        }
        public IActionResult Save(VMbook vm)
        {
            string name = Guid.NewGuid().ToString() + "." + vm.book.image.FileName.Split('.')[1];
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Images", name);
            vm.book.image.CopyTo(new FileStream(path, FileMode.Create));
            vm.book.imagePath = "http://localhost/BookStore/Spath/" + name;

            Bservice.Insert(vm.book);

            vm.books = Bservice.LoadAll();
            vm.authers = Aservice.LoadAll();
            vm.gategories = Cservice.LoadAll();
            return View("Book",vm);
        }
      
        public IActionResult Aedit(int id)
        {
            /*VMbook vm = new VMbook();
            vm.book = Bservice.Edit(id);

            vm.books = Bservice.LoadAll();
            vm.authers = Aservice.LoadAll();
            vm.gategories = Cservice.LoadAll();
            return View("Book", vm);*/
            Book B = new Book();
            B = Bservice.Edit(id);
            return Json(B);
        }
        public IActionResult update(VMbook vm)
        {
            Bservice.Update(vm.book);
            vm.books = Bservice.LoadAll();
            vm.authers = Aservice.LoadAll();
            vm.gategories = Cservice.LoadAll();
            return View("Book", vm);
        }
        public IActionResult Delete(int id)
        {
            VMbook vm = new VMbook();
            Bservice.Delete(id);
            vm.books = Bservice.LoadAll();
            vm.authers = Aservice.LoadAll();
            vm.gategories = Cservice.LoadAll();
            return View("Book", vm);
        }
    }
}
