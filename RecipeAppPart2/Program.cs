using RecipeAppPart2;
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Xml.Linq;

public class Program
{
    //Variables all used ace placeholders to create various objects to be added to lists
    public Program() { }
    List<Ingredient> Ingredients;
    List<Step> Steps;
    List<Recipe> Recipes;
    public static double factor;
    public static string ingredientName;
    public static string recipeName = null;
    public static double quantity;
    public static string unitOfMeasurement;
    public static double calories;
    public static string foodGroup;
    public static string step;
    public static int numRecipes;
    public static int numSteps;
    public static int numIngredients;
    public static double TotalCalories;

    //Delegate declared and instantiated for calory calculator
    public delegate void CaloryCheck(double calories);
    public static CaloryCheck cCheck = new CaloryCheck(CaloryChecker);

    //main method used to start the application
    public static void Main(string[] args)
    {
        Program program = new Program();
        NewRecipe();
        
    }

    //method used to create ingredients and steps lists to be added to each recipe and have each recipe added to the recipe list
    static void NewRecipe()
    {
        TotalCalories = 0;
        List<Recipe> Recipes = new List<Recipe>();
        Console.WriteLine("******WELCOME TO THE RECIPE APP******");
        Console.WriteLine(" ");
        Console.WriteLine("*********RECIPES*********");
        Console.WriteLine("How many recipes would you like to add?");

        while (numRecipes < 1)
        {
            try
            {
                numRecipes = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            if (numRecipes < 1)
            {

                Console.WriteLine("Please enter a valid and positive number of recipes to add");
            }

        }
        List<Ingredient> Ingredients = new List<Ingredient>();
        for (int i = 0; i < numRecipes; i++)
        {
            TotalCalories = 0;

            Console.WriteLine($"Enter the name of recipe number {i + 1}");
            recipeName = Console.ReadLine();
            Console.WriteLine($"How many ingredients does {recipeName} have?");
            while (numIngredients < 1)
            {
                try
                {
                    numIngredients = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
                if (numIngredients < 1)
                {

                    Console.WriteLine("Please enter a valid and positive number of ingredients to add");
                }

            }
            for (int a = 0; a < numIngredients; a++)
            {
                quantity = 0;
                calories = 0;
                Console.WriteLine("*********INGREDIENTS*********");
                Console.WriteLine($"Please enter the name of ingredient number {a + 1}");
                ingredientName = Console.ReadLine();
                Console.WriteLine($"Please enter the unit of measurement of {ingredientName}");
                unitOfMeasurement = Console.ReadLine();
                Console.WriteLine($"Please enter the number of {unitOfMeasurement} of {ingredientName} required");
                while (quantity < 1)
                {
                    try
                    {
                        quantity = Convert.ToDouble(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);

                    }
                    if (quantity < 1)
                    {

                        Console.WriteLine($"Please enter a valid and positive number {unitOfMeasurement}");
                    }

                }
                Console.WriteLine($"Please enter what food group {ingredientName} belongs to");
                foodGroup = Console.ReadLine();
                Console.WriteLine($"Please enter the amount of calories this will all contain");
                while (calories < 1)
                {
                    try
                    {
                        calories = Convert.ToDouble(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);

                    }
                    if (calories < 1)
                    {

                        Console.WriteLine("Please enter a valid and positive number of calories");
                    }

                }
                CaloryCalc(calories);
                cCheck(TotalCalories);
                Ingredient ingredient = new Ingredient(ingredientName, quantity, unitOfMeasurement, foodGroup, calories);
                Ingredients.Add(ingredient);


            }
            Console.WriteLine("*********STEPS*********");
            Console.WriteLine($"Please enter the number of steps required to make {recipeName}");
            while (numSteps < 1)
            {
                try
                {
                    numSteps = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
                if (numSteps < 1)
                {

                    Console.WriteLine("Please enter a valid and positive number of steps");
                }

            }
            List<Step> Steps = new List<Step>();
            for (int a = 0; a < numSteps; a++)
            {
                Console.WriteLine($"Please enter step number {a + 1}");
                step = Console.ReadLine();
                Step step1 = new Step(step);
                Steps.Add(step1);

            }

            Recipe recipe = new Recipe(recipeName, Ingredients, Steps, TotalCalories);
            Recipes.Add(recipe);
            Program program = new Program();
            program.Menu(Recipes);

        }
    }

    //method used to continuously add the calories of each recipe
    public static double CaloryCalc(double caloriesAdded)
    {
        TotalCalories += caloriesAdded;
        return TotalCalories;
    }

    //method used to remove a recipe from the recipe list
    public bool removeRecipe(string name, List<Recipe> Recipes)
    {
        
        
        foreach (Recipe recipe1 in Recipes)
        {
            if (recipe1.Name == name)
            {
                bool conatins = true;
                Recipes.RemoveAll(x => x.Name == name);
                Console.WriteLine("Recipe removed");
                return true;
            }
        }
        Console.WriteLine("No recipe was found with that name");
         return false; 
    }

    //method used to notify the user when a recipe's calories exceed 300
    public static void CaloryChecker(double caloryTotal)
    {
        if (caloryTotal > 300)
        {
            Console.WriteLine("Warning! Calory total for this recipe has exceeded 300 calories");
        }
    }

    //method used to clear the list of recipes of all the recipes
    public void clearRecipes(List<Recipe> Recipes) { Recipes.Clear(); }

    //method used to remove an ingredient from a recipe
    public void removeIngredient(List<Recipe> Recipes,string recipeName, string ingredientName)
    {

        foreach (Recipe recipe in Recipes)
        {
            if (recipe.Name == recipeName)
            {
                List<Ingredient> Ingredients = recipe.Ingredients;
                foreach (Ingredient ingredient1 in Ingredients)
                {
                    if (ingredient1.Name == ingredientName)
                    {
                        Ingredients.Remove(ingredient1);
                        Console.WriteLine("Ingredient removed;");

                    }

                }
            }
        }
    }

    //method used to display the names of all the recipes in alphabetical order
    public void DisplayRecipes(List<Recipe> Recipes)
    {
        if (Recipes.Count == 0)
        {
            Console.WriteLine("There are not any recipes in the list");
            return;
        }
        else if (Recipes.Count == 1)
        {
            foreach (Recipe recipe in Recipes)
            {
                Console.WriteLine($"Recipe name: {recipe.Name}");

            }
        }
        else {
            Recipes.Sort((r1, r2) => string.Compare(r1.Name, r2.Name));
            foreach (Recipe recipe in Recipes)
            {
                Console.WriteLine($"Recipe name: {recipe.Name}");

            }
        }
        
    }

    //method used to display all details of one specific recipe
    public void DisplayRecipe(string Name, List<Recipe> Recipes)
    {
        
        foreach (Recipe recipe in Recipes)
        {
            if (recipe.Name == Name)
            {
                Console.WriteLine($"Recipe name: {recipe.Name.ToUpper()}");
                Console.WriteLine($"Recipe ingredients: ");
                List<Ingredient> Ingredients = recipe.Ingredients;
                foreach (Ingredient ingredient in Ingredients)
                {
                    Console.WriteLine($"- {ingredient.Name.ToUpper()}");
                }
                List<Step> Steps = recipe.Steps;
                foreach (Step step in Steps)
                {
                    Console.WriteLine($"- {step.ToString()}");
                }
            }
        }
    }

   // Method used to scale the quantities of a specific recipe
    public void ScaleQuantities(string Name, double Factor, List<Recipe> Recipes)
    {
        string name;
        Factor = factor;
        foreach (Recipe recipe in Recipes)
        {
            if (recipe.Name == Name)
            {
                List<Ingredient> Ingredients = recipe.Ingredients;
                foreach (Ingredient ingredient in Ingredients)
                {
                    ingredient.Quantity *= factor;
                    ingredient.Calories *= factor;
                }
                recipe.TotalCalories *= factor;
            }
        }
    }

    //method used to return the scaled recipe's quantities back to the original
    public void ReturnQuantities(string name, List<Recipe> Recipes)
    {

        foreach (Recipe recipe in Recipes)
        {
            if (recipe.Name == name)
            {
                List<Ingredient> Ingredients = recipe.Ingredients;

                foreach (Ingredient ingredient in Ingredients)
                {
                    ingredient.Quantity /= factor;
                    ingredient.Calories /= factor;
                }
                recipe.TotalCalories /= factor;
            }
        }
    }

    //Menu method to give the user options on what they want to do
    public void Menu(List<Recipe> Recipes)
    {
        List<Recipe> Recipes1 = Recipes;
        int menuOption = 0;
        Console.WriteLine("*********MENU**********");
        Console.WriteLine("1. Display all recipe names");
        Console.WriteLine("2. Display specific recipe");
        Console.WriteLine("3. Scale quantities of a recipe");
        Console.WriteLine("4. Return quantities to original");
        Console.WriteLine("5. Add new recipes");
        Console.WriteLine("6. Remove recipe");
        Console.WriteLine("7. Clear all recipes");
        Console.WriteLine("8. End recipe app");
        
        while (menuOption < 1)
        {
            try
            {
                menuOption = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

        }
        if (menuOption < 1 || menuOption > 8)
        {
            Console.WriteLine($"Please enter a valid menu option from 1-8");
            menuOption = Convert.ToInt32(Console.ReadLine());
        }
        switch (menuOption)
        {
            case 1:
                DisplayRecipes(Recipes1);
                Menu(Recipes1);
                break;
            case 2:
                Console.WriteLine("Please enter the name of the recipe you would like to view");
                string viewRecipe = Console.ReadLine();
                DisplayRecipe(viewRecipe, Recipes1);
                Menu(Recipes1);
                break;
            case 3:
                Console.WriteLine("Please enter the name of the recipe you would like to scale");
                recipeName = Console.ReadLine();
                Console.WriteLine("Please choose the factor that you would like to scale your quantities by (0.5, 2 or 3)");
                factor = Convert.ToDouble(Console.ReadLine());
                while (factor != 0.5 && factor != 2 && factor != 3)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Please enter a valid factor number between 0.5, 2 and 3");
                    factor = Convert.ToDouble(Console.ReadLine());
                }
                ScaleQuantities(recipeName, factor, Recipes1);
                Console.WriteLine($"Quantities of {recipeName} changed by a factor of {factor}");
                Menu(Recipes1);
                break;
            case 4:
                if(recipeName == null)
                {
                    Console.WriteLine("No quantities have been changed, so nothing can be reverted");
                }
                else
                {
                    ReturnQuantities(recipeName, Recipes1);
                    Console.WriteLine("Quantities returned");
                }
                Menu(Recipes1);
                break;
                case 5:
                NewRecipe();
                break;
                case 6:
                Console.WriteLine("Please enter the name of the recipe you want to remove");
                string recipeToRemove = Console.ReadLine();
                removeRecipe(recipeToRemove, Recipes1);
                Menu(Recipes1);
                break;
                case 7:
                clearRecipes(Recipes1);
                Menu(Recipes1);
                break;
            case 8:
                break;

        }
    }
} 
    

  




