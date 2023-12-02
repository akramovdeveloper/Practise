namespace Practise.LeetCode.Easy._605CanPlaceFlowers;
public class Solution605
{
    public static bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        int res = 0;
        for (int i = 0; i < flowerbed.Length; i++)
        {
            if (flowerbed[i] == 0)
            {
                var isEmptyPrev = i == 0 || flowerbed[i - 1] == 0;
                var isEmptyNext = i == flowerbed.Length - 1 || flowerbed[i + 1] == 0;
                if (isEmptyPrev && isEmptyNext)
                {
                    flowerbed[i] = 1;
                    res++;
                }
            }
        }
        return res >= n;
    }
}
