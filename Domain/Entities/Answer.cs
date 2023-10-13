
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(300)]
        public string Name { get; set; }
        public bool Status { get; set; } = false;
        [ForeignKey("Question")]
        public int QuestionId  { get; set; }
        public Question Question  { get; set; }
    }
}
