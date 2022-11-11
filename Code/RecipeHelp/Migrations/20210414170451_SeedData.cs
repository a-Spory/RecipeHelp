using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeHelp.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Budget", "Cooktime", "Course", "Cuisine", "Diet", "Difficulty", "IngredientId", "Ingredients", "Name", "Status", "UserId" },
                values: new object[] { 1, "Cheap", 40, "Dinner", "American", "Omni", "Easy", 0, "Bun, Lettuce, Mayo, Tomato, Beef Patty", "Hamburger", null, 0 });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Budget", "Cooktime", "Course", "Cuisine", "Diet", "Difficulty", "IngredientId", "Ingredients", "Name", "Status", "UserId" },
                values: new object[] { 2, "Cheap", 25, "Dinner", "American", "Omni", "Medium", 0, "Clams", "Clam Chowder", null, 0 });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Budget", "Cooktime", "Course", "Cuisine", "Diet", "Difficulty", "IngredientId", "Ingredients", "Name", "Status", "UserId" },
                values: new object[] { 3, "Cheap", 40, "Dinner", "Italian", "Omni", "Easy", 0, "Spahetti Pasta, Garlic, Tomatoes, Oregano", "Spaghetti", null, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
