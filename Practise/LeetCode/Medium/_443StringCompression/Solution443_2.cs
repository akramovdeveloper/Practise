using System.Text;

namespace Practise.LeetCode.Medium._443StringCompression;
public class Solution443_2
{
    public static int Compress(char[] chars)
    {
        // "a","a","b","b","c","c","c"
        var sb = new StringBuilder();
        var target = chars[0];
        sb.Append(target);
        var counter = 1;
        for (int i = 1; i < chars.Length; i++)
        {
            if (target == chars[i]) counter++;

            else
            {
                if (counter > 1) sb.Append(counter);

                target = chars[i];
                sb.Append(target);
                counter = 1;
            }
        }
        if (counter > 1) sb.Append(counter);

        var arr = sb.ToString().ToCharArray();

        for (int i = 0; i < arr.Length; i++) chars[i] = arr[i];

        return arr.Length;
    }
}
