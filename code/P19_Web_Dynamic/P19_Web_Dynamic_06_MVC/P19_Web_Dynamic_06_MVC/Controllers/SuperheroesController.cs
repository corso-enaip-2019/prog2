using Microsoft.AspNetCore.Mvc;
using P19_Web_Dynamic_06_MVC.DataAccess;
using P19_Web_Dynamic_06_MVC.Infrastructure;
using P19_Web_Dynamic_06_MVC.Infrastructure.Exceptions;
using P19_Web_Dynamic_06_MVC.ViewModels;

namespace P19_Web_Dynamic_06_MVC.Controllers
{
    public class SuperheroesController : BaseController
    {
        private static bool _firstTime = true;

        [HttpGet]
        public IActionResult Index()
        {
            if (_firstTime)
            {
                ViewData["InitialMessage"] = "Welcome to the superheroes management!";
                _firstTime = false;
            }
            var vms = Repository.Instance.GetAllSuperheroes();

            return View(vms);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["MiniEnemyList"] = P19_Web_Dynamic_06_MVC.DataAccess.Repository.Instance.GetAllVillains_OnlyIdName();
            var model = Repository.Instance.GetSuperhero(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(SuperheroEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Repository.Instance.UpdateSuperhero(viewModel);
                    TempData["MessageText"] = "Superhero successfully updated!";
                    TempData["MessageSeverity"] = MessageSeverity.Ok;
                }
                catch (NotFoundException)
                {
                    TempData["MessageText"] = "Superhero not found!";
                    TempData["MessageSeverity"] = MessageSeverity.Error;
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(viewModel);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = Repository.Instance.GetSuperhero(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                Repository.Instance.RemoveSuperhero(id);
                TempData["MessageText"] = "Superhero successfully deleted!";
                TempData["MessageSeverity"] = MessageSeverity.Ok;
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                TempData["MessageText"] = "Superhero not found!";
                TempData["MessageSeverity"] = MessageSeverity.Error;
                return RedirectToAction(nameof(SuperheroNotFound));
            }
        }

        [HttpGet]
        public IActionResult SuperheroNotFound()
        {
            return View();
        }
    }
}
