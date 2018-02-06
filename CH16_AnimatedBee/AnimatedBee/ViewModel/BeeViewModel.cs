using AnimatedBee.View;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;

namespace AnimatedBee.ViewModel
{
    public class BeeViewModel
    {
        private readonly ObservableCollection<System.Windows.UIElement> _sprites = new ObservableCollection<UIElement>();
        public INotifyCollectionChanged Sprites => _sprites;

        public BeeViewModel()
        {
            var firstBee = BeeFactory.Build(50, 50, TimeSpan.FromMilliseconds(50));
            _sprites.Add(firstBee);
            var secondBee = BeeFactory.Build(200, 200, TimeSpan.FromMilliseconds(75));
            _sprites.Add(secondBee);
            var thirdBee = BeeFactory.Build(300, 125, TimeSpan.FromMilliseconds(100));
            _sprites.Add(thirdBee);

            firstBee.Animate(50, 450, 40, 3);
            secondBee.Animate(80, 380, 260, 4);
            thirdBee.Animate(230, 10, 100, 5);
        }
    }
}
