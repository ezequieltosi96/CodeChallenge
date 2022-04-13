namespace CodeChallenge.Application.Interfaces.Mediator.Command
{
    public interface ICommandHandler<TCommand, out TResult> where TCommand : ICommand<TResult>
    {
        TResult Handle(TCommand command);
    }
}
