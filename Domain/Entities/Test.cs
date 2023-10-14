namespace Domain
{
    public class Test
    {
        public int Id { get; set; }
        [MaxLength(15)]
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
        public virtual List<Question>? Questions { get; set; }
        public int MentorId { get; set; }
        public virtual User Mentor { get; set; } = null!;
    }
}

