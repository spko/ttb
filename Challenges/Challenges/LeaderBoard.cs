using System;

namespace Challenges.Challenges
{
    public class LeaderBoard
    {
        public static void Run(string[] args)
        {
            // Number of players
            string[] scores_temp = Console.ReadLine().Split(' ');

            // Players scores in descending order 
            int[] scores = FindDistincts(scores_temp);

            // Number of levels finished by Alice
            int m = Convert.ToInt32(Console.ReadLine());

            // Alice's cumulative scores
            string[] alice_temp = Console.ReadLine().Split(' ');
            int[] alice = Array.ConvertAll(alice_temp, Int32.Parse);

            int lastIndex = scores.Length;

            // Loop through Alice's scores
            for (int i = 0; i < m; i++)
            {
                int currentAliceScore = alice[i];
                int position = -1;
                for (int s = lastIndex; s > 0; s--)
                {
                    int currentScore = scores[s - 1];
                    if (currentAliceScore < currentScore)
                    {
                        position = s + 1;
                        lastIndex = s;
                        break;
                    }
                }

                if (position == -1)
                {
                    position = 1;
                }

                Console.WriteLine(position);
            }
        }

        private static int[] FindDistincts(string[] input)
        {
            int[] result = new int[input.Length];

            int previousValue = -1;
            int distinctIndex = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int v = Int32.Parse(input[i]);
                if (previousValue != v)
                {
                    result[distinctIndex] = v;
                    distinctIndex++;
                }

                previousValue = v;
            }

            int[] distinctArray = new int[distinctIndex + 1 > result.Length ? result.Length : distinctIndex];
            for (int j = 0; j < distinctIndex; j++)
            {
                distinctArray[j] = result[j];
            }

            return distinctArray;
        }
    }
}