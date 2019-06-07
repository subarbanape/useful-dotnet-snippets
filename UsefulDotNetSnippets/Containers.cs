using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvinun.UsefulDotNetSnippets
{
    public static class Containers
    {
        public static List<List<T>> Init2DList<T>(int rows, int columns)
        {
            List<List<T>> list = new List<List<T>>();
            for (int row = 0; row < rows; row++)
            {
                List<T> insideList = new List<T>();
                for (int col = 0; col < columns; col++)
                    insideList.Add(default(T));
                list.Add(insideList);
            }
            return list;
        }

        public static int[,] Create2DArray(int rows, int columns)
        {
            int[,] sample2DArray = new int[rows, columns];
            Random random = new Random();

            for (int row = 0; row < sample2DArray.GetLength(0); row++)
                for (int col = 0; col < sample2DArray.GetLength(1); col++)
                {
                    sample2DArray[row, col] = random.Next();
                }

            return sample2DArray;
        }

    }
}
