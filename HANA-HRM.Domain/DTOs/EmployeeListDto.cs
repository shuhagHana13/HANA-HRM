using System;
using System.Collections.Generic;
using System.Text;

namespace HANA_HRM.Domain.DTOs
{
    public class EmployeeListDto
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? DesignationName { get; set; }= string.Empty;
    }
}
