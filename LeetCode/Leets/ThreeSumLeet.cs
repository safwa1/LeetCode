/*
Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

Notice that the solution set must not contain duplicate triplets.

 
Example 1:

Input: nums = [-1,0,1,2,-1,-4]
Output: [[-1,-1,2],[-1,0,1]]
Explanation: 
nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
The distinct triplets are [-1,0,1] and [-1,-1,2].
Notice that the order of the output and the order of the triplets does not matter.
Example 2:

Input: nums = [0,1,1]
Output: []
Explanation: The only possible triplet does not sum up to 0.
Example 3:

Input: nums = [0,0,0]
Output: [[0,0,0]]
Explanation: The only possible triplet sums up to 0.
 

Constraints:

3 <= nums.length <= 3000
-105 <= nums[i] <= 105
*/

using LeetCode.Common;

namespace LeetCode.Leets;

/// <summary>
/// LeetCode 15. 3Sum.
/// <see href="https://leetcode.com/problems/3sum/"/>
/// <remarks>
/// Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]]
/// such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
/// The solution set must not contain duplicate triplets.
/// This solution uses a two-pointer approach after sorting the array.
/// </remarks>
/// </summary>
public class ThreeSumLeet: ILeet
{
    /// <summary>
    /// Finds all unique triplets in the array which give the sum of zero.
    /// </summary>
    /// <param name="nums">An array of integers.</param>
    /// <returns>A list of lists, where each inner list is a unique triplet that sums to zero.</returns>
    private static List<List<int>> ThreeSum(int[] nums)
    {
        var result = new List<List<int>>();
        Array.Sort(nums);

        // The last possible triplet would be at indices (n-3, n-2, n-1)
        // so we only need to iterate i up to n-3.
        for (var i = 0; i < nums.Length - 2; i++)
        {
            // Skip duplicate values for the first element of the triplet
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            var j = i + 1;
            var k = nums.Length - 1;

            while (j < k)
            {
                var sum = nums[i] + nums[j] + nums[k];

                switch (sum)
                {
                    case < 0:
                        j++;
                        break;
                    case > 0:
                        k--;
                        break;
                    default:
                        result.Add([nums[i], nums[j], nums[k]]);
                        j++;
                        k--;
                        
                        // Skip duplicates for the second and third elements to avoid duplicate triplets
                        while (j < k && nums[j] == nums[j - 1]) j++;
                        while (j < k && nums[k] == nums[k + 1]) k--;
                        break;
                }
            }
        }

        return result;
    }

    /// <summary>
    /// Executes sample cases for the <see cref="ThreeSum"/> method and prints results to the console.
    /// </summary>
    public void Execute()
    {
        Console.WriteLine(ThreeSum([-1, 0, 1, 2, -1, -4]).ToJoinString());
        Console.WriteLine(ThreeSum([0, 1, 1]).ToJoinString());
        Console.WriteLine(ThreeSum([0, 0, 0]).ToJoinString());
    }
}