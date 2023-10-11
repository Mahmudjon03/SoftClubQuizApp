
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Question
    {
        public int Id { get; set; }
        [MaxLength(300)]
        public string Title { get; set; }
        public int TestId { get; set; }
        public List<Answer>? Answers { get; set; }
        public Test Test { get; set; }
    }
}
