namespace Domain
{
    public class StudentTestQuestion
    {
        public int Id { get; set; }
        public string Title { get; set; } =null!;
        public int StudentTestId { get; set; }
        public virtual StudentTest StudentTest { get; set; } =null!;
        public virtual ICollection<StudentTestQuestionAnswer>? Answers { get; set; }
    }
}

