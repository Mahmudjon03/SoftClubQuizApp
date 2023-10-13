namespace Domain
{
    public class AddStudentQuestionAnswerDto
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsSelected { get; set; }
        public int StudentTestQuestionId  { get; set; }
    }
}

