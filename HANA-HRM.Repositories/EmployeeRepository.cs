using HANA_HRM.Domain.DTOs;
using HANA_HRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace HANA_HRM.Repositories
{
    public class EmployeeRepository (AppDbContext context) : IEmployeeRepository
    {
        private readonly AppDbContext _context = context;
        public async Task<List<EmployeeListDto>> GetAllEmployeesAsync(int idClient, CancellationToken cancellationToken)
        {
            var data= await _context.Employees
                 .Where(e => e.IdClient == idClient && e.IsActive==true)
                 .AsNoTracking()
                 .Select(e => new EmployeeListDto 
                 {
                     EmployeeId = e.Id,
                     EmployeeName = e.EmployeeName,
                     DesignationName = e.Designation != null ? e.Designation.DesignationName : null
                 })
                 .OrderByDescending(e=>e.EmployeeId)
                 .ToListAsync(cancellationToken);
            return data;
        }

        public async Task<EmployeeDto?> GetEmployeeByIdAsync(int idClient,int id,CancellationToken cancellationToken)
        {
            var data= await _context.Employees
                .Where(e => e.IdClient == idClient && e.Id == id)
                .AsNoTracking()
                .Select(e => new EmployeeDto
                {
                    IdClient = e.IdClient,
                    Id = e.Id,
                    EmployeeName = e.EmployeeName,
                    EmployeeNameBangla = e.EmployeeNameBangla,
                    EmployeeImage = e.EmployeeImage != null? Convert.ToBase64String(e.EmployeeImage) : null,
                    FatherName = e.FatherName,
                    MotherName = e.MotherName,
                    IdJobType = e.IdJobType,
                    IdEmployeeType = e.IdEmployeeType,
                    BirthDate = e.BirthDate,
                    JoiningDate = e.JoiningDate,
                    IdGender = e.IdGender,
                    IdReligion = e.IdReligion,
                    IdDepartment = e.IdDepartment,
                    IdSection = e.IdSection,
                    IdDesignation = e.IdDesignation,
                    HasOvertime = e.HasOvertime,
                    HasAttendenceBonus = e.HasAttendenceBonus,
                    IdWeekOff = e.IdWeekOff,
                    Address = e.Address,
                    PresentAddress = e.PresentAddress,
                    NationalIdentificationNumber = e.NationalIdentificationNumber,
                    ContactNo = e.ContactNo,
                    IdMaritalStatus = e.IdMaritalStatus,
                    IsActive = e.IsActive,                  
                    EmployeeDocuments = e.EmployeeDocuments
                    .Select(d => new EmployeeDocumentDto
                    {
                        IdClient = d.IdClient,
                        Id = d.Id,
                        DocumentName = d.DocumentName,
                        FileName = d.FileName,
                        UploadDate = d.UploadDate,
                        UploadedFileExtention = d.UploadedFileExtention,
                        UploadedFile = d.UploadedFile                  
                    }).ToList(),
                    EmployeeEducationInfos = e.EmployeeEducationInfos
                    .Select(ed => new EmployeeEducationInfoDto
                    {
                        IdClient = ed.IdClient,
                        Id = ed.Id,
                        IdEducationLevel = ed.IdEducationLevel,
                        IdEducationExamination = ed.IdEducationExamination,
                        IdEducationResult = ed.IdEducationResult,
                        Cgpa = ed.Cgpa,
                        ExamScale = ed.ExamScale,
                        Marks = ed.Marks,
                        Major = ed.Major,
                        PassingYear = ed.PassingYear,
                        InstituteName = ed.InstituteName,
                        IsForeignInstitute = ed.IsForeignInstitute,
                        Duration = ed.Duration,
                        Achievement = ed.Achievement                  
                    }).ToList(),
                    EmployeeFamilyInfos = e.EmployeeFamilyInfos
                    .Select(f => new EmployeeFamilyInfoDto
                    {
                        IdClient = f.IdClient,
                        Id = f.Id,
                        Name = f.Name,
                        IdGender = f.IdGender,
                        IdRelationship = f.IdRelationship,
                        DateOfBirth = f.DateOfBirth,
                        ContactNo = f.ContactNo,
                        CurrentAddress = f.CurrentAddress,
                        PermanentAddress = f.PermanentAddress                       
                    }).ToList(),
                    EmployeeProfessionalCertifications =
                        e.EmployeeProfessionalCertifications
                        .Select(c => new EmployeeProfessionalCertificationDto
                        {
                            IdClient = c.IdClient,
                            Id = c.Id,
                            CertificationTitle = c.CertificationTitle,
                            CertificationInstitute = c.CertificationInstitute,
                            InstituteLocation = c.InstituteLocation,
                            FromDate = c.FromDate,
                            ToDate = c.ToDate                                             
                        }).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);
            return data;
        }

        public async Task<int> CreateEmployeeAsync(EmployeeDto dto, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                IdClient = dto.IdClient,
                EmployeeName = dto.EmployeeName,
                EmployeeNameBangla = dto.EmployeeNameBangla,
                EmployeeImage = string.IsNullOrEmpty(dto.EmployeeImage)? null: Convert.FromBase64String(dto.EmployeeImage),
                FatherName = dto.FatherName,
                MotherName = dto.MotherName,
                IdJobType = dto.IdJobType,
                IdEmployeeType = dto.IdEmployeeType,
                BirthDate = dto.BirthDate,
                JoiningDate = dto.JoiningDate,
                IdGender = dto.IdGender,
                IdReportingManager = dto.IdReportingManager,
                IdReligion = dto.IdReligion,
                IdDepartment = dto.IdDepartment,
                IdSection = dto.IdSection,
                IdDesignation = dto.IdDesignation,
                HasOvertime = dto.HasOvertime,
                HasAttendenceBonus = dto.HasAttendenceBonus,
                IdWeekOff = dto.IdWeekOff,
                Address = dto.Address,
                PresentAddress = dto.PresentAddress,
                NationalIdentificationNumber = dto.NationalIdentificationNumber,
                ContactNo = dto.ContactNo,
                IdMaritalStatus = dto.IdMaritalStatus,
                IsActive = true,
                EmployeeDocuments = dto.EmployeeDocuments?
                    .Select(d => new EmployeeDocument
                    {
                        IdClient = d.IdClient,
                        DocumentName = d.DocumentName,
                        FileName = d.FileName,
                        UploadDate = d.UploadDate,
                        UploadedFile = d.UploadedFile,
                        UploadedFileExtention = d.UploadedFileExtention
                    }).ToList() ?? [],
                EmployeeEducationInfos = dto.EmployeeEducationInfos?
                    .Select(e => new EmployeeEducationInfo
                    {
                        IdClient = e.IdClient,
                        IdEducationLevel = e.IdEducationLevel,
                        IdEducationExamination = e.IdEducationExamination,
                        IdEducationResult = e.IdEducationResult,
                        Cgpa = e.Cgpa,
                        ExamScale = e.ExamScale,
                        Marks = e.Marks,
                        Major = e.Major,
                        PassingYear = e.PassingYear,
                        InstituteName = e.InstituteName,
                        IsForeignInstitute = e.IsForeignInstitute,
                        Duration = e.Duration,
                        Achievement = e.Achievement
                    }).ToList() ?? [],
                EmployeeFamilyInfos = dto.EmployeeFamilyInfos?
                    .Select(f => new EmployeeFamilyInfo
                    {
                        IdClient = f.IdClient,
                        Name = f.Name,
                        IdGender = f.IdGender,
                        IdRelationship = f.IdRelationship,
                        DateOfBirth = f.DateOfBirth,
                        ContactNo = f.ContactNo,
                        CurrentAddress = f.CurrentAddress,
                        PermanentAddress = f.PermanentAddress                   
                    }).ToList() ?? [],
                EmployeeProfessionalCertifications = dto.EmployeeProfessionalCertifications?
                    .Select(c => new EmployeeProfessionalCertification
                    {
                        IdClient = c.IdClient,
                        CertificationTitle = c.CertificationTitle,
                        CertificationInstitute = c.CertificationInstitute,
                        InstituteLocation = c.InstituteLocation,
                        FromDate = c.FromDate,
                        ToDate = c.ToDate
                    }).ToList() ?? []
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(cancellationToken);
            return employee.Id;
        }
        
        public async Task<bool> SoftDeleteEmployeeAsync(int idClient,int employeeId,CancellationToken cancellationToken)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e =>e.IdClient == idClient && e.Id == employeeId && e.IsActive == true,cancellationToken);

            if (employee == null)
                return false;

            employee.IsActive = false;
            employee.SetDate = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> UpdateEmployeeAsync(EmployeeDto dto,CancellationToken cancellationToken)
        {
            var employee = await _context.Employees
                .Include(e => e.EmployeeDocuments)
                .Include(e => e.EmployeeEducationInfos)
                .Include(e => e.EmployeeFamilyInfos)
                .Include(e => e.EmployeeProfessionalCertifications)
                .AsSplitQuery()
                .FirstOrDefaultAsync(e => e.IdClient == dto.IdClient && e.Id == dto.Id && e.IsActive == true, cancellationToken);
            if (employee == null)
                return false;
  
            employee.EmployeeName = dto.EmployeeName;
            employee.EmployeeNameBangla = dto.EmployeeNameBangla;
            employee.EmployeeImage = string.IsNullOrEmpty(dto.EmployeeImage)? employee.EmployeeImage: Convert.FromBase64String(dto.EmployeeImage);
            employee.FatherName = dto.FatherName;
            employee.MotherName = dto.MotherName;
            employee.IdJobType = dto.IdJobType;
            employee.IdEmployeeType = dto.IdEmployeeType;
            employee.IdGender = dto.IdGender;
            employee.IdReligion = dto.IdReligion;
            employee.IdDepartment = dto.IdDepartment;
            employee.IdReportingManager = dto.IdReportingManager;
            employee.IdSection = dto.IdSection;
            employee.IdDesignation = dto.IdDesignation;
            employee.IdWeekOff = dto.IdWeekOff;
            employee.IdMaritalStatus = dto.IdMaritalStatus;
            employee.BirthDate = dto.BirthDate;
            employee.JoiningDate = dto.JoiningDate;
            employee.HasOvertime = dto.HasOvertime;
            employee.HasAttendenceBonus = dto.HasAttendenceBonus;
            employee.Address = dto.Address;
            employee.PresentAddress = dto.PresentAddress;
            employee.NationalIdentificationNumber = dto.NationalIdentificationNumber;
            employee.ContactNo = dto.ContactNo;
          

            var incomingDocs = dto.EmployeeDocuments ?? [];
            var existingDocs = employee.EmployeeDocuments;
            foreach (var dtoDoc in incomingDocs)
            {
                var existing = existingDocs.FirstOrDefault(x => x.Id == dtoDoc.Id);
                if (existing != null)
                {   //update
                    existing.DocumentName = dtoDoc.DocumentName;
                    existing.FileName = dtoDoc.FileName;
                    existing.UploadDate = dtoDoc.UploadDate;
                    existing.UploadedFile = dtoDoc.UploadedFile;
                    existing.UploadedFileExtention = dtoDoc.UploadedFileExtention;
                  
                }
                else
                {
                    existingDocs.Add(new EmployeeDocument
                    {   //insert
                        IdClient = dtoDoc.IdClient,
                        DocumentName = dtoDoc.DocumentName,
                        FileName = dtoDoc.FileName,
                        UploadDate = dtoDoc.UploadDate,
                        UploadedFile = dtoDoc.UploadedFile,
                        UploadedFileExtention = dtoDoc.UploadedFileExtention,
                     
                    });
                }
            }
            //delete
            var docIds = incomingDocs.Where(x => x.Id > 0).Select(x => x.Id).ToHashSet();
            var docsToRemove = existingDocs.Where(x => x.Id > 0 && !docIds.Contains(x.Id)).ToList();
            _context.EmployeeDocuments.RemoveRange(docsToRemove);

            var incomingEdu = dto.EmployeeEducationInfos ?? [];
            var existingEdu = employee.EmployeeEducationInfos;
            foreach (var dtoEdu in incomingEdu)
            {
                var existing = existingEdu.FirstOrDefault(x => x.Id == dtoEdu.Id);
                if (existing != null)
                {
                    existing.IdEducationLevel = dtoEdu.IdEducationLevel;
                    existing.IdEducationExamination = dtoEdu.IdEducationExamination;
                    existing.IdEducationResult = dtoEdu.IdEducationResult;
                    existing.Cgpa = dtoEdu.Cgpa;
                    existing.ExamScale = dtoEdu.ExamScale;
                    existing.Marks = dtoEdu.Marks;
                    existing.Major = dtoEdu.Major;
                    existing.PassingYear = dtoEdu.PassingYear;
                    existing.InstituteName = dtoEdu.InstituteName;
                    existing.IsForeignInstitute = dtoEdu.IsForeignInstitute;
                    existing.Duration = dtoEdu.Duration;
                    existing.Achievement = dtoEdu.Achievement;                 
                }
                else
                {
                    existingEdu.Add(new EmployeeEducationInfo
                    {
                        IdClient = dtoEdu.IdClient,
                        IdEducationLevel = dtoEdu.IdEducationLevel,
                        IdEducationExamination = dtoEdu.IdEducationExamination,
                        IdEducationResult = dtoEdu.IdEducationResult,
                        Cgpa = dtoEdu.Cgpa,
                        ExamScale = dtoEdu.ExamScale,
                        Marks = dtoEdu.Marks,
                        Major = dtoEdu.Major,
                        PassingYear = dtoEdu.PassingYear,
                        InstituteName = dtoEdu.InstituteName,
                        IsForeignInstitute = dtoEdu.IsForeignInstitute,
                        Duration = dtoEdu.Duration,
                        Achievement = dtoEdu.Achievement                  
                    });
                }
            }
            var eduIds = incomingEdu.Where(x => x.Id > 0).Select(x => x.Id).ToHashSet();
            var eduToRemove = existingEdu.Where(x => x.Id > 0 && !eduIds.Contains(x.Id)).ToList();
            _context.EmployeeEducationInfos.RemoveRange(eduToRemove);

            var incomingFamily = dto.EmployeeFamilyInfos ?? [];
            var existingFamily = employee.EmployeeFamilyInfos;
            foreach (var dtoFamily in incomingFamily)
            {
                var existing = existingFamily.FirstOrDefault(x => x.Id == dtoFamily.Id);
                if (existing != null)
                {
                    existing.Name = dtoFamily.Name;
                    existing.IdGender = dtoFamily.IdGender;
                    existing.IdRelationship = dtoFamily.IdRelationship;
                    existing.DateOfBirth = dtoFamily.DateOfBirth;
                    existing.ContactNo = dtoFamily.ContactNo;
                    existing.CurrentAddress = dtoFamily.CurrentAddress;
                    existing.PermanentAddress = dtoFamily.PermanentAddress;
                
                }
                else
                {
                    existingFamily.Add(new EmployeeFamilyInfo
                    {
                        IdClient = dtoFamily.IdClient,
                        Name = dtoFamily.Name,
                        IdGender = dtoFamily.IdGender,
                        IdRelationship = dtoFamily.IdRelationship,
                        DateOfBirth = dtoFamily.DateOfBirth,
                        ContactNo = dtoFamily.ContactNo,
                        CurrentAddress = dtoFamily.CurrentAddress,
                        PermanentAddress = dtoFamily.PermanentAddress,
                
                    });
                }
            }
            var familyIds = incomingFamily.Where(x => x.Id > 0).Select(x => x.Id).ToHashSet();
            var familyToRemove = existingFamily.Where(x => x.Id > 0 && !familyIds.Contains(x.Id)).ToList();
            _context.EmployeeFamilyInfos.RemoveRange(familyToRemove);
            
            var incomingCertificates = dto.EmployeeProfessionalCertifications ?? [];
            var existingCertificates = employee.EmployeeProfessionalCertifications;
            foreach (var dtoCert in incomingCertificates)
            {
                var existing = existingCertificates.FirstOrDefault(x => x.Id == dtoCert.Id);
                if (existing != null)
                {
                    existing.CertificationTitle = dtoCert.CertificationTitle;
                    existing.CertificationInstitute = dtoCert.CertificationInstitute;
                    existing.InstituteLocation = dtoCert.InstituteLocation;
                    existing.FromDate = dtoCert.FromDate;
                    existing.ToDate = dtoCert.ToDate;
                  
                }
                else
                {
                    existingCertificates.Add(new EmployeeProfessionalCertification
                    {
                        IdClient = dtoCert.IdClient,
                        CertificationTitle = dtoCert.CertificationTitle,
                        CertificationInstitute = dtoCert.CertificationInstitute,
                        InstituteLocation = dtoCert.InstituteLocation,
                        FromDate = dtoCert.FromDate,
                        ToDate = dtoCert.ToDate                       
                    });
                }
            }
            var certIds = incomingCertificates.Where(x => x.Id > 0).Select(x => x.Id).ToHashSet();
            var certificateToRemove = existingCertificates.Where(x => x.Id > 0 && !certIds.Contains(x.Id)).ToList();
            _context.EmployeeProfessionalCertifications.RemoveRange(certificateToRemove);

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

    }
}

