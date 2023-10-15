using System;
using System.Collections.Generic;

//we need to create namespace currency library and then we called public function and create splitamount function with if conditions...

namespace CurrencyLibrary
{
    public static class CurrencyHelper
    {
        public static decimal SplitAmount(decimal amount, int peopleCount)
        {
            if (peopleCount <= 0) throw new ArgumentException("People count must be greater than zero.");
            return amount / peopleCount;
        }

        //one more time we need to called public dictionary and calculatetip function then dictionary function..

        public static Dictionary<string, decimal> CalculateTips(Dictionary<string, decimal> mealCosts, float tipPercentage)
        {
            Dictionary<string, decimal> tips = new Dictionary<string, decimal>();

            decimal totalCost = 0;
            foreach (var cost in mealCosts.Values)
                totalCost += cost;

            foreach (var entry in mealCosts)
            {
                decimal tip = (entry.Value / totalCost) * (totalCost * tipPercentage / 100);
                tips[entry.Key] = Math.Round(tip, 2);
            }

            return tips;
        }

        //public static function called with tip per person function and then we called if condition.
        public static decimal TipPerPerson(decimal totalAmount, int patronCount, float tipPercentage)
        {
            if (patronCount <= 0) throw new ArgumentException("Patron count must be greater than zero.");
            return (totalAmount * tipPercentage / 100) / patronCount;
        }
    }
}
