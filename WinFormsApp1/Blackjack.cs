using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Threading;

namespace WinFormsApp1
{
    public partial class Blackjack : Form
    {

        public enum Suit { hearts, diamonds, clubs, spades }
        public enum Rank
        {
            Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
            Jack, Queen, King, Ace
        }

        public class Card
        {
            public Suit Suit;
            public Rank Rank;

            public Card(Suit suit, Rank rank)
            {
                Suit = suit;
                Rank = rank;
            }

            public override string ToString() => $"{Rank} of {Suit}";
        }

        public class Deck
        {
            private List<Card> _cards = new List<Card>();
            private Random _rng = new Random();

            public Deck()
            {
                Reset();
            }

            public void Reset()
            {
                _cards.Clear();
                //Automatyczne generowanie 52 kart przy użyciu pętli po enumach
                foreach (Suit s in Enum.GetValues(typeof(Suit)))
                {
                    foreach (Rank r in Enum.GetValues(typeof(Rank)))
                    {
                        _cards.Add(new Card(s, r));
                    }
                }
            }

            public void Shuffle()
            {
                //Algorytm Fisher-Yates
                int n = _cards.Count;
                while (n > 1)
                {
                    n--;
                    int k = _rng.Next(n + 1);
                    Card value = _cards[k];
                    _cards[k] = _cards[n];
                    _cards[n] = value;
                }
            }

            public Card Draw()
            {
                if (_cards.Count == 0) throw new InvalidOperationException("Talia jest pusta!");

                Card card = _cards[0];
                _cards.RemoveAt(0);
                return card;
            }

            public int cardscount()
            {
                int c = _cards.Count;
                return c;
            }
        }

        public int handsum(List<Card> hand)
        {
            int total = 0;
            int aces = 0;
            int idx = 0;
            foreach (Card card in hand)
            {
                //poniewaz pierwsza karta dealera jest zakryta, musimy zastosować wyjątek
                if (idx == 0 && hand == dealerhand && hand.Count == 2 && AlwaysShowFlag == false)
                {
                    idx++;
                    continue;
                }
                if (card.Rank == Rank.Ace)
                {
                    aces++;
                    total += 11;
                }
                else if (card.Rank >= Rank.Jack)
                {
                    total += 10;
                }
                else
                {
                    total += (int)card.Rank;
                }
                idx++;
            }

            //zmienność asa (11 lub 1)
            if (hand == playerhand)
            {
                while (total > 21 && aces > 0)
                {
                    total = total - 10;
                    aces--;
                }
                return total;
            }
            else
            //soft 17 dla dealera
            {
                while ((total > 21 || total == 17) && aces > 0)
                {
                    total = total - 10;
                    aces--;
                }
                return total;
            }

        }


        public void UpdateHand(List<Card> hand, FlowLayoutPanel panel)
        {
            panel.Controls.Clear();
            string fileName;
            string filePath;
            int idx = 0;
            foreach (Card card in hand)
            {
                PictureBox pb = new PictureBox();
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Width = 100;
                pb.Height = 145;
                //poniewaz pierwsza karta dealera jest zakryta, musimy zastosować wyjątek
                if (hand == dealerhand && hand.Count <= 2 && idx == 0 && AlwaysShowFlag == false)
                {
                    fileName = "back.png";
                    filePath = Path.Combine(Application.StartupPath, "Karty", fileName);
                }
                else
                {
                    fileName = $"{card.Suit}_{(int)card.Rank}.png";
                    filePath = Path.Combine(Application.StartupPath, "Karty", fileName);
                }

                if (File.Exists(filePath))
                {
                    pb.Image = Image.FromFile(filePath);
                }
                else
                {
                    //czerwony kolor = błąd wczytywania obrazka.
                    pb.BackColor = Color.Red;
                }

                panel.Controls.Add(pb);
                idx++;
            }
        }


