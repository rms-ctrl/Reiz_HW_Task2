using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reiz_HW_Task2
{
    internal class Utilities
    {
        /* Just a redirection method according to User preference.
         */
        public static void CreateStructure(Branch branch)
        {
            Console.WriteLine("Would you like to create the structure yourself " +
                "or use the one from the example? " +
                "(answer 'Myself' for custom structure, press ENTER for the Example)\n");
            string answer = Console.ReadLine();
            if (answer == "Myself")
            {
                CreateCustomStructure(branch);
            }
            else
            {
                CreateExampleStructure(branch);
            }
        }

        /* Calculates the maximum depth of our structure.
         * We go to the end of one of the paths and check
         * whether the current depth is greater than the maximum
         * depth that we already have.
         */
        public static int CalculateRecursively(int maxDepth, int currDepth, Branch currBranch)
        {
            currDepth++;
            if (currBranch.branches.Count == 0)
            {
                if (currDepth > maxDepth)
                {
                    maxDepth = currDepth;
                }
            }
            else
            {
                foreach (Branch branch in currBranch.branches)
                {
                    maxDepth = CalculateRecursively(maxDepth, currDepth, branch);
                }
            }
            return maxDepth;
        }
      
        /* A method in which the user creates the structure manually.
         * The imput always takes the left-most path.
         * When the user types in '0', it returns to the last fork
         * and continues the creation from there.
         */
        private static void CreateCustomStructure(Branch branch)
        {
            Console.WriteLine("\nHow many branches would you like this branch to have? ");           
            _ = int.TryParse(Console.ReadLine(), out int branchCount);
            if(branchCount == 0)
            {
                return;
            }
            else
            {
                for (int i = 0; i < branchCount; i++)
                {
                    branch.branches.Add(new Branch());
                }
                foreach (Branch tempBranch in branch.branches)
                {
                    CreateCustomStructure(tempBranch);
                }
            }
        }

        /* A method to visualize all paths of the structure recursively.
         */
        public static void Visualize(Branch branch, string path)
        {
            if (branch.branches.Count == 0)
            {
                string output = path.Remove(path.Length - 4);
                Console.WriteLine(output);
                return;
            }
            foreach(Branch tempBranch in branch.branches)
            {
                Visualize(tempBranch, path + " O ––– ");
            }
        }

        /* I am aware that this is a clumsy way to create it,
         * but just to have the example ready without input.
         *          1
         *         / \
         *        2   3
         *       /   /|\
         *      4   5 6 7
         *         /  |\
         *        8   9 10
         *            |
         *            11
         * We start adding the branches from the back.       
         * So Branch9 holds Branch11, which both are being held by Branch6,
         * then Branch3 and ultimately Branch1.
         * And this is repeated for all of the branch lines.
         */
        private static void CreateExampleStructure(Branch branch)
        {
            Branch branch9 = new Branch();
            Branch branch6 = new Branch();
            Branch branch5 = new Branch();
            Branch branch3 = new Branch();
            Branch branch2 = new Branch();
            branch9.branches.Add(new Branch());
            branch6.branches.Add(branch9);
            branch6.branches.Add(new Branch());
            branch5.branches.Add(new Branch());
            branch3.branches.Add(new Branch());
            branch3.branches.Add(branch6);
            branch3.branches.Add(branch5);
            branch2.branches.Add(new Branch());
            branch.branches.Add(branch2);
            branch.branches.Add(branch3);
        }
    }
}
