using Microsoft.AspNetCore.Http;

namespace Domain
{
    public class AddCourseDto:BaseGroupDto
    {
      public IFormFile ?CourseFoto { get; set; }

    }
}
