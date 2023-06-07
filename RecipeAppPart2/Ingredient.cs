using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeAppPart2
{
    public class Ingredient
    {
        //Properties of each ingredient used to create Ingredient objects
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        public string FoodGroup { get; set; }
        public double Calories { get; set; }
      
        //Empty construcotr for Ingredient
        public Ingredient() { }

        //Ingredient constructor with all properties as parameters
        public Ingredient(string name, double quantity, string unitOfMeasurement, string foodGroup, double calories)
        {
            Name = name;
            Quantity = quantity;
            UnitOfMeasurement = unitOfMeasurement;
            FoodGroup = foodGroup;
            Calories = calories;
          
        }
       
    }
}
