public static class AssessmentMappers
{
  public static AssessmentDto ToAssessmentDto(this Assessment assessment)
  {
    return new AssessmentDto
    {
      Id = assessment.Id,
      MaxMark = assessment.MaxMark,
      Name = assessment.Name,
      Questions = assessment.Questions
    };
  }

  public static Assessment ToAssessentFromCreate(this CreateAssessmentDto assessment)
  {
    return new Assessment
    {
      Id = assessment.Id,
      MaxMark = assessment.MaxMark,
      Name = assessment.Name,
      Questions = assessment.Questions,
    };
  }
}