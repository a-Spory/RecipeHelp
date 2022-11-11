using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeHelp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeHelp.Controllers
{
    public class HomeController : Controller
    {
        //FIELDS

        private IRecipeRepo _repository;
        //private readonly ILogger<HomeController> _logger;

        //CONSTRUCTORS

        public HomeController(IRecipeRepo repo)
        {
            _repository = repo;
        }

        //METHODS
        //READ
        public IActionResult Index()
        {
            IQueryable<Recipe> allRecipes = _repository.GetAllRecipes();
            return View(allRecipes);
        }

        [HttpGet]
        public IActionResult SearchResults(String keyword)
        {
            return View(_repository.GetRecipesByKeyword(keyword));
        }

        [HttpGet]
        public IActionResult RecipeDetails(int id)
        {
            Recipe recipe = _repository.GetRecipeById(id);
            if (recipe != null)
            {
                return View(recipe);
            }

            return RedirectToAction("Index");
        }

        //UPDATE
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }
    }
}
