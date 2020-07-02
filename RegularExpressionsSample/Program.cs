using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegularExpressionsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Find("test ion");
            string input = "Hey,I've just found this amazing URI at"+
                            "http://what was it -on yes https://www.wrox.com or "+
                            "http://www.wrox.com:80";
            FindURI(input);
        }
        public static void Find(string text)
        {
            const string pattern = @"\bt";
            MatchCollection matches = Regex.Matches(text, pattern,
                                                    RegexOptions.IgnoreCase|
                                                    RegexOptions.ExplicitCapture);
            foreach (Match item in matches)
            {
                Console.WriteLine(item.Index);
            }
            WriteMatches(text, matches);
        }
        public static void Find2(string input)
        {
            const string pattern = @"\bn";//查找以n开头的
            MatchCollection myMatches = Regex.Matches(input, pattern,
                                                    RegexOptions.IgnoreCase |
                                                    RegexOptions.ExplicitCapture);
            foreach (Match item in myMatches)
            {
                Console.WriteLine(item.Captures?.Count);
            }
        }
        public static void WriteMatches(string text,MatchCollection matches)
        {
            Console.WriteLine($"Original text was: \n\n{text}\n");
            Console.WriteLine($"No. of mathches: {matches.Count}");

            foreach (Match match in matches)
            {
                int index = match.Index;
                string result = match.ToString();
                int charsBefore = (index < 5) ? index : 5;
                int fromEnd = text.Length - index - result.Length;
                int charsAfter = (fromEnd < 5) ? fromEnd : 5;
                int charsToDisplay = charsBefore + charsAfter + result.Length;
                Console.WriteLine($"Index:{index},\tString: {result},\t" +
                    $"{text.Substring(index - charsBefore, charsToDisplay)}");
            }
        }
        public static void FindURI(string input)
        {
            const string pattern = @"\b(?<protocol>https?)(?:://)(?<address>[.\w]+)([\s:](?<port>[\d]{2,4})?)\b";
            var r = new Regex(pattern);
            MatchCollection mc = r.Matches(input);
            foreach (Match item in mc)
            {
                Console.WriteLine($"Match: {item}");
                foreach (Group group in item.Groups)
                {
                    if (group.Success)
                    {
                        Console.WriteLine($"group index: {group.Index}, value: {group.Value}");
                    }
                }
                foreach (var groupName in r.GetGroupNames())
                {
                    Console.WriteLine($"match for {groupName}: {item.Groups[groupName].Value}");
                }
            }
        }
    }
}
