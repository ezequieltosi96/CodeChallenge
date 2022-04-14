using CodeChallenge.Domain.Base;
using System.Collections.Generic;

namespace CodeChallenge.Application.Interfaces.Services.Base
{
    public interface IServiceBase<T> where T : EntityBase
    {
        int Create(T entity);

        int Modify(T entity);

        IList<T> GetAll();
    }
}
