using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;

namespace JimmysComics.DataModel
{
    public class ComicQueryManager
    {
        public ObservableCollection<ComicQuery> AvailableQueries { get; private set; }

        public ObservableCollection<object> CurrentQueryResults { get; private set; }

        public string Title { get; set; }

        public ComicQueryManager()
        {
            UpdateAvailableQueries();
            CurrentQueryResults = new ObservableCollection<object>();
        }

        private void UpdateAvailableQueries()
        {
            AvailableQueries = new ObservableCollection<ComicQuery> {
                new ComicQuery("LINQ makes queries easy", "A sample query",
                    "Let's show Jimmy how flexible LINQ is",
                    CreateImageFromAssets("purple_250x250.jpg")),

                new ComicQuery("Expensive comics", "Comics over $500",
                    "Comics whose value is over 500 bucks."
                        + " Jimmy can use this to figure out which comics are most coveted.",
                    CreateImageFromAssets("captain_amazing_250x250.jpg")),

                new ComicQuery("LINQ is versatile 1", "Modify every item returned from the query",
                    "This code will add a string onto the end of each string in an array.",
                    CreateImageFromAssets("bluegray_250x250.jpg")),

                new ComicQuery("LINQ is versatile 2", "Perform calculations on collections",
                    "LINQ provides extension methods for your collections (and anything else"
                      + " that implements IEnumerable<T>).",
                    CreateImageFromAssets("purple_250x250.jpg")),

                new ComicQuery("LINQ is versatile 3",
                    "Store all or part of your results in a new sequence",
                    "Sometimes you’ll want to keep your results from a LINQ query around.",
                    CreateImageFromAssets("bluegray_250x250.jpg")),

                new ComicQuery("Group comics by price range",
                    "Combine Jimmy's values into groups",
                    "Jimmy buys a lot of cheap comic books, some midrange comic books, and"
                         + " a few expensive ones, and he wants to know what his options are"
                         + " before he decides what comics to buy.",
                        CreateImageFromAssets("captain_amazing_250x250.jpg")),

                new ComicQuery("Join purchases with prices",
                    "Let's see if Jimmy drives a hard bargain",
                    "This query creates a list of Purchase classes that contain Jimmy's purchases"
                         + " and compares them with the prices he found on Greg's List.",
                    CreateImageFromAssets("captain_amazing_250x250.jpg")),

                new ComicQuery("All comics in the collection",
                   "Get all of the comics in the collection",
                   "This query returns all of the comics",
                   CreateImageFromAssets("captain_amazing_zoom_250x250.jpg")),
            };
        }

