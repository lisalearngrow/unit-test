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
        public int findLCSLength(string s1, string s2)
        {
            // TODO: Optimize by going over the short string
            Console.WriteLine("Starting\n\n\n");
            Console.WriteLine(" s1: " + s1 + " s2: " + s2);
            var longestStr = getLCSRecursive(s1, s2, 0, "");
            return longestStr.Length;
        }

        
        public string getLCSRecursive(String s1, String s2, int index, string currentString)
        {
            if (s1 == null || s1 == "" || s2 == "" || s2 == null || index > (s1.Length -1) )
                return "";

            Console.WriteLine(" index: " + index + " currentString: " + currentString);

            // Don't select the letter, skip over it
            var choice2 = getLCSRecursive(s1, s2, index + 1, currentString);

            // Select the letter
            var choice1 = "";
            var potentialstr = currentString + s1[index];

            // Add the letter we're looking at IF it meets the constraint
            if (s2.Contains(potentialstr))
            {
                Console.WriteLine("Added char: " + s1[index]);
                // Add the letter + the next recursive values
                choice1 = s1[index] + getLCSRecursive(s1, s2, index + 1, potentialstr);
            }

            if (choice1.Length > choice2.Length)
            {
                Console.WriteLine("Returned Add string: " + choice1);
                return choice1;
            }

            Console.WriteLine("Returned Skip string: " + choice2);
            return choice2;
        }

        static void Main(string[] args)
        {
            Solution lcs = new Solution();
            Console.WriteLine(lcs.findLCSLength("abdca", "cbda"));
            Console.WriteLine(lcs.findLCSLength("passport", "ppsspt"));
        }
    }
}
