public class CreateAssessmentDto
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public int MaxMark { get; set; }
  public List<QuestionT>? Questions { get; set; }
}