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
        // Complete the maxSubsetSum function below.
        static int maxSubsetSum(int[] arr)
        {

            Console.WriteLine("STARTING");

            var result = maxSubsetSumRecursive(arr, 0, new List<int>());

            Console.WriteLine("RESULT: " + result);

            if (result < 0)
                return 0;

            return result;
        }

        static int maxSubsetSumRecursive(int[] arr, int index, List<int> selected)
        {

            // Exit condition (The index has reached the end)
            if (index >= arr.Length || arr.Length < 1)
                return 0;

            if (selected == null)
                selected = new List<int>();

            // Choose the current number, index + 2
            var choice1 = new List<int>(selected);
            choice1.Add(arr[index]);

            var choice1sum = 0;
            // Only choose the number if it's positive.  But I'd still 
            if (arr[index] > 0)
                choice1sum = arr[index] + maxSubsetSumRecursive(arr, index + 2, choice1);

            // Don't choose the next number, index + 1
            var choice2sum = maxSubsetSumRecursive(arr, index + 1, selected);
            Console.WriteLine(" ");
            Console.WriteLine("Set: ");
            for (int i = 0; i < choice1.Count; i++)
            {
                Console.WriteLine("   Num: " + choice1[i]);
            }

            Console.WriteLine("Sums: ");
            Console.WriteLine(choice1sum);
            Console.WriteLine(choice2sum);
            Console.WriteLine(" ");

            if (choice1sum > choice2sum)
                return choice1sum;

            // Get the higher sum of both arrays
            return choice2sum;
        }


        static void Main(string[] args)
        {
            Solution run = new Solution();
            int[] arr = new int[] { -2, 1, 3, -4, 5 };

            Console.WriteLine(maxSubsetSum(arr));
            
        }
    }
}
