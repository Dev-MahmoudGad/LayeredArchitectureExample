using Test.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test.Domain.Enums;

namespace Test.Domain.Entities;

[Table("Employee", Schema = "HR")]
public class Employee : Audit
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public decimal Salary { get; set; }
    public string Email { get; set; }
    [StringLength(150)]
    public string? Filename { get; init; }
    public byte[]? FileData { get; set; }
    public FileType? FileType { get; set; }
    public int DepartmentId { get; set; }

}

