using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Server.Services.EmployeesService;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            Employee response = await _employeesService.AddEmployee(addEmployeeDto);
            if(response != null)
            {
                return Created($"/api/[controller]/{response.Id}", response);
            }
            return NotFound(new { message = "Adding employee failed." });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            List<Employee> response = await _employeesService.GetAllEmployees();
            if(response != null)
            {
                return Ok(response);
            }
            return NotFound(new { message = "No employees found" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            Employee response = await _employeesService.GetEmployee(id);
            if(response != null)
            {
                return Ok(response);
            }
            return NotFound(new { message = "User not found" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(UpdateEmployeeDto UpdateEmployeeDto, int id)
        {
            Employee response = await _employeesService.UpdateEmployee(UpdateEmployeeDto, id);
            if(response != null)
            {
                return Ok(response);
            }
            return NotFound(new { message = "Error retrieving employee data" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            Employee response = await _employeesService.DeleteEmployee(id);
            if(response != null)
            {
                return Ok(response);
            }
            return NotFound(new { message = "Failed to delete employee data" });
        }
    }
}
