using Microsoft.EntityFrameworkCore;

public class QuestionRepo : IQuestionRepo
{
  private readonly AppDbContext _context;
  public QuestionRepo(AppDbContext context)
  {
    _context = context;
  }

  public async Task<QuestionT> CreateAsync(CreateQuestionDto question)
  {
    if (question == null) return null;
    await _context.Questions.AddAsync(question.ToQuestionFromCreate());
    await _context.SaveChangesAsync();
    return question.ToQuestionFromCreate();
  }

  public async Task<QuestionT> DeleteAsync(int id)
  {
    var question = await _context.Questions.FirstOrDefaultAsync(
      x => x.Id == id
    );
    if (question == null) return null;
    _context.Remove(question);
    await _context.SaveChangesAsync();
    return question;
  }

  public async Task<List<QuestionT>> GetAllAsync(QueryObject query)
  {
    var questions = _context.Questions
    .AsQueryable();
    if (query.Level.HasValue)
    {
      questions = questions.Where(q =>
       q.Level == query.Level.Value
      );
    }
    return await questions.ToListAsync();
  }

  public async Task<QuestionT> GetByIdAsync(int id)
  {
    var question = await _context.Questions.FirstOrDefaultAsync(x => x.Id == id);
    if (question == null) return null;
    return question;
  }

  public async Task<QuestionT> UpdateAsync(int id, UpdateQuestionDto updatedQuestion)
  {
    var question = await _context.Questions.FirstOrDefaultAsync(x => x.Id == id);
    if (question == null) return null;
    question.CorrectAnswer = updatedQuestion.CorrectAnswer;
    question.Level = updatedQuestion.Level;
    question.Options = question.Options;
    question.Question = updatedQuestion.Question;
    question.Mark = updatedQuestion.Mark;
    await _context.SaveChangesAsync();
    return question;
  }
}