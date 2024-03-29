﻿using System.Net.Http.Json;
using ZooIS.Shared.Models;
using static MudBlazor.CategoryTypes;

namespace ZooIS.Client.Services.EmployeesService
{
    public class EmployeesService : IEmployeesService
    {
        private readonly HttpClient _http;

        public List<Employee> Employees { get; set; } = new List<Employee>();

        public EmployeesService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> CreateEmployee(Employee employee)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync($"/api/employees", employee);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            HttpResponseMessage response = await _http.DeleteAsync($"/api/employees/{id}");
            if (response.IsSuccessStatusCode)
            {
                Employee employee = Employees.FirstOrDefault(e => e.Id == id);
                if (employee != null)
                {
                    Employees.Remove(employee);
                    return true;
                }
            }
            return false;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var result = await _http.GetFromJsonAsync<Employee>($"/api/employees/{id}");
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task GetEmployees()
        {
            List<Employee> result = new List<Employee>();
            try
            {
                result = await _http.GetFromJsonAsync<List<Employee>>("/api/employees");
            }
            catch { }
            if (result != null && result.Count > 0)
            {
                Employees = result;
            }
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            HttpResponseMessage response = await _http.PutAsJsonAsync($"/api/employees/{employee.Id}", employee);
            return response.IsSuccessStatusCode;
        }
    }
}
