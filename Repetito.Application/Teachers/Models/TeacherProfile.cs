using Repetito.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repetito.Application.Teachers.Models
{
    public record TeacherProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Sex Sex { get; set; }
        public City City { get; set; }
        public string Subject { get; set; }
        public double Rating { get; set; }
        public int Experience { get; set; }
    }
}
