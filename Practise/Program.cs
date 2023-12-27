using Practise.LeetCode.Medium._334IncreasingTripletSubsequence;
using Practise.LeetCode.Medium._443StringCompression;

namespace Practise;

internal class Program
{
    static void Main(string[] args)
    {
        char[] x = new char[] { 'a','a','a', 'b', 'b', 'a', 'a' };
        Console.WriteLine(Solution443_2.Compress(x));
    }
}
