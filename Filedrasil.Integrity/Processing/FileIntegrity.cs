using Filedrasil.Integrity.Reports;

namespace Filedrasil.Integrity.Processing;

public static class FileIntegrity
{
    /// <summary>
    /// Matches the blocks and sends back a list of indices where the data mismatches.
    /// </summary>
    /// <param name="blocks"></param>
    /// <returns>A list of indices where the data mismatches.</returns>
    /// <exception cref="ArgumentException">If the blocks are of mismatching sizes.</exception>
    public static int[] MatchBlocks(List<byte[]> blocks)
    {
        if (blocks.Select(x => x.Length).Distinct().Count() != 1)
            throw new ArgumentException("buffer size mismatch");
        List<int> result = new();
        for(int i = 0; i< blocks[i].Length; i++)
        {
            if(blocks.Select(x => x[i]).Distinct().Count() != 1)
                result.Add(i);
        }
        return result.ToArray();
    }

    public static byte? GetMajorityVotedByte(byte[] bytes)

    private readonly string[] FilePaths;
    private readonly int BufferSize;
    private readonly RepairOptions Options;

    public FileIntegrity(string[] files, int bufferSize = -1, RepairOptions? options = null)
    {
        FilePaths = files;
        BufferSize = bufferSize == -1 ? AssemblyConfig.BlockSize : bufferSize;
        Options = options ?? new();
    }

    public IntegrityReport Analyze()
    {
    }
}