using HANA_HRM.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HANA_HRM.Services
{
    public interface ICommonService
    {

        Task<List<CommonDropdownDto>> GetJobTypes(int idClient);
        Task<List<CommonDropdownDto>> GetGenders(int idClient);
        Task<List<CommonDropdownDto>> GetMaritalStatuses(int idClient);
        Task<List<CommonDropdownDto>> GetReligions(int idClient);
        Task<List<CommonDropdownDto>> GetDesignations(int idClient);
        Task<List<CommonDropdownDto>> GetSections(int idClient);
        Task<List<CommonDropdownDto>> GetWeekOffDays(int idClient);
        Task<List<CommonDropdownDto>> GetEducationResults(int idClient);
        Task<List<CommonDropdownDto>> GetEmployeeTypes(int idClient);
        Task<List<CommonDropdownDto>> GetEducationLevels(int idClient);
        Task<List<CommonDropdownDto>> GetEducationExaminations(int idClient);
        Task<List<CommonDropdownDto>> GetProfessionalCertifications(int idClient);
        Task<List<CommonDropdownDto>> GetRelationships(int idClient);
        Task<List<CommonDropdownDto>> GetDepartments(int idClient);

    }
}
