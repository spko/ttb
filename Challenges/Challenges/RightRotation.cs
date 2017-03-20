using System;

namespace Challenges.Challenges
{
    public class RightRotation
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
            // - For elements located on the left side of rotation limit (right to left) => Position + number of rotations
            // - For elements located on the right side of rotation limit (right to left) => Position of the element + Number of rotations - Size of array
            int rotationLimit = arraySize - rotations;
            int rightSideTranslationConstant = rotations - arraySize;
            int[] result = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                if (i < rotationLimit)
                {
                    result[rotations + i] = i;
                }
                else
                {
                    result[i + rightSideTranslationConstant] = i;
                }
            }

            return result;
        }
    }
}