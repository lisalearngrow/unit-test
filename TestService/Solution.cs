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

    static bool isSpecial(string current)
    {
        Console.WriteLine("Testing: " + current);
        if (current.Count() == 1)
            return true;

        if (current.Count() % 2 != 0)
        {
            // Middle has -1 due to zero based index
            int middle = (int)Math.Truncate((decimal)current.Length / 2);

            // Remove the middle letter and check the rest. 
            current = current.Remove(middle, 1);
            Console.WriteLine("Modified: " + current);
        }

        // Check to see if all the letters are the same
        var tempLetter = current[0];
        bool isSpecial = true;
        for (int j = 0; j < current.Length; j++)
        {
            if (tempLetter != current[j])
                isSpecial = false;
        }
        return isSpecial;
    }
    // Complete the substrCount function below.
    /*
        Brute force is to iterate over the string for each count of letters up to the size of the string.  1 letter substrings, 2 letter, 3 letter and throw them all in a list.
        
        You don't have to iterate over the whole string more than once, you could look at the next n letters for the current index.  For example aasbcssass,
        we could start at index 1, add that letter, then get that letter and the next one, then the additional letter.  This would make it easier to stop extra work.
    */

    static long substrCount(int n, string s)
    {
        /* Brute force first */
        List<string> specialStrings = new List<string>();

        for (int len = 1; len <= s.Length; len++)
        {
            // iterate over the whole string
            string current = "";

            for (int i = 0; (i + len - 1) < s.Length; i++)
            {
                // Count the current string if it meets the criteria
                current = s.Substring(i, len);
                Console.WriteLine("Current: " + current);
                if (isSpecial(current))
                {
                    specialStrings.Add(current);
                }
            }
        }
        // What did I get?
        Console.WriteLine("Final items:");
        foreach (var item in specialStrings)
        {
            Console.WriteLine(item);
        }

        return specialStrings.Count;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        string s = Console.ReadLine();

        long result = substrCount(n, s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
