using System;

namespace Challenges.Challenges
{
    public class HourGlass2DArrays
    {
        public static void Run(string[] args)
        {
            int[][] arr = new int[6][];
            for (int arr_i = 0; arr_i < 6; arr_i++)
            {
                string[] arr_temp = Console.ReadLine().Split(' ');
                arr[arr_i] = Array.ConvertAll(arr_temp, Int32.Parse);
            }

            int max = 7 * -9;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int hourGlassSum = ComputeHourglassSum(arr, i, j);
                    if (max < hourGlassSum)
                    {
                        max = hourGlassSum;
                    }
                }
            }

            Console.WriteLine(max);
        }

        private static int ComputeHourglassSum(int[][] baseSquare, int hourglassX, int hourglassY)
        {
            int sum = 0;
            for (int i = 1; i <= 3; i++)
            {
                if (i % 2 == 1)
                {
                    int x = hourglassX + (i - 1);
                    for (int j = 0; j < 3; j++)
                    {
                        sum += baseSquare[x][hourglassY + j];
                    }
                }
                else
                {
                    sum += baseSquare[hourglassX + 1][hourglassY + 1];
                }
            }

            return sum;
        }
    }
}