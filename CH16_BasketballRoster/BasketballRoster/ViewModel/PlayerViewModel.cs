using BasketballRoster.Model;

namespace BasketballRoster.ViewModel
{
    public class PlayerViewModel
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public static PlayerViewModel ValueOf(Player p)
        {
            return new PlayerViewModel
            {
                Name = p.Name,
                Number = p.Number
            };
        }
    }
}
