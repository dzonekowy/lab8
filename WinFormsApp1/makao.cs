using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public partial class makao : Form
    {
        private List<string> gameDeck = new List<string>();
        private List<string> discardPile = new List<string>();
        private List<string> playerHand = new List<string>();
        private List<string> computerHand = new List<string>();

        private bool playerSaidMakao = false;
        private bool isPlayerTurn = true;
        private Random rand = new Random();

        public makao()
        {
            InitializeComponent();
            StartNewGame();
        }

        private void StartNewGame()
        {
            InitializeFullDeck();
            playerHand.Clear();
            computerHand.Clear();
            discardPile.Clear();
            isPlayerTurn = true;
            playerSaidMakao = false;

            string startingCard = DrawFromDeckLogic();
            lblTable.Text = startingCard;
            UpdateTableColor(startingCard);

            for (int i = 0; i < 5; i++)
            {
                playerHand.Add(DrawFromDeckLogic());
                computerHand.Add(DrawFromDeckLogic());
            }

            UpdateStats();
            RefreshHand();
        }

        private void UpdateStats()
        {
            lblStats.Text = $"Twoje karty: {playerHand.Count} | Karty komputera: {computerHand.Count}";
        }

        private void InitializeFullDeck()
        {
            string[] suits = { "♥", "♠", "♦", "♣" };
            string[] values = { "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            gameDeck.Clear();
            foreach (var suit in suits)
                foreach (var val in values)
                    gameDeck.Add(val + suit);
        }

        private string DrawFromDeckLogic()
        {
            if (gameDeck.Count == 0) ReshuffleDiscardPile();
            if (gameDeck.Count == 0) return "6♥";

            int index = rand.Next(gameDeck.Count);
            string card = gameDeck[index];
            gameDeck.RemoveAt(index);
            return card;
        }

        private void ReshuffleDiscardPile()
        {
            string currentOnTable = lblTable.Text;
            MessageBox.Show("🃏 Przetasowanie stosu wyrzuconych kart!", "Krupier");
            gameDeck.AddRange(discardPile);
            discardPile.Clear();
            lblTable.Text = currentOnTable;
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (!isPlayerTurn) return;

            playerHand.Add(DrawFromDeckLogic());
            playerSaidMakao = false;
            EndPlayerTurn();
        }

        private void btnMakao_Click(object sender, EventArgs e)
        {
            if (playerHand.Count <= 2)
            {
                playerSaidMakao = true;
                MessageBox.Show("Krzyknąłeś: MAKAO! Teraz wyrzuć kartę.", "Refleks");
            }
            else
            {
                MessageBox.Show("Masz za dużo kart na Makao!", "Zasady");
            }
        }

        private void PlayCard(string card)
        {
            if (!isPlayerTurn) return;

            if (CanPlay(card, lblTable.Text))
            {
                if (playerHand.Count == 2 && !playerSaidMakao)
                {
                    MessageBox.Show("ZAPOMNIAŁEŚ POWIEDZIEĆ MAKAO! Dobierasz 2 karty kary.", "Kara");
                    playerHand.Add(DrawFromDeckLogic());
                    playerHand.Add(DrawFromDeckLogic());
                    playerSaidMakao = false;
                    RefreshHand();
                    UpdateStats();
                    EndPlayerTurn();
                    return;
                }

                discardPile.Add(lblTable.Text);
                lblTable.Text = card;
                UpdateTableColor(card);
                playerHand.Remove(card);

                if (playerHand.Count == 0)
                {
                    MessageBox.Show("MAKAO I PO MAKALE! WYGRAŁEŚ! 🎉", "Zwycięstwo");
                    StartNewGame();
                    return;
                }

                EndPlayerTurn();
            }
            else
            {
                MessageBox.Show("Ta karta nie pasuje!", "Błąd");
            }
        }

        private void EndPlayerTurn()
        {
            isPlayerTurn = false;
            playerSaidMakao = false;
            UpdateStats();
            RefreshHand();
            ComputerTurn();
        }

        private async void ComputerTurn()
        {
            await Task.Delay(1500);

            string tableCard = lblTable.Text;
            string cardToPlay = computerHand.FirstOrDefault(c => CanPlay(c, tableCard));

            if (cardToPlay != null)
            {
                if (computerHand.Count == 2)
                {
                    MessageBox.Show("Komputer krzyczy: MAKAO!", "AI");
                }

                discardPile.Add(lblTable.Text);
                lblTable.Text = cardToPlay;
                UpdateTableColor(cardToPlay);
                computerHand.Remove(cardToPlay);
            }
            else
            {
                computerHand.Add(DrawFromDeckLogic());
            }

            if (computerHand.Count == 0)
            {
                MessageBox.Show("Komputer wygrał! Spróbuj ponownie.", "Porażka");
                StartNewGame();
                return;
            }

            isPlayerTurn = true;
            UpdateStats();
            RefreshHand();
        }

        private bool CanPlay(string card, string table)
        {
            string cV = card.Substring(0, card.Length - 1);
            string tV = table.Substring(0, table.Length - 1);
            return cV == tV || card.Last() == table.Last();
        }

        private void RefreshHand()
        {
            flowHand.Controls.Clear();
            flowHand.Enabled = isPlayerTurn;
            foreach (string card in playerHand)
            {
                Button cardBtn = new Button { Text = card, Size = new Size(75, 110), BackColor = Color.White, Font = new Font("Arial", 10, FontStyle.Bold), FlatStyle = FlatStyle.Flat };
                if (card.Contains("♥") || card.Contains("♦")) cardBtn.ForeColor = Color.Red;
                cardBtn.Click += (s, e) => PlayCard(card);
                flowHand.Controls.Add(cardBtn);
            }
        }

        private void UpdateTableColor(string card)
        {
            lblTable.ForeColor = (card.Contains("♥") || card.Contains("♦")) ? Color.Red : Color.Black;
        }
    }
}