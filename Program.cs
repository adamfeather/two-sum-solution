using System;
using System.Collections;
using System.Collections.Generic;

namespace TwoSumSolution
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = new[] { 1, 2, 3, 4, 2, 3, 2, 1, 1, 3, 4, 5, 67, 87 };

            int desiredSum = 5;

            input = RemoveDuplicates(input);

            foreach (var pair in FindPairsWithSum(input, desiredSum))
            {
                Console.WriteLine(pair);
            }
        }

        private static int[] RemoveDuplicates(int[] input)
        {
            var hashtable = new Hashtable();

            foreach (var number in input)
            {
                if (hashtable.ContainsKey(number) == false)
                {
                    hashtable.Add(number, null);
                }
            }

            var result = new int[hashtable.Count];

            int i = 0;

            foreach (var key in hashtable.Keys)
            {
                result[i] = (int)key;
                i++;
            }

            return result;
        }

        private static IEnumerable FindPairsWithSum(int[] input, int desiredSum)
        {
            var pairs = new List<(int x, int y)>();

            var previousNumbers = new Hashtable();

            foreach (var number in input)
            {
                var numberToSeek = desiredSum - number;

                if (previousNumbers.ContainsKey(numberToSeek))
                {
                    pairs.Add((numberToSeek, number));
                }
                else
                {
                    previousNumbers.Add(number, null);
                }
            }

            return pairs;
        }
    }
}
