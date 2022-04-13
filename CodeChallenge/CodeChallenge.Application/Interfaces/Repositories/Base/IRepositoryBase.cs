using CodeChallenge.Domain.Base;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Application.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        IList<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

        T GetById(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        T Update(T entity);

        T Create(T entity);
    }
}
