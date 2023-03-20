using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.EmployeesService
{
    public interface IEmployeesService
    {
        List<Employee> Employees { get; set; }

        public Task GetEmployees();
        public Task<Employee> GetEmployee(int id);
        public Task<bool> CreateEmployee(Employee employee);
        public Task<bool> UpdateEmployee(Employee employee);
        public Task<bool> DeleteEmployee(int id);
    }
}
