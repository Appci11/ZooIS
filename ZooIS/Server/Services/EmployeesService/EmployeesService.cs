﻿using ZooIS.Shared.Dto;
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
            employee.DateOfDismissal = addEmployeeDto.DateOfDismissal;
            // Sutvarkyt .. gal i true geriau pakeist
            employee.RequestPasswordReset = false;
            // "aaa" slaptazodi i settings iskelt ir is ten naudot
            employee.PasswordHash = BCrypt.Net.BCrypt.HashPassword("aaa");

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            Employee? employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if(employee == null)
            {
                return null;
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
            return employee;
        }

        public async Task<Employee> UpdateEmployee(UpdateEmployeeDto UpdateEmployeeDto, int id)
        {
            Employee dbEmployee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            {
                if(dbEmployee == null)
                {
                    return null;
                }
                dbEmployee.Username = UpdateEmployeeDto.Username;
                dbEmployee.Email = UpdateEmployeeDto.Email;
                dbEmployee.RequestPasswordReset = UpdateEmployeeDto.RequestPasswordReset;
                dbEmployee.DeletionRequested = UpdateEmployeeDto.DeletionRequested;
                dbEmployee.IsDeleted = UpdateEmployeeDto.IsDeleted;
                dbEmployee.Role = UpdateEmployeeDto.Role;
                dbEmployee.DateOfEmployment = UpdateEmployeeDto.DateOfEmployment;
                dbEmployee.DateOfDismissal = UpdateEmployeeDto.DateOfDismissal;
                await _context.SaveChangesAsync();

                return dbEmployee;

            }
        }
    }
}
