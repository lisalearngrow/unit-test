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
    class Result
    {

        /*
         * Complete the 'checkMagazine' function below.
         *
         * The function accepts following parameters:
         *  1. STRING_ARRAY magazine
         *  2. STRING_ARRAY note
         */

        public static void checkMagazine(List<string> magazine, List<string> note)
        {
            var magWords = countWords(magazine);
            var noteWords = countWords(note);

            foreach (var word in noteWords.Keys)
            {
                //Console.WriteLine("Word: " + word + " Count: " + noteWords[word]);
                //Console.WriteLine("magWord: " + word + " Count: " + magWords[word]);

                if (!magWords.ContainsKey(word) || noteWords[word] > magWords[word])
                {
                    Console.WriteLine("No");
                    return;
                }
                
            }
            Console.WriteLine("Yes");
        }

        private static Dictionary<string, int> countWords(List<string> words)
        {
            var result = new Dictionary<string, int>(words.Count);
            foreach (var word in words)
            {
                //Console.WriteLine("Current word: " + word);
                if (!result.ContainsKey(word))
                {
                    //Console.WriteLine("Added word: " + word);
                    result.Add(word, 1);
                }
                else
                {
                    //Console.WriteLine("Incremented word: " + word);
                    result[word] = result[word] + 1;
                }
            }

            return result;
        }

    }

    public class Solution
    {
        public static void Main()
        {

            string magazineWords = "two times three is not four";
            string noteWords = "two times two is four";

            List<string> magazine = magazineWords.TrimEnd().Split(' ').ToList();

            List<string> note = noteWords.TrimEnd().Split(' ').ToList();

            Result.checkMagazine(magazine, note);
        }
    }

}
