using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvinun.UsefulDotNetSnippets
{
    public static class Linq_DevsAndSkills
    {
        public static void somefunction()
        {
            List<List<string>> listSkillsAndDevs = new List<List<string>>()
            {
                new List<string>() {"C#","John" },
                new List<string>() {"C#","Bob" },
                new List<string>() {"C#","Ron" },
                new List<string>() {"C#","Kim" },
                new List<string>() {"C#","Tim" },
                new List<string>() { "C#", "Gill" },
                new List<string>() {"C#","Vinu" },

                new List<string>() {"SQL","Vinu" },
                new List<string>() {"SQL","Tim" },
                new List<string>() {"SQL","Jack" },
                new List<string>() {"SQL","Jym" },
                new List<string>() {"SQL","Gill" },
                new List<string>() {"SQL","Kim" },

                new List<string>() {"Java","Ilam" },
                new List<string>() {"Java","Ravi" },
                new List<string>() {"Java","Ben" },
                new List<string>() {"Java","Ken" },
                new List<string>() {"Java","Kim" },
                new List<string>() {"Java","Lyn" },
                new List<string>() {"Java","Vinu" },

                new List<string>() {"ReactJS","Vinu" },
                new List<string>() {"ReactJS","Ben" },
                new List<string>() {"ReactJS","Kim" },
                new List<string>() { "ReactJS", "Gill" },
            };


            // **********************************
            // **********************************
            // PROBLEM 1 - JUST GET ALL THE SKILLS
            // Get distinct skill items 
            // Lambda Way
            var skillsLambdaWay = listSkillsAndDevs.GroupBy(item => item[0]);
            // Query Way
            var skillsQueryWay = (from item in listSkillsAndDevs
                                  group item by item[0]);
            // **********************************
            // **********************************

            // **********************************
            // **********************************
            // PROBLEM 2 - FIND THE DEVS WHO KNOW BOTH C# AND REACTJS

            // Find devs who knows reactjs and c# 
            var reactJsAndCSharpDevs = (from item in listSkillsAndDevs
                                        where (item[0] == "C#" || item[0] == "ReactJS")
                                        select item[1])
                                        .GroupBy(item => item);


            // The same above query is used here inside "from XXXX in (<HERE>)"
            // You can either user the result of the above query or just use the query inside like this itself
            // To show that you are a 'complex being' :-) 
            var allDevsWhoKnowCSharpOrReactJS =
                (from DevName in
                        (from item in listSkillsAndDevs
                         where (item[0] == "C#" || item[0] == "ReactJS")
                         select new { Dev = item[1], ToGroup = item[1] })
                 group DevName by DevName.Dev into DevGroup
                 select DevGroup);
            // If you are using Group By, then you cant use Select 
            // If you are using Group By and Into, then you need to use Select like shown below

            // The above is repeated again to continue working on the solution
            // END RESULT ACHIEVED
            var devsWhoOnlyCSharpAndReactJS_QueryAndLambdaWay =
                (from DevName in
                        (from item in listSkillsAndDevs
                         where (item[0] == "C#" || item[0] == "ReactJS")
                         select new { Dev = item[1], ToGroup = item[1] })
                 group DevName by DevName.Dev into DevGroup
                 select DevGroup).Where(item => item.Count() == 2);
            // See, here we have mixed LAMBDA with QUERY expression

            // END RESULT ACHIEVED
            var devsWhoOnlyCSharpAndReactJS_QueryWay = from Dev in
                (from DevName in
                        (from item in listSkillsAndDevs
                         where (item[0] == "C#" || item[0] == "ReactJS")
                         select new { Dev = item[1], ToGroup = item[1] })
                 group DevName by DevName.Dev into DevGroup
                 select DevGroup)
                    where Dev.Count() == 2
                    select Dev;

            // See, here its a pure QUERY expression
            // **********************************
            // **********************************
            // **********************************

            // **********************************
            // **********************************
            // PROBLEM 3 - FIND THE DEVS WHO HAVE ALL SKILLS

            // Approach is to count the total skills first 
            // Then group the list by the dev and their skills
            // Select the dev whose skills count is equal to total skills obtained 

            var devsWhoHaveAllSkills =
                                    // Get the Devs who has all the skills
                                    from item in
                                    (
                                            // Group by Dev Names
                                            from devAndSkills in
                                            (
                                                // Create an anonymous list of Dev and Skills
                                                from skillAndDev in listSkillsAndDevs
                                                select new { Dev = skillAndDev[1], Skills = skillAndDev[0] }
                                            )
                                            group devAndSkills by devAndSkills.Dev
                                    )
                                    where item.Count() == (from itemSkill in listSkillsAndDevs
                                                           group itemSkill by itemSkill[0]).Count()
                                    select item.Key;
            // **********************************
            // **********************************
            // **********************************


            // **********************************
            // **********************************
            // PROBLEM 5 - RANK THE DEVS IN THE ORDER OF THEIR SKILLS

            var rankTheDevs =
                                        // order by devs with highest skills
                                        (from devOrdered in
                                        (
                                            // Group by Dev
                                            from devAndSkills in
                                            (
                                                // Create an anonymous list of Dev and Skills
                                                from item in listSkillsAndDevs
                                                select new { Dev = item[1], Skills = item[0] }
                                            )
                                            group devAndSkills by devAndSkills.Dev
                                        )
                                         orderby devOrdered.Count() descending
                                         select devOrdered)
                                         // This is just a LAMBDA select to take advantage of 'index' (can be any name) to rank the list
                                         .Select((devOrderedItem, index) => new
                                         {
                                             Dev = devOrderedItem.Key,
                                             // We use ToList and Select again to simplofy the complex IEnumerable object into simple list form.
                                             // Otherwise, there will be too much hierarchical data that we have to anyway simplify after obtaining the results.
                                             Skills = devOrderedItem.ToList().Select(devAndSkillCollection => devAndSkillCollection.Skills).ToList(),
                                             Rank = index + 1
                                         }
                                         );
            // In this problem, I have mixed QUERY style with LAMBDA since I didnt find the 'index' feature in QUERY style exp. which LAMBDA has
            // So, my methodology is to start with QUERY and whereever there is no feature available in QUERY, use LAMBDA
            // **********************************
            // **********************************
            // **********************************
        }
    }
}
