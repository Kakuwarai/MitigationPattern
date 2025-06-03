using Web_API_Test.Models;
using static Web_API_Test.Classes.EmployeesDto;

namespace Web_API_Test.Repository
{
    public interface IEmployeesRepository : IRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetEmployeeById(int Id);
        Task AddEmployeeAsync(EmployeeInfo employee);
        Task EditEmployeeAsync(EmployeeInfo NewEmployeeDetails, int Id);
        Task RemoveEmployeeAsync(int EmployeeId);
    }
}
