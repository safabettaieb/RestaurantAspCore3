﻿using RestaurantAspCore3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAspCore3.Areas.Admin.Services
{
     public interface ISubCategoryService
    {
        public Task<IEnumerable<SubCategory>> GetSubCategoriesByCategoryName(String name);
    }
}
