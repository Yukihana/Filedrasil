namespace Filedrasil.Integrity.Reports
{
    public class IntegrityReport
    {
        public readonly RepairStatus Status;
        public readonly string Message;
        private readonly int[]? RepairedIndices;

        public IntegrityReport(RepairStatus status = RepairStatus.None, int[]? repairedIndices = null, string? message = null)
        {
            Message = message ?? string.Empty;
            Status = status;
            RepairedIndices = repairedIndices;
        }
    }
}