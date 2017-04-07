using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenges.Challenges
{
    public class AlgorithmicCrush
    {
        public static void Run(string[] args)
        {
            // Instructions
            int[] ins = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            long[] a = new long[ins[0]];

            // Read input operations
            int operations = ins[1];
            long max = 0;
            for (int i = 0; i < operations; i++)
            {
                int[] operation = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                int start = operation[0] - 1;
                int end = operation[1];
                int sum = operation[2];
                if (a[start] < 0)
                {
                    a[start] = sum;
                }
                else
                {
                    a[start] += sum;
                }


                if (start == end)
                {
                    a[start] += sum;
                }
                else
                {
                    a[start] = sum;
                    if (end < a.Length)
                    {
                        a[end] -= sum;
                    }
                }
            }

            long p = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                a[i] += p;
                p = a[i];
                if (max < p)
                {
                    max = p;
                }
            }

            Console.WriteLine(max);
        }
    }
}