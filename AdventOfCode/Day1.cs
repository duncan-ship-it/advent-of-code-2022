using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    static class Day1
    {
        private const string _caloriePrompt = "Paste the calories of each elf";

        /// <summary>
        /// Part 1: Find the most calories held by a single elf
        /// </summary>
        public static int GetHighestElfCalories()
        {
            string[] input = Helpers.ReadMultipleLines(_caloriePrompt);

            int sum = 0;
            int max = 0;

            int calories;

            foreach (string line in input)
            {
                string trimmed = line.Trim();

                if (int.TryParse(trimmed, out calories)) sum += calories;
                else if (trimmed == "")
                {
                    if (max < sum) max = sum;
                    sum = 0;
                }
                else throw new ArgumentException(String.Format("'{0}' was neither empty nor integer", line));
            }

            return max;
        }

        /// <summary>
        /// Part 2: Find the total calories held by the top three elves
        /// </summary>
        public static int GetTopThreeTotalCalories()
        {
            string[] input = Helpers.ReadMultipleLines(_caloriePrompt);

            int sum = 0;
            var elfCalories = new List<int>();

            int calories;

            foreach (string line in input)
            {
                string trimmed = line.Trim();

                if (int.TryParse(trimmed, out calories)) sum += calories;
                else if (trimmed == "")
                {
                    elfCalories.Add(sum);
                    sum = 0;
                }
                else throw new ArgumentException(String.Format("'{0}' was neither empty nor integer", line));
            }

            elfCalories.Sort((a, b) => b.CompareTo(a));

            return elfCalories.GetRange(0, 3).Aggregate((a, b) => a + b);
        }
    }
}
