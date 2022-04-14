using CodeChallenge.Cross.Constants;
using CodeChallenge.Domain.Base;
using Nest;
using System;

namespace CodeChallenge.Tools.ElasticSearch
{
    public class ElasticClient : Application.Interfaces.ElasticSearch.IElasticClient
    {
        private readonly Nest.ElasticClient _client;
        private readonly string _defaultIndex;

        public ElasticClient()
        {
            //var uri = Environment.GetEnvironmentVariable(EnvironmentKeys.KEY_ELASTIC_SEARCH_URI);
            //_defaultIndex = Environment.GetEnvironmentVariable(EnvironmentKeys.KEY_ELASTIC_SEARCH_DEFAULT_INDEX);
            _defaultIndex = "permissions";

            var settings = new ConnectionSettings(new Uri("http://es:9200")).DefaultIndex(_defaultIndex);

            _client = new Nest.ElasticClient(settings);
        }

        public void IndexDocument<T>(T entity, string index = null) where T : EntityBase
        {
            if (string.IsNullOrEmpty(index))
            {
                index = _defaultIndex;
            }

            CreateIndexIfNotExist<T>(index);

            _client.IndexDocument(entity);
        }

        public void UpdateDocument<T>(T entity, string index = null) where T : EntityBase
        {
            if (string.IsNullOrEmpty(index))
            {
                index = _defaultIndex;
            }

            _client.Update<T, T>(entity.Id, u => u.Index(index).Doc(entity));
        }

        private void CreateIndexIfNotExist<T>(string index) where T : EntityBase
        {
            if (!_client.Indices.Exists(index).Exists)
            {
                _client.Indices.Create(index, i => i.Map<T>(x => x.AutoMap()));
            }
        }
    }
}
