/*
Given an integer x, return true if x is a palindrome, and false otherwise.

Example 1:

Input: x = 121
Output: true
Explanation: 121 reads as 121 from left to right and from right to left.
Example 2:

Input: x = -121
Output: false
Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
Example 3:

Input: x = 10
Output: false
Explanation: Reads 01 from right to left. Therefore it is not a palindrome.


Constraints:

-231 <= x <= 231 - 1


Follow up: Could you solve it without converting the integer to a string?
*/

using LeetCode.Common;

namespace LeetCode.Leets;

/// <summary>
/// LeetCode 9. Palindrome Number.
/// <see href="https://leetcode.com/problems/palindrome-number/"/>
/// <remarks>
/// Given an integer x, return true if x is a palindrome, and false otherwise.
/// This solution solves it without converting the integer to a string by reversing the number.
/// </remarks>
/// </summary>
public class IsPalindromeLeet : ILeet
{
    /// <summary>
    /// Checks if an integer is a palindrome by reversing it.
    /// <para>
    /// A number is a palindrome if it reads the same forwards and backwards.
    /// Negative numbers are not considered palindromes.
    /// </para>
    /// </summary>
    /// <param name="x">The integer to check.</param>
    /// <returns><c>true</c> if <paramref name="x"/> is a palindrome; otherwise, <c>false</c>.</returns>
    private bool IsPalindrome(int x)
    {
        if (x < 0) return false;

        int reversed = 0;
        int copy = x;

        while (copy > 0)
        {
            reversed = reversed * 10 + copy % 10;
            copy /= 10;
        }

        return x == reversed;
    }

    /// <summary>
    /// Executes sample cases for the <see cref="IsPalindrome"/> method and prints results to the console.
    /// </summary>
    public void Execute()
    {
        Console.WriteLine($"121 Is Palindrome: {IsPalindrome(121)}");
        Console.WriteLine($"-121 Is Palindrome: {IsPalindrome(-121)}");
        Console.WriteLine($"10 Is Palindrome: {IsPalindrome(10)}");
        Console.WriteLine($"11 Is Palindrome: {IsPalindrome(11)}");
    }
}
