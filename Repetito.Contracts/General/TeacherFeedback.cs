using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repetito.Contracts.General;

public record TeacherFeedback(
    string Comment,
    int Rating,
    Guid TeacherId
    );
