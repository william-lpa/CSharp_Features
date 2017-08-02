using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace CSharp7
{
    public class OutSelfDeclaring
    {
        public OutSelfDeclaring()
        {
            BeforeOutSelfDeclaring();
            AfterOutSelfDeclaring();
        }

        private void BeforeOutSelfDeclaring()
        {
            var convertedNumber = 0;

            if (int.TryParse("123", out convertedNumber))
            {
                Console.WriteLine(convertedNumber);
            }
        }
        private void AfterOutSelfDeclaring()
        {
            if (int.TryParse("123", out var nvertedNumber)) //you can even ignore de value with a _
            {
                Console.WriteLine(convertedNumber);
            }
        }
    }

}
