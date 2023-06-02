class LineExecutor : ILineExecutor
{
    private readonly IEnumerable<ICommand> _supportedCommands;
    private readonly IEmployeesProvider _employeesProvider;

    public LineExecutor(
        IEnumerable<ICommand> supportedCommands,
        IEmployeesProvider employeesProvider)
    {
        _supportedCommands = supportedCommands;
        _employeesProvider = employeesProvider;
    }

    public void ExecuteLine(string line)
    {
        var commandText = line.Split(" ")[0];

        var payload = line.Length != commandText.Length
                ? line[(commandText.Length + 1) ..].Replace(".", ",")
                : string.Empty;

        var command = _supportedCommands.Single(x =>
            string.Equals(x.GetAssignedCommandText(), commandText, StringComparison.InvariantCultureIgnoreCase));

        try
        {
            command.Execute(payload);
            _employeesProvider.SaveChanges();
        }
        catch (Exception x)
        {
            Console.WriteLine("An error occurred while executing the command:");
            Console.WriteLine($"\tCommand: {line}");
            Console.WriteLine($"\tErrorMessage: {x.Message}");
        }
    }
}