        public void UpdateSum(List<Card> hand, TextBox textbox)
        {
            textbox.Clear();
            int suma = 0;
            //poniewaz pierwsza karta dealera jest zakryta, musimy zastosować wyjątek
            if (hand == dealerhand && hand.Count == 2 && AlwaysShowFlag == false)
            {
                suma = handsum(hand);
                textbox.Text = $">{suma.ToString()}";
                return;
            }

            suma = handsum(hand);
            textbox.Text = suma.ToString();
            return;
        }







        Deck deck = new Deck();
        public List<Card> dealerhand = new List<Card>();
        public List<Card> playerhand = new List<Card>();
        public bool AlwaysShowFlag = false;

        private Form1 okno1;
        public Blackjack(Form1 form1, string nazwa)
        {

            InitializeComponent();
            zaklad_numeric.Maximum = decimal.MaxValue;
            this.okno1 = form1;
            deck.Reset();
            deck.Shuffle();
            Log("Witaj! Postaw zakład aby rozpocząć grę.", Color.Black);
            gracz_label.Text = nazwa;
        }

        public double zaklad = 0;
        public double saldo = 50;
        private void Log(string message, Color color)
        {
            log_box.SelectionStart = log_box.TextLength;
            log_box.SelectionLength = 0;

            log_box.SelectionColor = color;
            log_box.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");

            // Automatyczne przewinięcie na dół
            log_box.ScrollToCaret();
        }

        public async Task KoniecGry(int outcome)
        {
            double wygrana = 0;
            Log("Koniec Gry!", Color.Blue);
            start_button.Enabled = true;
            zaklad_numeric.Enabled = true;
            button_hit.Enabled = false;
            button_hold.Enabled = false;
            double_down_button.Enabled = false;
            await Task.Delay(1000);
            switch (outcome)
            {
                //przegrana (x0)
                case 0:
                    wygrana = zaklad * 0;
                    Log($"Twoja wygrana (x0) = {wygrana}", Color.Red);
                    break;

                //remis (x1)
                case 1:
                    wygrana = zaklad * 1;
                    Log($"Twoja wygrana (x1) = {wygrana}", Color.DarkOrange);
                    break;

                //BLACKJACK wygrana (x3)
                case 2:
                    wygrana = zaklad * 3;
                    Log($"Twoja wygrana (x3) = {wygrana}", Color.Green);
                    break;

                //wygrana (x2)
                case 3:
                    wygrana = zaklad * 2;
                    Log($"Twoja wygrana (x2) = {wygrana}", Color.Green);
                    break;
            }
            saldo = saldo + wygrana;
            saldo_ilosc.Text = saldo.ToString();
            await Task.Delay(1000);
            if (saldo == 0)
            {
                Log("Brak środków w saldzie! Aby spróbować ponownie, zrestartuj aplikację.", Color.Red);
                start_button.Enabled = false;
            }
            else
            {
                Log("Postaw nowy zakład, by rozpocząc kolejną grę.", Color.Black);
                
            }
            ZapiszWynik(wygrana);

        }

        public void ZapiszWynik(double wygrana)
        {
            string sciezka = "wynik.txt";
            string nazwagracza = gracz_label.Text;
            string winlosedraw ="";
            double roznica = wygrana - zaklad;
            switch (roznica)
            {
                case > 0:
                    winlosedraw = "Wygrana";
                    break;
                case < 0:
                    winlosedraw = "Przegrana";
                    break;
                case 0:
                    winlosedraw = "Remis";
                    break;
            }
            //wynik jest wyświetlany jako różnica wygrana - zakład
            string tresc = $"{nazwagracza},Blackjack,{winlosedraw},{roznica},{DateTime.Now:dd.MM.yyyy},{DateTime.Now:HH:mm}\n";
            File.AppendAllText(sciezka, tresc);
        }


