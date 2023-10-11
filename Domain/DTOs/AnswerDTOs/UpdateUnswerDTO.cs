namespace Domain.DTOs.AnswerDTOs;

public class UpdateUnswerDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool? Status { get; set; } = false;
    public int QuestionId { get; set; }
}
