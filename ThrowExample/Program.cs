using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ThrowExample
{
    class Program
    {
        static void Main(string[] args)
        {
            DoSomething();
        }

        private static void DoSomething()
        {
            Console.WriteLine("Some Work Done!");
            try
            {
                ThrowAndError(0);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
            }
        }

        private static void ThrowAndError(int cenarioError)
        {
            try
            {
                throw new NotImplementedException("Not Implemented");
            }
            catch (Exception err)
            {
                switch (cenarioError)
                {
                    case 0:
                        throw;
                    case 1:
                        throw err;
                    case 2:
                        throw new ArgumentException("Method was not implemented");
                    case 3:
                        ExceptionDispatchInfo.Capture(err).Throw();
                        break;
                }
            }
        }


    }
}
