public static class QuestionMappers
{
  public static QuestionDto ToQuestionDto(this QuestionT question)
  {
    return new QuestionDto
    {
      Id = question.Id,
      CorrectAnswer = question.CorrectAnswer,
      Options = question.Options,
      Question = question.Question,
      Mark = question.Mark,
      Level = question.Level
    };
  }
  public static QuestionT ToQuestionFromCreate(this CreateQuestionDto question)
  {
    return new QuestionT
    {
      CorrectAnswer = question.CorrectAnswer,
      Options = question.Options,
      Question = question.Question,
      Mark = question.Mark,
      Level = question.Level
    };
  }

  public static QuestionT ToQuestionFromUpdate(this UpdateQuestionDto updated)
  {
    return new QuestionT
    {
      CorrectAnswer = updated.CorrectAnswer,
      Mark = updated.Mark,
      Options = updated.Options,
      Question = updated.Question,
      Level = updated.Level
    };
  }
}