using Recipe_App;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Xml.Linq;

class Program
{
   static string name;
   static int quantity = 0;
   static string unitOfMeasurement;
  static  int factor = 0;
  static  int numIngredients = 0;
   static int numOfSteps = 0;
    static void Main(string[] args)
    {



        Console.WriteLine(" ");
        Console.WriteLine("Welcome to the Recipe app!");
        Console.WriteLine(" ");

        newRecipe();

    }
    //method for adding a new recipe to the arrays
    static void newRecipe()
    {
        Console.WriteLine("*****INGREDIENTS*****");
        Console.WriteLine(" ");
        Console.WriteLine("Please begin by entering the number of ingredients for the recipe");
        //prompting user input for the number of ingredients
        numIngredients = Convert.ToInt32(Console.ReadLine());
        //exception handling in case of invalid input
        while (numIngredients < 1)
        {
            try { numIngredients = Convert.ToInt32(Console.ReadLine()); }
            catch (Exception e)
            {
                Console.WriteLine(" ");
                Console.WriteLine(e.Message);
                

            }
            if (numIngredients < 1)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Please enter a valid number of ingredients");
            }


        }
        
        
        //for loop that loops the amount of times specified by user to capture each ingredient
        for (int i = 0; i < numIngredients; i++)
        {
            quantity = 0;
            Console.WriteLine(" ");
            Console.WriteLine("Please enter the name of ingredient " + (i + 1));
            //prompting user input for the name of ingredients
            name = Console.ReadLine();
            Console.WriteLine(" ");
            Console.WriteLine($"Please enter the quantity of {name} required");
            //exception handling in case of invalid input
            while (quantity < 1)
            {
                try { quantity = Convert.ToInt32(Console.ReadLine()); }
                catch (Exception e)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(e.Message);
                   
                }
                if (quantity < 1)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine($"Please enter a valid quantity of {name}");
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine($"Please enter the unit of measurement for {name}");
            unitOfMeasurement = Console.ReadLine();
           
           
            Ingredient ingredient = new Ingredient(name,quantity,unitOfMeasurement);
            ingredient.addIngredient(ingredient);
        }
        Console.WriteLine(" ");
        Console.WriteLine("*****STEPS*****");
        Console.WriteLine(" ");
        Console.WriteLine("Please enter the number of steps in the recipe");
        numOfSteps = Convert.ToInt32(Console.ReadLine());
        //exception handling in case of invalid input
        while (numOfSteps < 1)
        {
           
            try { numOfSteps = Convert.ToInt32(Console.ReadLine()); }
            catch (Exception e)
            {
                Console.WriteLine(" ");
                Console.WriteLine(e.Message);
                

            }
            if (numOfSteps < 1)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Please enter a valid number of steps");
            }



        }
        Steps steps = new Steps();
        steps.listOfSteps = new List<string>(numOfSteps);

        for (int i = 0; i < numOfSteps; i++)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Please enter step number " + (i + 1));
            string recipeStep = Console.ReadLine();

            steps.addStep(i, recipeStep);
        }

        Console.WriteLine(" ");
        Console.WriteLine("The Full recipe is : ");
        Ingredient ingredient1 = new Ingredient(name, quantity, unitOfMeasurement);

        display(numIngredients, numOfSteps, ingredient1, steps);

        menu(numIngredients, numOfSteps, ingredient1, steps);
    }
   //method for printing the ingredients and steps
    static void display(int numIngredients, int numOfSteps, Ingredient ingredient, Steps steps)
    {
        if (ingredient.ingredients[0].Name == null)
        {
            Console.WriteLine(" ");
            Console.WriteLine("The recipes are empty");
            Console.WriteLine(" ");
        }
        else
        {
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine(" ");
                Console.WriteLine($"{ingredient.ingredients[i].Quantity} {ingredient.ingredients[i].UnitOfMeasurement} of {ingredient.ingredients[i].Name}");

            }
            Console.WriteLine(" ");
            for (int i = 0; i < numOfSteps; i++)
            {
                Console.WriteLine(" ");
                Console.WriteLine($"Step number {i + 1} : {steps.displaySteps(i)}");
            }
        }
    }
    //method for displaying menu
    static void menu(int numIngredients, int numOfSteps, Ingredient ingredient, Steps steps)
    {
        Ingredient ingredient1= ingredient;
        Steps steps1= steps;
        double factor = 0;
        int input = 0;

        //displaying menu for options to the user
        Console.WriteLine(" ");
        Console.WriteLine("*****MENU*****");
        Console.WriteLine(" ");
        Console.WriteLine("Please select a menu option :");
        Console.WriteLine(" ");
        Console.WriteLine("1. View the full recipe.");
        Console.WriteLine("2. Scale the quantities of the recipe.");
        Console.WriteLine("3. Return the quantities back to the original values.");
        Console.WriteLine("4. Clear all ingredients and steps.");
        Console.WriteLine("5. Add new recipe (only if recipe book is empty).");
        Console.WriteLine("6. End recipe app.");
        Console.WriteLine(" ");

        //exception handling in case of invalid input
        while (input < 1)
        {
            try { input = Convert.ToInt32(Console.ReadLine()); }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            if (input > 5 || input < 1)
            {
                Console.WriteLine($"Please enter a valid menu number");
                
                
            }
            

        }

        //switch case for menu options
        switch (input)
        {
            case 1:
                display(numIngredients, numOfSteps, ingredient1, steps1);
                menu(numIngredients, numOfSteps, ingredient1, steps1);
                break;
            case 2:
                Console.WriteLine(" ");
                Console.WriteLine("Please choose the factor that you would like to scale your quantities by (0.5, 2 or 3)");
                ingredient1.Factor = Convert.ToDouble(Console.ReadLine());

                //exception handling in case of invalid input
                while (ingredient1.Factor != 0.5 && ingredient1.Factor != 2 && ingredient1.Factor != 3)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Please enter a valid factor number between 0.5, 2 and 3");
                  
                    ingredient1.Factor = Convert.ToDouble(Console.ReadLine());

                }
                Console.WriteLine(" ");
                Console.WriteLine($"Factor of {ingredient1.Factor} implemented!");
                Console.WriteLine(" ");
                ingredient1.scaleQuantities();
                menu(numIngredients, numOfSteps, ingredient1, steps1);
                break;
            case 3:
                Console.WriteLine(" ");
                if (ingredient1.Factor != 0.5 && ingredient1.Factor != 2 && ingredient1.Factor != 3)
                {
                    Console.WriteLine("The quantities have not been changed yet, or the factor is not valid");
                    Console.WriteLine(" ");
                    menu(numIngredients, numOfSteps, ingredient1, steps1);
                    break;
                }
                if (ingredient1.Factor == 0.5 || ingredient1.Factor == 2 || ingredient1.Factor == 3)
                {
                    ingredient.resetQuantities();
                    Console.WriteLine("Quantities have been reset!");
                    Console.WriteLine(" ");
                }
                menu(numIngredients, numOfSteps, ingredient1, steps1);
                break;
            case 4:
                Console.WriteLine(" ");
                if (ingredient.ingredients[0].Name == null) { Console.WriteLine("Recipe book is already empty."); }
                else
                {
                    Console.WriteLine("Recipe book cleared!");
                }
                ingredient.clearIngredients();
                steps.clearSteps();
               
                menu(numIngredients, numOfSteps, ingredient1, steps1);
                break;
            case 5:
                numIngredients = 0;
                numOfSteps = 0;
                Console.WriteLine(" ");
                if (ingredient1.ingredients[0].Name != null)
                {
                    Console.WriteLine("The recipe book is not empty, please empty it first to be able to enter a new recipe");
                    
                    menu(numIngredients, numOfSteps, ingredient1, steps1);
                }
                newRecipe();
                break;

            case 6:
                Console.WriteLine(" ");
                Console.WriteLine("Thank you for using Recipe Book App!");
                break;

        }
    }
}
  
