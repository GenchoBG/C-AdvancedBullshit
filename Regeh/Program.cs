/*
 * Problem 1 – Regeh
You need to read a line from the console and match everything that is in square brackets. However, there are some rules that you need to follow:
You must have no whitespaces inside the match.
Inside the match you must have [(ASCII Symbols)<(Some digits)REGEH(Some digits)>(ASCII Symbols)] 
If you have nested brackets you need to match the inner most.
 [asdSd[asdasd<4REGEH23>asdUsd]
After you find a match you must extract the numbers between the “<”, “>” brackets. Then use this number like index to get character from input. Every index is the sum of all previous indexes. When the index is larger than the string length start from the beginning of the string. Continue that process until you traverse the string enough times for the index to fit.
Input
On the first line you will receive input that may contain any character.
Output
You must print on the console a single line with characters, that you find in the string
Constraints
The line may contain any character
Line length will be 1 < n < 1000000
Time limit: 0.3 sec. Memory limit: 16 MB.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharp_Advanced_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"\[[^\s[\]<>]*<(\d+)REGEH(\d+)>[^\s[\]<>]*\]";
            var input = Console.ReadLine();
            var matches = Regex.Matches(input, pattern);
            var output = "";
            var index = 0;
            foreach (Match match in matches)
            {
                var nums = new int[] { int.Parse(match.Groups[1].ToString()), int.Parse(match.Groups[2].ToString()) };
                foreach (var num in nums)
                {
                    index += num;
                    while (index >= input.Length)
                    {
                        index -= input.Length;
                    }
                    output += input[index];
                }
            }
            Console.WriteLine(output);
        }
    }
}
