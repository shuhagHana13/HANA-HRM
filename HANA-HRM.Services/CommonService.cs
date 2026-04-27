using HANA_HRM.Domain.DTOs;
using HANA_HRM.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HANA_HRM.Services
{
    public class CommonService(ICommonRepository commonRepository) : ICommonService
    {
        private readonly ICommonRepository _commonRepository = commonRepository;

        public async Task<List<CommonDropdownDto>> GetDepartments(int idClient)
        {
            return await _commonRepository.GetDepartments(idClient);
        }

        public async Task<List<CommonDropdownDto>> GetDesignations(int idClient)
        {
     
            return await _commonRepository.GetDesignations(idClient);
        }


        public async Task<List<CommonDropdownDto>> GetEducationExaminations(int idClient)
        {
            return await _commonRepository.GetEducationExaminations(idClient);
        }

        public async Task<List<CommonDropdownDto>> GetEducationLevels(int idClient)
        {
            return await _commonRepository.GetEducationLevels(idClient);
        
        }

        public async Task<List<CommonDropdownDto>> GetEducationResults(int idClient)
        {
            return await _commonRepository.GetEducationResults(idClient);
        }

        public async Task<List<CommonDropdownDto>> GetEmployeeTypes(int idClient)
        {
            return await _commonRepository.GetEmployeeTypes(idClient);
        }

        public async Task<List<CommonDropdownDto>> GetGenders(int idClient)
        {
            return await _commonRepository.GetGenders(idClient);
        }

        public async Task<List<CommonDropdownDto>> GetJobTypes(int idClient)
        {
            return await _commonRepository.GetJobTypes(idClient);
        }

        public async Task<List<CommonDropdownDto>> GetMaritalStatuses(int idClient)
        {
            return await _commonRepository.GetMaritalStatuses(idClient);
        }

        public async Task<List<CommonDropdownDto>> GetProfessionalCertifications(int idClient)
        {
            return await _commonRepository.GetProfessionalCertifications(idClient);
        }

        public async Task<List<CommonDropdownDto>> GetRelationships(int idClient)
        {
            return await _commonRepository.GetRelationships(idClient);
        }

        public async Task<List<CommonDropdownDto>> GetReligions(int idClient)
        {
            return await _commonRepository.GetReligions(idClient);
        }

        public async Task<List<CommonDropdownDto>> GetSections(int idClient)
        {
            return await _commonRepository.GetSections(idClient);
        }

        public async Task<List<CommonDropdownDto>> GetWeekOffDays(int idClient)
        {
            return await _commonRepository.GetWeekOffDays(idClient);
        }
    }
}
