
using System.ComponentModel.DataAnnotations;

public class CreateAssessmentDto
{
  public int Id { get; set; }
  [Required]
  public string? Name { get; set; }
  [Required]
  public int MaxMark { get; set; }
  public List<QuestionT>? Questions { get; set; }
}