namespace Domain.DTOs.AnswerDTOs;

public class AddAnswerDTO
{
    public string Name { get; set; }
    public bool? Status { get; set; } = false;
    public int QuestionId { get; set; }
}
