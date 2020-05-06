using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAspCore3.Areas.Admin.Services;
using RestaurantAspCore3.Models;

namespace RestaurantAspCore3.Areas.Admin.ApiControllers
{
    [Route("api/subcategories")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService SubCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            SubCategoryService = subCategoryService;
        }


        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> GetSubCategoriesByCategoryName(String name)
        {
            var SubCategories = await SubCategoryService.GetSubCategoriesByCategoryName(name);
            return Ok(SubCategories);

        }
    }
}