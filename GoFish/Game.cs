using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GoFish
{
    internal class Game
    {
        private List<Player> players;
        private Dictionary<Values, Player> books;
        private Deck stock;
        private TextBox textBoxOnForm;

        public Game(string playerName, IEnumerable<string> opponentNames, TextBox textBoxOnForm)
        {
            Random random = new Random();
            this.textBoxOnForm = textBoxOnForm;
            players = new List<Player>();
            players.Add(new GoFish.Player(playerName, random, textBoxOnForm));
            foreach (string opponent in opponentNames)
            {
                players.Add(new GoFish.Player(opponent, random, textBoxOnForm));
            }
            books = new Dictionary<Values, Player>();
            stock = new Deck();
            Deal();
            players[0].SortHand();
        }

        /// <summary>
        /// this is where the game starts
        /// shuffle the <see cref="Deck">stock</see>
        /// deal cards to player
        /// then pulloutbooks
        /// </summary>
        private void Deal()
        {
            stock.Shuffle();
            for (int i = 0; i < 5; i++)
                foreach (Player player in players)
                    player.TakeCard(stock.Deal());
            foreach (Player player in players)
                PullOutBooks(player);
        }

        /// <summary>
        /// each player <see cref="Player.AskForACard(List{Player}, int, Deck, Values)"/>
        /// then <see cref="PullOutBooks(Player)"/>
        /// if a <see cref="Player"/> runs out of <see cref="Card"/> he draws a new hand from <see cref="Deck">stock</see>
        /// </summary>
        /// <param name="selectedPlayerCard"><see cref="Card"/> the player selected</param>
        /// <returns>true if stock is empty</returns>
        public bool PlayOneRound(int selectedPlayerCard)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (i == 0 && selectedPlayerCard >= 0)
                    players[i].AskForACard(players, i, stock, (Values)selectedPlayerCard);
                else
                    players[i].AskForACard(players, i, stock);
                if (PullOutBooks(players[i]))
                    for (int j = 0; j < 5; j++)
                        if (players[i].TakeCard(stock.Deal()) == false || stock.Count == 0) // when there's no card to deal, TakeCard() returns false => game ends
                        {
                            textBoxOnForm.Text += $"The stock is out of cards. Game over!";
                            return true;
                        }                            
            }
            players[0].SortHand();
            return false;
        }

        /// <summary>
        /// Pull out a player's books
        /// </summary>
        /// <param name="player"></param>
        /// <returns>true if a player ran out of cards</returns>
        public bool PullOutBooks(Player player)
        {
            foreach (Values value in player.PullOutBooks())
                books.Add(value, player);
            if (player.CardCount == 0)
                return true;
            return false; 
        }

        /// <summary>
        /// describes everyone's books
        /// </summary>
        /// <returns>a long string</returns>{
        public string DescribeBooks()
        {
            string descriptionOfBooks = string.Empty;
            foreach (Values book in books.Keys)
                descriptionOfBooks += $"{books[book].Name} has a book of {Card.Plural(book)}" + Environment.NewLine;
            return descriptionOfBooks; 
        }

        /// <summary>
        /// keeps track of how many books each <see cref="Player"/> ended up with
        /// finds the largest number of books any winner has
        /// </summary>
        /// <returns>list of <see cref="Player">winners</see> in a string</returns>
        public string GetWinnerName()
        {
            Dictionary<string, int> scoresPerPlayer = new Dictionary<string, int>();
            List<string> winners = new List<string>();
            foreach (Player player in players)
            {
                int numberOfBooks = 0;
                foreach (Values book in books.Keys)
                    if (player.Name == books[book].Name)
                        numberOfBooks++;
                scoresPerPlayer.Add(player.Name, numberOfBooks);
            }
            int largestNumberOfBooks = 0;
            foreach (string winner in scoresPerPlayer.Keys)
                if (scoresPerPlayer[winner] > largestNumberOfBooks)
                    largestNumberOfBooks = scoresPerPlayer[winner];
            foreach (string winner in scoresPerPlayer.Keys)
                if (scoresPerPlayer[winner] == largestNumberOfBooks)
                    winners.Add(winner);
            if (winners.Count == 1)
                return $"{winners} ";
        }
    }
}