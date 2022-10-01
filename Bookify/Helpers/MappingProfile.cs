using AutoMapper;
using Bookify.Dtos;
using Bookify.Models;
using Bookify.Models.Identity;
using Bookify.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Bookify.Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Genre, GenreDto>();
        CreateMap<UserDto, User>()
            .ForMember(u => u.DisplayName, o => o.MapFrom(u => u.DisplayName))
            .ReverseMap();
        CreateMap<Review, ReviewDto>()
            .ForMember(r => r.User, o => o.MapFrom(r => r.User.DisplayName));
        CreateMap<Book, BookDto>()
            .ForMember(b => b.Author, o => o.MapFrom(b => (b.Author.FirstName + " " +  b.Author.LastName)))
            .ForMember(b => b.BookSoldCopies, o => o.MapFrom(b => b.BookSoldCopies.SoldCopies));
        CreateMap<IdentityRole, IdentityRoleDto>()
            .ForMember(r => r.Name, o => o.MapFrom(r => r.Name));
        CreateMap<AddUserViewModel, User>().ReverseMap();
        CreateMap<AddGenreViewModel, Genre>().ReverseMap();
        CreateMap<AddAuthorViewModel,Author>().ReverseMap();
        CreateMap<OrderDto, Order>()
            .ReverseMap()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

    }
}