using Domain.DTOs.CourseDto;
using Domain.DTOs.UserDto;
using Domain.Wapper;

namespace Infrastructure.Servises.CourseServises;

    public interface ICourseServise
    {
        Task<Response<List<GetCourseDto>>> GetCourse();
        Task<Response<GetCourseDto>> AddCourse(AddCourseDto user);
        Task<Response<GetCourseDto>> UpdateUser(AddCourseDto user);
        Task<Response<GetCourseDto>> DeleteUser(int id);
        Task<Response<GetCourseDto>> GetUserById(int id);

    }

