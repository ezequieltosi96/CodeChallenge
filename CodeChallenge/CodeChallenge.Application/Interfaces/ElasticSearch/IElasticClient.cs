using CodeChallenge.Domain.Base;

namespace CodeChallenge.Application.Interfaces.ElasticSearch
{
    public interface IElasticClient
    {
        void IndexDocument<T>(T entity, string index = null) where T : EntityBase;

        void UpdateDocument<T>(T entity, string index = null) where T : EntityBase;
    }
}
