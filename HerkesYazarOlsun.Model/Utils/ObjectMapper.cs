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
                    
                    .ReverseMap();

                
                 cfg.CreateMap<UsersDetails, UsersDetails>()
               .ForAllMembers(opt =>
                   opt.Condition((src, dest, srcMember, destMember) =>
                   {
                       // Sistem alanlarını atla
                       if (opt.DestinationMember.Name == nameof(NewBaseEntity.ID) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.CREATE_AT) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.MODIFIED_AT) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.USER_CREATED_ID) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.USER_MODIFIED_ID) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.OLUSTURAN_EMAIL) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.USER_MODIFIED_MAIL) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.IS_DELETED) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.IS_MODIFIED))
                       {
                           return false;
                       }

                       // srcMember null değilse ve string ise boş string değilse
                       if (srcMember is string str)
                           return !string.IsNullOrWhiteSpace(str);

                       // nullable değer tipleri için null kontrolü
                       if (srcMember == null)
                           return false;

                       // diğer durumlarda (int, bool vb.) src değerini al
                       return true;
                   }));
                

                cfg.CreateMap<Bildirimler, Bildirimler>()
               .ForAllMembers(opt =>
                   opt.Condition((src, dest, srcMember, destMember) =>
                   {
                       // Sistem alanlarını atla
                       if (opt.DestinationMember.Name == nameof(NewBaseEntity.ID) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.CREATE_AT) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.MODIFIED_AT) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.USER_CREATED_ID) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.USER_MODIFIED_ID) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.OLUSTURAN_EMAIL) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.USER_MODIFIED_MAIL) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.IS_DELETED) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.IS_MODIFIED))
                       {
                           return false;
                       }

                       // srcMember null değilse ve string ise boş string değilse
                       if (srcMember is string str)
                           return !string.IsNullOrWhiteSpace(str);

                       // nullable değer tipleri için null kontrolü
                       if (srcMember == null)
                           return false;

                       // diğer durumlarda (int, bool vb.) src değerini al
                       return true;
                   }));

                cfg.CreateMap<Users, Users>()
               .ForAllMembers(opt =>
                   opt.Condition((src, dest, srcMember, destMember) =>
                   {
                       // Sistem alanlarını atla
                       if (opt.DestinationMember.Name == nameof(NewBaseEntity.ID) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.CREATE_AT) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.MODIFIED_AT) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.USER_CREATED_ID) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.USER_MODIFIED_ID) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.OLUSTURAN_EMAIL) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.USER_MODIFIED_MAIL) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.IS_DELETED) ||
                           opt.DestinationMember.Name == nameof(NewBaseEntity.IS_MODIFIED))
                       {
                           return false;
                       }

                       // srcMember null değilse ve string ise boş string değilse
                       if (srcMember is string str)
                           return !string.IsNullOrWhiteSpace(str);

                       // nullable değer tipleri için null kontrolü
                       if (srcMember == null)
                           return false;

                       // diğer durumlarda (int, bool vb.) src değerini al
                       return true;
                   }));

                cfg.CreateMap<Profile, Profile>()
            .ForAllMembers(opt =>
                opt.Condition((src, dest, srcMember, destMember) =>
                {
                    // Sistem alanlarını atla
                    if (opt.DestinationMember.Name == nameof(NewBaseEntity.ID) ||
                        opt.DestinationMember.Name == nameof(NewBaseEntity.CREATE_AT) ||
                        opt.DestinationMember.Name == nameof(NewBaseEntity.MODIFIED_AT) ||
                        opt.DestinationMember.Name == nameof(NewBaseEntity.USER_CREATED_ID) ||
                        opt.DestinationMember.Name == nameof(NewBaseEntity.USER_MODIFIED_ID) ||
                        opt.DestinationMember.Name == nameof(NewBaseEntity.OLUSTURAN_EMAIL) ||
                        opt.DestinationMember.Name == nameof(NewBaseEntity.USER_MODIFIED_MAIL) ||
                        opt.DestinationMember.Name == nameof(NewBaseEntity.IS_DELETED) ||
                        opt.DestinationMember.Name == nameof(NewBaseEntity.IS_MODIFIED))
                    {
                        return false;
                    }

                    // srcMember null değilse ve string ise boş string değilse
                    if (srcMember is string str)
                        return !string.IsNullOrWhiteSpace(str);

                    // nullable değer tipleri için null kontrolü
                    if (srcMember == null)
                        return false;

                    // diğer durumlarda (int, bool vb.) src değerini al
                    return true;
                }));


                cfg.CreateMap<VM_WriterFollow, WriterFollow>().ReverseMap();
                cfg.CreateMap<VM_ODEME_SPONSORLARI, OdemeSponsorlari>().ReverseMap();
                cfg.CreateMap<VM_ODEME, Odeme>().ReverseMap();
                cfg.CreateMap<VM_CAROUSEL_DUYURU, CarouselDuyuru>().ReverseMap();
                cfg.CreateMap<VM_AYARLAR, Ayarlar>().ReverseMap();
                

                cfg.CreateMap<VM_KARTLAR, Kartlar>().ReverseMap();
                cfg.CreateMap<VM_WriterStars, WriterStars>().ReverseMap();

                cfg.CreateMap<VM_WriterStars, WriterStars>().ReverseMap();
                cfg.CreateMap<VM_TALEPLER, Talepler>().ReverseMap(); 


                cfg.CreateMap<HerkesYazarOlsun.Model.ViewModel.VM_PROFILE, HerkesYazarOlsun.Model.Entity.Profil>()
                    .ReverseMap();

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
