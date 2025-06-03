using Microsoft.EntityFrameworkCore;
using Web_API_Test.Models;

namespace Web_API_Test.Repository
{
    public class SummaryRepository : Repository<EvaluationSummary>,ISummaryRepository
    {
        private readonly PerformanceEvaluationContext _db;

        public SummaryRepository(PerformanceEvaluationContext context) : base(context)
        {
            _db = context;
        }

        public async Task<EvaluationSummary?> EvaluationSummaries(int Id)
        {
            var employeeEvaluation = await _db.Evaluations
                                    .Where(item => item.EmployeeId.Equals(Id))
                                    .OrderByDescending(item => item.EvaluationDate)
                                    .FirstOrDefaultAsync();
            if(employeeEvaluation == null)
            {
                return null;
            }

            var kpis = await _db.Kpis
                             .Where(item => item.EvaluationId.Equals(employeeEvaluation.Id))
                             .ToListAsync();

            EvaluationSummary evaluationSummary = new EvaluationSummary()
            {
                EmployeeId = Id,
                EvaluationDate = employeeEvaluation.EvaluationDate,
            };
            decimal totalScore = 0m;

            if (kpis.Any())
            {
                totalScore = kpis.Average(k => k.Score);
            }

            evaluationSummary.TotalScore = totalScore;

            return evaluationSummary;

        }
        
    }
}
