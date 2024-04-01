using Test.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Test.Domain.Entities;

[Table("Department", Schema = "HR")]
public class Department : Audit
{

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string DepartmentName { get; set; }


}
