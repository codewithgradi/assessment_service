using System.ComponentModel.DataAnnotations;

public class CreateQuestionDto
{
  public int Id { get; set; }
  [Required]
  public string? Question { get; set; }
  [Required]
  public string? CorrectAnswer { get; set; }
  [Required]
  public QuestionLevel Level { get; set; }
  public List<string>? Options { get; set; }
  public int Mark { get; set; }
}