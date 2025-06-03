using Web_API_Test.Models;
using static Web_API_Test.Classes.EvaluationDto;

namespace Web_API_Test.Service
{
    public interface IEvaluationService
    {
        Task AddEvaluationForEmployee(EvaluationInfo Evaluation);
        Task<IEnumerable<Evaluation>> GetAllEvaluation();
        Task<Evaluation> GetEvaluationById(int Id);
        Task<IEnumerable<EvaluationByEmployee>> GetEvaluationByEmployeeId(int Id);
        Task AddKpi(KpiClass Kpi, int Id);
        Task<IEnumerable<Kpi>> GetKpisForEvaluation(int Id);
    }
}
