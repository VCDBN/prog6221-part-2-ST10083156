using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_App
{
    public class Steps
    {
       public string Step { get; set; }

       //array to hold steps for recipe
       public List <string> listOfSteps;
        public Steps() { listOfSteps = new List <string>(); }
       
        public Steps(string step) 
        {
            step = Step;
            listOfSteps = new List<string>();
        }

        //method to add step to array
        public void addStep(int i, string step)
        {
            listOfSteps[i] = step;
        }

        //method to clear array of steps
        public void clearSteps()
        {
            listOfSteps.Clear();
        }

        //method to return specific step
        public string displaySteps(int index)
        {
            return listOfSteps[index];
        }
    }
}
