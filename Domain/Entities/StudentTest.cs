namespace Domain
{
    public class StudentTest
    {
        public int Id { get; set; }
        public int StudentId { get; set; }        
        public virtual User Student  { get; set; }=null!;
        public int TestId { get; set; }
        public virtual Test Test { get; set; }=null!;
    }
}

