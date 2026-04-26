using HANA_HRM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HANA_HRM.Domain.DTOs
{
    public class EmployeeDocumentDto
    {

        public int IdClient { get; set; }
        public int Id { get; set; }
        public string DocumentName { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public DateTime UploadDate { get; set; }
        public string? UploadedFileExtention { get; set; }
        public byte[]? UploadedFile { get; set; }
        public DateTime? SetDate { get; set; }
        public string? CreatedBy { get; set; }

    }
}
