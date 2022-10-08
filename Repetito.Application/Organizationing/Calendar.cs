using Repetito.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repetito.Application.Organizationing
{
    public class Calendar
    {
        public ICollection<CalendarEntry> CalendarEntries { get; set; }
    }
}
