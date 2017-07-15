using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SintaxFeatures
{
    class ExpressionBodiedMembers
    {
        public ExpressionBodiedMembers()
        {
            Console.WriteLine(new PersonAfterExpressionBodiedMembers().ToString());
            Console.WriteLine(new PersonBeforeExpressionBodiedMembers().ToString());
        }
    }
    class PersonBeforeExpressionBodiedMembers
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return string.Concat(FirstName, " ", LastName);
            }
        }
        public int Age { get; set; }
        public bool IsMajorAge
        {
            get { return Age > 17; }
        }
        public string Address { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}", FullName, Age);
        }

        public bool DoesLikeIceCream(string flavour)
        {
            return flavour == "Chocolate" ? true : false;
        }
    }

    class PersonAfterExpressionBodiedMembers
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => string.Concat(FirstName, " ", LastName);
        public int Age { get; set; }
        public bool IsMajorAge => Age > 17;
        public string Address { get; set; }

        public override string ToString() => string.Format("{0}, {1}", FullName, Age);

        public bool DoesLikeIceCream(string flavour) => flavour == "Chocolate" ? true : false;
    }
}
