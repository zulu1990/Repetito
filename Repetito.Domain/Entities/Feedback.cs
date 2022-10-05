using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repetito.Domain.Entities
{
    public class Feedback : BaseEntity
    {
        public Guid TeacherId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
