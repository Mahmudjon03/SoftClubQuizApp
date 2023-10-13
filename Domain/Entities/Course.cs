using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Course
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [MaxLength(100)]
        public string? CourseFoto { get; set; }
        public virtual List<Group>? Group { get; set; }

     
    }
}
