using System;
using System.Runtime.ExceptionServices;

namespace ThrowExample
{
    class Program
    {
        private const int cenarioError = 0;
        static void Main(string[] args)
        {
            try
            {
                DoSomething();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.StackTrace);
            }
            Console.ReadKey();
        }

        private static void DoSomething()
        {
            try
            {
                Console.WriteLine("Some Work Done!");
                ThrowOne();

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
                        throw new ArgumentException("Argument Exception");
                    case 3:
                        ExceptionDispatchInfo.Capture(err).Throw();
                        break;
                }
            }
        }

        private static void ThrowOne()
        {
            ThrowTwo();
        }

        private static void ThrowTwo()
        {
            ThrowThree();
        }

        private static void ThrowThree()
        {
            try
            {
                throw new NotImplementedException("Not Implemented");
            }
            catch (Exception err)
            {
                throw;
            }
        }
    }
}
