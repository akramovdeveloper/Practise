using System.Text;

namespace Practise.LeetCode.Medium._443StringCompression;
public class Solution443
{
    public static int Compress(char[] chars)
    {
        var resString = new StringBuilder();
        for (int i = 0; i < chars.Count(); i++)
        {
            var counter = 1;
            if (i > 0 && chars[i - 1] == chars[i]) continue;
            for (int j = i+1; j < chars.Count(); j++) 
            {
                if (chars[i] != chars[j]) break;
                counter++;
            }
            resString.Append(chars[i]);
            if (counter > 1) resString.Append(counter);
        }
        var arr = resString.ToString().ToCharArray();
        for (int i = 0; i < arr.Length; i++)
        {
            chars[i] = arr[i];
        }
        return arr.Length;
    }
}
