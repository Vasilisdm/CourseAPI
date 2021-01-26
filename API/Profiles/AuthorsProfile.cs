using API.Helpers;
using AutoMapper;

namespace API.Profiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            CreateMap<CourseLibrary.API.Entities.Author, Models.AuthorDTO>()
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")
                ).ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge())
                );
        }
    }
}
