using System.Collections.Generic;

namespace GoFish
{
    public class Card
    {
        public Suits Suit { get; set; }
        public Values Value { get; set; }

        public string Name
        {
            get
            {
                return $"{Value.ToString()} of {Suit.ToString()}"; 
            }
        }

        public override string ToString()
        {
            return Name;
        }

        internal static string Plural(Values value)
        {
            if (value == Values.Six)
                return "Sixes";
            return value.ToString() + "s";
        }
    }

    /// <summary>
    /// first compares by suit, then by value
    /// </summary>
    public class CardComparer_bySuit : Comparer<Card>
    {
        public override int Compare(Card x, Card y)
        {
            if (x.Suit < y.Suit)
                return -1;
            else if (x.Suit > y.Suit)
                return 1;
            else
            {
                if (x.Value < y.Value)
                    return -1;
                else if (x.Value > y.Value)
                    return 1;
                else
                    return 0;
            }
        }
    }

    /// <summary>
    /// first compares by value, then by suit
    /// </summary>
    public class CardComparer_byValue : Comparer<Card>
    {
        public override int Compare(Card x, Card y)
        {
            if (x.Value < y.Value)
                return -1;
            if (x.Value > y.Value)
                return 1;
            if (x.Suit < y.Suit)
                return -1;
            if (x.Suit > y.Suit)
                return 1;
            return 0;
        }
    }
}
