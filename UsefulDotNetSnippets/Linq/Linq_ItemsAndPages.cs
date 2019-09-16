using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvinun.UsefulDotNetSnippets
{
    public class Linq_ItemsAndPages
    {
        public static void somefunction()
        {
            List<List<string>> list = new List<List<string>>()
            {
                new List<string>() {"p2","1","2" },
                new List<string>() {"p5","2","3" },
                new List<string>() {"p3","3","4" },
                new List<string>() {"p6","4","5" },
                new List<string>() {"p9","5","6" },
                new List<string>() {"p1","6","7" },
                new List<string>() {"p4","7","8" },
            };

            int itemsPerPage = 4;
            int pageNumberToReturn = 1;
            int sortByColumn = 0;
            int sortByOrder = 0;

            // sort by the column - sortByColumn & sortByOrder
            var sortedList = sortByOrder == 1 ?
                list.OrderByDescending(items => items[sortByColumn]) :
                list.OrderBy(items => items[sortByColumn]);

            // Divide the list items by pages
            Dictionary<int, List<List<string>>> result = new Dictionary<int, List<List<string>>>();
            int pageItemCount = 0;
            int count = sortedList.Count();
            for (int i = 0; i < count;)
            {
                int itemsPerPageMin = (count - i) <= itemsPerPage ? (count - i) : itemsPerPage;
                var page = sortedList.ToList().GetRange(i, itemsPerPageMin);
                i += itemsPerPage;
                result.Add(pageItemCount, page);
                pageItemCount++;
            }

            // Print the specified page
            var pageResult = result.Count() >= pageNumberToReturn ? result[pageNumberToReturn] : null;
            // priting the list inside a list
            pageResult.ToList().ForEach(item => { Console.WriteLine(String.Join(" ", item.ToArray())); });

            // Above solution - just using pure LINQ 
            var resultPureLinq = (sortByOrder == 1 ?
                list.OrderByDescending(items => items[sortByColumn]) :
                list.OrderBy(items => items[sortByColumn]))
                .ToList()
                .GetRange(pageNumberToReturn * itemsPerPage, (list.Count - (pageNumberToReturn * itemsPerPage)) > itemsPerPage ? itemsPerPage : (list.Count - (pageNumberToReturn * itemsPerPage)));
        }
    }
}
