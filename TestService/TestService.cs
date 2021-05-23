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
            int?[,] profitCache = new int?[capacity + 1, profits.Length + 1];
            return recursiveSolveKnapsack(profits, weights, capacity, 0, profitCache);
        }

        // capacity decreases as we add weight
        // OPTIMIZATION: I can cache the results using the capacity & index
        public int recursiveSolveKnapsack(int[] profits, int[] weights, int capacity, int index, int?[,] profitCache)
        {
            // check to see if we are over capacity or out of the index range.  
            // This means there was no fruit that would fit in the bag
            if (capacity <= 0 || index >= profits.Length)
                return 0;

            // If this profit is in the cache, simply return it
            if (profitCache[capacity, index] != null)
                return (int)profitCache[capacity, index];

            //Console.WriteLine("Capacity: " + capacity + " Index: " + index + " Weight: " + weights[index] + " Profit: " + profits[index]);

            int profit1 = 0;

            // Is there room in the stack for the next item?
            if (weights[index] <= capacity)
            {
                //Console.WriteLine("Added fruit index: " + index); 
                // Get the profit if we grab the first item and then recursively get the highest profit 
                profit1 = profits[index] + recursiveSolveKnapsack(profits, weights, capacity - weights[index], index + 1, profitCache);
            }
            int profit2 = recursiveSolveKnapsack(profits, weights, capacity, index + 1, profitCache);

            //Console.WriteLine("profit1: " + profit1 + " profit2: " + profit2);

            int maxProfit = Math.Max(profit1, profit2);

            // Store the profit we've found
            profitCache[capacity, index] = maxProfit;

            return maxProfit;
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
