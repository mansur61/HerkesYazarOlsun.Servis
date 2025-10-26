using AutoMapper;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.Model.Utils
{
    public static class ObjectMapper
    {
        private static readonly IMapper _mapper;

        static ObjectMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Books -> VM_BOOKS mapping
                cfg.CreateMap<Books, VM_BOOKS>()
                    .ForMember(dest => dest.Categori, opt => opt.MapFrom(src => src.Categori))
                    .ForMember(dest => dest.BooksPageList, opt => opt.MapFrom(src => src.BooksPageList))
                    .ForMember(dest => dest.BooksComments, opt => opt.MapFrom(src => src.BooksComments))
                    .ForMember(dest => dest.BooksDegerlendirme, opt => opt.MapFrom(src => src.BooksDegerlendirme))
                    .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Yazar))
                    .ForMember(dest => dest.BooksStars, opt => opt.MapFrom(src => src.BooksStars))
                    .ForMember(dest => dest.FavoriBooks, opt => opt.MapFrom(src => src.FavoriBooks))
                    .ReverseMap(); // ters map

                // Category -> VM_CATEGORI
                cfg.CreateMap<Category, VM_CATEGORI>().ReverseMap();

                // BooksStars -> VM_BOOK_STAR
                cfg.CreateMap<BooksStars, VM_BOOK_STAR>().ReverseMap();

                // FavoriBooks -> VM_FAVORI_BOOK
                cfg.CreateMap<FavoriBooks, VM_FAVORI_BOOK>().ReverseMap();

                // BooksPages -> VM_BOOKS_PAGES
                cfg.CreateMap<BooksPages, VM_BOOKS_PAGES>().ReverseMap();

                // BooksComment -> VM_BOOKS_COMMENT
                cfg.CreateMap<BooksComment, VM_BOOKS_COMMENT>().ReverseMap();

                // BooksDegerlendirme -> VM_BOOKS_DEGERLENDIRME
                cfg.CreateMap<BooksDegerlendirme, VM_BOOKS_DEGERLENDIRME>().ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

        public static TDto Map<TEntity, TDto>(TEntity entity)
        {
            return _mapper.Map<TDto>(entity);
        }

        public static TDto Map<TEntity, TDto>(TEntity entity, TDto destination)
        {
            return _mapper.Map(entity, destination);
        }

        public static List<TDto> MapList<TEntity, TDto>(List<TEntity> entity, List<TDto> destination)
        {
            foreach (var item in entity)
            {
                destination.Add(_mapper.Map<TDto>(item));
            }
            return destination;
        }
    }
}
