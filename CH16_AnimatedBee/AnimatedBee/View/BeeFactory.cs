using System;
using System.Collections.Generic;

namespace AnimatedBee.View
{
    public static class BeeFactory
    {
        public static AnimatedImage Build(double width, double height, TimeSpan flapInterval)
        {
            var imageNames = new List<string>
            {
                "Images\\Bee animation 1.png",
                "Images\\Bee animation 2.png",
                "Images\\Bee animation 3.png",
                "Images\\Bee animation 4.png"
            };

            return new AnimatedImage(imageNames, flapInterval)
            {
                Width = width,
                Height = height
            };
        }
    }
}
