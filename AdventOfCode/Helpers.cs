using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    static class Helpers
    {
        private const string _defaultMultiLinePrompt = "Paste the input";

        public static string[] ReadMultipleLines(string prompt = _defaultMultiLinePrompt)
        {
            Console.WriteLine(String.Format("{0} (In the next line, enter CTRL+Z)", prompt));
            return Console.In.ReadToEnd().Split('\n');
        }
    }
}
