namespace Domain;

public class GetAnswerDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool? Status { get; set; }
    public int QuestionId { get; set; }
}
