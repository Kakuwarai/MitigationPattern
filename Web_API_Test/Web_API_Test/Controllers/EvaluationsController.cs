using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_Test.Models;
using Web_API_Test.Service;
using static Web_API_Test.Classes.EvaluationDto;

namespace Web_API_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationsController : ControllerBase
    {
        readonly IEvaluationService _evaluationService;

        public EvaluationsController(IEvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }

        [HttpPost]
        public async Task<IActionResult> AddEvaluationForEmployee(EvaluationInfo evaluationInfo)
        {
            try
            {
                await _evaluationService.AddEvaluationForEmployee(evaluationInfo);
                return Ok("Added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    Message = ex.InnerException?.Message ?? ex.Message,
                    ex.StackTrace
                });

            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvaluation()
        {
            try
            {
                var evaluationLsit = await _evaluationService.GetAllEvaluation();
                return Ok(evaluationLsit);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    Message = ex.InnerException?.Message ?? ex.Message,
                    ex.StackTrace
                });

            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetEvaluationById(int Id)
        {
            try
            {
                var evaluation = await _evaluationService.GetEvaluationById(Id);
                return Ok(evaluation);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    Message = ex.InnerException?.Message ?? ex.Message,
                    ex.StackTrace
                });

            }
        }

        [HttpGet("employees/{Id}/evaluation")]
        public async Task<IActionResult> GetEvaluationByEmployeeId(int Id)
        {
            try
            {
                var evaluationList = await _evaluationService.GetEvaluationByEmployeeId(Id);
                return Ok(evaluationList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    Message = ex.InnerException?.Message ?? ex.Message,
                    ex.StackTrace
                });

            }
        }

        [HttpPost("evaluations/{Id}/kpis")]
        public async Task<IActionResult> AddKpiEvaluation(KpiClass Kpi, int Id)
        {
            try
            {
                await _evaluationService.AddKpi(Kpi,Id);
                return Ok("KPI successfully Added.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    Message = ex.InnerException?.Message ?? ex.Message,
                    ex.StackTrace
                });

            }
        }

        [HttpGet("evaluations/{Id}/kpis")]
        public async Task<IActionResult> GetKpisForEvaluation(int Id)
        {
            try
            {
                var kpis = await _evaluationService.GetKpisForEvaluation(Id);
                return Ok(kpis);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    Message = ex.InnerException?.Message ?? ex.Message,
                    ex.StackTrace
                });

            }
        }

    }
}
