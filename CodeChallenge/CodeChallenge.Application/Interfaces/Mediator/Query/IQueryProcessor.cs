namespace CodeChallenge.Application.Interfaces.Mediator.Query
{
    public interface IQueryProcessor
    {
        TResult Process<TResult>(IQuery<TResult> query);
    }
}
