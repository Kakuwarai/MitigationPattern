using Web_API_Test.Models;

namespace Web_API_Test.Repository
{
    public interface ISummaryRepository : IRepository<EvaluationSummary>
    {
        Task<EvaluationSummary?> EvaluationSummaries(int Id);
    }
}
