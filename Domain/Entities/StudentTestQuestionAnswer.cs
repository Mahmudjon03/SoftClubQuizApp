namespace Domain
{
    public class StudentTestQuestionAnswer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(300)]
        public string Name { get; set; } = null!;
        public StudentTestResponse StudentTestResponse  { get; set; }
        public bool IsSelected { get; set; }
        public bool IsCorrect { get; set; }
        public int StudentTestQuestionId  { get; set; }
        public virtual StudentTestQuestion StudentTestQuestion  { get; set; }= null!;
    }
    public enum StudentTestResponse
    {
        Correct=1,
        InCorrect = 2
    }
}

