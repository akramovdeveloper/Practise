namespace Practise.LeetCode.Medium._151ReverseWordsinaString;
public class Solution151_2
{
    public static string ReverseWords(string s)
    {
        var begin = 0;
        var end = 0;
        List<string> words = new List<string>();
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ')
            {
                if (begin != end)
                    words.Add(s.Substring(begin, end-begin));
                end++;
                begin = end;
            }
            else end++;
        }
        if (begin != end)
            words.Add(s.Substring(begin, end-begin));
        words.Reverse();
        return string.Join(" ", words.ToArray());
    }
}
