using Microsoft.AspNetCore.Mvc;
using P19_Web_Dynamic_06_MVC.DataAccess;
using P19_Web_Dynamic_06_MVC.Infrastructure;
using P19_Web_Dynamic_06_MVC.Infrastructure.Exceptions;
using P19_Web_Dynamic_06_MVC.ViewModels;

namespace P19_Web_Dynamic_06_MVC.Controllers
{
    public class VillainsController : BaseController
    {
        private static bool _firstTime = true;

        [HttpGet]
        public IActionResult Index()
        {
            if (_firstTime)
            {
                ViewData["InitialMessage"] = "Welcome to the villains management!";
                _firstTime = false;
            }
            var vms = Repository.Instance.GetAllVillains();
            return View(vms);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var superheroes = Repository.Instance.GetAllSuperheroNames();
            ViewData["superheroes"] = superheroes;

            var model = Repository.Instance.GetVillain(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(VillainEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Repository.Instance.UpdateVillain(viewModel);
                    TempData["MessageText"] = "Villain successfully updated!";
                    TempData["MessageSeverity"] = MessageSeverity.Ok;
                }
                catch (NotFoundException)
                {
                    TempData["MessageText"] = "Villain not found!";
                    TempData["MessageSeverity"] = MessageSeverity.Error;
                }
                catch(InvalidInputException)
                {
                    TempData["MessageText"] = "Villain with invalid fields!";
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
            var model = Repository.Instance.GetVillain(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                Repository.Instance.RemoveVillain(id);
                TempData["MessageText"] = "Villain successfully deleted!";
                TempData["MessageSeverity"] = MessageSeverity.Ok;
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                TempData["MessageText"] = "Villain not found!";
                TempData["MessageSeverity"] = MessageSeverity.Error;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
