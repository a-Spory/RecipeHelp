using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeHelp.Models
{
    public class EfRecipeRepo : IRecipeRepo
    {
        //   F i e l d s   &   P r o p e r t i e s

        private AppDbContext _context;
        private IUserRepo _userRepo;

        //   C o n s t r u c t o r s

        public EfRecipeRepo(AppDbContext context, IUserRepo uRepo)
        {
            _context = context;
            _userRepo = uRepo;
        }

        //   M e t h o d s

        //CREATE

        public Recipe Create(Recipe r)
        {
            _context.Recipes.Add(r);
            _context.SaveChanges();
            return r;
        }

        //READ
        public IQueryable<Recipe> GetAllRecipes()
        {
            return _context.Recipes;
        }

        public Recipe GetRecipeById(int rId)
        {
            return _context.Recipes
                .Where(r => r.Id == rId)
                .FirstOrDefault();
        }

        public IQueryable<Recipe> GetRecipesByKeyword(String keyword)
        {
            return _context.Recipes
                .Where(r => r.Name.Contains(keyword) || r.Ingredients.Contains(keyword));
        }


        public IQueryable<Recipe> GetRecipesByFilter(string keyword, int cooktime, string budget, string difficulty, string course, string cuisine, string diet)
        {
            return _context.Recipes
                            .Where(r => r.Name.Contains(keyword) || r.Ingredients.Contains(keyword) || r.Cooktime.Equals(cooktime) || r.Budget.Contains(budget) || r.Difficulty.Contains(difficulty) || r.Course.Contains(course) || r.Cuisine.Contains(cuisine) || r.Diet.Contains(diet));
        }

        public IQueryable<Recipe> GetRecipeByUserId(int id)
        {
            if (_userRepo.IsUserLoggedIn())
            {
                return _context.Recipes
                               .Where(r => r.UserId == id);
            }

            return null;
        }

        public int GetNumRecipesSharedByUser(int id)
        {
            if (_userRepo.IsUserLoggedIn())
            {
                return _context.Recipes
                                .Where(r => r.UserId == id)
                                .Count();
            }

            return 0;
        }

        //UPDATE

        public Recipe Update(Recipe recipe)
        {
            Recipe recipeToUpdate =
                _context.Recipes
                .SingleOrDefault(r => r.Id == recipe.Id);

            if(recipeToUpdate != null)
            {
                recipeToUpdate.Budget = recipe.Budget;
                recipeToUpdate.Cooktime = recipe.Cooktime;
                recipeToUpdate.Course = recipe.Course;
                recipeToUpdate.Cuisine = recipe.Cuisine;
                recipeToUpdate.Diet = recipe.Diet;
                recipeToUpdate.Difficulty = recipe.Difficulty;
                recipeToUpdate.Ingredients = recipe.Ingredients;
                recipeToUpdate.Name = recipe.Name;
            }

            return recipeToUpdate;
        }

        //DELETE

        public bool DeleteRecipe(int id)
        {
            Recipe recipeToDelete = _context.Recipes.Find(id);
            if (recipeToDelete == null) return false;

            _context.Recipes.Remove(recipeToDelete);
            _context.SaveChanges();
            return true;
        }
    }
}
