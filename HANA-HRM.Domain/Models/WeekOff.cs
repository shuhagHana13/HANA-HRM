using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HANA_HRM.Models;

[PrimaryKey("IdClient", "Id")]
[Table("WeekOff")]
[Index("IdClient", Name = "UNQ_WeekOff", IsUnique = true)]
public partial class WeekOff
{
    [Key]
    public int IdClient { get; set; }

    [Key]
    public int Id { get; set; }

    [StringLength(3)]
    public string? WeekOffDay { get; set; }

    public DateTime? SetDate { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    [InverseProperty("WeekOff")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
