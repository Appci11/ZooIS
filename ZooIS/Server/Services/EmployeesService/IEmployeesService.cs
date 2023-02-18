using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.EmployeesService
{
    public interface IEmployeesService
    {
        Task<Employee> AddEmployee(AddEmployeeDto addEmployeeDto);
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> UpdateEmployee(EmployeeUpdateDto employeeUpdateDto, int id);
        Task<Employee> DeleteEmployee(int id);
    }
}
