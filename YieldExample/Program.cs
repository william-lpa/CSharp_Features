using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>(10);
            tree.Insert(5);
            tree.Insert(11);
            tree.Insert(5);
            tree.Insert(-12);
            tree.Insert(15);
            tree.Insert(0);
            tree.Insert(14);
            tree.Insert(-8);
            tree.Insert(10);

            //tree.WalkTree(); //cannot change IEnumerator state

            foreach (int item in tree)
                Console.WriteLine(item + " some logic change here");

            Console.ReadLine();
        }
    }
}
