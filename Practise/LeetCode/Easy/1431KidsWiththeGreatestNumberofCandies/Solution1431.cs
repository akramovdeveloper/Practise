namespace Practise.LeetCode.Easy._1431KidsWiththeGreatestNumberofCandies;
public class Solution1431
{
    public static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        List<bool> result = new();
        var max = candies.Max() - extraCandies;
        for (int i = 0; i < candies.Length; i++)
            result.Add(candies[i] >= max);
        return result;
    }
}
