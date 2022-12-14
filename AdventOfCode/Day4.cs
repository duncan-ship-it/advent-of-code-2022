using System;

namespace AdventOfCode
{
    static class Day4
    {
        private const string _rangePrompt = "Enter the assignment pairs with format 0-0,0-0";

        private static bool EitherRangeContained(Range range1, Range range2)
        {
            if (range1.Start.Value < range2.Start.Value)
                return range1.End.Value >= range2.End.Value;
            else if (range1.Start.Value > range2.Start.Value)
                return range1.End.Value <= range2.End.Value;

            return true;
        }
        private static bool RangesOverlap(Range range1, Range range2)
        {
            if (range1.End.Value >= range2.Start.Value)
                return range1.Start.Value <= range2.End.Value;
            else if (range1.Start.Value <= range2.End.Value)
                return range1.End.Value >= range2.Start.Value;

            return false;
        }

        private static Range ParseRange(string range)
        {
            string[] indices = range.Split('-');

            int start;
            int end;

            if (!(int.TryParse(indices[0], out start) && int.TryParse(indices[1], out end)))
                throw new ArgumentException("'{0}' is not an expected range input");

            return new Range(start, end);
        }

        /// <summary>
        /// Part 1: Count pairs of ranges where either range is contained within the other
        /// </summary>
        public static int CountContainedAssignmentPairs()
        {
            string[] rangeInputs = Helpers.ReadMultipleLines(_rangePrompt);

            int containedRanges = 0;

            foreach (string rangePair in rangeInputs)
            {
                string[] ranges = rangePair.TrimEnd('\r').Split(',');

                Range range1 = ParseRange(ranges[0]);
                Range range2 = ParseRange(ranges[1]);

                if (EitherRangeContained(range1, range2)) 
                    containedRanges++;
            }

            return containedRanges;
        }

        /// <summary>
        /// Part 2: Count pairs of ranges where the ranges are overlapping
        /// </summary>
        public static int CountOverlappingAssignmentPairs()
        {
            string[] rangeInputs = Helpers.ReadMultipleLines(_rangePrompt);

            int containedRanges = 0;

            foreach (string rangePair in rangeInputs)
            {
                string[] ranges = rangePair.TrimEnd('\r').Split(',');

                Range range1 = ParseRange(ranges[0]);
                Range range2 = ParseRange(ranges[1]);

                if (RangesOverlap(range1, range2))
                    containedRanges++;
            }

            return containedRanges;
        }
    }
}
