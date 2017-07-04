using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_5.Caller_Information
{
    class Log
    {
        private const string LOG_DIRECTORY = "C:";
        private const string FILE_NAME = "log.txt";
        private static Log instance;
        private IEnumerable<LogEntry> entries;
        public static Log Instance => instance = (instance ?? new Log());
        private Log()
        {
            Path.Combine(LOG_DIRECTORY, FILE_NAME);
        }
    }
}
