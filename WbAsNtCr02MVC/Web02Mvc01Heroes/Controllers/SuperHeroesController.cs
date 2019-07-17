using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web02Mvc01Heroes.Controllers
{
    public class SuperHeroesController : Controller
    {
        public IActionResult Index()
        {
            return View("VillainsHomeList");
        }
    }
}