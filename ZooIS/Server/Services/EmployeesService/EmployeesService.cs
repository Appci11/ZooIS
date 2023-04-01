using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.EmployeesService
{
    public class EmployeesService : IEmployeesService
    {
        private readonly DataContext _context;

        public EmployeesService(DataContext context)
        {
            _context = context;
        }
        public async Task<Employee> AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            Employee employee = new Employee();

            employee.Username= addEmployeeDto.Username;
            employee.Email= addEmployeeDto.Email;
            employee.Role= addEmployeeDto.Role;
            employee.DateOfEmployment = addEmployeeDto.DateOfEmployment;
            employee.RequestPasswordReset = true;
            // "aaa" slaptazodi i settings iskelt ir is ten naudot
            employee.PasswordHash = BCrypt.Net.BCrypt.HashPassword("aaa");

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            UserSettings settings = new UserSettings() { Id = employee.Id };
            _context.UserSettings.Add(settings);
            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            Employee? employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if(employee == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            Employee? employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
#pragma warning disable CS8603 // Possible null reference return.
            return employee;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Employee> UpdateEmployee(UpdateEmployeeDto UpdateEmployeeDto, int id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Employee dbEmployee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            {
                if(dbEmployee == null)
                {
#pragma warning disable CS8603 // Possible null reference return.
                    return null;
#pragma warning restore CS8603 // Possible null reference return.
                }
                dbEmployee.Username = UpdateEmployeeDto.Username;
                dbEmployee.Email = UpdateEmployeeDto.Email;
                dbEmployee.RequestPasswordReset = UpdateEmployeeDto.RequestPasswordReset;
                dbEmployee.DeletionRequested = UpdateEmployeeDto.DeletionRequested;
                dbEmployee.IsDeleted = UpdateEmployeeDto.IsDeleted;
                dbEmployee.Role = UpdateEmployeeDto.Role;
                dbEmployee.DateOfEmployment = UpdateEmployeeDto.DateOfEmployment;
                await _context.SaveChangesAsync();

                return dbEmployee;

            }
        }
    }
}
