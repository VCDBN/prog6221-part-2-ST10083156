using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_App
{
    public class Ingredient
    {
        //Properties for each ingredient
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        public double Factor { get; set; }

        //Array to hold ingredient details

       public List <Ingredient> ingredients { get; set; }
     

        public Ingredient() {}

        //Ingredient constructor
        public Ingredient(string name, int quantity, string unitOfMeasurement) 
        {
            Name = name;
            Quantity = quantity;
            UnitOfMeasurement = unitOfMeasurement;

            
        }

       

        //method used to add ingredients to array
        public void addIngredient(Ingredient ingredient)
        {
       ingredients.Add(ingredient);
        }

        //Method used to find ingredients in array
        public Boolean findIngredient(string name)
        {
           
            foreach(Ingredient ingredient in ingredients)
            {
                if (ingredient.Name == name) { return true ; }
            }
             return false ; 
            
        }

        //method used to scale quantities
        public void scaleQuantities()
        {
            
            for (int i = 0; i < ingredients.Count(); i++)
            {
                ingredients[i].Quantity *= Factor;
            }
        }

        //method used to reset quantities
        public void resetQuantities() 
        {
            for ( int i =0; i<ingredients.Count(); i++)
            {
                ingredients[i].Quantity /= Factor;
            }
            Factor = 0;
        }

        //method used to clear array
        public void clearIngredients()
        {
            ingredients.Clear();
        }
        //method to display name of specific ingredient
        public string displayName(int index)
        {
            
            return ingredients[index].Name;
        }
        //method to display unit of measurement of specific ingredient
        public string displayUnit(int index)
        {

            return ingredients[index].UnitOfMeasurement;
        }
        //method to display quantity of specific ingredient
        public double displayQuantity(int index)
        {

            return ingredients[index].Quantity;
        }

    }
}
