using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_5.Caller_Atributes
{
    class Log : IEnumerable<LogEntry>
    {
        private const string LOG_DIRECTORY = "C:";
        private const string FILE_NAME = "log.txt";
        private static Log instance;
        private IList<LogEntry> entries;
        public static Log Instance => instance = (instance ?? new Log());
        private Log()
        {
            Path.Combine(LOG_DIRECTORY, FILE_NAME);
            entries = new List<LogEntry>();
        }

        public void AddEntry(LogEntry entry)
        {
            entries.Add(entry);
        }

        public IEnumerator<LogEntry> GetEnumerator()
        {
            return entries.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
