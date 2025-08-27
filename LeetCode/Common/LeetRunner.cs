namespace LeetCode.Common;

public static class LeetRunner
{
    public static void Run(params Type[] leetTypes)
    {
        foreach (var type in leetTypes)
        {
            if (!typeof(ILeet).IsAssignableFrom(type))
            {
                Console.WriteLine($"{type.Name} does not implement ILeet.");
                continue;
            }
            Console.WriteLine($"Running {type.Name}...");
            if (Activator.CreateInstance(type) is not ILeet instance) continue;
            instance.Execute();
            Console.WriteLine();
        }
    }
    
    public static void Run(Type type, params object[] args)
    {
        if (!typeof(ILeet).IsAssignableFrom(type))
        {
            Console.WriteLine($"{type.Name} does not implement ILeet.");
            return;
        }

        Console.WriteLine($"Running {type.Name}...");
        if (Activator.CreateInstance(type, args) is ILeet instance)
        {
            instance.Execute();
            Console.WriteLine();       
        }
    }
}