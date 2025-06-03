using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_Test.Models;
using Web_API_Test.Service;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Web_API_Test.Classes.EmployeesDto;

namespace Web_API_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ISummaryService _summaryService;

        public EmployeesController(IEmployeeService employeeService, ISummaryService summaryService)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            _summaryService = summaryService;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployees([FromBody] EmployeeInfo NewEmployee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _employeeService.AddEmployeeAsync(NewEmployee);
                return Ok("Added succesfully.");
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
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployeesAsync();
                return Ok(employees);
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
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                var employees = await _employeeService.GetEmployeeByIdAsync(Id);
                return Ok(employees);
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

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeInfo EmployeeDetails, int Id)
        {
            try
            {
                await _employeeService.EditEmployeeAsync(EmployeeDetails, Id);
                return CreatedAtAction(nameof(GetAllEmployees), new { id = Id }, EmployeeDetails);
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

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveEmployee(int Id)
        {
            try
            {
                await _employeeService.RemoveEmployeeAsync(Id);
                return Ok("Successfully Removed.");
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

        [HttpGet("/api/employees/{Id}/evaluation-summary")]
        public async Task<IActionResult> EvaluationSummary(int Id)
        {
            try
            {
                var summary = await _summaryService.EvaluationSummary(Id);
                return Ok(summary);
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
