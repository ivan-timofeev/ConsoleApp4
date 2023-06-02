interface ICommand
{
    string GetAssignedCommandText();
    void Execute(string payload);
}
