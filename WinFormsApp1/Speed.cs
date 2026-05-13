using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Speed : Form
    {
        private const int HandSize = 5;
        private const int TotalCards = 52;
        int sek = 0;
        public enum Suit { Hearts, Diamonds, Clubs, Spades }
        public class Card
        {
            public int Value { get; set; } //2-10, 11(J), 12(Q), 13(K), 14(A)
            public Suit CardSuit{ get; set; }
            public Image CardImage { get; set; }
            public override string ToString() => $"{Value} {CardSuit}";
        }

        private Queue<Card> playerReserve = new Queue<Card>();
        private Queue<Card> enemyReserve = new Queue<Card>();

        private Card[] playerHand = new Card[5];
        private Card[] enemyHand = new Card[5];

        private Card cardOnStack1;
        private Card cardOnStack2;

        private List<Card> pile1 = new List<Card>();
        private List<Card> pile2 = new List<Card>();

        private Random rnd = new Random();

        private void FillHands()
        {
            //Dobranie kart
            for (int i = 0; i < HandSize; i++)
            {
                if (playerHand[i] == null && playerReserve.Count > 0)
                {
                    playerHand[i] = playerReserve.Dequeue();
                }

                if (enemyHand[i] == null && enemyReserve.Count > 0)
                {
                    enemyHand[i] = enemyReserve.Dequeue();
                }
            }

            NumOfLeftCards.Text = $"Karty gracza: {playerReserve.Count}";
            EnemLeftCards.Text = $"Karty komputera: {enemyReserve.Count}";
            UpdateUI();
        }

        private void DealFirstCardsToCenter()
        {
            //Wyrzucamy po jednej karcie z rezerw na sam środek
            if (playerReserve.Count > 0)
            {
                cardOnStack1 = playerReserve.Dequeue();
                pile1.Add(cardOnStack1);
            }
            if (enemyReserve.Count > 0)
            {
                cardOnStack2 = enemyReserve.Dequeue();
                pile2.Add(cardOnStack2);
            }

            UpdateUI();
        }

        private void UpdateUI()
        {
            // Aktualizacja przycisków gracza (awersy)
            UpdateButtonDisplay(Card1, playerHand[0]);
            UpdateButtonDisplay(Card2, playerHand[1]);
            UpdateButtonDisplay(Card3, playerHand[2]);
            UpdateButtonDisplay(Card4, playerHand[3]);
            UpdateButtonDisplay(Card5, playerHand[4]);

            // Aktualizacja przycisków przeciwnika (na razie tylko sprawdzamy czy ma kartę i dajemy "tył")
            Image backImage = (Image)WinFormsApp1.Properties.Resources.ResourceManager.GetObject("back_dark");
            UpdateEnemyButtonDisplay(EnemyCard1, enemyHand[0], backImage);
            UpdateEnemyButtonDisplay(EnemyCard2, enemyHand[1], backImage);
            UpdateEnemyButtonDisplay(EnemyCard3, enemyHand[2], backImage);
            UpdateEnemyButtonDisplay(EnemyCard4, enemyHand[3], backImage);
            UpdateEnemyButtonDisplay(EnemyCard5, enemyHand[4], backImage);

            // Aktualizacja stosów na środku
            UpdateButtonDisplay(Stack1, cardOnStack1);
            UpdateButtonDisplay(Stack2, cardOnStack2);

        }

        private void UpdateButtonDisplay(Button btn, Card card)
        {
            if (card != null)
            {
                btn.BackgroundImage = card.CardImage;
                btn.BackgroundImageLayout = ImageLayout.Zoom;
                btn.Text = ""; // Czyścimy ewentualny tekst
            }
            else
            {
                btn.BackgroundImage = null; // Karta zniknęła
            }
        }

        private void UpdateEnemyButtonDisplay(Button btn, Card card, Image backImage)
        {
            if (card != null)
            {
                btn.BackgroundImage = backImage; // Dla przeciwnika pokazujemy tył karty
                btn.BackgroundImageLayout = ImageLayout.Zoom;
                btn.Text = "";
            }
            else
            {
                btn.BackgroundImage = null;
            }
        }

        private void StartNewRound()
        {
            // Nowa runda to po prostu wyłożenie nowych kart na środek (np. po przyklepaniu)
            DealFirstCardsToCenter();
            FillHands();

        }

        private void TransferTableToReserve(Queue<Card> targetReserve)
        {
            // Przenosimy wszystkie zebrane karty z obu stosów do rezerwy pechowca
            foreach (var c in pile1) targetReserve.Enqueue(c);
            foreach (var c in pile2) targetReserve.Enqueue(c);

            pile1.Clear();
            pile2.Clear();
            cardOnStack1 = null;
            cardOnStack2 = null;
        }

        private void InitializeAndDealDeck()
        {
            List<Card> fullDeck = new List<Card>();

            //Generowanie 52 kart
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (int val = 2; val <= 14; val++)
                {
                    //Zamiana liczb 11-14 na litery J, Q, K, A dla nazw plików
                    string valStr = val.ToString();
                    if (val == 11) valStr = "J";
                    if (val == 12) valStr = "Q";
                    if (val == 13) valStr = "K";
                    if (val == 14) valStr = "A";

                    string resourceName = $"{suit.ToString().ToLower()}_{valStr}";

                    Image img = (Image)WinFormsApp1.Properties.Resources.ResourceManager.GetObject(resourceName);
                    fullDeck.Add(new Card { Value = val, CardSuit = suit, CardImage = img });
                }
            }

            //Tasowanie talii Fisher-Yates shuffle
            for (int i = fullDeck.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                var temp = fullDeck[i];
                fullDeck[i] = fullDeck[j];
                fullDeck[j] = temp;
            }

            //Rozdanie po 26 kart 
            for (int i = 0; i < 52; i++)
            {
                if (i % 2 == 0)
                    playerReserve.Enqueue(fullDeck[i]);
                else
                    enemyReserve.Enqueue(fullDeck[i]);
            }
        }

        private bool CanPlaceCard(int handValue, int stackValue)
        {
            if (Math.Abs(handValue - stackValue) == 1) return true;

            if ((handValue == 14 && stackValue == 2) || (handValue == 2 && stackValue == 14)) return true;

            return false;
        }

        public Speed()
        {
            InitializeComponent();
        }

        private void Stack1_Click(object sender, EventArgs e)
        {

        }

        private void Stack2_Click(object sender, EventArgs e)
        {

        }

        private void Slap_Click(object sender, EventArgs e)
        {
            if (cardOnStack1.Value == cardOnStack2.Value)
            {
                //Przyklepanie 
                TransferTableToReserve(enemyReserve);
                InfoBar.Text = "PRZYKLEPANE! Przeciwnik bierze kary";
                StartNewRound();
            }
            else
            {
                //Przyklepanie błędne
                TransferTableToReserve(playerReserve);
                InfoBar.Text = "PUDŁO! Bierzesz karty karne";
            }
        }

        private void Card1_Click(object sender, EventArgs e)
        {

        }

        private void Card2_Click(object sender, EventArgs e)
        {

        }

        private void Card3_Click(object sender, EventArgs e)
        {

        }

        private void Card4_Click(object sender, EventArgs e)
        {

        }

        private void NumOfLeftCards_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Time_Click(object sender, EventArgs e)
        {

        }

        private void EnemyCard1_Click(object sender, EventArgs e)
        {

        }

        private void EnemyCard2_Click(object sender, EventArgs e)
        {

        }

        private void EnemyCard3_Click(object sender, EventArgs e)
        {

        }

        private void EnemyCard4_Click(object sender, EventArgs e)
        {

        }

        private void EnemyCard5_Click(object sender, EventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {
            InitializeAndDealDeck();

            FillHands();
            DealFirstCardsToCenter();

            timer1.Start();
            Start.Visible = false;
        }
    }
}
