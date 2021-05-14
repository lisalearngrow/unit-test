using System;

namespace TestService
{

    class Solution
    {
        // Complete the countSwaps function below.
        public static void countSwaps(int[] a)
        {
            var swapsService = new SwapsService();
            swapsService.countTheSwaps(a);
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));
            countSwaps(a);
        }
    }

    public class SwapInfo
    {
        public int Count { get; set; }
        public int StartNum { get; set; }
        public int EndNum { get; set; }

        public SwapInfo()
        {
            this.Count = -1;
            this.StartNum = -1;
            this.EndNum = -1;
        }

        public SwapInfo(int count, int startNum, int endNum)
        {
            this.Count = count;
            this.StartNum = startNum;
            this.EndNum = endNum;
        }

        public override bool Equals(object obj)
        {
            return obj is SwapInfo result &&
                   Count == result.Count &&
                   StartNum == result.StartNum &&
                   EndNum == result.EndNum;
        }

    }

    public class SwapsService
    {

        public SwapInfo countTheSwaps(int[] a)
        {
            var result = new SwapInfo();

            if (a == null || a.Length < 1)
            {
                Console.WriteLine("Array is empty or null");
                return result;
            }

            // This is a valid case, so set to 0 swaps
            result.Count = 0;

            for (int i = 0; i < a.Length; i++)
            {

                for (int j = 0; j < a.Length - 1; j++)
                {
                    // Swap adjacent elements if they are in decreasing order
                    if (a[j] > a[j + 1])
                    {

                        // swap the values
                        int tempA = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = tempA;
                        result.Count++;
                    }
                }
            }

            result.StartNum = a[0];
            result.EndNum = a[a.Length - 1];

            Console.WriteLine(String.Format("Array is sorted in {0} swaps.", result.Count));
            Console.WriteLine(String.Format("First Element: {0}", a[0]));
            Console.WriteLine(String.Format("Last Element: {0}", a[a.Length - 1]));

            return result;
        }
    }
}
