using System.Text.RegularExpressions;

namespace Practise.LeetCode.Medium._151ReverseWordsinaString;
public class Solution151
{
    public static string ReverseWords(string s)
    {
        var reg = Regex.Matches(s, @"\b\w+\b");
        var reversedReg = new List<Match>(reg);
        reversedReg.Reverse();
        string result = "";
        for (int i = 0; i < reversedReg.Count; i++)
            result += i == 0 ? reversedReg[i].Value : $" {reversedReg[i].Value}";
        return result;
    }
}
