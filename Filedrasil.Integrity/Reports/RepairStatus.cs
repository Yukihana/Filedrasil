using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filedrasil.Integrity.Reports
{
    public enum RepairStatus
    {
        None,
        InsufficientCopies,
        InconsistentLengths,
        IndeterminateVote,
        CompletedWithRepairs,
        NoRepairsRequired,
    }
}
