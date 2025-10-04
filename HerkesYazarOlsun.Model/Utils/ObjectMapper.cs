using AutoMapper;

namespace HerkesYazarOlsun.Model.Utils
{
    public static class ObjectMapper
    {
        public static TDto Map<TEntity, TDto>(TEntity entity)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TDto>();
                cfg.CreateMap<TDto, TEntity>(); // ters map desteği
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<TDto>(entity);
        }

        public static TDto Map<TEntity, TDto>(TEntity entity, TDto destination)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TDto>();
                cfg.CreateMap<TDto, TEntity>(); // ters map desteği
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map(entity, destination);
        }

        public static List<TDto> MapList<TEntity, TDto>(List<TEntity> entity, List<TDto> destination)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TDto>();
                cfg.CreateMap<TDto, TEntity>(); // ters map desteği
            });

            IMapper mapper = config.CreateMapper();

            foreach (var item in entity)
            {
                destination.Add(mapper.Map<TDto>(item));
            }

            return destination;
        }
    }
}
