using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(300)]
        public string Name { get; set; } = null!;
        public bool IsCorrect { get; set; }
        [ForeignKey("Question")]
        public int QuestionId  { get; set; }
        public virtual Question Question  { get; set; }=null!;
    }
}