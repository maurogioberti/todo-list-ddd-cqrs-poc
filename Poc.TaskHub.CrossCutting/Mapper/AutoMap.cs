using AutoMapper;

namespace Poc.TaskHub.CrossCutting.Mapper
{
    /// <summary>
    /// The AutoMap class provides methods for mapping objects of one type to objects of another type.
    /// It uses AutoMapper under the hood to handle the actual mapping process. This class abstracts
    /// away the complexities of configuring AutoMapper and provides a simple, straightforward interface
    /// for object-to-object mapping. It supports both individual objects and collections of objects.
    /// </summary>
    public static class AutoMap
    {
        /// <summary>
        /// Generates a simple mapping from a source to a destination.
        /// </summary>
        /// <typeparam name="TSource">Origin source class</typeparam>
        /// <typeparam name="TDestination">Destination class</typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            var mapper = CreateMapper<TSource, TDestination>();
            return mapper.Map<TSource, TDestination>(source);
        }

        /// <summary>
        /// Generates a simple mapping from a source collection to a destination collection.
        /// </summary>
        /// <typeparam name="TSource">Origin source class</typeparam>
        /// <typeparam name="TDestination">Destination class</typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source)
        {
            if (source == null || !source.Any())
                return new List<TDestination>();

            var mapper = CreateMapper<TSource, TDestination>();
            var destinations = source.Select(x => mapper.Map<TSource, TDestination>(x));
            return destinations;
        }

        private static IMapper CreateMapper<TSource, TDestination>()
        {
            var configuration = SetupConfiguration<TSource, TDestination>();
            var mapper = configuration.CreateMapper();
            return mapper;
        }

        private static MapperConfiguration SetupConfiguration<TSource, TDestination>()
            => new(cfg => cfg.CreateMap<TSource, TDestination>());
    }
}