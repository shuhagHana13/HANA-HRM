using HANA_HRM.Domain.DTOs;
using HANA_HRM.Repositories;
using System.Threading;

namespace HANA_HRM.Services
{
    public class EmployeeService(IEmployeeRepository repository) : IEmployeeService
    {

        private readonly IEmployeeRepository _repository = repository;

        public async Task<List<EmployeeListDto>> GetAllEmployeesAsync(int idClient, CancellationToken cancellationToken)
        {
            return await _repository.GetAllEmployeesAsync(idClient, cancellationToken);
        }
        public async Task<EmployeeDto?> GetEmployeeByIdAsync(int idClient, int id, CancellationToken cancellationToken)
        {
            return await _repository.GetEmployeeByIdAsync(idClient, id, cancellationToken);
        }
        public Task<int> CreateEmployeeAsync(EmployeeDto employeeDto,CancellationToken cancellationToken)
        {
            return _repository.CreateEmployeeAsync(employeeDto, cancellationToken);
        }
        public async Task<bool> UpdateEmployeeAsync(EmployeeDto dto,CancellationToken cancellationToken)
        {
            return await _repository.UpdateEmployeeAsync(dto, cancellationToken);
        }
        public async Task<bool> SoftDeleteEmployeeAsync(int idClient,int employeeId, CancellationToken cancellationToken)
        {
            return await _repository.SoftDeleteEmployeeAsync(idClient, employeeId, cancellationToken);
        }

       
    }
}
