using System;

namespace Challenges.Challenges
{
    public class SparseArrays
    {
        public static void Run(string[] args)
        {
            // Number of strings to process
            int n = int.Parse(Console.ReadLine());

            // Collection of all input string in char[] format
            char[][] s = new char[n][];
            for (int i = 0; i < n; i++)
            {
                s[i] = Console.ReadLine().ToCharArray();
            }

            // Number of queries
            int nq = int.Parse(Console.ReadLine());

            // Input queries
            for (int i = 0; i < nq; i++)
            {
                char[] q = Console.ReadLine().ToCharArray();
                Console.WriteLine(FindString(s, q));
            }
        }

        private static int FindString(char[][] source, char[] q)
        {
            int matches = 0;
            for (int i = 0; i < source.Length; i++)
            {
                char[] s = source[i];
                if (Equals(s, q))
                {
                    matches++;
                }
            }

            return matches;
        }

        private static bool Equals(char[] a, char[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}