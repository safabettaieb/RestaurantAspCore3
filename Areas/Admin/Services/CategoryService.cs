﻿using Microsoft.EntityFrameworkCore;
using RestaurantAspCore3.Data;
using RestaurantAspCore3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAspCore3.Areas.Admin.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _db;

        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }
      
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _db.categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _db.categories.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
