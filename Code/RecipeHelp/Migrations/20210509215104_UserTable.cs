using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeHelp.Migrations
{
    public partial class UserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Recipes");

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
