using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvinun.UsefulDotNetSnippets
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Commented Code. Uncomment to run them.

            //List<List<int>> list = Containers.Init2DList<int>(4, 4);

            //int[,] sample2DArray = Containers.Create2DArray(300, 300);
            //for (int row = 0; row < sample2DArray.GetLength(0); row++)
            //{
            //    for (int col = 0; col < sample2DArray.GetLength(1); col++)
            //    {
            //        Console.Write(sample2DArray[row, col] + " ");
            //    }
            //    Console.WriteLine();
            //}

            //int[,] twodarrays = new int[3, 3] { { 1, 2, 3, }, { 4, 5, 6, }, { 7, 8, 9 } };

            //foreach (var item in twodarrays)
            //{
            //    Console.WriteLine(item);
            //}

            //Linq.EnumerableMethods();

            #endregion

            StringOperations.IterateOverCommaDelimitedString();            

        }
    }
}
