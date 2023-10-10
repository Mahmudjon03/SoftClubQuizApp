namespace Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CourseFoto { get; set; }
        public List<Group> Group { get; set; }
    }
}
