
using AutoMapper;
using Domain.DTOs.AnswerDTOs;
using Domain.DTOs.CourseDto;
using Domain.DTOs.QuestionDTOs;
using Domain.DTOs.TestDTOs;
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


        CreateMap<Test, AddTestDTO>().ReverseMap();
        CreateMap<Test, UpdateTestDTO>().ReverseMap();

        CreateMap<Question, AddQuestionDTO>().ReverseMap();
        CreateMap<Question, UpdateQuestionDTO>().ReverseMap();

        CreateMap<Answer, AddAnswerDTO>().ReverseMap();
        CreateMap<Answer, UpdateUnswerDTO>().ReverseMap();
    } 
}

