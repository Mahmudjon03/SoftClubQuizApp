namespace Domain
{
    public class Question
    {
        public int Id { get; set; }
        [MaxLength(300)]
        public string Title { get; set; } =null!;
        public int TestId { get; set; }
        public virtual Test Test { get; set; } =null!;
         public virtual ICollection<Answer>? Answers { get; set; }
    }
}

