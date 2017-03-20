using System;

namespace Challenges.Challenges
{
    public class DynamicArray
    {
        private static int sequenciesQuantity;
        private static int[][] sequences;
        private static int lastAns;

        public static void Run(string[] args)
        {
            string seq = Console.ReadLine();
            int[] seqs = Array.ConvertAll(seq.Split(' '), int.Parse);

            // Declare variables:
            // Create the 2D array of X sequences from input
            sequenciesQuantity = seqs[0];
            sequences = new int[sequenciesQuantity][];
            lastAns = 0;

            // Number of queries to be applied
            int qNb = seqs[1];

            for (int i = 0; i < qNb; i++)
            {
                string queryInput = Console.ReadLine();
                int[] queryInfo = Array.ConvertAll(queryInput.Split(' '), int.Parse);
                int query = queryInfo[0];

                // Find the sequence
                int seqIndex = FindSequenceIndex(queryInfo[1]);
                if (query == 1)
                {
                    ApplyQuery1(seqIndex, queryInfo[2]);
                }
                else if (query == 2)
                {
                    ApplyQuery2(seqIndex, queryInfo[2]);
                }
            }
        }

        private static int FindSequenceIndex(int x)
        {
            return (x ^ lastAns) % sequenciesQuantity;
        }

        private static void ApplyQuery1(int seqIndex, int valueToAppend)
        {
            int[] seq = sequences[seqIndex] ?? new int[0];

            int[] newArray = new int[seq.Length + 1];
            for (int i = 0; i < seq.Length; i++)
            {
                newArray[i] = seq[i];
            }

            newArray[newArray.Length - 1] = valueToAppend;
            sequences[seqIndex] = newArray;
        }

        private static void ApplyQuery2(int seqIndex, int y)
        {
            int[] currentSeq = sequences[seqIndex];
            lastAns = currentSeq[y % currentSeq.Length];
            Console.WriteLine(lastAns);
        }
    }
}