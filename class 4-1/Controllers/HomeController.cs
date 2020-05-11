using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using class_4_1.Models;
using class_4_1.data;

namespace class_4_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            PplDb db = new PplDb();
            HomeViewModel vm = new HomeViewModel();
            vm.People = db.GetPeople(); 
            return View(vm);
        }
        public IActionResult AddPeople()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPeople(List<Person> ppl)
        {
            PplDb db = new PplDb();
            db.AddListPpl(ppl);
            return Redirect("/home/index");
        }
    }
}
