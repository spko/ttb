using System;

namespace Challenges.Challenges
{
    public class LeftRotation
    {
        public static void Run(string[] args)
        {
            string userInput = Console.ReadLine();
            int[] instructions = Array.ConvertAll(userInput.Split(' '), int.Parse);

            int n = instructions[0];
            int d = instructions[1];

            string litteralInput = Console.ReadLine();
            int[] array = Array.ConvertAll(litteralInput.Split(' '), int.Parse);

            int[] newPositions = ComputeNewPositions(n, d);
            for (int i = 0; i < newPositions.Length; i++)
            {
                Console.Write(array[newPositions[i]] + " ");
            }
        }

        private static int[] ComputeNewPositions(int arraySize, int rotations)
        {
            // Left rotation translation:
            // - For elements before located on the left side of rotation limit => Source array length - number of rotations
            // - For elements before located on the right side of rotation limit => Position of the element - Number of rotations 
            int translationLowerPartConstant = arraySize - rotations;
            int[] result = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                if (i < rotations)
                {
                    result[translationLowerPartConstant + i] = i;
                }
                else
                {
                    result[i - rotations] = i;
                }
            }

            return result;
        }
    }
}