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
        private Dictionary<string, int> _cache;

        // Complete the maxSubsetSum function below.
        static int maxSubsetSum(int[] arr)
        {
            //Console.WriteLine("STARTING");

            Solution run = new Solution();
            run._cache = new Dictionary<string, int>();
            var result = run.maxSubsetSumRecursive(arr, 0);

            //Console.WriteLine("RESULT: " + result);

            if (result < 0)
                return 0;

            return result;
        }

        int maxSubsetSumRecursive(int[] arr, int index)
        {

            // Exit condition (The index has reached the end)
            if (index >= arr.Length)
                return 0;

            // Create the hash
            string hash = index.ToString();

            //Console.WriteLine("Hash: " + hash);

            // Only grab from cache if there was anything selected
            if (this._cache.ContainsKey(hash))
            {
                //Console.WriteLine("Got cache hit! ");
                return _cache[hash];
            }

            // Choose the current number, index + 2
            var choice1Sum = 0;
            // Only choose the number if it's positive.  
            if (arr[index] > 0)
            {
                hash += arr[index] + "|";
                choice1Sum = arr[index] + maxSubsetSumRecursive(arr, index + 2);
            }

            //Console.WriteLine(" ");
            //Console.WriteLine("Set: ");
            

            // Don't choose the next number, index + 1
            var choice2Sum = maxSubsetSumRecursive(arr, index + 1);
            
            //Console.WriteLine("Sums: ");
            //Console.WriteLine(choice1Sum);
            //Console.WriteLine(choice2Sum);
            //Console.WriteLine(" ");

            if (choice1Sum > choice2Sum)
                _cache[hash] = choice1Sum;
            else
                _cache[hash] = choice2Sum;

            // Get the higher sum of both arrays
            return this._cache[hash];
        }

        static void Main(string[] args)
        {
            Solution run = new Solution();
            int[] arr = new int[] { -2, 1, 3, -4, 5 };

            Console.WriteLine(maxSubsetSum(arr));
            
        }
    }
}
