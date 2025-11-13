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
                    
                    //.AfterMap((src, dest) =>
                    //{
                    //    Eğer hedefte BooksPageList doluysa
                    //    if (src.BooksPageList != null)
                    //    {
                    //        foreach (var page in src.BooksPageList)
                    //        {
                    //            Kaynak kitap ID'sini kullanarak BooksId doldur
                    //            page.BookId = src.ID;
                    //        }
                    //    }
                    //})
                    .ReverseMap();
                    //ForMember(dest => dest.Yazar, opt => opt.Ignore())
                    //.ForMember(dest => dest.Categori, opt => opt.Ignore())
                    //.ForMember(dest => dest.BooksPageList, opt => opt.Ignore())
                    //.ForMember(dest => dest.BooksComments, opt => opt.Ignore())
                    //.ForMember(dest => dest.BooksDegerlendirme, opt => opt.Ignore())
                    //.ForMember(dest => dest.BooksStars, opt => opt.Ignore())
                    //.ForMember(dest => dest.FavoriBooks, opt => opt.Ignore()); // ters map

                cfg.CreateMap<VM_WriterFollow, WriterFollow>().ReverseMap();
                cfg.CreateMap<VM_ODEME_SPONSORLARI, OdemeSponsorlari>().ReverseMap();
                cfg.CreateMap<VM_ODEME, Odeme>().ReverseMap();
                cfg.CreateMap<VM_CAROUSEL_DUYURU, CarouselDuyuru>().ReverseMap();
                cfg.CreateMap<VM_AYARLAR, Ayarlar>().ReverseMap();
                

                cfg.CreateMap<VM_KARTLAR, Kartlar>().ReverseMap();
                cfg.CreateMap<VM_WriterStars, WriterStars>().ReverseMap();

                cfg.CreateMap<VM_WriterStars, WriterStars>().ReverseMap();
                cfg.CreateMap<VM_TALEPLER, Talepler>().ReverseMap();
                cfg.CreateMap<VM_TALEPLER, Talepler>().ReverseMap();


                cfg.CreateMap<VM_PROFILE, Profile>().ReverseMap();

                cfg.CreateMap<VM_PROFILE, Profile>().ReverseMap();


                cfg.CreateMap<VM_SPONSORLAR, Sponsorlar>().ReverseMap();

                cfg.CreateMap<VM_FAVORI_YAZARLAR, FavoriYazarlar>().ReverseMap();

                // Users -> VM_USERS
                cfg.CreateMap<VM_USERS, Users>().ReverseMap();

                // VM_USERS -> Users
                cfg.CreateMap<Users, VM_USERS>().ReverseMap();

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
