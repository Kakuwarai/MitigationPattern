using Microsoft.EntityFrameworkCore;
using Web_API_Test.Models;

public class PerformanceEvaluationContext : DbContext
{
    public PerformanceEvaluationContext(DbContextOptions<PerformanceEvaluationContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Evaluation> Evaluations { get; set; }
    public DbSet<Kpi> Kpis { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

  /*      modelBuilder.Entity<EvaluationSummary>().HasKey(e => new { e.EmployeeId, e.EvaluationDate });*/

    }
}
