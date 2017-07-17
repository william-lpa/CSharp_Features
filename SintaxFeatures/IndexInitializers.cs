using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SintaxFeatures
{
    class IndexInitializers
    {
        public IndexInitializers()
        {
            Console.WriteLine(BeforeIndexInitializer());
            Console.WriteLine(AfterIndexInitializer().Values);

        }
        private List<string> BeforeIndexInitializer()
        {
            return new List<string>
            {
                "Page not Found",
                "Page moved, but left a forwarding address.",
                "The web server can't come out to play today."
            };
        }

        private SortedDictionary<string, string> AfterIndexInitializer()
        {
            return new SortedDictionary<string, string>
            {
                ["404"] = "Page not found",
                ["302"] = "Page moved, but left a forwarding address.",
                ["500"] = "The web server can't come out to play today."
            };
        }
    }
}
