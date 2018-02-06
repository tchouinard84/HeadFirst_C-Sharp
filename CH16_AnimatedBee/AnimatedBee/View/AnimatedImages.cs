using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AnimatedBee.View
{
    public static class AnimatedImages
    {
        public static void Location(this AnimatedImage bee, double x, double y)
        {
            Canvas.SetLeft(bee, x);
            Canvas.SetTop(bee, y);
        }

        public static void Animate(this AnimatedImage bee, double fromX, double toX, double y, double seconds)
        {
            Canvas.SetTop(bee, y);
            var animation = DoubleAnimation(fromX, toX, seconds);

            Storyboard.SetTarget(animation, bee);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.LeftProperty));

            var storyboard = new Storyboard();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }

        private static DoubleAnimation DoubleAnimation(double fromX, double toX, double seconds)
        {
            return new DoubleAnimation
            {
                From = fromX,
                To = toX,
                Duration = TimeSpan.FromSeconds(seconds),
                RepeatBehavior = RepeatBehavior.Forever,
                AutoReverse = true
            };
        }
    }
}
