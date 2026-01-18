using Microsoft.EntityFrameworkCore;

public class AssessRepo : IAssessmentRepo
{
  private readonly AppDbContext _context;
  public AssessRepo(AppDbContext context)
  {
    _context = context;
  }
  public async Task<bool> AssessmentExists(int id)
  {

    return await _context.Assessments.AnyAsync(x => x.Id == id);
  }

  public async Task<Assessment> CreateAsync(CreateAssessmentDto assesment)
  {
    if (assesment == null) return null;
    var assesmentDto = assesment.ToAssessentFromCreate();
    await _context.Assessments.AddAsync(assesmentDto);
    await _context.SaveChangesAsync();
    return assesmentDto;
  }

  public async Task<Assessment> DeleteAsync(int id)
  {
    var assesment = await _context.Assessments.FirstOrDefaultAsync(x => x.Id == id);
    if (assesment == null) return null;
    _context.Remove(assesment);
    await _context.SaveChangesAsync();
    return assesment;
  }

  public async Task<List<Assessment>> GetAllAsync(QueryObject query)
  {
    var assesments = _context.Assessments.Include(c => c.Questions).AsQueryable();
    if (!string.IsNullOrWhiteSpace(query.Name))
    {
      assesments = assesments.Where(c => c.Name.Contains(query.Name));
    }
    //Pagination
    var skipNumber = (query.PageNumber - 1) * query.PageSize;

    return await assesments
    .Skip(skipNumber)
    .Take(query.PageSize)
    .ToListAsync();
  }

  public async Task<Assessment> GetOneAsync(int id)
  {
    var assesment = await _context.Assessments.FirstOrDefaultAsync(x => x.Id == id);
    if (assesment == null) return null;
    return assesment;
  }
}