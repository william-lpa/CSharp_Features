using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharp_5.Caller_Information
{
    public enum SeverityLevel
    {
        Information, Warning, Error, Critical
    }
    internal class LogEntry
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

        static void InsertLog(string methodName, string fileName, int lineNumber, string message)
        {
            Console.WriteLine("{0} called method B at {1} ", methodName, DateTime.Now);
        }
    }
}