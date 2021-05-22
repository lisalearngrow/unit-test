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

class Result
{

    /*
     * Complete the 'commonChild' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING s1
     *  2. STRING s2
     */

    public static int commonChild(string s1, string s2)
    {
        var resultCount = 0;

        Console.WriteLine("length of string 1: " + s1.Length);
        Console.WriteLine("length of string 2: " + s2.Length);

        // Store the unique letters of the first string
        var string1Occurences = new Dictionary<char, int>();
        foreach (char letter in s1)
        {
            if (!string1Occurences.ContainsKey(letter))
            {
                string1Occurences.Add(letter, 1);
            }
            else
            {
                string1Occurences[letter] = string1Occurences[letter] + 1;
            }
        }

        var stringTwoOccurences = new Dictionary<char, int>();
        foreach (char letter in s2)
        {
            if (!stringTwoOccurences.ContainsKey(letter))
            {
                stringTwoOccurences.Add(letter, 1);
            }
            else
            {
                stringTwoOccurences[letter] = stringTwoOccurences[letter] + 1;
            }
        }

        // Remove letters not in common from string 1 & 2
        var newS1 = "";
        var newS2 = "";

        foreach(char c in s1)
        {
            if (stringTwoOccurences.ContainsKey(c))
                newS1 = newS1 + c;
            else
            {
                Console.WriteLine("REJECTED: " + c);
            }
        }

        foreach (char c in s2)
        {
            if (string1Occurences.ContainsKey(c))
                newS2 = newS2 + c;
            else
            {
                Console.WriteLine("REJECTED: " + c);
            }
        }

        Console.WriteLine("length of string 1 occurences: " + newS1.Length);
        Console.WriteLine("length of string 2: " + newS2.Length);

        var numLettersLookedAt = 0;

        // This string will get smaller and smaller as we look for letters
        string currentS1 = newS1;

        // This tracks where we are looking at string 1 so we don't start over.
        int trackingIndex = 0;

        // iterate over the second string
        for (int i = 0; i < newS2.Length; i++) {
            var currentLetter = newS2[i];
            numLettersLookedAt++;

            Console.WriteLine("INDEX: " + trackingIndex);

            Console.WriteLine("looking at: " + currentLetter);

            // check to see if the letter was present in the other string.  This doesn't mean it's still available
            if (!string1Occurences.ContainsKey(currentLetter))
                continue;

            // Then check to see if you can find the letter in string 1.  If so, count it
            for(int currentIndex = trackingIndex; currentIndex < currentS1.Length; currentIndex++)
            {
                var l = currentS1[currentIndex];

                Console.WriteLine("Comparing: " + l + " " + currentLetter);

                // Found the letter
                if (l == currentLetter)
                {
                    Console.WriteLine("letter found: " + l);

                    // Increased the count
                    resultCount++;

                    trackingIndex = currentIndex + 1;
                    break;
                }
            }

        }

        return resultCount;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s1 = Console.ReadLine();

        string s2 = Console.ReadLine();

        int result = Result.commonChild(s1, s2);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
