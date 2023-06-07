using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeAppPart2
{
    public class Step
    {
        //Property for each step
        public string RecipeStep { get; set; }
       
        //Empty constructor for step class
        public Step() { }

        //Step constructor with parameter with properties
        public Step (string recipeStep)
        {
            RecipeStep = recipeStep;
           
        }
         
        
    }
}
