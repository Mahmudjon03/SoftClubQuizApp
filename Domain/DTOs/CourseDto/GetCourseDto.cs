namespace Domain
{
    public class GetCourseDto:BaseGroupDto
    {
        public string? CourseFoto { get; set; }
        public List<GetGroupDto> Group { get; set; }
    }
}
