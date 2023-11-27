using System.Text;

namespace Practise.LeetCode.Easy;
public class Solution
{
    public static string MergeAlternately(string word1, string word2)
    {
        int i = 0;
        StringBuilder result = new StringBuilder();
        while (i < word1.Length || i < word2.Length)
        {
            if (word1.Length > i)
                result.Append(word1[i]);

            if (word2.Length > i)
                result.Append(word2[i]);

            i++;
        }

        return result.ToString();
    }
}