        private static BitmapImage CreateImageFromAssets(string imageFilename)
        {
            try
            {
                var uri = new Uri(@"..\Assets\" + imageFilename, UriKind.RelativeOrAbsolute);
                return new BitmapImage(uri);
            }
            catch (System.IO.IOException)
            {
                return new BitmapImage();
            }
        }


        public void UpdateQueryResults(ComicQuery query)
        {
            Title = query.Title;

            switch (query.Title)
            {
                case "LINQ makes queries easy": LinqMakesQueriesEasy(); break;
                case "Expensive comics": ExpensiveComics(); break;
                case "LINQ is versatile 1": LinqIsVersatile1(); break;
                case "LINQ is versatile 2": LinqIsVersatile2(); break;
                case "LINQ is versatile 3": LinqIsVersatile3(); break;
                case "Group comics by price range":
                    CombineJimmysValuesIntoGroups();
                    break;
                case "Join purchases with prices":
                    JoinPurchasesWithPrices();
                    break;
                case "All comics in the collection": AllComics(); break;
            }
        }

        public static IEnumerable<Comic> BuildCatalog()
        {
            return new List<Comic> {
                new Comic { Name = "Johnny America vs. the Pinko", Issue = 6, Year = 1949, CoverPrice = "10 cents",
                    MainVillain = "The Pinko", Cover = CreateImageFromAssets("Captain Amazing Issue 6 cover.png"),
                    Synopsis = "Captain Amazing must save America from Communists as The Pinko and his"
                        + " communist henchmen threaten to take over Fort Knox and steal all of the nation's gold." },

                new Comic { Name = "Rock and Roll (limited edition)", Issue = 19, Year = 1957, CoverPrice = "10 cents",
                    MainVillain = "Doctor Vortran", Cover = CreateImageFromAssets("Captain Amazing Issue 19 cover.png"),
                    Synopsis = "Doctor Vortran wreaks havoc with the nation's youth with his radio wave device that"
                        + " uses the latest dance craze to send rock and roll fans into a mind-control trance." },

                new Comic { Name = "Woman’s Work", Issue = 36, Year = 1968, CoverPrice = "12 cents",
                    MainVillain = "Hysterianna", Cover = CreateImageFromAssets("Captain Amazing Issue 36 cover.png"),
                    Synopsis = "The Captain faces his first female foe, Hysterianna, whose incredible telepathic"
                        + " and telekinetic abilities have allowed her to raise an all-girl army that"
                                + " even the Captain has trouble resisting." },

                new Comic { Name = "Hippie Madness (misprinted)", Issue = 57, Year = 1973, CoverPrice = "20 cents",
                    MainVillain = "The Mayor", Cover = CreateImageFromAssets("Captain Amazing Issue 57 cover.png"),
                    Synopsis = "A zombie apocalypse threatens Objectville when The Mayor rigs the election by"
                        + " introducing his zombification agent into the city's cigarette supply." },

                new Comic { Name = "Revenge of the New Wave Freak (damaged)", Issue = 68, Year = 1984,
                    CoverPrice = "75 cents", MainVillain = "The Swindler",
                    Cover = CreateImageFromAssets("Captain Amazing Issue 68 cover.png"),
                    Synopsis = "A tainted batch of eye makeup turns Dr. Alvin Mudd into the Captain's new nemesis,"
                        + " in The Swindler's first appearance in a Captain Amazing comic." },

                new Comic { Name = "Black Monday", Issue = 74, Year = 1986, CoverPrice = "75 cents",
                    MainVillain = "The Mayor", Cover = CreateImageFromAssets("Captain Amazing Issue 74 cover.png"),
                    Synopsis = "The Mayor returns to throw Objectville into a financial crisis by directing his"
                        + " zombie creation powers to the floor of the Objectville Stock Exchange." },

                new Comic { Name = "Tribal Tattoo Madness", Issue = 83, Year = 1996, CoverPrice = "Two bucks",
                    MainVillain = "Mokey Man", Cover = CreateImageFromAssets("Captain Amazing Issue 83 cover.png"),
                    Synopsis = "Monkey Man escapes from his island prison and wreaks havoc with his circus sideshow"
                        + " of tattooed henchmen that and their deadly grunge ray." },

                new Comic { Name = "The Death of an Object", Issue = 97, Year = 2013, CoverPrice = "Four bucks",
                    MainVillain = "The Swindler", Cover = CreateImageFromAssets("Captain Amazing Issue 97 cover.png"),
                    Synopsis = "The Swindler's clone army attacks Objectville in a ruse to trap and kill the "
                        + " Captain. Can the scientists of Objectville find a way to bring him back?" },
            };
        }

        private static Dictionary<int, decimal> GetPrices()
        {
            return new Dictionary<int, decimal> {
            { 6, 3600M }, { 19, 500M }, { 36, 650M }, { 57, 13525M },
            { 68, 250M }, { 74, 75M }, { 83, 25.75M }, { 97, 35.25M },
        };
        }

        private void LinqMakesQueriesEasy()
        {
            int[] values = { 0, 12, 44, 36, 92, 54, 13, 8 };
            var result = from v in values
                         where v < 37
                         orderby v
                         select v;

            CurrentQueryResults.Clear();
            foreach (var i in result)
                CurrentQueryResults.Add(
                     new
                     {
                         Title = i.ToString(),
                         Image = CreateImageFromAssets("purple_250x250.jpg"),
                     }
                    );
        }

        private void ExpensiveComics()
        {
            var comics = BuildCatalog();
            var values = GetPrices();

            var mostExpensive = from comic in comics
                                where values[comic.Issue] > 500
                                orderby values[comic.Issue] descending
                                select comic;

            CurrentQueryResults.Clear();
            foreach (var comic in mostExpensive)
                CurrentQueryResults.Add(
                        new
                        {
                            Title = $"{comic.Name} is worth {values[comic.Issue]:c}",
                            Image = CreateImageFromAssets("captain_amazing_250x250.jpg"),
                        }
                    );
        }

        private void LinqIsVersatile1()
        {
            string[] sandwiches = { "ham and cheese", "salami with mayo",
        "turkey and swiss", "chicken cutlet" };
            var sandwichesOnRye =
                from sandwich in sandwiches
                select sandwich + " on rye";

            CurrentQueryResults.Clear();
            foreach (var sandwich in sandwichesOnRye)
                CurrentQueryResults.Add(CreateAnonymousListViewItem(sandwich, "bluegray_250x250.jpg"));
        }

        private void LinqIsVersatile2()
        {
            var random = new Random();
            var listOfNumbers = new List<int>();
            var length = random.Next(50, 150);
            for (var i = 0; i < length; i++)
                listOfNumbers.Add(random.Next(100));

            CurrentQueryResults.Clear();
            CurrentQueryResults.Add(
                CreateAnonymousListViewItem($"There are {listOfNumbers.Count} numbers"));
            CurrentQueryResults.Add(
                CreateAnonymousListViewItem($"The smallest is {listOfNumbers.Min()}"));
            CurrentQueryResults.Add(
                CreateAnonymousListViewItem($"The biggest is {listOfNumbers.Max()}"));
            CurrentQueryResults.Add(
                CreateAnonymousListViewItem($"The sum is {listOfNumbers.Sum()}"));
            CurrentQueryResults.Add(
                CreateAnonymousListViewItem($"The average is {listOfNumbers.Average():F2}"));
        }

        private void LinqIsVersatile3()
        {
            var listOfNumbers = new List<int>();
            for (var i = 1; i <= 10000; i++)
                listOfNumbers.Add(i);

            var under50Sorted =
                    from number in listOfNumbers
                    where number < 50
                    orderby number descending
                    select number;

            var firstFive = under50Sorted.Take(6);

            var shortList = firstFive.ToList();
            foreach (var n in shortList)
                CurrentQueryResults.Add(CreateAnonymousListViewItem(n.ToString(), "bluegray_250x250.jpg"));
        }

        private object CreateAnonymousListViewItem(string title,
                        string imageFilename = "purple_250x250.jpg")
        {
            return new
            {
                Title = title,
                Image = CreateImageFromAssets(imageFilename),
            };
        }

        private void CombineJimmysValuesIntoGroups()
        {
            var values = GetPrices();
            var priceGroups =
                from pair in values
                group pair.Key by Purchase.EvaluatePrice(pair.Value)
                    into priceGroup
                orderby priceGroup.Key descending
                select priceGroup;
            foreach (var group in priceGroups)
            {
                var message = $"I found {@group.Count()} {@group.Key} comics: issues ";
                foreach (var price in group)
                    message += price.ToString() + " ";
                CurrentQueryResults.Add(
                   CreateAnonymousListViewItem(message, "captain_amazing_250x250.jpg"));
            }
        }

        private void JoinPurchasesWithPrices()
        {
            var comics = BuildCatalog();
            var values = GetPrices();
            var purchases = Purchase.FindPurchases();
            var results =
                from comic in comics
                join purchase in purchases
                on comic.Issue equals purchase.Issue
                orderby comic.Issue ascending
                select new
                {
                    Comic = comic,
                    Price = purchase.Price,
                    Title = comic.Name,
                    Subtitle = "Issue #" + comic.Issue,
                    Description = $"Bought for {purchase.Price:c}",
                    Image = CreateImageFromAssets("captain_amazing_250x250.jpg"),
                };

            decimal gregsListValue = 0;
            decimal totalSpent = 0;
            foreach (var result in results)
            {
                gregsListValue += values[result.Comic.Issue];
                totalSpent += result.Price;
                CurrentQueryResults.Add(result);
            }

            Title = $"I spent {totalSpent:c} on comics worth {gregsListValue:c}";
        }

        private void AllComics()
        {
            foreach (var comic in BuildCatalog())
            {
                var result = new
                {
                    Image = CreateImageFromAssets("captain_amazing_zoom_250x250.jpg"),
                    Title = comic.Name,
                    Subtitle = "Issue #" + comic.Issue,
                    Description = "The Captain versus " + comic.MainVillain,
                    Comic = comic,
                };
                CurrentQueryResults.Add(result);
            }
        }
    }
}
