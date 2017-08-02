using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SintaxFeatures
{
    class StringInterpolation
    {
        public StringInterpolation()
        {
            Console.WriteLine(new PersonBeforeStringInterpolation().ToString());
            Console.WriteLine(new PersonAfterStringInterpolation().ToString());
        }
    }
    class PersonBeforeStringInterpolation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => string.Concat(FirstName, " ", LastName);
        public int Age { get; set; }
        public bool IsMajorAge => Age > 17;
        public string Address { get; set; }
        public bool DoesLikeIceCream(string flavour) => flavour == "Chocolate" ? true : false;

        public string ToStringConcatenation()
        {
            return FullName + " has " + Age + " years old and he lives at " + Address + ". He likes chocolate ice cream";
        }
        public string ToStringConcatMethod()
        {
            return string.Concat(FullName, " has ", Age, " years old and he lives at ", Address, ". He likes chocolate ice cream");
        }
        public string ToStringStringFormat()
        {
            return string.Format("{0} has {1} years old and he lives at {2}. He likes chocolate ice cream", FullName, Age, Address);
        }
    }

    class PersonAfterStringInterpolation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => string.Concat(FirstName, " ", LastName);
        public int Age { get; set; }
        public bool IsMajorAge => Age > 17;
        public string Address { get; set; }
        public bool DoesLikeIceCream(string flavour) => flavour == "Chocolate" ? true : false;

        public string ToStringInterpolated()
        {
            return $"{FullName} has {Age} years old and he lives at {Address}. He likes chocolate ice cream";
        }
    }
}

