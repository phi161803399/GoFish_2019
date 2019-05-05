using System;
using System.Collections.Generic;

namespace GoFish
{
    public class Deck
    {
        private List<Card> cards;

        public int Count { get { return cards.Count; } }

        public Deck()
        {
            cards = new List<Card>();
            for (int suit = 0; suit <= 3; suit++)
                for (int value = 1; value <= 13; value++)
                    this.AddCard(new Card() { Suit = (Suits)suit, Value = (Values)value });
        }

        public Deck(IEnumerable<Card> initialCards)
        {
            cards = new List<Card>(initialCards);
        }

        public bool AddCard(Card cardToAdd)
        {
            if (cards != null)
            {
                cards.Add(cardToAdd);
                return true;
            }
            return false;
        }

        public Card Deal(int index)
        {
            Card cardToDeal = null;
            if (cards != null && index >= 0) 
            {
                cardToDeal = cards[index];
                cards.RemoveAt(index);
            };
            return cardToDeal;
        }

        public void Shuffle()
        {
            // this method shuffles the cards by rearranging them in a random order
            List<Card> shuffledCards = new List<Card>();
            Random random = new Random();
            while (Count > 0)
            {
                int randomCardNumber = random.Next(Count);
                shuffledCards.Add(cards[randomCardNumber]);
                cards.RemoveAt(randomCardNumber);
            }
            cards = shuffledCards;
        }

        public IEnumerable<string> GetCardNames()
        {
            string[] cardNames = new string[Count];
            for (int i = 0; i < Count; i++)
                if (cards != null)
                    cardNames[i] = cards[i].ToString();
            return cardNames;
        }

        public void Sort()
        {
            cards.Sort(new CardComparer_bySuit()); 
        }
    }
}
