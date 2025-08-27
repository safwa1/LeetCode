using static System.Activator;

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

    extension<T>(T) where T : class, new()
    {
        public static T New() => CreateInstance<T>();

        public static T? New(params object[] args) => CreateInstance(typeof(T), args) as T;

        public static T CreateSingleton() => ObjectFactory.CreateSingleton<T>();

        public static T? CreateSingleton(params object[] args) => ObjectFactory.CreateSingleton<T>(args);
    }

    extension(Type type)
    {
        public bool IsAssignableFrom<T>() => typeof(T).IsAssignableFrom(type);
        public T? NewInstance<T>(params object[] args) where T : class => CreateInstance(type, args) as T;
        public object? NewInstance(params object[] args) => CreateInstance(type, args);
    }

    extension<T>(T t)
    {
        public bool IsInstanceOf<TTargetType>()
        {
            return t is TTargetType;
        }

        public bool IsNotInstanceOf<TTargetType>()
        {
            return t is not TTargetType;       
        }
        
        public TTargetType As<TTargetType>()
        {
            return (TTargetType)Convert.ChangeType(t, typeof(TTargetType))!;
        }
        
        public TTargetType As<TTargetType>(TTargetType defaultValue)
        {
            return t is TTargetType targetType ? targetType : defaultValue;
        }
        
        public TTargetType As<TTargetType>(Func<TTargetType> defaultValueFactory)
        {
            return t is TTargetType targetType ? targetType : defaultValueFactory();
        }
        
        public TTargetType As<TTargetType>(Func<TTargetType> defaultValueFactory, TTargetType defaultValue)
        {
            return t is TTargetType targetType ? targetType : defaultValueFactory();
        }
    }
}