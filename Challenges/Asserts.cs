using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    public class Asserts
    {
        private const string Fail = "Test - {0} # FAIL - {1}";
        private const string Success = "Test - {0} # Success";
        private const string DefaultFailMessage = "Arrays are not equals";

        public static void ArrayAreEquals(int[] arrayA, int[] arrayB, string testName, string errorMessage = DefaultFailMessage)
        {
            if (arrayA == null ^ arrayB == null)
            {
                Console.WriteLine(string.Format(Fail, testName, errorMessage));
            }

            if (arrayA.Length != arrayB.Length)
            {
                Console.WriteLine(string.Format(Fail, testName, errorMessage));
            }

            for (int i = 0; i < arrayA.Length; i++)
            {
                if (arrayA[i] != arrayB[i])
                {
                    Console.WriteLine(string.Format(Fail, testName, errorMessage));

                    return;
                }
            }

            Console.WriteLine(string.Format(Success, testName));
        }

        private static void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
