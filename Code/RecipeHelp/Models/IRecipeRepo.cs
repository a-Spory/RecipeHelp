using System.Collections.Generic;
using System.Linq;

namespace RecipeHelp.Models
{
    public interface IRecipeRepo
    {
        

        //CREATE
        public Recipe Create(Recipe r);

        //READ

        public IQueryable<Recipe> GetAllRecipes();
        public Recipe GetRecipeById(int id);
        public IQueryable<Recipe> GetRecipesByKeyword(string keyword);
        public IQueryable<Recipe> GetRecipesByFilter(string keyword, int cooktime, string budget, string difficulty, string course, string cuisine, string diet);
        public IQueryable<Recipe> GetRecipeByUserId(int id);
        public int GetNumRecipesSharedByUser(int id);

        //UPDATE

        public Recipe Update(Recipe r);

        //DELETE

        public bool DeleteRecipe(int id);
    }

    
}
