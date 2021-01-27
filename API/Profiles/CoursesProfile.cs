using System;
using AutoMapper;

namespace API.Profiles
{
    public class CoursesProfile : Profile
    {
        public CoursesProfile()
        {
            CreateMap<CourseLibrary.API.Entities.Course, Models.CourseDTO>();
        }
    }
}
