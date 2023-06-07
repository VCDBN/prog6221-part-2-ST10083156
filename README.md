##Recipe App##

This app was created so that users may be able to capture as many recipes as they would like, as well as the steps and ingredients it takes to make those recipes. It allows you to scale the quantities of the ingredients and capture the amount of calories each recipe has in it. It gives a warning when the calories in the recipe exceed 300 calories. Users can also view specific recipes or view all recipe names in alphabetical order.

##App usage##

The application is coded in C# and runs on the visual studio 2002 IDE. Once the download of Visual Studio 2022 is complete, you will need to open the project in the IDE.
This can be done by opening Visual Studio and selecting "Open existing project" and thereafter selecting the project name RecipeAppPart2.
Once open, the IDE will show you all the backend code for the program. All you are required to do is to location the green arrow at the top of the IDE that is located next to the name of the project. Once in the app just follow the prompts and use the application. Once completed you can end the application using the in-app prompts and close Visual Studio.

##Code Functionality##
The project makes use of 4 classes, a Recipe class, an Ingredient class, a Step class and a main Program class. Each class aside from the program class has various variables that represent properties for each object created for the classes. The main Program class holds the Lists for each class and it uses user input to create each list and manipulate the data already entered into the list as well as add more data to it. The menu method calls on various methods to complete the tasks that the user chooses and it loops it until the user selects the option to end the application. 

##Fixes from part 1##
From part 1 the code has used more input validation to check whether the user input is valid or not
