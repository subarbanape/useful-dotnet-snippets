using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvinun.UsefulDotNetSnippets
{
    public static class Linq_Cards
    {
        static IEnumerable<string> Suits()
        {
            yield return "clubs";
            yield return "diamonds";
            yield return "hearts";
            yield return "spades";
        }

        static IEnumerable<string> Ranks()
        {
            yield return "two";
            yield return "three";
            yield return "four";
            yield return "five";
            yield return "six";
            yield return "seven";
            yield return "eight";
            yield return "nine";
            yield return "ten";
            yield return "jack";
            yield return "queen";
            yield return "king";
            yield return "ace";
        }

        public static void Run()
        {
            // Below 2 produces the same output. One is with LINQ and other is LAMBDA
            var startingDeck = from s in Suits()
                               from r in Ranks()
                               select new { Suit = s, Rank = r };
            startingDeck.ToList().ForEach(item => Console.WriteLine(item));

            startingDeck = Suits().SelectMany(suit => Ranks().Select(rank => new { Suit = suit, Rank = rank }));
            startingDeck.ToList().ForEach(item => Console.WriteLine(item));

            // 52 cards in a deck, so 52 / 2 = 26
            var top = startingDeck.Take(26); // select top 26
            var bottom = startingDeck.Skip(26); // select bottom 26

            // TBD - Practice other exercises when time permits
            // https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/working-with-linq


        }
    }
}
