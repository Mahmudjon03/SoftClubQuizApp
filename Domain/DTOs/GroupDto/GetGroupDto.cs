

namespace Domain
{
    public class GetGroupDto:BaseGroupDto
    {
        public string? CourseName { get; set; } = null;
        public List<GetUserDto>? Students { get; set; }=new();
    }
}
