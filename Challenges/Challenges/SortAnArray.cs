using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.Challenges
{
    public static class SortAnArray
    {
        public static void Run(string[] args)
        {
            TestSort(SortArrayWhileLoop, "While Loop");

            TestSort(SortArrayBubbleSort, "Bubble sort");
        }

        private static void TestSort(Action<int[]> sorter, string sortType)
        {
            int[] input = { 4, 4, 34, 1, 87, 3, 2, 5, 6, 7, 70 };
            sorter(input);
            Array.ForEach(input, v => Console.Write(v + " "));
            Asserts.ArrayAreEquals(input, new int[] { 1, 2, 3, 4, 4, 5, 6, 7, 34, 70, 87 }, sortType);

            input = new int[] { 4, 43, 2, 10, 40, 76, 3, 5, 99, 80, 70 };
            sorter(input);
            Array.ForEach(input, v => Console.Write(v + " "));
            Asserts.ArrayAreEquals(input, new int[] { 2, 3, 4, 5, 10, 40, 43, 70, 76, 80, 99 }, sortType);

            input = new int[] { 4, 4, 4 };
            sorter(input);
            Array.ForEach(input, v => Console.Write(v + " "));
            Asserts.ArrayAreEquals(input, new int[] { 4, 4, 4 }, sortType);

            input = new int[] { 99, 98, 97, 76, 75, 75, 76, 97, 98, 99, 1, 2, 3, 4, 4, 3, 2, 1 };
            sorter(input);
            Array.ForEach(input, v => Console.Write(v + " "));
            Asserts.ArrayAreEquals(input, new int[] { 1, 1, 2, 2, 3, 3, 4, 4, 75, 75, 76, 76, 97, 97, 98, 98, 99, 99 }, sortType);
        }

        private static void SortArrayWhileLoop(int[] arrayToSort)
        {
            bool notOrderedAsc = true;
            bool notOrderedDesc = true;
            while (notOrderedAsc && notOrderedDesc)
            {
                notOrderedAsc = false;
                notOrderedDesc = false;
                for (int i = 0; i < arrayToSort.Length - 1; i++)
                {
                    var currentV = arrayToSort[i];
                    var nextV = arrayToSort[i + 1];
                    if (currentV > nextV)
                    {
                        notOrderedAsc = true;
                        arrayToSort[i] = nextV;
                        arrayToSort[i + 1] = currentV;
                    }
                }

                for (int i = arrayToSort.Length - 1; i > 0; i--)
                {
                    var currentV = arrayToSort[i];
                    var prevV = arrayToSort[i - 1];
                    if (currentV < prevV)
                    {
                        notOrderedDesc = true;
                        arrayToSort[i] = prevV;
                        arrayToSort[i - 1] = currentV;
                    }
                }
            }
        }

        private static void SortArrayBubbleSort(int[] arrayToSort)
        {
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                for (int j = 0; j < arrayToSort.Length - 1 - i; j++)
                {
                    int current = arrayToSort[j];
                    int next = arrayToSort[j + 1];
                    if (current > next)
                    {
                        arrayToSort[j] = next;
                        arrayToSort[j + 1] = current;
                    }
                }
            }
        }
    }
}
