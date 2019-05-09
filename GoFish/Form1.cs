using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GoFish
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Game game;

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please enter your name", "Can't start the game yet");
                return;
            }
            game = new Game(
                txtName.Text,
                new List<string>() { "Joe", "Bob"},
                txtProgress);
            btnStart.Enabled = false;
            txtName.Enabled = false;
            lstHand.Enabled = true;
            btnAsk.Enabled = true;
            UpdateForm();
        }

        private void UpdateForm()
        {
            lstHand.Items.Clear();
            foreach (string cardName in game.GetPlayerCardNames())
            {
                lstHand.Items.Add(cardName);
            }
            txtBooks.Text = game.DescribeBooks();
            txtProgress.Text += game.DescribePlayerHands();
            txtProgress.SelectionStart = txtProgress.Text.Length;
            txtProgress.ScrollToCaret();
        }

        private void btnAsk_Click(object sender, EventArgs e)
        {
            if (lstHand.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a card");
                return;
            }
            if (game.PlayOneRound(lstHand.SelectedIndex)) // returns a boolean if true then game ends
            {
                txtProgress.Text = "The winner is ..." + game.GetWinnerName();
                txtBooks.Text = game.DescribeBooks();
                btnAsk.Enabled = false;
                lstHand.Enabled = false;
            }
            else
            {
                UpdateForm();
            }

        }
    }
}
