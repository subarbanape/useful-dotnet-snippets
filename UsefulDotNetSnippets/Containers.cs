using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvinun.UsefulDotNetSnippets
{
    public static class Containers
    {
        #region Lists
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
        #endregion

        #region Arrays
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
        #endregion

        #region Dictionary
        public static void DictionaryRelatedMethods()
        {
            // Dictionary commonly used methods
            Dictionary<int, int> scoresAndRanks = new Dictionary<int, int>();
            scoresAndRanks.Add(100, 1);
            scoresAndRanks.Add(90, 2);
            scoresAndRanks.Add(80, 3);
            scoresAndRanks.Add(70, 4);

            // Check if key already exist
            if (!scoresAndRanks.ContainsKey(60)) { scoresAndRanks.Add(60, 5); }

            // Print Dictionary
            foreach (KeyValuePair<int, int> kvp in scoresAndRanks)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
        }
        #endregion

        #region Tuples
        public static Tuple<int, int> ReturnMultipleValuesFromFunction()
        {
            return Tuple.Create(1, 2); // or return new Tuple<int, int>(1, 2);
        }



        #endregion
    }
}
