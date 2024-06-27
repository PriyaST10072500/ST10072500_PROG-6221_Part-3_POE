﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10072500_PROG_6221_Part_3_POE
{

    public class Ingredient
    {
        //Gets and Sets the IngredientName
        public string IngredientName { get; set; }

        //Gets and Sets the IngredientQuantity
        public string IngredientQuantity { get; set; }

        //Gets and Sets the IngredientUnit
        public string IngredientUnit { get; set; }

        //Gets and Sets the IngredientCalorieCount
        public string IngredientCalorieCount { get; set; }

        //Gets and Sets the IngredientFoodGroup
        public string IngredientFoodGroup { get; set; }
    }

    public class Steps
    {
        //Gets and Sets the RecipeDescription
        public string RecipeSteps { get; set; }

    }

    public class Recipe
    {
        //Gets and Sets the RecipeName
        public string RecipeName { get; set; }

        //Gets and Sets the Ingredient
        public ObservableCollection<Ingredient> Ingredients { get; set; }

        //Gets and Sets the Steps
        public ObservableCollection<Steps> Steps { get; set; }

        //Gets and Sets the Scale
        public bool IsScaled { get; set; }

        public Recipe()
        {
            Ingredients = new ObservableCollection<Ingredient>();
            Steps = new ObservableCollection<Steps>();
        }


        public bool MatchesFilter(string FilteringredientName, string FilterfoodGroup, double FiltermaxCalories)
        {
            // Check recipe for specific ingredient name
            if (!string.IsNullOrEmpty(FilteringredientName))
            {
                bool containsIngredient = Ingredients.Any(i => i.IngredientName.Equals(FilteringredientName, StringComparison.OrdinalIgnoreCase));
                if (!containsIngredient)
                    return false;
            }

            // Check recipe for a specific food group
            if (!string.IsNullOrEmpty(FilterfoodGroup))
            {
                bool belongsToFoodGroup = Ingredients.Any(i => i.IngredientFoodGroup.Equals(FilterfoodGroup, StringComparison.OrdinalIgnoreCase));
                if (!belongsToFoodGroup)
                    return false;
            }

            // Check total calories of recipe are within a limit
            if (FiltermaxCalories > 0)
            {
                double totalCalories = Ingredients.Sum(i =>
                {
                    double.TryParse(i.IngredientCalorieCount, out double calorieCount);
                    return calorieCount;
                });

                if (totalCalories > FiltermaxCalories)
                    return false;
            }

            return true;
        }


    }

}

