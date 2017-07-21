using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_7
{
    class TupleReturn
    {
        public TupleReturn()
        {
            InvokeOldTuple();
            InvokeNewTuple();
        }

        public void InvokeNewTuple()
        {
            //(string firstName, string lastName) = FullNameAfteTupleReturn();
            //string (firstName, lastName) = FullNameAfteTupleReturn();
            var (firstName, lastName) = LookUpAfteTupleReturn(0);
            Console.WriteLine($"{firstName} {lastName}");
        }
        public void InvokeOldTuple()
        {
            var name = LookUpBeforeTupleReturn(0); //ValueTuple<string, string>
            Console.WriteLine($"{name.Item1} {name.Item2}");
        }


        public Tuple<string, string> LookUpBeforeTupleReturn(long id) // tuple return type
        {
            return new Tuple<string, string>("Leonard", "William"); // tuple literal
        }

        public (string, string) LookUpAfteTupleReturn(long id) // tuple return type. You can add identifiers to them
        {
            return ( "William", "Pegler"); // tuple literal
        }


    }
}
