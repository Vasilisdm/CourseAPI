using System;
using API.Models;
using AutoMapper;
using CourseLibrary.API.Entities;

namespace API.Profiles
{
    public class CoursesProfile : Profile
    {
        public CoursesProfile()
        {
            CreateMap<Course, CourseDTO>();
            CreateMap<CourseForCreationDTO, Course>();
            CreateMap<CourseForUpdateDTO, Course>();
        }
    }
}
