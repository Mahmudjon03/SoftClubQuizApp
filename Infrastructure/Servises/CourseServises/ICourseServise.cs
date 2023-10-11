using Domain.DTOs.CourseDto;
using Domain.DTOs.UserDto;
using Domain.GetFilter;
using Domain.Wapper;

namespace Infrastructure.Servises.CourseServises;

    public interface ICourseServise
    {
        Task<PoginationResponse<List<GetCourseDto>>> GetCourse(GetFilter filter);
        Task<Response<GetCourseDto>> AddCourse(AddCourseDto course);
        Task<Response<GetCourseDto>> UpdateCourse(AddCourseDto course);
        Task<Response<GetCourseDto>> DeleteCourse(int id);
        Task<Response<GetCourseDto>> GetCourseById(int id);
}

