using Web_API_Test.Models;
using Web_API_Test.Repository;

namespace Web_API_Test.Service
{
    public class SummaryService : ISummaryService
    {
        private readonly ISummaryRepository _summaryRepository;

        public SummaryService(ISummaryRepository summaryRepository)
        {
            _summaryRepository = summaryRepository;
        }

        public async Task<EvaluationSummary?> EvaluationSummary(int Id)
        {
            var summary = await _summaryRepository.EvaluationSummaries(Id);
            return summary;
        }
    
    }
}
