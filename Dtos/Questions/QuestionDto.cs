public class QuestionDto
{
  public int Id { get; set; }
  public string? Question { get; set; }
  public string? CorrectAnswer { get; set; }
  public List<string>? Options { get; set; }
  public QuestionLevel Level { get; set; }

  public int Mark { get; set; }
}