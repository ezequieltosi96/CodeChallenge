namespace CodeChallenge.Application.Interfaces.Mediator.Query
{
    public interface IQueryHandler<TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
