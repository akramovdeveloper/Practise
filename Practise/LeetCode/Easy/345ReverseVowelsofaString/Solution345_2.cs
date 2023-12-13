using System.Text.RegularExpressions;

namespace Practise.LeetCode.Easy._345ReverseVowelsofaString;
public class Solution345_2
{
    public static string ReverseVowels(string s)
    {
        char[] chars = new char[] { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };
        var vowels = Regex.Matches(s, "[aAeEiIoOuU]");
        var reversedVowels = new List<Match>(vowels);
        reversedVowels.Reverse();
        char[] charArray = s.ToCharArray();
        int j = 0;
        for (int i = 0; i < charArray.Length; i++)
            if (chars.Contains(charArray[i]))
                charArray[i] = reversedVowels[j++].Value[0];

        return new string(charArray);
    }
}
