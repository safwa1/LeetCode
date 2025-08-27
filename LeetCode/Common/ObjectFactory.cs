using System.Collections.Concurrent;

namespace LeetCode.Common;

public static class ObjectFactory
{
    private static readonly Lock Lock = new();
    private static readonly ConcurrentDictionary<Type, object> Singletons = new();
    
    public static T New<T>() where T : class, new() => Activator.CreateInstance<T>();
    
    public static T? New<T>(params object[] args) where T : class => Activator.CreateInstance(typeof(T), args) as T;
    
    public static T CreateSingleton<T>() where T : class, new() => (T)Singletons.GetOrAdd(typeof(T), _ => Activator.CreateInstance<T>());

    public static T? CreateSingleton<T>(params object[] args) where T : class
    {
        using (Lock.EnterScope())
        {
            var newInstance = Activator.CreateInstance(typeof(T), args) as T;
            Singletons[typeof(T)] = newInstance!;
            return newInstance;
        }
    }
    
    public static void RemoveSingleton<T>() where T : class => Singletons.TryRemove(typeof(T), out _);
    
    public static void ClearAll() => Singletons.Clear();
}