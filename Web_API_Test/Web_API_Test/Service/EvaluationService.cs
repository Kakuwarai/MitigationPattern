using Web_API_Test.Models;
using Web_API_Test.Repository;
using static Web_API_Test.Classes.EvaluationDto;

namespace Web_API_Test.Service
{
    public class EvaluationService : IEvaluationService
    {
        private readonly IEvaluationRepository _evaluationRepository;

        public EvaluationService(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

        public async Task AddEvaluationForEmployee(EvaluationInfo Evaluation)
        {
            await _evaluationRepository.AddEvaluationForEmployee(Evaluation);
        }
        public async Task<IEnumerable<Evaluation>> GetAllEvaluation()
        {
            var evaluationList = await _evaluationRepository.GetAllEvaluation();
            return evaluationList;
        }
        public async Task<Evaluation> GetEvaluationById(int Id)
        {
            var evaluation = await _evaluationRepository.GetEvaluationById(Id);
            return evaluation;
        }
        public async Task<IEnumerable<EvaluationByEmployee>> GetEvaluationByEmployeeId(int Id)
        {
            var evaluationList = await _evaluationRepository.GetEvaluationByEmployeeId(Id);
            return evaluationList;
        }
        public async Task AddKpi(KpiClass Kpi, int Id)
        {
            await _evaluationRepository.AddKpi(Kpi,Id);
        }
        public async Task<IEnumerable<Kpi>> GetKpisForEvaluation(int Id)
        {
            var kpiList = await _evaluationRepository.GetKpisForEvaluation(Id);
            return kpiList;
        }
    }
}
