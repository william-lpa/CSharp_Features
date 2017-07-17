using System;
using static System.Math;
using static System.String;
namespace SintaxFeatures
{
    class BeforeStaticUsing
    {
        public int IntegerNumber { get; set; }

        public BeforeStaticUsing(string number)
        {
            if (!string.IsNullOrWhiteSpace(number))
                IntegerNumber = RoundNumber(double.Parse(number));
        }

        private int RoundNumber(double number) => (int)Math.Round(number);
    }
    class AfterStaticUsing
    {
        public int RoundedNumber { get; set; }

        public AfterStaticUsing(string number)
        {
            if (!IsNullOrWhiteSpace(number))
                RoundedNumber = RoundNumber(double.Parse(number));
        }

        private int RoundNumber(double number) => (int)Round(number);
    }
}
