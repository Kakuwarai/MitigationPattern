using Web_API_Test.Models;
using Web_API_Test.Repository;
using static Web_API_Test.Classes.EmployeesDto;

namespace Web_API_Test.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeesRepository _employeeRepository;

        public EmployeeService(IEmployeesRepository employeeRepo)
        {
            _employeeRepository = employeeRepo;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return employees;
        }

        public async Task AddEmployeeAsync(EmployeeInfo employee)
        {
            await _employeeRepository.AddEmployeeAsync(employee);
        }
        public async Task<Employee> GetEmployeeByIdAsync(int Id)
        {
            var employee = await _employeeRepository.GetByIdAsync(Id);
            return employee;
        }
        public async Task EditEmployeeAsync(EmployeeInfo Employee, int Id)
        {
            await _employeeRepository.EditEmployeeAsync(Employee,Id);
        }
        public async Task RemoveEmployeeAsync(int EmployeeId)
        {
            await _employeeRepository.RemoveEmployeeAsync(EmployeeId);
        }
    }
}
