using HANA_HRM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HANA_HRM.Domain.DTOs
{
    public class EmployeeProfessionalCertificationDto
    {
        public int IdClient { get; set; }
        public int Id { get; set; }
        public string CertificationTitle { get; set; } = null!;
        public string CertificationInstitute { get; set; } = null!;
        public string InstituteLocation { get; set; } = null!;
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? SetDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
