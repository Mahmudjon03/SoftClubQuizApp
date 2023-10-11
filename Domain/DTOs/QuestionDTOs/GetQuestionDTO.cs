using Domain.DTOs.AnswerDTOs;
using Domain.Entities;

namespace Domain.DTOs.QuestionDTOs;

public class GetQuestionDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public List<GetAnswerDTO>? Answers { get; set; }
}
