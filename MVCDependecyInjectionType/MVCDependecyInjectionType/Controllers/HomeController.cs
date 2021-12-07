using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCDependecyInjectionType.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDependecyInjectionType.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransient _transient1;
        private readonly IScoped _scoped1;
        private readonly ISingleton _singleton1;

        private readonly ITransient _transient2;
        private readonly IScoped _scoped2;
        private readonly ISingleton _singleton2;


        public HomeController(ITransient transient1, IScoped scoped1, ISingleton singleton1, ITransient transient2, IScoped scoped2, ISingleton singleton2)
        {
            _transient1 = transient1;
            _scoped1 = scoped1;
            _singleton1 = singleton1;

            _transient2 = transient2;
            _scoped2 = scoped2;
            _singleton2 = singleton2;
        }

        public IActionResult Index()
        {
            ViewBag.transient1 = _transient1;
            ViewBag.scoped1 = _scoped1;
            ViewBag.singleton1 = _singleton1;

            ViewBag.transient2 = _transient2;
            ViewBag.scoped2 = _scoped2;
            ViewBag.singleton2 = _singleton2;

            return View();
        }
         
    }
}
