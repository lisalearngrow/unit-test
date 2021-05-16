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
        private Dictionary<int, int> _data;
        Dictionary<int, HashSet<int>> _occurences;

        public Solution()
        {
            // Key: number (data), Value: number of occurences
            _data = new Dictionary<int, int>();

            // Key: Num of occurences, Value: List of numbers that happened that many times
            // _data and occurences must be kept up to date together.
            _occurences = new Dictionary<int, HashSet<int>>();

        }

        void updateOccurences(int entry, int oldOccurence, int newOccurence )
        {
            // If there were no occurences of the number before and there's
            // less now, then this was a delete. No need to delete something empty.
            if (newOccurence < 0)
                return;

            // Remove the entry from the occurence list. It should always exist.
            if (_occurences.ContainsKey(oldOccurence))
            {
                _occurences[oldOccurence].Remove(entry);
            }

            // Create the list of entries that happen "newOccurence" times
            if(!_occurences.ContainsKey(newOccurence))
            {
                _occurences[newOccurence] = new HashSet<int>();
            }

            // Add the current entry to the list of entries that happend "newOccurence" times
            _occurences[newOccurence].Add(entry);
        }

        void addEntry(int entry)
        {
            Console.WriteLine("Add:" + entry);

            if (_data.ContainsKey(entry))
            {
                updateOccurences(entry, _data[entry], _data[entry] + 1);
                _data[entry] = _data[entry] + 1;

            }
            else
            {
                // Create an entry if it doesn't exist
                updateOccurences(entry, 0, 1);
                _data.Add(entry, 1);
                
            }
        }

        void deleteEntry(int entry)
        {
            Console.WriteLine("Delete:" + entry);

            if (_data.ContainsKey(entry) && _data[entry] > 0)
            {
                updateOccurences(entry, _data[entry], _data[entry] - 1);
                _data[entry] = _data[entry] - 1;               
            }
        }

        // print 1 if any integer is present with x occurences
        int queryEntry(int occureces)
        {
            Console.WriteLine("Query:" + occureces);

            if (_occurences.ContainsKey(occureces) && _occurences[occureces].Count > 0)
                return 1;
            return 0;
        }

        // Complete the freqQuery function below. Return the _result
        static List<int> freqQuery(List<List<int>> queries)
        {
            var model = new Solution();
            var result = new List<int>();

            for (int i = 0; i < queries.Count; i++)
            {
                int operation = queries[i][0];
                int num = queries[i][1];

                Console.WriteLine("op:" + operation);
                Console.WriteLine("num:" + num);

                switch (operation)
                {
                    case 1:
                        model.addEntry(num);
                        break;
                    case 2:
                        model.deleteEntry(num);
                        break;
                    case 3:
                        result.Add(model.queryEntry(num));
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> queries = new List<List<int>>();

            for (int i = 0; i < q; i++)
            {
                queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
            }

            List<int> ans = freqQuery(queries);

            textWriter.WriteLine(String.Join("\n", ans));

            textWriter.Flush();
            textWriter.Close();
        }
    }

}
