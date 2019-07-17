using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Web02Mvc01Heroes.DataAccess;
using Web02Mvc01Heroes.Models;
using Web02Mvc01Heroes.ViewModels;
using Web02Mvc01Heroes.ViewModels.VillainsViewModels;

namespace Web02Mvc01Heroes.Controllers
{
    public class VillainsController : Controller
    {
        /* TempData["Message"] è il messaggio da visualizzare nella Home/Index dei villain. */

        /* Pagina principale con la "tabella ridotta" dei villain. */
        public IActionResult Index()
        {
            List<VillainsHomeListViewModel> model = Repository.Instance.GetVillainsFor_HomeList();
            return View("VillainsHomeList", model);
        }

        /* View per la modifica del villain. */
        public IActionResult EditVillainPageWithID(int iDOfVillainToEdit)
        {
            ViewData["inHeroesList"] = Repository.Instance.GetHeroList_ForVillainSEdit();
            VillainsVillainToEditViewModel model = Repository.Instance.GetVillainForEditPageFromID(iDOfVillainToEdit);
            return View("VillainsEditView", model);
        }

        /* Effettiva modifica. */
        public IActionResult EditVillainByID(Villain editedVillain)
        {
            if (Repository.Instance.EditVillain(editedVillain))
            {
                TempData["Message"] = editedVillain.NameVillain;
                return View("Index", "Villains");
            }
            else
            {
                TempData["Message"] = "Cannot complete the edit.";
                return RedirectToAction("EditVillainPageWithID", editedVillain.ID);
            }
        }

        /* View di conferma per l'eliminazione. */
        public IActionResult AskDeleteVillainWithID(int iDOfVillainToDelete)
        {
            VillainsVillainToDeleteViewModel model = Repository.Instance.GetVillainForDeletePageFromID(iDOfVillainToDelete);
            return View("VillainsEditView", model);
        }

        /* Effettiva eliminazione. */
        public IActionResult DeleteVillainByID(int iDOfVillainToDelete)
        {
            string message = (Repository.Instance.DeleteVillainByID(iDOfVillainToDelete)) ? "Villain succesfully deleted!" : "Villain not found.";
            TempData["Message"] = message;
            return RedirectToAction("Index", "Villains");
        }

        /* View per l'aggiunta d'un villain. */
        /* Effettiva aggiunta. */
    }
}