﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CnsApp31P19Libreria.DataAccess;
using CnsApp31P19Libreria.ViewModels;

namespace CnsApp31P19Libreria.Controllers
{
    public class BooksController : Controller
    {
        private AppDBContext _context;

        //public void AuthorsController(AppDBContext context)
        public void BooksController_(AppDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //public IActionResult Index(/*AuthorEditViewModel model*/)
        //{
        //    var viewModels = _context.Authors
        //        .Include(model => model.BookAuthors)
        //        .Select(model => new AuthorRowViewModel
        //        {
        //            IDesignTimeMvcBuilderConfiguration = model.ID,
        //            nameof = model.Name,
        //            WrittenBooks = model.BookAuthors.Count
        //        })
        //        .ToList();

        //    return View(model); //??
        //}

        //[HttpGet]
        //public IActionResult Get(int iD)
        //{
        //    var viewModel=await _context.Authors
        //        .Include(x=>x.BookAuthors)
        //        .ThenInclude(x=>x.Book)
        //        .Select(model=>new )

        //}


        //public IActionResult Post(int iD)
        //{
        //    throw new NotImplementedException();
        //}
    }
}