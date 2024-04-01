using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Test.Domain.Common;
public class Audit
{
    public DateTime CreatedOn { get; set; }
    public DateTime LastModifiedOn { get; set; }
}