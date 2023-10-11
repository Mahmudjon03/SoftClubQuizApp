using Domain.DTOs.CourseDto;
using Domain.GetFilter;
using Domain.Wapper;
using Infrastructure.Servises.CourseServises;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("controller")]
    public class CourseController:ControllerBase
    {
        private readonly ICourseServise _course;

        public CourseController(ICourseServise course)
        {
            _course = course;
        }
        [HttpGet("GetCourses")]
        public async Task<PoginationResponse<List<GetCourseDto>>> Get([FromQuery]GetFilter filter) => await _course.GetCourse(filter);
        [HttpGet("GetByIdCourse")]
        public async Task<Response<GetCourseDto>> GetById(int id)=> await _course.GetCourseById(id);
        [HttpDelete("DeleteCourse")]
        public async Task<Response<GetCourseDto>>  Delete(int id)=> await  _course.DeleteCourse(id);
        [HttpPut("UpdateCourse")]
        public async Task<Response<GetCourseDto>> Update([FromForm]AddCourseDto course)=> await _course.UpdateCourse(course);
        [HttpPost("AddCorses")]
        public async Task<Response<GetCourseDto>> AddCourses([FromForm]AddCourseDto course)=> await _course.AddCourse(course);
    }
}
