namespace Domain
{
    public class AddStudentTestQuestionDto
    {
        public int Id { get; set; }
        public string Title { get; set; } =null!;
        public List<AddStudentQuestionAnswerDto>? AnswerDtos { get; set; }
    }
}


