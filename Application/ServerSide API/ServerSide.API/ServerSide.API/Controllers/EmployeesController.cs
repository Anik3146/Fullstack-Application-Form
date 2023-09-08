using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerSide.API.Data;
using ServerSide.API.Models;
using System.Reflection.Metadata.Ecma335;

namespace ServerSide.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly ServerSideDbContext _serverSideDbContext;
        public EmployeesController(ServerSideDbContext serverSideDbContext)
        {
            this._serverSideDbContext = serverSideDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _serverSideDbContext.Employees.ToListAsync();

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
        {
            employeeRequest.Id = Guid.NewGuid();

            await _serverSideDbContext.Employees.AddAsync(employeeRequest);
            await _serverSideDbContext.SaveChangesAsync();

            return Ok(employeeRequest);

        }

        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employee =
            await _serverSideDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            
            if(employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        
        }

        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, Employee updateEmployeeRequest)
        {
            var employee = await _serverSideDbContext.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            employee.Name = updateEmployeeRequest.Name;
            employee.Email = updateEmployeeRequest.Email;
            employee.Salary = updateEmployeeRequest.Salary;
            employee.Phone = updateEmployeeRequest.Phone;
            employee.Department = updateEmployeeRequest.Department;

            await _serverSideDbContext.SaveChangesAsync();

            return Ok(employee);

        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _serverSideDbContext.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            _serverSideDbContext.Employees.Remove(employee);
            await _serverSideDbContext.SaveChangesAsync();

            return Ok(employee);
        }

      


    }
}
