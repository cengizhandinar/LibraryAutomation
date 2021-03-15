using System;
using AutoMapper;
using Library.Core.Enum;
using Library.Entities.Entities.Concrete;
using Library.Entities.Entities.Dtos.UserDto;
using Library.Entities.Entities.Dtos.BookDto;
using Library.Entities.Entities.Dtos.WriterDto;
using Library.Entities.Entities.Dtos.ContactDto;
using Library.Entities.Entities.Dtos.CategoryDto;
using Library.Entities.Entities.Dtos.CommentDto;
using Library.Entities.Entities.Dtos.PublisherDto;
using Library.Entities.Entities.Dtos.UserBookDto;
using Library.Entities.Entities.Dtos.FavoriteBookDto;
using Library.Entities.Entities.Dtos.BookCategoryDto;

namespace Library.Services.AutoMapper
{
    public class EntityProfiles : Profile
    {
        public EntityProfiles()
        {
            CreateMap<User, UserAddDto>().ReverseMap()
                .ForMember(dest => dest.CreatedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.UpdatedDate,
                    opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<User, UserGetDto>().ReverseMap()
                .ForMember(dest => dest.UpdatedDate,
                    opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<User, UserUpdateDto>().ReverseMap()
                .ForMember(dest => dest.UpdatedDate,
                opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<UserBook, UserBookAddDto>().ReverseMap()
                .ForMember(dest => dest.LendDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.BookStatus,
                opt => opt.MapFrom(x => BookStatus.Reading));
            CreateMap<UserBook, UserBookUpdateDto>().ReverseMap()
                .ForMember(dest => dest.ReceiveDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.BookStatus,
                    opt => opt.MapFrom(x => BookStatus.Read));
            CreateMap<Book, BookAddDto>().ReverseMap()
                .ForMember(dest => dest.CreatedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.UpdatedDate,
                    opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Book, BookUpdateDto>().ReverseMap()
                .ForMember(dest => dest.UpdatedDate,
                    opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Comment, CommentAddDto>().ReverseMap()
                .ForMember(dest => dest.CreatedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.UpdatedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.GeneralStatus,
                    opt => opt.MapFrom(x => GeneralStatus.WaitingApproval));
            CreateMap<Comment, CommentUpdateDto>().ReverseMap()
                .ForMember(dest => dest.UpdatedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.GeneralStatus,
                    opt => opt.MapFrom(x => GeneralStatus.WaitingApproval));
            CreateMap<Contact, ContactAddDto>().ReverseMap()
                .ForMember(dest => dest.CreatedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.UpdatedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.GeneralStatus,
                    opt => opt.MapFrom(x => GeneralStatus.Active));
            CreateMap<Category, CategoryAddDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();
            CreateMap<Publisher, PublisherAddDto>().ReverseMap();
            CreateMap<Publisher, PublisherUpdateDto>().ReverseMap();
            CreateMap<Writer, WriterAddDto>().ReverseMap();
            CreateMap<Writer, WriterUpdateDto>().ReverseMap();
            CreateMap<BookCategory, BookCategoryAddDto>().ReverseMap();
            CreateMap<FavoriteBook, FavoriteBookAddDto>().ReverseMap();
        }
    }
}
