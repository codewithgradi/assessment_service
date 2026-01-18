using System.ComponentModel.DataAnnotations.Schema;

public class QuestionT
{
  public int Id { get; set; }
  public string? Question { get; set; }
  public string? CorrectAnswer { get; set; }
  public List<string>? Options { get; set; }
  public int Mark { get; set; }

  public QuestionLevel Level { get; set; }

  [ForeignKey("Assessment")]
  public int AssessmentId { get; set; }
}
public enum QuestionLevel
{
  EASY,
  MEDIUM,
  HARD,
}