        public async Task NowaGra()
        {
            Log($"Rozpoczynam nową grę. Twój zakład = {zaklad}", Color.Blue);
            start_button.Enabled = false;
            zaklad_numeric.Enabled = false;
            AlwaysShowFlag = false;
            //Jeśli talia się kończy, zresetuj talię
            if (deck.cardscount() < 15)
            {
                deck.Reset();
                deck.Shuffle();
                Log("Talia się kończy, Dealer bierze nową talię i ją tasuje...", Color.Blue);

            }
            playerhand.Clear();
            dealerhand.Clear();
            suma_dealer.Clear();
            suma_gracz.Clear();
            reka_gracz.Controls.Clear();
            reka_dealer.Controls.Clear();
            await Task.Delay(1000);
            //pierwsze rozdanie
            playerhand.Add((Card)deck.Draw());
            Log("Dobierasz kartę...", Color.Black);
            UpdateHand(playerhand, reka_gracz);
            UpdateSum(playerhand, suma_gracz);
            await Task.Delay(1000);


            dealerhand.Add((Card)deck.Draw());
            Log("Dealer dobiera kartę...", Color.Black);
            UpdateHand(dealerhand, reka_dealer);
            await Task.Delay(1000);

            playerhand.Add((Card)deck.Draw());
            Log("Dobierasz kartę...", Color.Black);
            UpdateHand(playerhand, reka_gracz);
            UpdateSum(playerhand, suma_gracz);
            await Task.Delay(1000);

            dealerhand.Add((Card)deck.Draw());
            Log("Dealer dobiera kartę...", Color.Black);
            UpdateHand(dealerhand, reka_dealer);
            UpdateSum(dealerhand, suma_dealer);
            await Task.Delay(1000);

            if (handsum(playerhand) == 21)
            {
                Log("BLACKJACK! Posiadasz 21 w dwóch kartach!", Color.Green);
                await Task.Delay(1000);
                Log("Dealer sprawdza czy ma blackjacka...", Color.Black);
                await Task.Delay(1000);
                if (handsum(dealerhand) == 21)
                {
                    AlwaysShowFlag = true;
                    UpdateHand(dealerhand, reka_dealer);
                    UpdateSum(dealerhand, suma_dealer);
                    Log("Dealer również posiada BLACKJACKA, remis!", Color.DarkOrange);
                    KoniecGry(1);
                }
                else
                {
                    Log("Dealer posiada mniej niż 21, wygrana przez BLACKJACKA!", Color.Green);
                    KoniecGry(2);
                }
            }
            else
            {
                Log("Dealer sprawdza czy ma blackjacka...", Color.Black);
                await Task.Delay(1000);
                AlwaysShowFlag = true;

                if (handsum(dealerhand) == 21)
                {
                    Log("BLACKJACK! Dealer posiada 21 w dwóch kartach!", Color.Red);
                    UpdateHand(dealerhand, reka_dealer);
                    UpdateSum(dealerhand, suma_dealer);
                    await Task.Delay(1000);
                    if (handsum(playerhand) == 21)
                    {
                        Log("Również posiadasz BLACKJACKA, remis!", Color.DarkOrange);
                        KoniecGry(1);
                    }
                    else
                    {
                        Log("Posiadasz mniej niż 21, przegrana!", Color.Red);
                        KoniecGry(0);
                    }
                }
                else
                {
                    Log("Dealer nie ma blackjacka, twoja tura...", Color.Black);
                    button_hold.Enabled = true;
                    button_hit.Enabled = true;
                    if(saldo >= zaklad)
                        double_down_button.Enabled = true;
                }
            }

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void button_hold_Click(object sender, EventArgs e)
        {
            Log("Pasujesz. Tura dealera..", Color.Black);
            AlwaysShowFlag = true;
            button_hit.Enabled = false;
            button_hold.Enabled = false;
            double_down_button.Enabled = false;
            await Task.Delay(1000);
            pass();
            
        }

        private void dealer_label_Click(object sender, EventArgs e)
        {

        }

        private async void button_hit_Click(object sender, EventArgs e)
        {
            Log("Dobierasz kartę...", Color.Black);
            double_down_button.Enabled= false;
            await Task.Delay(1000);
            playerhand.Add((Card)deck.Draw());
            UpdateHand(playerhand, reka_gracz);
            UpdateSum(playerhand, suma_gracz);
            await Task.Delay(1000);
            bust();
        }


        public async void bust()
        {
            if (handsum(playerhand) > 21)
            {

                Log("Suma kart jest większa od 21!", Color.Red);
                AlwaysShowFlag = true;
                button_hit.Enabled = false;
                button_hold.Enabled = false;
                await Task.Delay(1000);
                Log("Dealer odkrywa karty...", Color.Black);
                UpdateHand(dealerhand, reka_dealer);
                UpdateSum(dealerhand, suma_dealer);
                await Task.Delay(1000);
                while (handsum(dealerhand) < 17)
                {
                    Log("Suma kart na ręce dealera jest mniejsza od 17. Dealer dobiera kartę...", Color.Black);
                    await Task.Delay(1000);
                    dealerhand.Add((Card)deck.Draw());
                    UpdateHand(dealerhand, reka_dealer);
                    UpdateSum(dealerhand, suma_dealer);

                }
                Log($"Suma kart na ręce dealera wynosi {handsum(dealerhand)}. Dealer kończy dobieranie.", Color.Black);

                if (handsum(dealerhand) > 21)
                {
                    Log("Suma kart na ręce dealera jest większa od 21, remis!", Color.DarkOrange);
                    KoniecGry(1);
                }
                else
                {
                    Log("Dealer posiada 21 lub mniej, przegrana!", Color.Red);
                    KoniecGry(0);
                }

            }
        }

        public async void pass()
        {
            Log("Dealer odkrywa karty...", Color.Black);
            UpdateHand(dealerhand, reka_dealer);
            UpdateSum(dealerhand, suma_dealer);
            await Task.Delay(1000);
            while (handsum(dealerhand) < 17)
            {
                Log("Suma kart na ręce dealera jest mniejsza od 17. Dealer dobiera kartę...", Color.Black);
                await Task.Delay(1000);
                dealerhand.Add((Card)deck.Draw());
                UpdateHand(dealerhand, reka_dealer);
                UpdateSum(dealerhand, suma_dealer);

            }
            Log($"Suma kart na ręce dealera wynosi {handsum(dealerhand)}. Dealer kończy dobieranie.", Color.Black);
            await Task.Delay(1000);

            if (handsum(dealerhand) > 21)
            {
                Log("Suma kart na ręce dealera jest większa od 21, wygrywasz!", Color.Green);
                KoniecGry(3);
            }
            else if (handsum(playerhand) > handsum(dealerhand))
            {
                Log("Posiadasz większą sumę kart od dealera, wygrywasz!", Color.Green);
                KoniecGry(3);
            }
            else if (handsum(playerhand) < handsum(dealerhand))
            {
                Log("Dealer posiada większą sumę kart od ciebie, przegrywasz!", Color.Red);
                KoniecGry(0);
            }
            else
            {
                Log("Posiadasz taką samą sumę kart co dealer, remis!", Color.DarkOrange);
                KoniecGry(1);
            }
        }







        private void saldo_label_Click(object sender, EventArgs e)
        {

        }

        private void start_button_Click(object sender, EventArgs e)
        {
            zaklad = (int)zaklad_numeric.Value;
            if (zaklad > saldo)
            {
                zaklad = saldo;
                zaklad_numeric.Value = (int)saldo;
            }
            saldo = saldo - zaklad;
            saldo_ilosc.Text = saldo.ToString();
            NowaGra();
        }

        private async void double_down_button_Click(object sender, EventArgs e)
        {
            saldo = saldo - zaklad;
            zaklad = zaklad * 2;
            saldo_ilosc.Text = saldo.ToString();
            zaklad_numeric.Value = (int)zaklad;
            Log($"Double Down! Dobierasz jedną kartę i podwajasz zakład! ({zaklad})", Color.Purple);
            await Task.Delay(1000);
            playerhand.Add((Card)deck.Draw());
            UpdateHand(playerhand, reka_gracz);
            UpdateSum(playerhand, suma_gracz);
            await Task.Delay(1000);
            if (handsum(playerhand) > 21)
               bust();
            else
               pass();

        }
    }
}
