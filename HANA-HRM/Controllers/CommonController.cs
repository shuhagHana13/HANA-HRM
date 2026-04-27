using HANA_HRM.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HANA_HRM.Controllers
{
    [Route("api/common")]
    [ApiController]
    public class CommonController(ICommonService service) : ControllerBase
    {
        private readonly ICommonService _service = service;      

        [HttpGet("designationsdropdown")]
        public async Task<IActionResult> GetDesignations([FromQuery] int idClient)
        {
            var data= await _service.GetDesignations(idClient);
            return Ok(data);
        }

        [HttpGet("genderdropdown")]
        public async Task<IActionResult> GettGenders([FromQuery] int idClient)
        {
            var data = await _service.GetGenders(idClient);
            return Ok(data);
        }

        [HttpGet("maritalstatusdropdown")]
        public async Task<IActionResult> GetMaritalStatus([FromQuery] int idClient)
        {
            var data = await _service.GetMaritalStatuses(idClient);
            return Ok(data);
        }

        [HttpGet("jobtypesdropdown")]
        public async Task<IActionResult> GetJobTypes([FromQuery] int idClient)
        {
            var data = await _service.GetJobTypes(idClient);
            return Ok(data);
        }

        [HttpGet("sectionsdropdown")]
        public async Task<IActionResult> GetSections([FromQuery] int idClient)
        {
            var data = await _service.GetSections(idClient);
            return Ok(data);
        }

        [HttpGet("religiondropdown")]
        public async Task<IActionResult> GetReligions([FromQuery] int idClient)
        {
            var data = await _service.GetReligions(idClient);
            return Ok(data);
        }


        [HttpGet("weekoffdaysdropdown")]
        public async Task<IActionResult> GetWeekOffDays([FromQuery] int idClient)
        {
            var data = await _service.GetWeekOffDays(idClient);
            return Ok(data);
        }

        [HttpGet("educationresultdropdown")]
        public async Task<IActionResult> GetEducationResults([FromQuery] int idClient)
        {
            var data = await _service.GetEducationResults(idClient);
            return Ok(data);
        }

        [HttpGet("employeetypesdropdown")]
        public async Task<IActionResult> GetEmployeeTypes([FromQuery] int idClient)
        {
            var data = await _service.GetEmployeeTypes(idClient);
            return Ok(data);
        }

        [HttpGet("educationlevelsdropdown")]
        public async Task<IActionResult> GetEducationLevels([FromQuery] int idClient)
        {
            var data = await _service.GetEducationLevels(idClient);
            return Ok(data);
        }

        [HttpGet("educationexaminationdropdown")]
        public async Task<IActionResult> GetEducationExaminations([FromQuery] int idClient)
        {
            var data = await _service.GetEducationExaminations(idClient);
            return Ok(data);
        }

        [HttpGet("professionalcertificationdropdown")]
        public async Task<IActionResult> GetProfessionalCertifications([FromQuery] int idClient)
        {
            var data = await _service.GetProfessionalCertifications(idClient);
            return Ok(data);
        }

        [HttpGet("relationshipdropdown")]
        public async Task<IActionResult> GetRelationships([FromQuery] int idClient)
        {
            var data = await _service.GetRelationships(idClient);
            return Ok(data);
        }

        [HttpGet("departmentsdropdown")]
        public async Task<IActionResult> GetDepartment([FromQuery] int idClient)
        {
            var data = await _service.GetDepartments(idClient);
            return Ok(data);
        }

    }
}
