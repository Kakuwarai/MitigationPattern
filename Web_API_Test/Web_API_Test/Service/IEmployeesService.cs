using Web_API_Test.Models;
using static Web_API_Test.Classes.EmployeesDto;

namespace Web_API_Test.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task AddEmployeeAsync(EmployeeInfo Employee);
        Task<Employee> GetEmployeeByIdAsync(int Id);
        Task EditEmployeeAsync(EmployeeInfo Employee, int Id);
        Task RemoveEmployeeAsync(int EmployeeId);
    }
}
