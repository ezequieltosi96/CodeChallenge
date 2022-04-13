namespace CodeChallenge.Application.Interfaces.Mediator.Command
{
    public interface ICommandProcessor
    {
        TResult Process<TResult>(ICommand<TResult> command);
    }
}
