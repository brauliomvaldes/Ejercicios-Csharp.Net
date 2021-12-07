using AspValidation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspValidation.Controllers
{
    public class BeerController : Controller
    {
        public IActionResult Create()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }
        [HttpPost]
        public IActionResult Create(Beer beer)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", beer);
            }

            // se procesan los datos, guardar o algo

            TempData["message"] = "Cerveza guardada exitosamente";
            return Redirect("Create");
        }

    }
}
