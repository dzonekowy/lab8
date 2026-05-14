using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Speed : Form
    {
        public Form1 menuGlowne;
        public string nazwaGracza;
        public int FinalTimeSeconds { get; private set; } = 0;
        public bool PlayerWon { get; private set; } = false;

        private const int HandSize = 5;
        private const int TotalCards = 52;
        int sek = 0;

        public enum Suit { Hearts, Diamonds, Clubs, Spades }
        public class Card
        {
            public int Value { get; set; } //2-10, 11(J), 12(Q), 13(K), 14(A)
            public Suit CardSuit { get; set; }
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
            NumOfLeftCards.Left = LeftCards.Left + (LeftCards.Width - NumOfLeftCards.Width) / 2;
            NumOfLeftCards.Top = LeftCards.Top - 25;

            NumOfEnemyCards.Text = $"Karty gracza: {enemyReserve.Count}";
            NumOfEnemyCards.Left = EnemLeftCards.Left + (EnemLeftCards.Width - NumOfEnemyCards.Width) / 2;
            NumOfEnemyCards.Top = EnemLeftCards.Top + EnemLeftCards.Height + 5;

            UpdateUI();
        }

        private void DealFirstCardsToCenter()
        {
            // Wypełniamy Stos 1 (Zapożyczamy od przeciwnika, jeśli my nie mamy)
            if (playerReserve.Count > 0)
            {
                cardOnStack1 = playerReserve.Dequeue();
                pile1.Add(cardOnStack1);
            }
            else if (enemyReserve.Count > 0)
            {
                cardOnStack1 = enemyReserve.Dequeue();
                pile1.Add(cardOnStack1);
            }

            // Wypełniamy Stos 2 (Zapożyczamy od gracza, jeśli komputer nie ma)
            if (enemyReserve.Count > 0)
            {
                cardOnStack2 = enemyReserve.Dequeue();
                pile2.Add(cardOnStack2);
            }
            else if (playerReserve.Count > 0)
            {
                cardOnStack2 = playerReserve.Dequeue();
                pile2.Add(cardOnStack2);
            }

            UpdateUI();
        }

        private void UpdateUI()
        {
            // Aktualizacja przycisków gracza 
            UpdateButtonDisplay(Card1, playerHand[0]);
            UpdateButtonDisplay(Card2, playerHand[1]);
            UpdateButtonDisplay(Card3, playerHand[2]);
            UpdateButtonDisplay(Card4, playerHand[3]);
            UpdateButtonDisplay(Card5, playerHand[4]);

            // Aktualizacja przycisków przeciwnika
            Image backImage = (Image)WinFormsApp1.Properties.Resources.ResourceManager.GetObject("back_light");
            UpdateEnemyButtonDisplay(EnemyCard1, enemyHand[0], backImage);
            UpdateEnemyButtonDisplay(EnemyCard2, enemyHand[1], backImage);
            UpdateEnemyButtonDisplay(EnemyCard3, enemyHand[2], backImage);
            UpdateEnemyButtonDisplay(EnemyCard4, enemyHand[3], backImage);
            UpdateEnemyButtonDisplay(EnemyCard5, enemyHand[4], backImage);

            // Aktualizacja stosów na środku
            UpdateButtonDisplay(Stack1, cardOnStack1);
            UpdateButtonDisplay(Stack2, cardOnStack2);

            if (playerReserve.Count > 0)
            {
                LeftCards.Visible = true;
                LeftCards.BackgroundImage = backImage;
                LeftCards.BackgroundImageLayout = ImageLayout.Zoom;
                LeftCards.Text = "";
            }
            else
            {
                LeftCards.Visible = false;
            }

            if (enemyReserve.Count > 0)
            {
                EnemLeftCards.Visible = true;
                EnemLeftCards.BackgroundImage = backImage;
                EnemLeftCards.BackgroundImageLayout = ImageLayout.Zoom;
                EnemLeftCards.Text = "";
            }
            else
            {
                EnemLeftCards.Visible = false;
            }
        }

        private void UpdateButtonDisplay(Button btn, Card card)
        {
            if (card != null)
            {
                btn.BackgroundImage = card.CardImage;
                btn.BackgroundImageLayout = ImageLayout.Zoom;
                btn.Text = "";
            }
            else
            {
                btn.BackgroundImage = null;
            }
        }

        private void UpdateEnemyButtonDisplay(Button btn, Card card, Image backImage)
        {
            if (card != null)
            {
                btn.BackgroundImage = backImage;
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

        private bool CanPlaceCard(int handValue, int stackValue)
        {
            if (Math.Abs(handValue - stackValue) == 1) return true;

            if ((handValue == 14 && stackValue == 2) || (handValue == 2 && stackValue == 14)) return true;

            return false;
        }

        private void TryPlayCard(int handIndex)
        {
            Card cardToPlay = playerHand[handIndex];
            if (cardToPlay == null) return;

            bool played = false;

            // Zmiana -> Jeśli stos jest pusty lub  karta pasuje
            if (cardOnStack1 == null || CanPlaceCard(cardToPlay.Value, cardOnStack1.Value))
            {
                cardOnStack1 = cardToPlay;
                pile1.Add(cardToPlay);
                played = true;
            }
            else if (cardOnStack2 == null || CanPlaceCard(cardToPlay.Value, cardOnStack2.Value))
            {
                cardOnStack2 = cardToPlay;
                pile2.Add(cardToPlay);
                played = true;
            }

            if (played)
            {
                playerHand[handIndex] = null;
                FillHands();
                UpdateUI();
                CheckWinCondition();
            }
            else
            {
                InfoBar.Text = "Nie możesz położyć tej karty!";
                InfoBar.Left = (this.ClientSize.Width - InfoBar.Width) / 2;
            }
        }

        private void CheckWinCondition()
        {
            if (playerReserve.Count == 0 && playerHand.All(c => c == null))
            {
                timer1.Stop();
                FinalTimeSeconds = sek;
                PlayerWon = true;
                ZapiszWynikDoHistorii();
                MessageBox.Show($"Wygrałeś! Twój czas to: {sek} sekund.", "Koniec Gry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (enemyReserve.Count == 0 && enemyHand.All(c => c == null))
            {
                timer1.Stop();
                FinalTimeSeconds = sek;
                PlayerWon = false;
                ZapiszWynikDoHistorii();
                MessageBox.Show($"Przegrałeś! Twój czas to: {sek} sekund.", "Koniec Gry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void ZapiszWynikDoHistorii()
        {
            string status = PlayerWon ? "Wygrana" : "Przegrana";
            string data = DateTime.Now.ToString("dd.MM.yyyy");
            string godzina = DateTime.Now.ToString("HH:mm");

            // Nazwa,Gra,Status,Wynik,Data,Godzina
            string liniaZzapisu = $"{nazwaGracza},Speed,{status},{FinalTimeSeconds},{data},{godzina}";
            System.IO.File.AppendAllText("wynik.txt", liniaZzapisu + Environment.NewLine);
        }

        private void RescueDeadlock()
        {
            // Zbieramy karty ze stołu do tymczasowej talii
            List<Card> tempDeck = new List<Card>();
            tempDeck.AddRange(pile1);
            tempDeck.AddRange(pile2);

            pile1.Clear();
            pile2.Clear();
            cardOnStack1 = null;
            cardOnStack2 = null;

            // Tasujemy te zebrane karty
            for (int i = tempDeck.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                var temp = tempDeck[i];
                tempDeck[i] = tempDeck[j];
                tempDeck[j] = temp;
            }

            // Rozdajemy po równo
            for (int i = 0; i < tempDeck.Count; i++)
            {
                if (i % 2 == 0) playerReserve.Enqueue(tempDeck[i]);
                else enemyReserve.Enqueue(tempDeck[i]);
            }

            // Kładziemy nowe karty na środek
            DealFirstCardsToCenter();
        }
        private void CheckIfStuck()
        {
            if (cardOnStack1 == null || cardOnStack2 == null) return;

            bool canPlayerMove = false;
            bool canEnemyMove = false;

            // Czy gracz ma jakikolwiek ruch?
            foreach (var card in playerHand)
            {
                if (card != null && (CanPlaceCard(card.Value, cardOnStack1.Value) || CanPlaceCard(card.Value, cardOnStack2.Value)))
                {
                    canPlayerMove = true;
                    break;
                }
            }

            // Czy komputer ma jakikolwiek ruch?
            foreach (var card in enemyHand)
            {
                if (card != null && (CanPlaceCard(card.Value, cardOnStack1.Value) || CanPlaceCard(card.Value, cardOnStack2.Value)))
                {
                    canEnemyMove = true;
                    break;
                }
            }

            // Jeśli OBAJ gracze utknęli (nikt nie ma ruchu)
            if (!canPlayerMove && !canEnemyMove)
            {
                InfoBar.Text = "ZABLOKOWANI! Rzucam nowe karty...";
                InfoBar.Left = (this.ClientSize.Width - InfoBar.Width) / 2;
                if (playerReserve.Count == 0 && enemyReserve.Count == 0)
                {
                    RescueDeadlock();
                }
                else
                {
                    DealFirstCardsToCenter();
                }
            }
        }

        public Speed(Form1 menu, string nazwa)
        {
            InitializeComponent();
            menuGlowne = menu;
            nazwaGracza = nazwa;

            if (string.IsNullOrWhiteSpace(nazwaGracza))
            {
                nazwaGracza = "Gość";
            }
        }

        private void Stack1_Click(object sender, EventArgs e)
        {

        }

        private void Stack2_Click(object sender, EventArgs e)
        {

        }

        private void Slap_Click(object sender, EventArgs e)
        {
            if (cardOnStack1 == null || cardOnStack2 == null)
            {
                return;
            }

            if (cardOnStack1.Value == cardOnStack2.Value)
            {
                //Przyklepanie 
                TransferTableToReserve(enemyReserve);
                InfoBar.Text = "PRZYKLEPANE! Przeciwnik bierze kary";
                InfoBar.Left = (this.ClientSize.Width - InfoBar.Width) / 2;
                StartNewRound();
            }
            else
            {
                //Przyklepanie błędne
                TransferTableToReserve(playerReserve);
                InfoBar.Text = "PUDŁO! Bierzesz karty karne";
                InfoBar.Left = (this.ClientSize.Width - InfoBar.Width) / 2;
                StartNewRound();
            }
        }
        private void Card1_Click(object sender, EventArgs e)
        {
            TryPlayCard(0);
        }

        private void Card2_Click(object sender, EventArgs e)
        {
            TryPlayCard(1);
        }

        private void Card3_Click(object sender, EventArgs e)
        {
            TryPlayCard(2);
        }

        private void Card4_Click(object sender, EventArgs e)
        {
            TryPlayCard(3);
        }
        private void Card5_Click(object sender, EventArgs e)
        {
            TryPlayCard(4);
        }

        private void NumOfLeftCards_Click(object sender, EventArgs e)
        {

        }
        int tickCounter = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sek++;
            Time.Text = $"Czas: {sek} s";
            Time.Left = (this.ClientSize.Width - Time.Width) / 2;

            bool computerPlayed = false;

            tickCounter++;

            if (tickCounter >= 2)
            {
                if (cardOnStack1 != null && cardOnStack2 != null && cardOnStack1.Value == cardOnStack2.Value)
                {
                    // Komputer zauważa równe karty. Dajemy mu 30% szans w każdej sekundzie, że przyklepie je pierwszy
                    if (rnd.Next(1, 101) <= 30)
                    {
                        TransferTableToReserve(playerReserve); // Jeśli komputer klepnie, to gracz dostaje karę
                        InfoBar.Text = "PRZECIWNIK BYŁ SZYBSZY! Bierzesz kary.";
                        InfoBar.Left = (this.ClientSize.Width - InfoBar.Width) / 2;
                        StartNewRound();
                        return;
                    }
                }

                for (int i = 0; i < HandSize; i++)
                {
                    if (enemyHand[i] != null)
                    {
                        // Czy pasuje na Stos 1?
                        if (cardOnStack1 == null || CanPlaceCard(enemyHand[i].Value, cardOnStack1.Value))
                        {
                            cardOnStack1 = enemyHand[i];
                            pile1.Add(cardOnStack1);
                            enemyHand[i] = null; // Komputer wyrzuca kartę
                            computerPlayed = true;
                            break; // Przerywamy pętlę, żeby komputer rzucił tylko 1 kartę na sekundę
                        }
                        // Jeśli nie, to czy pasuje na Stos 2?
                        else if (cardOnStack2 == null || CanPlaceCard(enemyHand[i].Value, cardOnStack2.Value))
                        {
                            cardOnStack2 = enemyHand[i];
                            pile2.Add(cardOnStack2);
                            enemyHand[i] = null;
                            computerPlayed = true;
                            break;
                        }
                    }
                }

                if (computerPlayed)
                {
                    FillHands();
                    UpdateUI();
                    CheckWinCondition();
                }

                // 3. Sprawdzanie, czy oboje graczy utknęło
                CheckIfStuck();

                tickCounter = 0;
            }



        }

        private void Time_Click(object sender, EventArgs e)
        {
            Time.Left = (this.ClientSize.Width - Time.Width) / 2;
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

        private void Speed_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LeftCards_Click(object sender, EventArgs e)
        {

        }

        private void NumOfEnemyCards_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private bool canPlaceAll = true;

        private void DropAllCards_Click(object sender, EventArgs e)
        {
            if(canPlaceAll==true)
            {
                for (int i = 0; i < HandSize; i++)
                {
                    if (playerHand[i] != null)
                    {
                        if (i%2 == 0)
                        {
                            cardOnStack1 = playerHand[i];
                            pile1.Add(playerHand[i]);
                        }
                        else
                        {
                            cardOnStack2 = playerHand[i];
                            pile2.Add(playerHand[i]);
                        }

                        playerHand[i] = null;
                    }
                }

                FillHands();

                UpdateUI();

                InfoBar.Text = "Wyrzuciłeś wszytskie karty z ręki!";
                InfoBar.Left = (this.ClientSize.Width - InfoBar.Width) / 2;

                canPlaceAll = false;

            }
            else
            {
                InfoBar.Text = "Możesz wyrzucić wszystkie karty tylko raz!";
                InfoBar.Left = (this.ClientSize.Width - InfoBar.Width) / 2;
            }
           
        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void Start_Click_1(object sender, EventArgs e)
        {
            InitializeAndDealDeck();

            FillHands();
            DealFirstCardsToCenter();

            timer1.Start();
            panel1.Visible = false;
        }
    }
}
