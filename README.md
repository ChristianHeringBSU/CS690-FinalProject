# CS690-FinalProject
This Repository Holds The Source Code For My Final Project For CS 690: Software Engineering

# Project Structure

  -The project is broken up into a few main components, each holds different elements of the application.

  - ## Program.cs
    - This file calls the MainMenu() function in our Menu class
  - ## Menu.cs
    - This is the file that holds the menu system for our application. It also does some input validation before passing it to the business logic layer.
  - ## Storage.cs
    - This file handles the storage/data layer of our application. All data is written to and read from JSON files.
  - ## *.cs
    - Grocery.cs, Ingredient.cs, Inventory.cs, and Recipe.cs all handle business logic for their respective elements.
    - ### Grocery.cs
      - This file handles the grocery list
    - ### Ingredient.cs
      - This file handles ingredient substitution logic
    - ### Inventory.cs
      - This file manages the ingredient inventory in Emma's pantry/kitchen
    - ### Recipe.cs
      - This file handles recipe management
