using AutoMapper;
using Domain;
using Domain.DTOs.GroupDto;
using Domain.Entities;

namespace Infrastructure;

    public class MapperProfile:Profile
    {

    public MapperProfile()
    {
       

        CreateMap<AddUserDto, User>().ReverseMap();
        CreateMap<User, GetUserDto>()
            .ForMember(gu => gu.Type, opt => opt.MapFrom(u => u.UserType.ToString())).
              ForMember(gu => gu.active, opt => opt.MapFrom(u => u.Active.ToString()));


        CreateMap<AddUserDto, GetUserDto>().ReverseMap();

          

        CreateMap<AddCourseDto,GetCourseDto>().ReverseMap();

        CreateMap<Course, GetCourseDto>().ReverseMap();

        CreateMap<Group, GetGroupDto>()
            .ForMember(gg => gg.CourseName, opt => opt.MapFrom(g => g.Course.Name)); 
        CreateMap<AddGroupDto,Group>().ReverseMap();
        CreateMap<AddGroupDto, GetGroupDto>().ReverseMap();

        CreateMap<Test,AddTestDTO>().ReverseMap();
        CreateMap<Test, UpdateTestDTO>().ReverseMap();

        CreateMap<Question, AddQuestionDTO>().ReverseMap();
        CreateMap<Question, UpdateQuestionDTO>().ReverseMap();

        CreateMap<Answer, AddAnswerDTO>().ReverseMap();
        CreateMap<Answer, UpdateUnswerDTO>().ReverseMap();

        CreateMap<AddStudentToGroupDto,UserGroup>().ReverseMap();  
    } 
}


