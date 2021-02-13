using API.Helpers;
using API.Models;
using AutoMapper;
using CourseLibrary.API.Entities;

namespace API.Profiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            CreateMap<Author, AuthorDTO>()
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")
                ).ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge())
                );

            CreateMap<AuthorForCreationDTO, Author>();
        }
    }
}
