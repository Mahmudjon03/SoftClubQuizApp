
using Domain.DTOs.UserDto;

namespace Domain.DTOs.GroupDto
{
    public class GetGroupDto:BaseCourseDto
    {
        public string? CourseName { get; set; } = null;
        public List<GetUserDto>? Users { get; set; }=new();
    }
}
