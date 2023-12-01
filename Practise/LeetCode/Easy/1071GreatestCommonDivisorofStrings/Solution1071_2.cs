using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise.LeetCode.Easy._1071GreatestCommonDivisorofStrings;
public class Solution1071_2
{
    public static string GcdOfStrings(string str1, string str2)
    {
        if (str1 + str2 != str2 + str1) return "";

        int num = FindGCD(str1.Length, str2.Length);

        return str1.Substring(0, num);

    }

    private static int FindGCD(int a, int b)
    {
        if (a == 0) return b;

        return FindGCD(b % a, a);
    }
}
