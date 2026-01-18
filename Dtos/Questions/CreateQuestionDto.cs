public class CreateQuestionDto
{
  public int Id { get; set; }
  public string? Question { get; set; }
  public string? CorrectAnswer { get; set; }
  public QuestionLevel Level { get; set; }
  public List<string>? Options { get; set; }
  public int Mark { get; set; }
}