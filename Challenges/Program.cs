﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Challenges.Challenges;

namespace Challenges
{
    public static class Program
    {
        private static readonly IDictionary<int, Action<string[]>> idToRunnerMapping;

        static Program()
        {
            idToRunnerMapping = new Dictionary<int, Action<string[]>>();
            idToRunnerMapping.Add(1, LeaderBoard.Run);
            idToRunnerMapping.Add(2, HourGlass2DArrays.Run);
        }

        public static void Main(string[] args)
        {
            for (int i = 0; i < idToRunnerMapping.Count; i++)
            {
                Console.WriteLine(i + 1  + ". - " + idToRunnerMapping[i + 1].Method.DeclaringType.Name);
            }

            var input = Console.ReadLine();
            LaunchRunner(input, args);

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        private static void LaunchRunner(string input, string[] args)
        {
            int id;
            if (int.TryParse(input, out id))
            {
                Action<string[]> runner = null;
                if (idToRunnerMapping.TryGetValue(id, out runner))
                {
                    runner(args);
                }
            }
        }
    }
}
