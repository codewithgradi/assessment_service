using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions options) : base(options)
  {

  }
  public DbSet<QuestionT> Questions { get; set; }
  public DbSet<Assessment> Assessments { get; set; }
}
