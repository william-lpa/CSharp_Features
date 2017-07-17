using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SintaxFeatures
{
    class NullPropagation
    {
        public NullPropagation()
        {
            var beforeElvis = new BeforeNullPropagationReadTextFile();
            beforeElvis.ReadFile();
            var processedFile = beforeElvis.ProcessFile();
            if (processedFile != null)
                Console.WriteLine(processedFile.ToUpper());

            var afterElvis = new AfterNullPropagationReadTextFile();
            afterElvis.ReadFile();
            Console.WriteLine(afterElvis?.ProcessFile()?.ToUpper());
        }
    }

    class BeforeNullPropagationReadTextFile
    {
        public string FullFileName { get; set; }
        List<string> LinesOfText { get; } = new List<string>();
        public int CountOfLines => LinesOfText != null ? LinesOfText.Count : 0;

        public void ReadFile()
        {
            using (StreamReader reader = File.OpenText(FullFileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (LinesOfText != null)
                        LinesOfText.Add(line);
                }
            }
        }

        public string ProcessFile()
        {
            foreach (var line in LinesOfText)
            {
                if (line != null)
                {
                    using (var stream = File.CreateText("c://" + line.Substring(0, 2) + ".dat"))
                    {
                        if (stream != null)
                            stream.Write(line.GetType() != null ? line.GetType().GUID.ToByteArray() : null);
                    }
                }
            }
            return "ok!";
        }

    }
    class AfterNullPropagationReadTextFile
    {
        public string FullFileName { get; set; }
        List<string> LinesOfText { get; } = new List<string>();
        public int CountOfLines => LinesOfText?.Count ?? 0;

        public void ReadFile()
        {
            using (StreamReader reader = File.OpenText(FullFileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    LinesOfText?.Add(line);
                }
            }
        }
        public string ProcessFile()
        {
            foreach (var line in LinesOfText)
            {
                File.CreateText("c://" + line?.Substring(0, 2) + ".dat")?.Write(line.GetType()?.GUID.ToByteArray());
            }
            return "ok!";
        }
    }

}

