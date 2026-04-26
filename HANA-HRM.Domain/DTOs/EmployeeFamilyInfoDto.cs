using HANA_HRM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HANA_HRM.Domain.DTOs
{
    public class EmployeeFamilyInfoDto
    {
        public int IdClient { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int IdGender { get; set; }
        public int IdRelationship { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ContactNo { get; set; }
        public string? CurrentAddress { get; set; }
        public string? PermanentAddress { get; set; }
        public DateTime? SetDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
