namespace Practise.LeetCode.Easy._1431KidsWiththeGreatestNumberofCandies;
public class Solution1431
{
    public static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        List<bool> result = new List<bool>();
        for (int i = 0; i < candies.Count(); i++)
        {
            if ((candies[i] + extraCandies) >= candies.Max()) result.Add(true);

            else result.Add(false);
        }
        return result;  
    }
}
