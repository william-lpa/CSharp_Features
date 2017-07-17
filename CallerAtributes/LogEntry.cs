using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSharp_5.Caller_Atributes
{
    public enum SeverityLevel
    {
        Information, Warning, Error, Critical
    }
    public class LogEntry
    {
        public string Method { get; private set; }
        public string SourceFile { get; private set; }
        public int LineNumber { get; private set; }
        public string Message { get; private set; }
        public SeverityLevel SeverityLevel { get; private set; }

        private LogEntry(string message, SeverityLevel level)
        {
            Message = message;
            SeverityLevel = level;
        }
        public static LogEntry CreateNew(string message, SeverityLevel level, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            var entry = new LogEntry(message, level);
            entry.Method = memberName;
            entry.SourceFile = sourceFilePath;
            entry.LineNumber = sourceLineNumber;
            return entry;
        }

        [Obsolete]
        public static LogEntry DeprecatedCreateNew(string message, SeverityLevel level, string memberName, string sourceFilePath, int sourceLineNumber)
        {
            var entry = new LogEntry(message, level);
            entry.Method = memberName;
            entry.SourceFile = sourceFilePath;
            entry.LineNumber = sourceLineNumber;
            return entry;
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Error Severity:" + SeverityLevel.ToString());
            builder.AppendLine("File:" + SourceFile);
            builder.AppendLine("Method:" + Method);
            builder.AppendLine("Line:" + LineNumber);
            builder.AppendLine("======================");
            return builder.ToString();
        }
    }
}