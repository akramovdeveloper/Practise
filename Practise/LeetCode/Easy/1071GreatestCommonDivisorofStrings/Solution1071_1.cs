namespace Practise.LeetCode.Easy._1071GreatestCommonDivisorofStrings;
public class Solution1071_1
{
    public static string GcdOfStrings(string str1, string str2)
    {
        var minLength = Math.Min(str1.Length, str2.Length);
        for (int i = minLength; i > 0; i--)
        {
            if (IsValid(str1, str2, i))
                return str1.Substring(0, i);
        }
        return "";
    }
    private static bool IsValid(string str1, string str2, int t)
    {
        if (str1.Length % t != 0 || str2.Length % t != 0) return false;
        var baseStr = str1.Substring(0, t);
        return string.IsNullOrEmpty(str1.Replace(baseStr, "")) && string.IsNullOrEmpty(str2.Replace(baseStr, ""));
    }
}
