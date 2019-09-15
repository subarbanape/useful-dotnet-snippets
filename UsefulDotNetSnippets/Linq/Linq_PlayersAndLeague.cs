using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvinun.UsefulDotNetSnippets
{
    public class Linq_PlayersAndLeague
    {
        public static RandomGenerator randomGenerator = new RandomGenerator();

        class League
        {
            public string Name;
            public Team[] Teams;
            public League(string name, Team[] teams)
            {
                Name = name;
                Teams = teams;
            }
        }

        class Team
        {
            public string Name;
            public Player[] Players; 
            public Team(string name, Player[] players)
            {
                Name = name;
                Players = players;
            }
        }

        class Player
        {
            public string Name;
            public int Age;
            public Player(string name) { Name = name; Age = randomGenerator.RandomNumber(21,40); }
        }

        public class RandomGenerator
        {
            private static Random rnd;
            static RandomGenerator()
            {
                rnd = new Random();
            }
            public int RandomNumber(int min, int max)
            {
                return rnd.Next(min, max);
            }
        }

        public static void SomeFunction()
        {
            Team[] westTeams = new Team[3] {
                new Team("Chargers", new Player[5] { new Player("Keenan"), new Player("Sean"), new Player("Geremy"), new Player("Austin"),new Player("Travis"),}),
                new Team("Broncos", new Player[5] { new Player("Cutler"), new Player("Bailey"), new Player("Marshall"), new Player("River"),new Player("Royce"),}),
                new Team("Oakland Riders", new Player[5] { new Player("Derek"), new Player("Dwayne"), new Player("Rodney"), new Player("Carr"),new Player("Denzelle"),}),
            };

            Team[] eastTeams = new Team[4] {
                new Team("Bills", new Player[5] { new Player("Josh"), new Player("Matt"), new Player("Ike"), new Player("Dion"),new Player("Patrick"),}),
                new Team("Patriots", new Player[5] { new Player("Tom"), new Player("Rex"), new Player("Marcus"), new Player("James"),new Player("Phillip"),}),
                new Team("Jets", new Player[5] { new Player("Nueman"), new Player("Atom"), new Player("Plaker"), new Player("Ronan"),new Player("Ldouza"),}),
                new Team("Dolphins", new Player[5] { new Player("Nemo"), new Player("Parrot"), new Player("Mango"), new Player("Kamal"),new Player("Dejavu"),}),
            };

            Team[] southTeams = new Team[3] {
                new Team("Titans", new Player[5] { new Player("Kareem"), new Player("Walter"), new Player("Brad"), new Player("Ajar"),new Player("Bachalu"),}),
                new Team("Colts", new Player[5] { new Player("Kishan"), new Player("Alaadin"), new Player("Brent"), new Player("Kappe"),new Player("Mane"),}),
                new Team("Texans", new Player[5] { new Player("Gopi"), new Player("Genie"), new Player("Bolima"), new Player("Kakkasu"),new Player("Neeru"),}),
            };

            Team[] northTeams = new Team[4] {
                new Team("Ravens", new Player[5] { new Player("Bagalu"), new Player("Bewawri"), new Player("Kakkeri"), new Player("Appais"),new Player("Ullais"),}),
                new Team("Bengals", new Player[5] { new Player("Rangole"), new Player("Kallanan"), new Player("Kalima"), new Player("Aitoja"),new Player("Kawade"),}),
                new Team("Browns", new Player[5] { new Player("Yeatch"), new Player("Thikamy"), new Player("Kadima"), new Player("Mendai"),new Player("Enikau"),}),
                new Team("Steelers", new Player[5] { new Player("Jaliga"), new Player("Gonney"), new Player("Loafy"), new Player("Ikkappa"),new Player("Ieregeu"),}),
            };


            List<League> leagues = new List<League>() {
                new League("AFC-West", westTeams),
                new League("AFC-South", southTeams),
                new League("AFC-North", northTeams),
                new League("AFC-East", eastTeams),
            };

            // Problem - get all teams
            var allTeams_QueryWay = from league in leagues
                           from team in league.Teams
                           select team;

            // See the difference between Select and Select Many is that the result for 
            // select is not flattened and teams are still grouped under leagues
            var allTeams_LambdaWay_Unflattened = leagues.Select(league => league.Teams);
            var allTeams_LambdaWay = leagues.SelectMany(league => league.Teams);

            var allTeams_MixedWay = from team in leagues.SelectMany(league => league.Teams)
                                    select team;

            // Problem - get all players
            var allPlayers_LambdaWay = leagues
                                        .SelectMany(league => league.Teams)
                                        .SelectMany(team => team.Players);

            // Problem - get all players whose age more than 33
            var allPlayers_whoseAgeMoreThan33 = leagues
                                                    .SelectMany(league => league.Teams)
                                                    .SelectMany(team => team.Players)
                                                    .Where(player => player.Age > 33);

            // Problem - get players from certain teams only
            var playersFromCertainTeams = leagues
                                            .SelectMany(league => league.Teams)
                                            .Where(team => team.Name == "Bengals" || team.Name == "Titans")
                                            .SelectMany(team => team.Players);

            // Problem - get all the players, their team and league
            var playersTheirTeamAndTheirLeague = leagues
                                                    .SelectMany(league => league.Teams,
                                                            (league, team) => new { LeagueName = league.Name, Team = team })
                                                     .SelectMany(leagueNameAndTeam => leagueNameAndTeam.Team.Players, 
                                                            (team, player) => new { PlayerName = player.Name, TeamName = team.Team.Name, LeagueName = team.LeagueName });
        }
    }
}
