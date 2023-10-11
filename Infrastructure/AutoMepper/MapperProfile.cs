
using AutoMapper;
using Domain.DTOs.CourseDto;
using Domain.DTOs.GroupDto;
using Domain.DTOs.UserDto;
using Domain.Entities;
using Web;

namespace Infrastructure;

    public class MapperProfile:Profile
    {

    public MapperProfile()
    {
       

        CreateMap<AddUserDto, User>().ReverseMap();
        CreateMap<User, GetUserDto>()
            .ForMember(gu => gu.Type, opt => opt.MapFrom(u => u.Type.ToString()))
            .ForMember(gu => gu.GroupName, opt => opt.MapFrom(u => u.UserGroup.Select(g => g.Group.Name)));
        CreateMap<AddUserDto, GetUserDto>().ReverseMap();

          

        CreateMap<AddCourseDto,GetCourseDto>().ReverseMap();
        CreateMap<Course, GetCourseDto>().ReverseMap();

        CreateMap<Group, GetGroupDto>()
            .ForMember(gg => gg.CourseName, opt => opt.MapFrom(g => g.Course.Name)); 
        CreateMap<AddGroupDto,Group>().ReverseMap();
        CreateMap<AddGroupDto, GetGroupDto>().ReverseMap();



    }
}

