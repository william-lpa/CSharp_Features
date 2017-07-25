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
            var listOfDates = new List<DateTime>()
            {
                new DateTime(2010, 01, 30),
                new DateTime(2011, 02, 11),
                new DateTime(2015, 01, 22),
                new DateTime(2012, 05, 21),
                new DateTime(1999, 08, 19),
                new DateTime(2016, 07, 12),
                new DateTime(2017, 02, 02),
                new DateTime(2017, 04, 08)
            };

            GetHighestDateBeforeNestedFunctions(listOfDates);
            GetHigestDateAfterNestedFunctions(listOfDates);
        }
        public DateTime GetHighestDateBeforeNestedFunctions(IList<DateTime> values)
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

        public DateTime GetHigestDateAfterNestedFunctions(IList<DateTime> values)
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

