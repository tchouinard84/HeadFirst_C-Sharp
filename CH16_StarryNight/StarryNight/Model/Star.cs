using System.Windows;

namespace StarryNight.Model
{
    public class Star
    {
        public Point Location { get; set; }

        public Star(Point location)
        {
            Location = location;
        }
    }
}
