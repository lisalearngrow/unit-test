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

class Solution
{
    // This function requires that the first entry exists. O(1)  
    static List<List<long>> getNextEntry(List<long> triplet, Dictionary<long, int> numberCounts, long r)
    {

        //Console.WriteLine("There");

        var result = new List<List<long>>();

        // Look at the last entry and see how many next entries we can create
        var lastEntry = triplet[triplet.Count - 1];
        var nextEntry = lastEntry * r;
        var numOccurences = 0;

        if (numberCounts.ContainsKey(nextEntry))
        {
            numOccurences = numberCounts[nextEntry];
        }
        else
            return result;

        triplet.Add(nextEntry);

        for (int i = 0; i < numOccurences; i++)
        {
            // Yes, there will be duplicates, that's the point
            result.Add(new List<long>(triplet));
        }

        //Console.WriteLine("Got something");

        //foreach(var t in result)
        //{
        //    foreach (var item in t)
        //    {
        //        Console.WriteLine("Item: " + item);
        //    }
        //}

        return result;
    }

    // Complete the countTriplets function below.
    /* 
    Go through the list of numbers and remove anything that isn't divisible by 3.  
    Create result lists List<List<int>>.  This will store the valid touples 
     
     */
    static long countTriplets(List<long> arr, long r)
    {
        int tripletCount = 0;

        // This tracks the number of occurences so I can find the next entry
        var numberCounts = new Dictionary<long, int>(arr.Count);

        // This tracks the numbers themselves so I can start the tuples


        // O(n)
        // The input only gives sorted info that is divisible by r.  Add it to the dictionary and track how many there are.
        foreach(var entry in arr)
        {

            if (!numberCounts.ContainsKey(entry))
                numberCounts[entry] = 1;
            else
                numberCounts[entry] = numberCounts[entry] + 1;
        }

        // To support special case if r=1.  1 will be the only valid number.  Need to remove 1 from the numberCounts
        if (numberCounts.ContainsKey(1))
        {
            numberCounts[1] = numberCounts[1] - 1;
        }

        // Stores what we are working on
        var tripletLists = new Stack<List<long>>();

        // Create tuples 
        foreach(var entry in arr)
        {
            //Console.WriteLine("Entry: " + entry);

            var tuple = new List<long>(3);
            tuple.Add(entry);
            tripletLists.Push(tuple);
        }

        while (tripletLists.Count > 0)
        {

            var triplet = tripletLists.Pop();
            var possibleTriplets = getNextEntry(triplet, numberCounts, r);

            foreach(var t in possibleTriplets)
            {
                //Console.WriteLine("Here");

                // If we found a valid triplet, then count it.  Otherwise, add it onto the stack to find the next numbers.
                if (t.Count == 3)
                    tripletCount++;
                else
                    tripletLists.Push(t);
            }

        }
        return tripletCount;

    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nr = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(nr[0]);

        long r = Convert.ToInt64(nr[1]);

        List<long> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

        long ans = countTriplets(arr, r);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }
}
