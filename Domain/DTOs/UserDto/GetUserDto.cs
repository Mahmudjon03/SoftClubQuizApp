using Domain.Enums;

namespace Domain.DTOs.UserDto
{
    public class GetUserDto:BaseUserDto
    {
        public string Type { get; set; }
        public string GroupName { get; set; }
    }
}
