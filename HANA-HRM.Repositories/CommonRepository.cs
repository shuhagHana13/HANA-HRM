using HANA_HRM.Domain.DTOs;
using HANA_HRM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace HANA_HRM.Repositories
{
    public class CommonRepository(AppDbContext context) : ICommonRepository
    {
        private readonly AppDbContext _context = context;
  
        public async Task<List<CommonDropdownDto>> GetDesignations(int idClient)
        {

            var data= await _context.Designations
                    .Where(x => x.IdClient == idClient && x.IsActive == true)
                    .AsNoTracking()
                    .Select(x => new CommonDropdownDto
                    {
                        Id = x.Id,
                        Name = x.DesignationName ?? string.Empty
                    })
                    .ToListAsync();
            return data;
        }

        public async Task<List<CommonDropdownDto>> GetEducationExaminations(int idClient)
        {

            var data= await _context.EducationExaminations
                    .Where(x => x.IdClient == idClient)
                    .AsNoTracking()
                    .Select(x => new CommonDropdownDto
                    {
                        Id = x.Id,
                        Name = x.ExamName ?? string.Empty
                    })
                    .ToListAsync();
            return data;
        }

        public async Task<List<CommonDropdownDto>> GetEducationLevels(int idClient)
        {
            var data= await _context.EducationLevels
                    .Where(x => x.IdClient == idClient)
                    .AsNoTracking()
                    .Select(x => new CommonDropdownDto
                    {
                        Id = x.Id,
                        Name = x.EducationLevelName ?? string.Empty
                    })
                    .ToListAsync();
            return data;
        }

        public async Task<List<CommonDropdownDto>> GetEducationResults(int idClient)
        {
            var data= await _context.EducationResults
                     .Where(x => x.IdClient == idClient)
                     .AsNoTracking()
                     .Select(x => new CommonDropdownDto
                     {
                         Id = x.Id,
                         Name = x.ResultName ?? string.Empty
                     })
                     .ToListAsync();
            return data;
        }

        public async Task<List<CommonDropdownDto>> GetEmployeeTypes(int idClient)
        {
            var data= await _context.EmployeeTypes
                   .Where(x => x.IdClient == idClient)
                   .AsNoTracking()
                   .Select(x => new CommonDropdownDto
                   {
                       Id = x.Id,
                       Name = x.TypeName ?? string.Empty
                   })
                   .ToListAsync();
            return data;
        }

        public async Task<List<CommonDropdownDto>> GetGenders(int idClient)
        {
            var data= await _context.Genders
                    .Where(x => x.IdClient == idClient)
                    .AsNoTracking()
                    .Select(x => new CommonDropdownDto
                    {
                        Id = x.Id,
                        Name = x.GenderName ?? string.Empty
                    })
                    .ToListAsync();
            return data;
        }


        public async Task<List<CommonDropdownDto>> GetJobTypes(int idClient)
        {
            var data= await _context.JobTypes
                   .Where(x => x.IdClient == idClient)
                   .AsNoTracking()
                   .Select(x => new CommonDropdownDto
                   {
                       Id = x.Id,
                       Name = x.JobTypeName ?? string.Empty
                   })
                   .ToListAsync();
            return data;
        }


        public async Task<List<CommonDropdownDto>> GetMaritalStatuses(int idClient)
        {
            var data= await _context.MaritalStatuses
                  .Where(x => x.IdClient == idClient)
                  .AsNoTracking()
                  .Select(x => new CommonDropdownDto
                  {
                      Id = x.Id,
                      Name = x.MaritalStatusName ?? string.Empty
                  })
                  .ToListAsync();
            return data;
        }


        public async Task<List<CommonDropdownDto>> GetProfessionalCertifications(int idClient)
        {
            var data= await _context.EmployeeProfessionalCertifications
                    .Where(x => x.IdClient == idClient)
                    .AsNoTracking()
                    .Select(x => new CommonDropdownDto
                    {
                        Id = x.Id,
                        Name = x.CertificationTitle ?? string.Empty
                    })
                    .ToListAsync();
            return data;
        }


        public async Task<List<CommonDropdownDto>> GetRelationships(int idClient)
        {
            var data= await _context.Relationships
                   .Where(x => x.IdClient == idClient)
                   .AsNoTracking()
                   .Select(x => new CommonDropdownDto
                   {
                       Id = x.Id,
                       Name = x.RelationName ?? string.Empty
                   })
                   .ToListAsync();
            return data;
        }


        public async Task<List<CommonDropdownDto>> GetReligions(int idClient)
        {
            var data= await _context.Religions
                  .Where(x => x.IdClient == idClient)
                  .AsNoTracking()
                  .Select(x => new CommonDropdownDto
                  {
                      Id = x.Id,
                      Name = x.ReligionName ?? string.Empty
                  })
                  .ToListAsync();
            return data;

        }


        public async Task<List<CommonDropdownDto>> GetSections(int idClient)
        {
            var data= await _context.Sections
                 .Where(x => x.IdClient == idClient)
                 .AsNoTracking()
                 .Select(x => new CommonDropdownDto
                 {
                     Id = x.Id,
                     Name = x.SectionName ?? string.Empty
                 })
                 .ToListAsync();
            return data;
        }


        public async Task<List<CommonDropdownDto>> GetWeekOffDays(int idClient)
        {
            var data= await _context.WeekOffs
                 .Where(x => x.IdClient == idClient)
                 .AsNoTracking()
                 .Select(x => new CommonDropdownDto
                 {
                     Id = x.Id,
                     Name = x.WeekOffDay ?? string.Empty
                 })
                 .ToListAsync();
            return data;
        }
    }
}
