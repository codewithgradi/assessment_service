public interface IAssessmentRepo
{
  Task<List<Assessment>> GetAllAsync(QueryObject query);
  Task<Assessment> GetOneAsync(int id);
  Task<Assessment> DeleteAsync(int id);
  Task<Assessment> CreateAsync(CreateAssessmentDto assesment);
  Task<bool> AssessmentExists(int id);
}