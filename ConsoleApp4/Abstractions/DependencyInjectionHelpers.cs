using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp4.Abstractions;

public static class DependencyInjectionHelpers
{
    public static IServiceCollection AddCommands(this IServiceCollection services)
    {
        var types = typeof(ICommand).Assembly.GetTypes();

        foreach (var type in types)
        {
            if (type.IsAssignableTo(typeof(ICommand))
                && type != typeof(ICommand))
            {
                services.AddTransient(typeof(ICommand), type);
            }
        }

        return services;
    }
}
