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

        public Card Peek(int cardNumber)
        {
            return cards[cardNumber];
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

        /// <summary>
        /// it deals a card off the top of the deck
        /// </summary>
        /// <returns><see cref="Card"/></returns>
        public Card Deal()
        {
            return Deal(0);
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

        /// <summary>
        /// searches through the entire deck for cards with a certain value
        /// </summary>
        /// <param name="value"><see cref="Values">value</see></param>
        /// <returns></returns>
        public bool ContainsValue(Values value)
        {
            foreach (Card card in cards)
                if (card.Value == value)
                    return true;
            return false;
        }

        /// <summary>
        /// removes a book of cards from the deck
        /// </summary>
        /// <param name="value"><see cref="Values">value</see></param>
        /// <returns><see cref="Deck">book of cards</see></returns>
        public Deck PullOutValues(Values value)
        {
            Deck deckToReturn = new Deck(new Card[] { });
            for (int i = Count - 1; i >= 0; i--)
                if (cards[i].Value == value)
                    deckToReturn.AddCard(Deal(i));
            return deckToReturn;
        }

        /// <summary>
        /// checks if deck has a book of a certain value
        /// </summary>
        /// <param name="value"><see cref="Values"/></param>
        /// <returns></returns>
        public bool HasBook(Values value)
        {
            int numberOfCards = 0;
            foreach (Card card in cards)
                if (card.Value == value)
                    numberOfCards++;
            if (numberOfCards == 4)
                return true;
            return false;
        }

        /// <summary>
        /// this method shuffles the cards by rearranging them in a random order
        /// </summary>
        public void Shuffle()
        {
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

        public void SortByValue()
        {
            cards.Sort(new CardComparer_byValue());
        }
    }
}
