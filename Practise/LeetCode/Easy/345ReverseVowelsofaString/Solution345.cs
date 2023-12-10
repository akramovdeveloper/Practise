namespace Practise.LeetCode.Easy._345ReverseVowelsofaString;
public class Solution345
{
    public static string ReverseVowels(string s)
    {
        char[] chars = new char[] { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };
        char[] charArray = s.ToCharArray();
        List<char> list = new();
        foreach (char item in charArray)
            if (chars.Contains(item))
                list.Add(item);

        list.Reverse();
        int j = 0;
        for (int i = 0; i < charArray.Length; i++)
            if (chars.Contains(s[i]))
                charArray[i] = list[j++];

        return new string(charArray);
    }
}
