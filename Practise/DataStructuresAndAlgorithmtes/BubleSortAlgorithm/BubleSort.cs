namespace Practise.DataStructuresAndAlgorithmtes;
public class BubleSort
{
    public static void Solution()
    {
        int[] nums = { new Random().Next(0,200), new Random().Next(0, 200), new Random().Next(0, 200), new Random().Next(0, 200), new Random().Next(0, 200), new Random().Next(0, 200), new Random().Next(0, 200), new Random().Next(0, 200), new Random().Next(0, 200), new Random().Next(0, 200), new Random().Next(0, 200) };

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i+1; j < nums.Length; j++)
            {
                if (nums[i] > nums[j])
                {
                    var temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                }
            }
        }
        nums.ToList().ForEach(nums => { Console.Write(nums + ", "); });
    }
}
