using Microsoft.EntityFrameworkCore;
using Web_API_Test.Models;
using static Web_API_Test.Classes.EvaluationDto;

namespace Web_API_Test.Repository
{
        public class EvaluationRepository : Repository<Evaluation>, IEvaluationRepository
        {
            private readonly PerformanceEvaluationContext _db;

            public EvaluationRepository(PerformanceEvaluationContext context) : base(context)
            {
                _db = context;
            }

            public async Task AddEvaluationForEmployee(EvaluationInfo Evaluation)
            {
               Evaluation addEvaluation = new Evaluation() { 
               EmployeeId = Evaluation.EmployeeId,
               EvaluationDate = Evaluation.EvaluationDate,
               Comments = Evaluation.Comments,
               };

                await _db.Evaluations.AddAsync(addEvaluation);
                await _db.SaveChangesAsync();
            }

            public async Task<IEnumerable<Evaluation>> GetAllEvaluation()
            {
                var evaluationList = await _db.Evaluations.Include(item => item.Employee).ToListAsync();
                return evaluationList;
            }

            public async Task<Evaluation> GetEvaluationById(int Id)
            {
            var evaluation = await _db.Evaluations
                .Include(item => item.Employee)
                .FirstOrDefaultAsync(item => item.Id.Equals(Id))
                    ?? throw new Exception("Evaluation didn't exist.");
                return evaluation;
            }

            public async Task<IEnumerable<EvaluationByEmployee>> GetEvaluationByEmployeeId(int Id)
            {
                var evaluation = await _db.Evaluations.Where(item => item.EmployeeId.Equals(Id))
                .Select(item => new EvaluationByEmployee
                {
                    Id = item.Id,
                    EmployeeId = item.EmployeeId,
                    EvaluationDate = item.EvaluationDate,
                    Comments = item.Comments,
                }).ToListAsync()
                    ?? throw new Exception("Employee didn't exist.");
                return evaluation;
            }

        public async Task AddKpi(KpiClass Kpi,int Id)
        {

            if (Kpi.Score < 1 || Kpi.Score > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(Kpi.Score), "Score must be between 1 and 5.");
            }
            Kpi newKpi = new()
            {
                EvaluationId = Id,
                KPIName = Kpi.KPIName,
                Score = Kpi.Score,
            };
            await _db.Kpis.AddAsync(newKpi);
            await _db.SaveChangesAsync();

        }

        public async Task<IEnumerable<Kpi>> GetKpisForEvaluation(int Id)
        {
            var kpiList = await _db.Kpis.Where(item => item.EvaluationId.Equals(Id)).Include(item => item.Evaluation).ThenInclude(item => item.Employee).ToListAsync();
            return kpiList;

        }

        }
    }
