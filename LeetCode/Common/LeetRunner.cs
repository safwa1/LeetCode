using static System.Console;

namespace LeetCode.Common;

public static class LeetRunner
{
    public static void Run(params Type[] leetTypes)
    {
        foreach (var type in leetTypes)
        {
            if (!type.IsAssignableFrom<ILeet>())
            {
                WriteLine($"{type.Name} does not implement ILeet.");
                continue;
            }
            
            WriteLine($"Running {type.Name}...");
            if (type.NewInstance() is not ILeet instance) continue;
            instance.Execute();
            WriteLine();
        }
    }
    
    public static void Run(Type type, params object[] args)
    {
        if (!type.IsAssignableFrom<ILeet>())
        {
            WriteLine($"{type.Name} does not implement ILeet.");
            return;
        }

        WriteLine($"Running {type.Name}...");
        if (type.NewInstance(args) is not ILeet instance) return;
        instance.Execute();
        WriteLine();
    }
}