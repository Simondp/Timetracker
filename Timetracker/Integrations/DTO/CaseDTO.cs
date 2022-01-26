using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetracker.Integrations.DTO
{
    internal class CaseDTO
    {
        int CaseId { get; set; }    
        string CaseName { get; set; }
        int CaseStatus { get; set; }
        float TimeEstimate { get; set; }

    }
}
