// See https://aka.ms/new-console-template for more information


using ConsoleApp4.Abstractions;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    public static void Main(string[] args)
    {
        var serviceProvider =
            new ServiceCollection()
                .AddSingleton<IEmployeesProvider, EmployeesProvider>()
                .AddTransient<ILineExecutor, LineExecutor>()
                .AddCommands()
                .BuildServiceProvider();

        using var scope = serviceProvider.CreateScope();
        var lineExecutor = scope.ServiceProvider
            .GetRequiredService<ILineExecutor>();

        foreach (var line in args)
        {
            lineExecutor.ExecuteLine(line);
        }
    }
}
