namespace Domain;

public class GetTestDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<GetQuestionDTO>? Questions { get; set; }
}
