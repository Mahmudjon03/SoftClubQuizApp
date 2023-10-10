
using Microsoft.AspNetCore.Http;

namespace Domain.DTOs.CourseDto
{
    public class AddCourseDto:BaseCourseDto
    {
      public IFormFile CourseFoto { get; set; }

    }
}
