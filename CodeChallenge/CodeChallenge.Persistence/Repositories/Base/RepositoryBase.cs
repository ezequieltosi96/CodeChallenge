using CodeChallenge.Application.Interfaces.Repositories.Base;
using CodeChallenge.Domain.Base;
using CodeChallenge.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Persistence.Repositories.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, 
                               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = _unitOfWork.Context.Set<T>();

            if(include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query.ToList();
        }

        public T GetById(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _unitOfWork.Context.Set<T>();

            if (include != null)
                query = include(query);

            return query.FirstOrDefault(x => x.Id == id);
        }

        public T Update(T entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public T Create(T entity)
        {
            _unitOfWork.Context.Set<T>().Add(entity);

            return entity;
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }
    }
}
