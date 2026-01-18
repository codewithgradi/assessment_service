public class Assessment
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public List<QuestionT>? Questions { get; set; }
  public int MaxMark { get; set; }
}