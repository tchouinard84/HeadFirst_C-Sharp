using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using static System.Windows.Controls.Canvas;

namespace StarryNight.View
{
    public static class BeeStarHelper
    {
        public static AnimatedImage BeeFactory(double width, double height, TimeSpan flapInterval)
        {
            var imageNames = new List<string>
            {
                "Bee animation 1.png",
                "Bee animation 2.png",
                "Bee animation 3.png",
                "Bee animation 4.png"
            };

            return new AnimatedImage(imageNames, flapInterval) { Width = width, Height = height };
        }

        public static void SetCanvasLocation(UIElement control, double x, double y)
        {
            SetLeft(control, x);
            SetTop(control, y);
        }

        public static void MoveElementOnCanvas(UIElement uiElement, double toX, double toY)
        {
            var fromX = GetLeft(uiElement);
            var fromY = GetTop(uiElement);

            var animationX = CreateDoubleAnimation(uiElement, fromX, toX, new PropertyPath(LeftProperty));
            var animationY = CreateDoubleAnimation(uiElement, fromY, toY, new PropertyPath(TopProperty));
            var storyboard = new Storyboard();
            storyboard.Children.Add(animationX);
            storyboard.Children.Add(animationY);
            storyboard.Begin();
        }

        private static DoubleAnimation CreateDoubleAnimation(UIElement uiElement, double from, double to, PropertyPath propertyToAnimate)
        {
            var animation = new DoubleAnimation();
            Storyboard.SetTarget(animation, uiElement);
            Storyboard.SetTargetProperty(animation, propertyToAnimate);
            animation.From = from;
            animation.To = to;
            animation.Duration = TimeSpan.FromSeconds(3);
            return animation;
        }

        public static void SendToBack(StarControl newStar)
        {
            Panel.SetZIndex(newStar, -1000);
        }
    }
}
