using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoFish
{
    public class Player
    {
        private string name;
        public string Name { get { return name; } }
        private Random random;
        private Deck cards;
        private TextBox textBoxOnForm;

        public int CardCount { get { return cards.Count; } }
        public void TakeCard(Card card) { cards.AddCard(card); }
        public IEnumerable<string> GetCardNames() { return cards.GetCardNames(); }
        public Card Peek(int cardNumber) { return cards.Peek(cardNumber); }
        public void SortHand() { cards.SortByValue(); }

        public Player(string name, Random random, TextBox textBoxOnForm)
        {
            this.name = name;
            this.random = random;
            this.textBoxOnForm = textBoxOnForm;
            textBoxOnForm.Text += $"{Name} has just joined the game" + Environment.NewLine;
        }

        public IEnumerable<Values> PullOutBooks()
        {
            List<Values> books = new List<Values>();
            for (int i = 1; i <= 13; i++)
            {
                Values value = (Values)i;
                if (cards.HasBook(value))
                {
                    books.Add(value);
                    cards.PullOutValues(value);
                }
            }
            return books;
        }

        /// <summary>
        /// peek at a random card in deck and return its value
        /// </summary>
        /// <returns><see cref="Values"/></returns>
        public Values GetRandomValue()
        {
            return Peek(random.Next(CardCount)).Value;
        }

        /// <summary>
        /// an opponent asks if I have any cards of a certain value
        /// if so I return a Deck with cards of this value
        /// </summary>
        /// <param name="value"><see cref="Values"/></param>
        /// <returns><see cref="Deck"/></returns>
        public Deck DoYouHaveAny(Values value)
        {
            if (cards.ContainsValue(value))
            {
                Deck deckToReturn = cards.PullOutValues(value);
                int numberOfCards = deckToReturn.Count;
                if (numberOfCards > 1)
                    textBoxOnForm.Text += $"{Name} has {numberOfCards} {Card.Plural(value)}" + Environment.NewLine;
                else
                    textBoxOnForm.Text += $"{Name} has {numberOfCards} {value}" + Environment.NewLine;
                return deckToReturn;
            }   
            return new Deck(new Card[] { }); // deck with no cards
        }

        /// <summary>
        /// ask for a card when player is a computerplayer or when deck is empty
        /// </summary>
        /// <param name="players"></param>
        /// <param name="myIndex"></param>
        /// <param name="stock"></param>
        public void AskForACard(List<Player> players, int myIndex, Deck stock)
        {
            if (CardCount > 0)
                AskForACard(players, myIndex, stock, GetRandomValue());
            else
                takeCardFromStock(stock);
        }

        /// <summary>
        /// takes a card from stock when player has no cards to ask or when he hasn't received any cards
        /// </summary>
        /// <param name="stock"><see cref="Deck">stock</see></param>
        private void takeCardFromStock(Deck stock)
        {
            textBoxOnForm.Text += $"{Name} had to draw from the stock" + Environment.NewLine;
            TakeCard(stock.Deal());
        }

        /// <summary>
        /// ask the other players for a value
        /// if so cards are added to deck
        /// </summary>
        /// <param name="players"></param>
        /// <param name="myIndex"></param>
        /// <param name="stock"></param>
        /// <param name="value"></param>
        public void AskForACard(List<Player> players, int myIndex, Deck stock, Values value)
        {
            int cardsReceived = 0;
            textBoxOnForm.Text += $"{Name} asks if anyone has a {value}" + Environment.NewLine;
            for (int i = 0; i < players.Count; i++)
            {
                if (i == myIndex)
                    continue;
                Deck deckToAdd = players[i].DoYouHaveAny(value);
                int numberOfCardsToAdd = deckToAdd.Count;
                if (numberOfCardsToAdd > 0)
                    cardsReceived += numberOfCardsToAdd;
                    for (int j = 0; j < numberOfCardsToAdd; j++)
                        TakeCard(deckToAdd.Deal());
            }
            if (cardsReceived == 0)
                takeCardFromStock(stock);
        }
    }
}
