namespace Practise.LeetCode.Medium._238ProductofArrayExceptSelf;
public class Solution238
{
    public static int[] ProductExceptSelf(params int[] nums)
    {
        // 1,2,3,4
        int[] res = new int[nums.Length];
        int[] prev = Enumerable.Repeat(1, nums.Length).ToArray();
        int[] next = Enumerable.Repeat(1, nums.Length).ToArray();
        for (int i = 0; i < nums.Length; i++)
            if (i != 0)
                prev[i] = nums[i - 1] * prev[i - 1];

        for (int i = nums.Length - 1; i >= 0; i--)
            if (i != nums.Length - 1)
                next[i] = next[i + 1] * nums[i + 1];

        for (int i = 0; i < nums.Length; i++)
            res[i] = prev[i] * next[i];

        return res;
    }
}
