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

        public int solveKnapsack(int[] profits, int[] weights, int capacity)
        {
            // TODO: Write your code here
            return -1;
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
