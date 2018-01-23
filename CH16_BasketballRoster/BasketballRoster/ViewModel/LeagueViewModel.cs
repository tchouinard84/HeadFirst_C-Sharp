﻿using BasketballRoster.Model;
using System.Collections.Generic;

namespace BasketballRoster.ViewModel
{
    public class LeagueViewModel
    {
        public RosterViewModel JimmysTeam { get; set; }
        public RosterViewModel BriansTeam { get; set; }

        public LeagueViewModel()
        {
            JimmysTeam = new RosterViewModel(new Roster("The Amazins", GetAmazinPlayers()));
            BriansTeam = new RosterViewModel(new Roster("The Bombers", GetBomberPlayers()));
        }

        private static IEnumerable<Player> GetAmazinPlayers()
        {
            return new[]
            {
                new Player("Jimmy", 42, true),
                new Player("Henry", 11, true),
                new Player("Bob", 4, true),
                new Player("Lucinda", 18, true),
                new Player("Kim", 16, true),
                new Player("Bertha", 23, false),
                new Player("Ed", 21, false)
            };
        }

        private static IEnumerable<Player> GetBomberPlayers()
        {
            return new[]
            {
                new Player("Brian", 31, true),
                new Player("Lloyd", 23, true),
                new Player("Kathleen", 6, true),
                new Player("Mike", 0, true),
                new Player("Joe", 42, true),
                new Player("Herb", 32, false),
                new Player("Fingers", 8, false)
            };
        }
    }
}
