using CSharp_5.Caller_Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CallerAtributes
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateOldRegistry();
            GenerateRegistries();
            GenerateOtherRegistries();
            //Log.Instance.AddEntry(LogEntry.DeprecatedCreateNew());
            foreach (var entry in Log.Instance)
            {
                Console.WriteLine(entry.ToString());
            }
            Console.ReadKey();
        }
        public static void GenerateOldRegistry()
        {
            var sf = new System.Diagnostics.StackTrace();
            var frame = sf.GetFrame(0);
            Log.Instance.AddEntry(LogEntry.DeprecatedCreateNew("Error Number " + 1, SeverityLevel.Error, frame.GetMethod().Name, frame.GetFileName(), frame.GetFileLineNumber()));
        }


        private static void GenerateOtherRegistries()
        {
            for (int i = 0; i < 7; i++)
            {
                Log.Instance.AddEntry(LogEntry.CreateNew("Error Number " + 1, SeverityLevel.Error));
            }
        }

        private static void GenerateRegistries()
        {
            for (int i = 0; i < 7; i++)
            {
                Log.Instance.AddEntry(LogEntry.CreateNew("Error Number " + 1, SeverityLevel.Information));
            }
        }
    }
}
