using Microsoft.EntityFrameworkCore;
using Web_API_Test.Models;
using static Web_API_Test.Classes.EmployeesDto;

namespace Web_API_Test.Repository
{
    public class EmployeeRepository: Repository<Employee>, IEmployeesRepository
    {
        private readonly PerformanceEvaluationContext _db;

        public EmployeeRepository(PerformanceEvaluationContext context) : base(context)
        {
            _db = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployeeById(int Id)
        {
            return await _db.Employees.Where(item => item.Id.Equals(Id)).ToListAsync();
        }

        public async Task AddEmployeeAsync(EmployeeInfo employee)
        {
            await _db.Employees.AddAsync(new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Position = employee.Position,
            });
            await _db.SaveChangesAsync();
        }

        public async Task EditEmployeeAsync(EmployeeInfo NewEmployeeDetails, int Id)
        {
            Employee employee = await _db.Employees.FirstOrDefaultAsync(item => item.Id == Id)
                ?? throw new Exception("Employee didn't exist.");

            employee.FirstName = NewEmployeeDetails.FirstName;
            employee.LastName = NewEmployeeDetails.LastName;
            employee.Position = NewEmployeeDetails.Position;

            await _db.SaveChangesAsync();
        }

        public async Task RemoveEmployeeAsync(int EmployeeId)
        {
            Employee employee = await _db.Employees.FirstOrDefaultAsync(item => item.Id == EmployeeId)
                ?? throw new Exception("Employee didn't exist.");

             _db.Employees.Remove(employee);

            await _db.SaveChangesAsync();
        }
    }
}
