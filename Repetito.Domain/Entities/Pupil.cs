using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repetito.Domain.Entities
{
    public class Pupil : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }


        public List<Teacher> Teachers { get; set; }
        public ICollection<CalendarEntry> Calendar { get; set; }
    }
}
