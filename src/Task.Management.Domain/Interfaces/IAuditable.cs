using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Management.Domain.Interfaces
{
    public interface IAuditable
    {
        DateTime DeletedAt { get; set; }
    }
}
