
using AutoMapper;
using Domain.DTOs.CourseDto;
using Domain.DTOs.UserDto;
using Domain.Entities;
using Web;

namespace Infrastructure;

    public class MapperProfile:Profile
    {

    public MapperProfile()
    {
       

        CreateMap<AddUserDto, User>().ReverseMap();
        CreateMap<GetUserDto, User>().ReverseMap();
        CreateMap<AddUserDto, GetUserDto>().ReverseMap();

          

        CreateMap<AddCourseDto,GetCourseDto>().ReverseMap();
        CreateMap<Course, GetCourseDto>().ReverseMap();
       
    } 
}

