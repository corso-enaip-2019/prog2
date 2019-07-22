﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P19_Web_Dynamic_07_FullStack.DataAccess;
using P19_Web_Dynamic_07_FullStack.Infrastructure;
using P19_Web_Dynamic_07_FullStack.Infrastructure.Exceptions;
using P19_Web_Dynamic_07_FullStack.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P19_Web_Dynamic_07_FullStack.Controllers
{
    public class SuperheroesController : BaseController
    {
        private static bool _firstTime = true;

        public SuperheroesController(AppDbContext context)
            : base(context)
        { }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (_firstTime)
            {
                ViewData["InitialMessage"] = "Welcome to the superheroes management!";
                _firstTime = false;
            }

            var vms = await _context
                .Superheroes
                .Select(x => new SuperheroRowViewModel
                    {
                        Id = x.Id,
                        Name = x.HeroName,
                        Strength = x.Strength,
                        EnemiesCount = x.Enemies.Count
                    })
                .ToListAsync();

            return View(vms);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["villains"] = await GetVillainNamesAsync();

            var model = await GetViewModelAsync(id);

            if (model == null)
            {
                TempData["MessageText"] = "Superhero not found!";
                TempData["MessageSeverity"] = MessageSeverity.Error;
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuperheroEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var toUpdate = await _context.Superheroes
                        .Include(x => x.Enemies)
                        .FirstOrDefaultAsync(x => x.Id == viewModel.Id);

                    toUpdate.AssetsValue = viewModel.AssetsValue;
                    toUpdate.CanFly = viewModel.CanFly;
                    toUpdate.HeroName = viewModel.HeroName;
                    toUpdate.Powers = viewModel.Powers;
                    toUpdate.SecretName = viewModel.SecretName;
                    toUpdate.Strength = viewModel.Strength;

                    toUpdate.Enemies.Clear();

                    if (viewModel.EnemiesIds != null)
                    {
                        foreach (var enemyId in viewModel.EnemiesIds)
                        {
                            var villain = await _context.Villains
                                .FirstOrDefaultAsync(x => x.Id == enemyId);
                            toUpdate.Enemies.Add(villain);
                        }
                    }

                    await _context.SaveChangesAsync();

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
                ViewData["villains"] = await GetVillainNamesAsync();
                return View(viewModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await GetViewModelAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var toRemove = await _context.Superheroes.FirstOrDefaultAsync(x => x.Id == id);
                _context.Superheroes.Remove(toRemove);
                await _context.SaveChangesAsync();

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

        private async Task<SuperheroEditViewModel> GetViewModelAsync(int id)
        {
            return await _context
                .Superheroes
                .Select(x => new SuperheroEditViewModel
                    {
                        Id = x.Id,
                        AssetsValue = x.AssetsValue,
                        CanFly = x.CanFly,
                        HeroName = x.HeroName,
                        Powers = x.Powers,
                        SecretName = x.SecretName,
                        Strength = x.Strength,
                        EnemiesIds = x.Enemies.Select(y => y.Id).ToList()
                    })
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        private async Task<List<SelectRowViewModel>> GetVillainNamesAsync()
        {
            return await _context
                .Villains
                .Select(x => new SelectRowViewModel
                    {
                        Id = x.Id,
                        Name = x.VillainName,
                    })
                .ToListAsync();
        }
    }
}
