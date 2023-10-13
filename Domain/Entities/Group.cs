namespace Domain
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public int CourseId { get; set; }
        public virtual Course Course { get; set; } 
        public virtual ICollection<UserGroup> userGroup { get; set; } 

    }
}
