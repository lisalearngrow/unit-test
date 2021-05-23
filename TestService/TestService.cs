using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace TestService
{


    class Bag
    {
        // Will hold the indexes of the items
        public List<int> Values { get; set; }
        public List<int> Selected { get; set; }

        public int Profit { get; set; }
        public int Weight { get; set; }

        public Bag()
        {
            Values = new List<int>();
            Selected = new List<int>();
        }

        public Bag(Bag bag)
        {
            Values = new List<int>(bag.Values);
            Selected = new List<int>(bag.Selected);
            Profit = bag.Profit;
            Weight = bag.Weight;
        }

    }

    class Solution
    {
        /*
       for each item 'i' 
       create a new set which INCLUDES item 'i' if the total weight does not exceed the capacity, and 
       recursively process the remaining capacity and items

       create a new set WITHOUT item 'i', and recursively process the remaining items 
       return the set from the above two sets with higher profit 
       */

        public int solveKnapsack(int[] profits, int[] weights, int capacity)
        {
            //Console.WriteLine("Starting");
            // Make new set with everything available, but nothing in the bag
            Bag bag = new Bag();
            bag.Values = new List<int>();

            // Add all indexes
            for (int index = 0; index < profits.Length; index++)
            {
                Console.WriteLine("Adding values: " + index);
                bag.Values.Add(index);
            }
          
            return solveKnapsackRecursive(bag, profits, weights, capacity);
        }

        public int solveKnapsackRecursive(Bag bag, int[] profits, int[] weights, int capacity)
        {
            // Are there more things we could put in the bag? No, then return the weight
            if (bag.Values.Count <= 0)
                return bag.Profit;
            
            Bag bagA = new Bag(bag);
            Bag bagNoA = new Bag(bag);

            var profitA = bagA.Profit;

            // Pick the next value to look at
            var index = bag.Values[0];

            Console.WriteLine("Index: " + index);

            // Remove the first value from bagNoA
            bagNoA.Values.RemoveAt(0);

            // Calculate the possible new weight
            var newWeight = bagA.Weight + weights[index];

            Console.WriteLine("Weight: " + newWeight);

            // If it will fit in bag A, then add it.
            if (newWeight <= capacity)
            {
                // Add it to the bag and recalculate the weight and profit
                bagA.Selected.Add(index);
                bagA.Weight = newWeight;
                bagA.Profit = bagA.Profit + profits[index];
                Console.WriteLine("Adding item to bagA: " + index);
                Console.WriteLine("Profit in bagA: " + bagA.Profit);

                // Recursivly look for more items to put in the bag 
                profitA = solveKnapsackRecursive(bagA, profits, weights, capacity);
            }
            
            var profitNoA = solveKnapsackRecursive(bagNoA, profits, weights, capacity);

            Console.WriteLine("wieghtNoA: " + profitNoA);
            Console.WriteLine("wieghtA: " + profitA);

            if (profitA > profitNoA)
                return profitA;

            return profitNoA;
        }

        static void Main(string[] args)
        {
            Solution ks = new Solution();
            int[] profits = { 1, 6, 10, 16 };
            int[] weights = { 1, 2, 3, 5 };
            int maxProfit = ks.solveKnapsack(profits, weights, 7);
            Console.WriteLine("Total knapsack profit ---> " + maxProfit);
            maxProfit = ks.solveKnapsack(profits, weights, 6);
            Console.WriteLine("Total knapsack profit ---> " + maxProfit);
        }
    }
}
