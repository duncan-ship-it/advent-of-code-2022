using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    static class Day3
    {
        private const string _rucksackPrompt = "Enter rucksack here:";

        private static int GetPriorityValue(char item)
        {
            if (!Char.IsUpper(item)) return item - '0' - 48;  // lowercase: 1 to 26
            else return item - '0' + 10;                      // uppercase: 27 to 52
        }

        /// <summary>
        /// Part 1: Find the sum of priorities of common items in both compartments for each rucksack
        /// </summary>
        public static int SumOfPrioritiesOfCommonItems()
        {
            string[] rucksacks = Helpers.ReadMultipleLines(_rucksackPrompt);

            int sum = 0;

            foreach (string rucksack in rucksacks)
            {
                char[] items = rucksack.TrimEnd('\r').ToCharArray();

                int halfway = rucksack.Length / 2;

                var uniqueFirstItems = new HashSet<char>(items[0..halfway]);

                for (int i = halfway; i < items.Length; i++)
                {
                    if (uniqueFirstItems.Contains(items[i]))
                    {
                        uniqueFirstItems.Remove(items[i]);  // TODO: redundant remove, iterate over hashset of second part of rucksack
                        sum += GetPriorityValue(items[i]);
                    }
                }
            }

            return sum;
        }

        /// <summary>
        /// Part 2: Find the sum of each common item contained in each set of 3 rucksacks
        /// </summary>
        public static int SumOfBadgePriorities()
        {
            string[] rucksacks = Helpers.ReadMultipleLines(_rucksackPrompt);

            int sum = 0;
            
            for (int i = 0; i < rucksacks.Length - 1; i += 3)  // increment over batches of three (ignore last empty line)
            {
                char badge = '\0';  // initialise badge to null character

                var rucksack1 = new HashSet<char>(rucksacks[i + 1].ToCharArray());
                var rucksack2 = new HashSet<char>(rucksacks[i + 2].ToCharArray());

                foreach (char c in rucksacks[i])
                {
                    if (rucksack1.Contains(c) && rucksack2.Contains(c))  // O(1) contain checks of other rucksacks
                    {
                        badge = c;
                        break;
                    }
                }

                if (badge != '\0')
                    sum += GetPriorityValue(badge);
                else
                    throw new ArgumentException(String.Format("Rucksack batch #{0} does not have a badge", i / 3));
            }

            return sum;
        }
    }
}
