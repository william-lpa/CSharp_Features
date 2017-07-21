using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_7
{
    class NestedFunctions
    {
        public NestedFunctions()
        {
            GetMaxBeforeDateNestedFunctions(new List<DateTime>() { });

        }
        public DateTime GetMaxBeforeDateNestedFunctions(IList<DateTime> values)
        {
            Func<DateTime, DateTime, DateTime> ReturnBiggerDate = (leftDate, rightDate) =>
             {
                 return (leftDate > rightDate) ? leftDate : rightDate;
             };

            var biggestDate = values.First();

            foreach (var date in values)
                biggestDate = ReturnBiggerDate(biggestDate, date);

            return biggestDate;
        }

        public DateTime GetMaxAfterDateNestedFunctions(IList<DateTime> values)
        {
            DateTime ReturnBiggerDate(DateTime leftDate, DateTime rightDate)
            {
                return (leftDate > rightDate) ? leftDate : rightDate;
            };

            var biggestDate = values.First();

            foreach (var date in values)
                biggestDate = ReturnBiggerDate(biggestDate, date);

            return biggestDate;
        }
    }
}
}
