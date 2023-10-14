using System.Text.Json.Serialization;

namespace Domain
{
    public class GetExamTestsForUserDto
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public int QuestionCount { get; set; }
        public List<GetExamQuestionsForUserDto> Questions { get; set; } = new();
    }
    public class GetExamQuestionsForUserDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public List<GetExamAnswersForUserDto> Answers { get; set; } = new();
    }
    public class GetExamAnswersForUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsSelected { get; set; }
    }

}


