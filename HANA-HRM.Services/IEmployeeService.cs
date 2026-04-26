using HANA_HRM.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HANA_HRM.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeListDto>> GetAllEmployeesAsync(int idClient, CancellationToken cancellationToken);
        Task<EmployeeDto?> GetEmployeeByIdAsync(int idClient,int id,CancellationToken cancellationToken);
        Task<int> CreateEmployeeAsync(EmployeeDto employeeDto, CancellationToken cancellationToken);

        Task<bool> UpdateEmployeeAsync(EmployeeDto dto,CancellationToken cancellationToken);

        Task<bool> SoftDeleteEmployeeAsync(int idClient, int employeeId, CancellationToken cancellationToken);



    }
}
