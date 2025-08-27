namespace LeetCode.Common;

public static class IntExt
{
    extension(IList<int> nums)
    {
        public string ToJoinString(string separator = ",")
        {
            return string.Join(separator, nums);
        }
    }
    
    extension(IList<IList<int>> nums)
    {
        public string ToJoinString(string separator = ",")
        {
            var innerStrings = nums.Select(inner => $"[{string.Join(separator, inner)}]");
            return $"[{string.Join(", ", innerStrings)}]";
        }
    }
    
    extension(List<List<int>> nums)
    {
        public string ToJoinString(string separator = ",")
        {
            var innerStrings = nums.Select(inner => $"[{string.Join(separator, inner)}]");
            return $"[{string.Join(", ", innerStrings)}]";
        }
    }
    
    extension(int[] nums)
    {
        public string ToJoinString(string separator = ",")
        {
            return string.Join(separator, nums);
        }
    }
}