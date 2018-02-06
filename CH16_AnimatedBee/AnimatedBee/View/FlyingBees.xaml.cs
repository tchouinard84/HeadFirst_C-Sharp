using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AnimatedBee.View
{
    /// <summary>
    /// Interaction logic for FlyingBees.xaml
    /// </summary>
    public partial class FlyingBees : Window
    {
        public FlyingBees()
        {
            InitializeComponent();

            var imageNames = new List<string>
            {
                "Images\\Bee animation 1.png",
                "Images\\Bee animation 2.png",
                "Images\\Bee animation 3.png",
                "Images\\Bee animation 4.png"
            };

            firstBee.StartAnimation(imageNames, TimeSpan.FromMilliseconds(50));
            secondBee.StartAnimation(imageNames, TimeSpan.FromMilliseconds(75));
            thirdBee.StartAnimation(imageNames, TimeSpan.FromMilliseconds(100));

            MoveBee(firstBee, 50, 450, 3);
            MoveBee(secondBee, 80, 380, 4);
            MoveBee(thirdBee, 230, 10, 6);
        }

        private void MoveBee(AnimatedImage bee, double from, double to, double seconds)
        {
            var storyboard = new Storyboard();
            var animation = new DoubleAnimation();
            Storyboard.SetTarget(animation, bee);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.LeftProperty));
            animation.From = from;
            animation.To = to;
            animation.Duration = TimeSpan.FromSeconds(seconds);
            animation.RepeatBehavior = RepeatBehavior.Forever;
            animation.AutoReverse = true;
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
    }
}
