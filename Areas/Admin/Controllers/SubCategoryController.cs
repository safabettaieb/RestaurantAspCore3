using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAspCore3.Data;
using RestaurantAspCore3.Models;
using RestaurantAspCore3.Models.ViewModels;

namespace RestaurantAspCore3.Areas.Admin.Controllers
{
    [Area ("Admin")] 
    public class SubCategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SubCategoryController(ApplicationDbContext _db)
        {
            this._db = _db;
        }


        public async Task<IActionResult> Index()
        {
            var subCategories = await (_db.subCategories.Include(s=>s.Category).ToListAsync());
            return View(subCategories);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            SubCategoryAndCategory SubCategoryAndCategory = new SubCategoryAndCategory()
            {
                Categories = await _db.categories.ToListAsync(),
                SubCategories = await _db.subCategories.ToListAsync(),
                SubCategory = new SubCategory()
            };
            return View(SubCategoryAndCategory);

        }

        public async Task<IActionResult> create(SubCategory SubCategory)
        {
            if (ModelState.IsValid)
            {
                _db.subCategories.Add(SubCategory);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(SubCategory);
        }

    }
    
}