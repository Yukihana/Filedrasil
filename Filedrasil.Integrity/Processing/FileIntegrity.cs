using Filedrasil.Integrity.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filedrasil.Integrity.Processing
{
    public class FileIntegrity
    {
        private readonly string[] FilePaths;
        private readonly int BufferSize;
        private readonly RepairOptions Options;

        public FileIntegrity(string[] files, int bufferSize = -1, RepairOptions? options = null)
        {
            FilePaths = files;
            BufferSize = bufferSize == -1 ? AssemblyConfig.BufferSize : bufferSize;
            Options = options ?? new();
        }

        public IntegrityReport Analyze()
        {

        }
    }
}
