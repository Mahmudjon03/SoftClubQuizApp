using System.Text.Json.Serialization;

namespace Domain
{
    public class AddStudentTestDto
    {
        [JsonIgnore]
        public int StudentId { get; set; }
        public int TestId { get; set; }
        public List<AddStudentTestQuestionDto>? QuestionDtos { get; set; }
    }
}


