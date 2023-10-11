using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string CourseFoto { get; set; }
        public List<Group> Group { get; set; }

     
    }
}
