using Filedrasil.Integrity.Reports;
using Filedrasil.Integrity.Types;

namespace Filedrasil.Integrity.Processing
{
    public static class IntegrityCheck
    {

        /// <summary>
        /// Compares all bytes and returns the voted majority. Only peforms repair if byte count of all instances are same.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Repaired bytes</returns>
        public static IntegrityReport RepairByVotes(List<byte[]> data)
        {
            // Check copy count
            if (data.Count < 3)
                return new IntegrityReport(RepairStatus.InsufficientCopies);

            // Check data lengths
            int length = -1;
            foreach (byte[] bytes in data)
            {
                if (length == -1)
                    length = bytes.Length;
                else if (bytes.Length != length)
                    return new IntegrityReport(RepairStatus.InconsistentLengths);
            }

            // Prepare
            Counter<byte> counter = new();
            int copyIndex;
            List<int> modifiedCopies = new();
            int totalRepaired = 0;

            // For each byte: Analyze and repair
            for (int byteOffset = 0; byteOffset < length; byteOffset++)
            {
                // Clear workset
                counter.Clear();

                // Add corresponding bytes from each copy, analyze and get the voted byte
                for (copyIndex = 0; copyIndex < data.Count; copyIndex++)
                    counter.Add(data[copyIndex][byteOffset]);
                byte[] voted = counter.GetVoted();

                // If conflict in count, return
                if (voted.Length > 1)
                    return new IntegrityReport(RepairStatus.IndeterminateVote);

                // Check and repair
                for (copyIndex = 0; copyIndex < data.Count; copyIndex++)
                {
                    if (data[copyIndex][byteOffset] != voted[0])
                    {
                        data[copyIndex][byteOffset] = voted[0];

                        // Add report stats
                        modifiedCopies.Add(copyIndex);
                        totalRepaired++;
                    }
                }
            }

            // Finish
            return new IntegrityReport(
                modifiedCopies.Count > 0 ? RepairStatus.CompletedWithRepairs : RepairStatus.NoRepairsRequired,
                modifiedCopies.Distinct().OrderBy(x => x).ToArray());
        }
        public static byte? RepairBits(List<byte> data)
        {
            throw new NotImplementedException();
        }
    }
}