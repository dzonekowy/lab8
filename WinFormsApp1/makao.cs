using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class makao : Form
    {
        private List<string> playerHand = new List<string>();
        private string[] deck = {
            "6♥", "7♥", "8♥", "9♥", "10♥", "J♥", "Q♥", "K♥", "A♥",
            "6♠", "7♠", "8♠", "9♠", "10♠", "J♠", "Q♠", "K♠", "A♠",
            "6♦", "7♦", "8♦", "9♦", "10♦", "J♦", "Q♦", "K♦", "A♦",
            "6♣", "7♣", "8♣", "9♣", "10♣", "J♣", "Q♣", "K♣", "A♣"
        };
        private Random rand = new Random();

        public makao()
        {
            InitializeComponent();
            StartNewGame();
        }

        private void StartNewGame()
        {
            lblTable.Text = deck[rand.Next(deck.Length)];
            if (lblTable.Text.Contains("♥") || lblTable.Text.Contains("♦")) lblTable.ForeColor = Color.Red;

            for (int i = 0; i < 5; i++) playerHand.Add(deck[rand.Next(deck.Length)]);
            RefreshHand();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            playerHand.Add(deck[rand.Next(deck.Length)]);
            RefreshHand();
        }

        private void RefreshHand()
        {
            flowHand.Controls.Clear();
            foreach (string card in playerHand)
            {
                Button cardBtn = new Button();
                cardBtn.Text = card;
                cardBtn.Size = new Size(75, 110);
                cardBtn.BackColor = Color.White;
                cardBtn.Font = new Font("Arial", 12, FontStyle.Bold);
                cardBtn.FlatStyle = FlatStyle.Flat;

                if (card.Contains("♥") || card.Contains("♦")) cardBtn.ForeColor = Color.Red;
                else cardBtn.ForeColor = Color.Black;

                cardBtn.Click += (s, e) => PlayCard(card);
                flowHand.Controls.Add(cardBtn);
            }
        }

        private void PlayCard(string card)
        {
            string tableCard = lblTable.Text;
            bool sameValue = card.Substring(0, card.Length - 1) == tableCard.Substring(0, tableCard.Length - 1);
            bool sameSuit = card.Last() == tableCard.Last();

            if (sameValue || sameSuit)
            {
                lblTable.Text = card;
                lblTable.ForeColor = (card.Contains("♥") || card.Contains("♦")) ? Color.Red : Color.Black;
                playerHand.Remove(card);
                RefreshHand();
                if (playerHand.Count == 0) MessageBox.Show("Wygrałeś!");
            }
        }
    }
}