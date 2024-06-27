using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10072500_PROG_6221_Part_3_POE
{
    //Delegate
    public delegate void CaloriesExceededEventHandler(object sender, EventArgs e);

    public class CaloriesAmount
    {
        //Calorie Variables
        private double calorieLimit;
        private double calorieTotalAmt;

        public event CaloriesExceededEventHandler CaloriesExceeded;

        private CaloriesAmount() { }

        public CaloriesAmount(double calorieLimit, double calorieTotalAmt)
        {
            this.calorieLimit = calorieLimit;
            this.calorieTotalAmt = calorieTotalAmt;
        }

        public double CalorieLimit => calorieLimit;
        public double CalorieTotalAmount => calorieTotalAmt;

        public void Credit(double amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            calorieTotalAmt += amount;
            CheckCalories();
        }

        protected virtual void OnCaloriesExceeded(EventArgs e)
        {
            CaloriesExceeded?.Invoke(this, e);
        }

        //Check if calories are greater than 300
        private void CheckCalories()
        {
            if (calorieTotalAmt > 300)
                OnCaloriesExceeded(EventArgs.Empty);
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

