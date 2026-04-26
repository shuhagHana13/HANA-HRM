using HANA_HRM.Domain.DTOs;
using HANA_HRM.Services;
using Microsoft.AspNetCore.Mvc;

namespace HANA_HRM.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController(IEmployeeService employeeService) : ControllerBase
    {
        private readonly IEmployeeService _employeeService = employeeService;
       
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee([FromQuery] int idClient,CancellationToken cancellationToken)
        {
            var employees = await _employeeService.GetAllEmployeesAsync(idClient,cancellationToken);

            if (employees == null) {
                return NotFound("Employee not found");
            }
            return Ok(employees);
        }

        [HttpGet("{id:int}", Name = "GetEmployeeDetailsById")]
        public async Task<IActionResult> GetEmployeeById([FromQuery] int idClient, int id, CancellationToken cancellationToken)
        {
            var result = await _employeeService.GetEmployeeByIdAsync(idClient, id, cancellationToken);

            if (result == null) {
                return NotFound("Employee not found");
            }            
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDto employeeDto,CancellationToken cancellationToken)
        {
            var id = await _employeeService.CreateEmployeeAsync(employeeDto, cancellationToken);
            return CreatedAtRoute("GetEmployeeDetailsById", new { idClient = employeeDto.IdClient, id },new { EmployeeId = id });
        }


        [HttpDelete]
        public async Task<IActionResult> SoftDeleteEmployee([FromQuery] int idClient, [FromQuery] int employeeId, CancellationToken cancellationToken)
        {
            var deleted = await _employeeService.SoftDeleteEmployeeAsync(idClient, employeeId, cancellationToken);

            if (!deleted){
               return NotFound(new { Message = "Employee not found or already inactive" });
            }          
            return Ok(new{  Message = "Employee soft deleted successfully"});
        }


        [HttpPut]
        public async Task<IActionResult> UpdateEmployee( [FromBody] EmployeeDto dto,CancellationToken cancellationToken)
        {
            var updated = await _employeeService.UpdateEmployeeAsync(dto, cancellationToken);

            if (!updated){
              return NotFound(new { Message = "Employee not found or inactive" });
            }    
            
            return Ok(new{Message = "Employee updated successfully"});
        }
    }
}
