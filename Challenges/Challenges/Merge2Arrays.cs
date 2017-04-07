// Write a function which merges two sorted integer arrays and returns one (new) sorted array back. Merging should happen in most efficient way. Method description in Java:
// public int[] mergeTwoArrays(int[] array1, int[] array2) {
// }
// Example by data:
// array1 = [1,5,7];
// array2 = [6,7,9,15];
// result = [1,5,6,7,7,9,15]
// Code should be written in browser in real-time without testing/running it in IDE and then copy-pasting the result. It's important to see the process to find the solution.
// Extra points: write unit tests for the method.



// [1,5,7] [6,7,9,15]

using System;
using System.Collections.Generic;
using Challenges.Challenges.Models;

namespace Challenges.Challenges
{
    public class Merge2Arrays
    {
        public static void Run(string[] args)
        {
            int[] a = new[] { 1, 2, 3, 5 };
            int[] b = new[] { 4, 6, 7, 8, 9, 10 };
            MergeWithLinkedList(a, b);

            MergeWithArrays(a, b);
        }

        public static int[] MergeWithLinkedList(int[] arrayA, int[] arrayB)
        {
            if (arrayA == null || arrayB == null)
            {
                return null;
            }

            if (arrayA.Length == 0)
            {
                return arrayB;
            }
            if (arrayB.Length == 0)
            {
                return arrayA;
            }

            int[] refArray = arrayB;
            int[] loopArray = arrayA;
            if (arrayA.Length > arrayB.Length)
            {
                refArray = arrayA;
                loopArray = arrayB;
            }

            // Creation of the base ordered linked list with values of longest array
            Node root = ConstructLinkedList(refArray);

            // Loop throught the second smaller array, find the position of the each element in the previously created linked list
            // and insert a node in the correct position;
            for (int i = 0; i < loopArray.Length; i++)
            {
                int currentValue = loopArray[i];
                var newNode = new Node { Value = currentValue };

                // If the current value is lower than the root, it will be first of our linked list;
                if (currentValue < root.Value)
                {
                    newNode.Next = root;
                    root = newNode;
                }
                else
                {
                    // Find the position of the current node within the linked list
                    Node n = root;
                    while (n.Next != null)
                    {
                        // If The value is lower than the next one, we insert it here
                        if (currentValue < n.Next.Value)
                        {
                            newNode.Next = n.Next;
                            n.Next = newNode;
                            break;
                        }
                        else
                        {
                            // Otherwise we jumping to the next one;
                            n = n.Next;
                        }
                    }
                }
            }

            return LinkedListToArray(root);
        }

        public static int[] MergeWithArrays(int[] arrayA, int[] arrayB)
        {
            if (arrayA == null && arrayB == null)
            {
                return null;
            }
            if (arrayA == null || arrayA.Length == 0)
            {
                return arrayB;
            }
            if (arrayB == null || arrayB.Length == 0)
            {
                return arrayA;
            }

            // Creation of the array of the sum of both input arrays
            int[] result = new int[arrayA.Length + arrayB.Length];
            int itA = 0;
            int itB = 0;
            int itResult = 0;
            int doublon = 0;
            while (itA < arrayA.Length && itB < arrayB.Length)
            {
                int currentValueA = arrayA[itA];
                int currentValueB = arrayB[itB];

                // Compare values and push them into the current result index
                if (currentValueA < currentValueB)
                {
                    result[itResult] = currentValueA;

                    // Increment iterator A to get to next value
                    itA++;
                }
                else if (currentValueA == currentValueB)
                {
                    result[itResult] = currentValueA;

                    // Increment both iterators A and B to get to next value
                    itA++;
                    itB++;

                    // Increment the doublon counter to remove trailing zero
                    doublon++;
                }
                else
                {
                    result[itResult] = currentValueB;

                    // Increment iterator B to get to next value
                    itB++;
                }

                // Increment the result index, in order to complete the result array, if input Arrays A and B don't have the same size
                itResult++;
            }

            // There was an bug here, I was comparing arrays length and not their respectives last index values
            // Which were causing a bug when arrays have the same size, but not all values from one of them were processed in the previous loop
            if (itA == itB)
            {
                return result;
            }
            else if (itA < itB) // Get the biggest array and copy from it remaining elements at the end of the final array
            {
                // Copy remaining elements in A from the last processed index to result array
                Array.Copy(arrayA, itA, result, itResult, arrayA.Length - itA);
            }
            else
            {
                // Copy remaining elements in B from the last processed index to result array
                Array.Copy(arrayB, itB, result, itResult, arrayB.Length - itB);
            }

            // if some duplicate data was found, we have to resize the result array, in order to remove trailing values
            int maximumSize = arrayA.Length + arrayB.Length - doublon;
            if (result.Length > maximumSize)
            {
                Array.Resize(ref result, maximumSize);
            }

            return result;
        }

        private static void Test_EmptyArrays()
        {
            int[] a = new int[0];
            int[] b = new int[0];

            var result = MergeWithArrays(a, b);
            AssertAreEqual(new int[0], result, "Empty array expected");
        }

        private static void Test_NullArrays()
        {
            int[] a = new int[] { 1 };
            int[] b = new int[] { 32 };

            var result = MergeWithArrays(null, null);
            AssertAreEqual(null, result, "Null array expected");

            result = MergeWithArrays(a, null);
            AssertAreEqual(a, result, "A array expected");

            result = MergeWithArrays(null, b);
            AssertAreEqual(b, result, "B array expected");
        }

        private static void Test_Arrays_Nominal()
        {
            int[] a = new int[] { 1, 2, 6 };
            int[] b = new int[] { 4, 32, 50 };
            int[] e = new[] { 1, 2, 4, 6, 32, 50 };

            var result = MergeWithArrays(a, b);
            AssertAreEqual(e, result, "Merged arrays not matching");

            a = new int[] { 6, 7, 9, 15 };
            b = new int[] { 1, 5, 7 };
            e = new[] { 1, 5, 6, 7, 9, 15 };

            result = MergeWithArrays(a, b);
            AssertAreEqual(e, result, "Merged arrays not matching");
        }

        // Compare the expected array and the actual one. Returns false if they are not matching
        private static bool CheckResultComparison(int[] expected, int[] actual)
        {
            if (expected == null ^ actual == null)
            {
                return false;
            }

            if (expected == null)
            {
                return true;
            }

            if (expected.Length != actual.Length)
            {
                return false;
            }

            for (int i = 0; i < expected.Length; i++)
            {
                if (expected[i] != actual[i])
                {
                    return false;
                }
            }

            return true;
        }

        // Does nothing but writing the result of test on the Standard output
        private static void AssertAreEqual(int[] expected, int[] actual, string message)
        {
            string fail = "FAIL - {0}";
            string success = "SUCCESS";
            if (!CheckResultComparison(expected, actual))
            {
                Console.WriteLine(fail, message);
            }
            else
            {
                Console.WriteLine(success);
            }
        }

        private static Node ConstructLinkedList(int[] arraySource)
        {
            Node root = new Node { Value = arraySource[0] };
            Node previous = root;
            for (int i = 1; i < arraySource.Length; i++)
            {
                var currentNode = new Node { Value = arraySource[i] };
                previous.Next = currentNode;
                previous = currentNode;
            }

            return root;
        }

        private static int[] LinkedListToArray(Node root)
        {
            Node n = root;
            List<int> result = new List<int>();
            while (n != null)
            {
                result.Add(n.Value);
                n = n.Next;
            }

            return result.ToArray();
        }
    }
}