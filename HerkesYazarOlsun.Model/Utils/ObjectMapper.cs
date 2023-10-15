using AutoMapper;
namespace HerkesYazarOlsun.Model.Utils
{
    public static class ObjectMapper
    {
        public static TDto Map<TEntity, TDto>(TEntity entity)
        {
            //Create a map
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TDto>();
            });

            IMapper mapper = config.CreateMapper();

            //Use the created map
            var dest = mapper.Map<TEntity, TDto>(entity);
            return dest;
        }

        public static TDto Map<TEntity, TDto>(TEntity entity, TDto destination)
        {
            //Create a map
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TDto>();
            });

            IMapper mapper = config.CreateMapper();

            //Use the created map
            var dest = mapper.Map<TEntity, TDto>(entity, destination);
            return dest;
        }

        public static List<TDto> MapList<TEntity, TDto>(List<TEntity> entity, List<TDto> destination)
        {
            foreach (var item in entity)
            {
                destination.Add(Map<TEntity, TDto>(item));
            }
            //Create a map
            return destination;
        }
    }
}
