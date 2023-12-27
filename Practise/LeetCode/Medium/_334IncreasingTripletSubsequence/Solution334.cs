namespace Practise.LeetCode.Medium._334IncreasingTripletSubsequence;
public class Solution334
{
    public static bool IncreasingTriplet(params int[] nums)
    {
        var small = int.MaxValue;
        var medium = int.MaxValue;
        foreach (var item in nums)
        {
            if (item <= small) small = item;
            else if (item <= medium) medium = item;
            else return true;
        }
        return false; 
    }
}
