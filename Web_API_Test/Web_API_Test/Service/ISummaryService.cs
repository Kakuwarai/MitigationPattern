using Web_API_Test.Models;

namespace Web_API_Test.Service
{
    public interface ISummaryService
    {
        Task<EvaluationSummary?> EvaluationSummary(int Id);
    }
}
