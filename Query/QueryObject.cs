public class QueryObject
{
  public string Name { get; set; } = null;
  public int PageNumber { get; set; } = 1;
  public int PageSize { get; set; } = 5;
  public QuestionLevel? Level { get; set; } = QuestionLevel.EASY;
}