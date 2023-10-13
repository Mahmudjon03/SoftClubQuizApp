namespace Domain
{
    public class AddStudentTestQuestionDto
    {
        public int Id { get; set; }
        public string Title { get; set; } =null!;
        public int StudentTestId { get; set; }
        public List<AddStudentQuestionAnswerDto>? AnswerDtos { get; set; }
    }
}


