using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAspCore3.Areas.Admin.Services;
using RestaurantAspCore3.Data;
using RestaurantAspCore3.Models;

namespace RestaurantAspCore3.Areas.Admin.ApiControllers
{
    [ApiController]
    [Route("/api/categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService CategoryService;


        public CategoryController(ICategoryService CategoryService)
        {
            this.CategoryService = CategoryService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetCategories()
        {
            var Categories = await CategoryService.GetCategories();

            return Ok(Categories);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddCategory(Category Category)
        {
            if (ModelState.IsValid)
            {
                var C = await CategoryService.AddCategory(Category);
                return Ok(C);

            }
            return BadRequest();

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var Category = await CategoryService.GetCategoryById(id);
            return Ok(Category);
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Category Category)
        {
            if (ModelState.IsValid)

            {
                var CategoryInDB = await CategoryService.UpdateCategory(id, Category);
                return Ok(CategoryInDB);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var DelCategory = await CategoryService.DeleteCategory(id);
            return Ok(DelCategory);
                 
        }
    }
}
