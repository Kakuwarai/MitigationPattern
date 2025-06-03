
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Threading.Tasks;
using System.Linq;
using Web_API_Test.Repository;
using Web_API_Test.Models;
using static Web_API_Test.Classes.EmployeesDto;
using static Web_API_Test.Classes.EvaluationDto;

namespace Web_API_Test.Tests
{
    public class UnitTest1
    {
        private PerformanceEvaluationContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<PerformanceEvaluationContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            var context = new PerformanceEvaluationContext(options);
            context.Database.EnsureCreated();
            return context;
        }

        [Fact]
        public async Task AddEmployeeAsync_ShouldAddEmployee()
        {
            // Arrange
            var context = GetInMemoryContext();
            var _db = new EmployeeRepository(context);
            var employee = new EmployeeInfo { FirstName = "Test", LastName = "User", Position = "Dev" };

            // Act
            await _db.AddEmployeeAsync(employee);
            var result = await context.Employees.FirstOrDefaultAsync(item => item.Id == 1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("User", result.LastName);
            Assert.Equal("Dev", result.Position);
        }

        [Fact]
        public async Task AddEmployeeEvaluation()
        {

            var context = GetInMemoryContext();
            var _db = new EvaluationRepository(context);
            var evaluation = new EvaluationInfo
            {
                EmployeeId = 1,
                EvaluationDate = DateTime.Now,
                Comments = "Test"
            };

            await _db.AddEvaluationForEmployee(evaluation);
            var result = context.Evaluations.FirstOrDefault(item => item.Id == 1);

            Assert.NotNull(result);
            Assert.Equal(1, result.EmployeeId);
            Assert.Equal("Test", result.Comments);
        }
    }
}