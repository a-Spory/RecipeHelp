﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeHelp.Models;

namespace RecipeHelp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210414170451_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RecipeHelp.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Budget")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cooktime")
                        .HasColumnType("int");

                    b.Property<string>("Course")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cuisine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Budget = "Cheap",
                            Cooktime = 40,
                            Course = "Dinner",
                            Cuisine = "American",
                            Diet = "Omni",
                            Difficulty = "Easy",
                            IngredientId = 0,
                            Ingredients = "Bun, Lettuce, Mayo, Tomato, Beef Patty",
                            Name = "Hamburger",
                            UserId = 0
                        },
                        new
                        {
                            Id = 2,
                            Budget = "Cheap",
                            Cooktime = 25,
                            Course = "Dinner",
                            Cuisine = "American",
                            Diet = "Omni",
                            Difficulty = "Medium",
                            IngredientId = 0,
                            Ingredients = "Clams",
                            Name = "Clam Chowder",
                            UserId = 0
                        },
                        new
                        {
                            Id = 3,
                            Budget = "Cheap",
                            Cooktime = 40,
                            Course = "Dinner",
                            Cuisine = "Italian",
                            Diet = "Omni",
                            Difficulty = "Easy",
                            IngredientId = 0,
                            Ingredients = "Spahetti Pasta, Garlic, Tomatoes, Oregano",
                            Name = "Spaghetti",
                            UserId = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
