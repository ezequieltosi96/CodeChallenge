using AutoMapper;
using CodeChallenge.Application.Interfaces.Mapping;

namespace CodeChallenge.Tools.Automapper
{
    public class Mapping : IMapping
    {
        private readonly IMapper _mapper;

        public Mapping(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map<TSource, TDestination>(source, destination);
        }
    }
}
