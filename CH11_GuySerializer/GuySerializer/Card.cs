using System;
using System.Runtime.Serialization;

namespace GuySerializer
{
    [DataContract(Namespace = "HeadFirst_CSharp/CH11")]
    public class Card
    {
        private static Random random = new Random();

        [DataMember]
        public Suit Suit { get; set; }

        [DataMember]
        public Rank Rank { get; set; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public static Card RandomCard()
        {
            return new Card((Suit)random.Next(4), (Rank)random.Next(1, 14));
        }

        public string Name => $"{Rank.ToString()} of {Suit.ToString()}";

        public override string ToString()
        {
            return Name;
        }
    }
}
