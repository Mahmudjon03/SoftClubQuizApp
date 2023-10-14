

namespace Domain
{
    public class GetGroupDto:BaseGroupDto
    {
        public string? CourseName { get; set; } = null;
        public List<GetUserDto>? Students { get; set; }=new();
        public List<GetUserDto>? Mentor { get; set; } = new();
        public List<GetTestDTO>? Test { get; set; } = new();


    }
}
