using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repetito.Contracts.General
{
    public record FeedbackDTO
    {
        public string Comment { get; set; }
        public int Rating { get; set; }   
    }
}
