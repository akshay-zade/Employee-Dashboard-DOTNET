using Crud_operation_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Threading.Tasks.Dataflow;

namespace Crud_operation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] Employee model) 
        {
            await _employeeRepository.AddEmpolyeeAsync(model);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult> GetEmployee()
        {
            var employeelist = await _employeeRepository.GetAllEmployeeAsync();
            return Ok(employeelist);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult> GetAllEmployeeBYId([FromRoute] int id)
        {
            var employee = await _employeeRepository.GetAllEmployeeBYId(id);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee([FromRoute] int id, [FromBody] Employee model)
        {
            
            await _employeeRepository.UpdateEmployee(id, model);
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee([FromRoute] int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
            return Ok();
        }
    }
}
