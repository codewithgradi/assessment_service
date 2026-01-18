public interface IQuestionRepo
{
  Task<List<QuestionT>> GetAllAsync(QueryObject query);
  Task<QuestionT> GetByIdAsync(int id);
  Task<QuestionT> CreateAsync(CreateQuestionDto question);
  Task<QuestionT> UpdateAsync(int id, UpdateQuestionDto question);
  Task<QuestionT> DeleteAsync(int id);

}