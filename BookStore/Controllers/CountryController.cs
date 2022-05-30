using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class CountryController : Controller
    {
        ICountryService Cservice;
        public CountryController(ICountryService _Cservice)
        {
            Cservice = _Cservice;
        }
        public IActionResult Index()
        {
            VMCountry vm = new VMCountry();
            vm.licountrys = Cservice.LoadAll();
            return View("NewCountry",vm);
        }
        public IActionResult Save(VMCountry vm)
        {
            Cservice.Insert(vm.Country);
            vm.licountrys = Cservice.LoadAll();
            return View("NewCountry", vm);
        }
    }
}
