using System.Collections.Generic;
using BasketballRoster.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace BasketballRoster.ViewModel
{
    public class RosterViewModel
    {
        public string TeamName { get; set; }
        public ObservableCollection<PlayerViewModel> Starters { get; set; }
        public ObservableCollection<PlayerViewModel> Bench { get; set; }

        public RosterViewModel(Roster roster)
        {
            TeamName = roster.TeamName;
            UpdateRosters(roster);
        }

        private void UpdateRosters(Roster roster)
        {
            Starters = new ObservableCollection<PlayerViewModel>(DetermineStarters(roster));
            Bench = new ObservableCollection<PlayerViewModel>(DetermineBenchPlayers(roster));
        }

        private static IEnumerable<PlayerViewModel> DetermineStarters(Roster roster)
        {
            return from player in roster.Players
                where player.Starter == true
                select PlayerViewModel.ValueOf(player);
        }

        private static IEnumerable<PlayerViewModel> DetermineBenchPlayers(Roster roster)
        {
            return from player in roster.Players
                where player.Starter == false
                select PlayerViewModel.ValueOf(player);
        }
    }
}
