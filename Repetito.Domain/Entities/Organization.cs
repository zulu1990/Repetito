using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repetito.Domain.Entities
{
    public class Organization : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
