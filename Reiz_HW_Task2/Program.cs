using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reiz_HW_Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Branch branch = new Branch();
            Utilities.CreateStructure(branch);
            int finalDepth = Utilities.CalculateRecursively(0, 0, branch);
            Console.WriteLine("\nThe final depth of the structure is " + finalDepth);
            Utilities.Visualize(branch, " O –––");
            Console.ReadKey();
        }
    }
}
