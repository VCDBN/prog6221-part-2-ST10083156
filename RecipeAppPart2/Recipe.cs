using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeAppPart2
{
    public class Recipe
    {

        //All properties of a recipe as variables
        public string Name { get; set; }
       public List <Ingredient> Ingredients { get; set;}
       public List<Step> Steps { get; set; }
        public double TotalCalories { get; set; }

        //Empty constructor for Recipe class
        public Recipe() { }

        //Constructor for Recipe class with all properties as parameters
        public Recipe(string name, List<Ingredient> ingredients, List<Step> steps, double totalCalories)
        {
            Name = name;
            Ingredients = ingredients;
            Steps = steps;
            TotalCalories = totalCalories;
        }
    }
}
