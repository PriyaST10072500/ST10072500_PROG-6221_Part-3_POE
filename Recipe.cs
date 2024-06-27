using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        // Calculates the total calories
        public double TotalCalories
        {
            get
            {
                return Ingredients.Sum(i =>
                {
                    double.TryParse(i.IngredientCalorieCount, out double calorieCount);
                    return calorieCount;
                });
            }
        }


        //Method to copy of recipe
        public Recipe DeepClone()
        {
            var clone = new Recipe
            {
                RecipeName = this.RecipeName,
                IsScaled = this.IsScaled,
                Ingredients = new ObservableCollection<Ingredient>(this.Ingredients.Select(i => new Ingredient
                {
                    IngredientName = i.IngredientName,
                    IngredientQuantity = i.IngredientQuantity,
                    IngredientUnit = i.IngredientUnit,
                    IngredientCalorieCount = i.IngredientCalorieCount,
                    IngredientFoodGroup = i.IngredientFoodGroup
                })),
                Steps = new ObservableCollection<Steps>(this.Steps.Select(i => new Steps
                {
                    RecipeSteps = i.RecipeSteps
                }))
            };
            return clone;
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

//References 
//https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements
//https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/
//https://stackoverflow.com/questions/14792066/change-background-color-on-c-sharp-console-application
//https://www.webstaurantstore.com/guide/582/measurements-and-conversions-guide.html
//https://www.geeksforgeeks.org/console-clear-method-in-c-sharp/
//https://www.geeksforgeeks.org/scale-factor/
//https://stackoverflow.com/questions/52337184/c-getting-user-value-and-resetting-it
//https://stackoverflow.com/questions/13214081/declare-a-generic-collection
//https://www.geeksforgeeks.org/c-sharp-delegates/
//https://learn.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-wpf?view=vs-2022
//https://learn.microsoft.com/en-us/dotnet/desktop/wpf/overview/?view=netdesktop-8.0
//https://stackoverflow.com/questions/4279185/what-is-the-use-of-observablecollection-in-net
//https://www.c-sharpcorner.com/UploadFile/e06010/observablecollection-in-wpf/
//https://stackoverflow.com/questions/26196/filtering-collections-in-c-sharp