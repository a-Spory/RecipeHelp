using Microsoft.AspNetCore.Mvc;
using RecipeHelp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeHelp.Controllers
{
    public class RecipeController : Controller
    {
        //FIELDS & PROPERTIES

        private IRecipeRepo _repository;

        //CONSTRUCTORS
        public RecipeController (IRecipeRepo repo)
        {
            _repository = repo;
        }

        //METHODS
        //CREATE

        [HttpGet]
        public IActionResult Add()
        {
            
            Recipe newRecipe = new Recipe();
            return View(newRecipe);
        }

        [HttpPost]
        public IActionResult Add(Recipe recipe)
        {
            
            if (ModelState.IsValid)
            {
                _repository.Create(recipe);
                return RedirectToAction("Index");
            }

            return View(recipe);
        }

        //READ

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

        public IActionResult UserRecipeDetails(int id)
        {

            Recipe recipe = _repository.GetRecipeById(id);
            if (recipe != null)
            {
                return View(recipe);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UserRecipes(int id)
        {
            IQueryable<Recipe> r = _repository.GetRecipeByUserId(id);
            return View(r);
        }

        public IActionResult Index()
        {
            IQueryable<Recipe> allRecipes = _repository.GetAllRecipes();

            return View(allRecipes);
        }

        //UPDATE

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Recipe recipe = _repository.GetRecipeById(id);
            if(recipe != null)
            {
                return View(recipe);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Recipe updateRecipe)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(updateRecipe);
                return RedirectToAction("Index");
            }
            return View(updateRecipe);
        }

        //DELETE
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Recipe recipe = _repository.GetRecipeById(id);
            if (recipe != null) return View(recipe);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Recipe r)
        {
            _repository.DeleteRecipe(r.Id);
            return RedirectToAction("Index");
        }
        
    }
}
