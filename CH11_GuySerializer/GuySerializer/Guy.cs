using System.Runtime.Serialization;

namespace GuySerializer
{
    [DataContract(Namespace = "HeadFirst_CSharp/CH11")]
    public class Guy
    {
        public Guy(string name, int age, decimal cash)
        {
            Name = name;
            Age = age;
            Cash = cash;
            TrumpCard = Card.RandomCard();
        }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public int Age { get; private set; }

        [DataMember]
        public decimal Cash { get; private set; }

        [DataMember(Name = "MyCard")]
        public Card TrumpCard { get; set; }

        public override string ToString()
        {
            return $"My name is {Name}, I'm {Age}, I have {Cash} bucks, and my trump card is {TrumpCard}";
        }
    }
}