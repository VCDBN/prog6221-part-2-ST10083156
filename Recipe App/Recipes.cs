using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_App
{
    public class Recipe
    {
        public string Name { get; set; }
       public List <Ingredient> Ingredients = new List<Ingredient>();
       public List<Steps> Steps = new List<Steps>();
       public List<Recipe> Recipes= new List<Recipe>();

        public Recipe() { }
        public Recipe(string name, List <Ingredient> ingredients, List<Steps> steps) 
        { 
            Name = name;
            List<Recipe> Recipes = new List<Recipe>();
            ingredients = Ingredients;
            steps = Steps;
        }

        public void addRecipe(Recipe recipe) 
        {
            Recipes.Add(recipe);
            
        }

        public void removeRecipe(Recipe recipe) 
        {
            Recipes.Remove(recipe); 
        }

    }
}
