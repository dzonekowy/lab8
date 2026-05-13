using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Threading;
using System.ComponentModel;

namespace WinFormsApp1
{
    public partial class Monopoly : Form
    {
        int monopolyMoney = 1000;//ile pieniedzy na start
        List<Label> boardLabels;
        List<Label> positionLabels;
        MonoGame monogame;
        int tura = 0;
        int diceRoll;
        int bankmoney = 0;
        int iloscGraczy = 2;
        int liczbabankrutow = 0;
        bool koniecgry = false;
        int x = 0;

        class MonoPlayer
        {
            public int monoMoney { get; set; }
            public string monoName { get; set; }
            public int monoPosition { get; set; }
            public List<string> monoProperties { get; set; }
            public string monotypgracza { get; set; }//prehistoria zostalo po botach
            public int skipTura { get; set; }
            public bool Bankrut { get; set; }
            public int iloscbezpiecznychsskipow { get; set; }

            public MonoPlayer(int initialMoney)
            {
                monoMoney = initialMoney;
                monoPosition = 0;
                monoProperties = new List<string>();
                skipTura = 0;
                Bankrut = false;
                iloscbezpiecznychsskipow = 0;
            }
        }

        class MonoPole
        {
            public string monopoleName { get; set; }
            public int monopolePrice { get; set; }
            public string monopoleOwner { get; set; }
            public string monopoletype { get; set; }
            public int monoposition { get; set; }

            public MonoPole(string name, int price, string typ, int position)
            {
                monopoleName = name;
                monopolePrice = price;
                monopoleOwner = "None";
                monopoletype = typ;
                monoposition = position;
            }
        }

        class MonoGame
        {
            public List<MonoPlayer> players { get; set; }
            public List<MonoPole> poles { get; set; }

            public MonoGame()
            {
                players = new List<MonoPlayer>();
                poles = new List<MonoPole>();
            }
        }

        public Monopoly()
        {
            InitializeComponent();
            monokostkabutton.Visible = false;
            monokupuje.Visible = false;
            monoanuluj.Visible = false;
        }

        private void buttonStart_Click(object sender, EventArgs e)//ustawienie ile graczy i rozpoczecie gry
        {
            iloscGraczy = (int)numGracze.Value;
            numGracze.Visible = false;
            buttonStart.Visible = false;
            label59.Visible = false;
            monocosiestalolabel.Visible = true;
            monozwyciezcatext.Visible = true;
            monozapiszbutton.Visible = true;
        }

        void Startgry()//stworzenie graczy, pol, poczotek gry
        {

            monocosiestalolabel.Visible = true;
            monogame.poles = new List<MonoPole>
            {
                new MonoPole("START", 0, "start", 0), //mozna zmieniac nazwy pol na inne nazwa to pierwsze
                new MonoPole("LENIUCHOWO", 200, "nieruchomosc", 1),
                new MonoPole("SZANSA", 0, "SZANSA", 2),
                new MonoPole("LECH", 250, "nieruchomosc", 3),
                new MonoPole("PODATEK", 10, "PODATEK", 4),
                new MonoPole("PERON1", 0, "PERON", 5),
                new MonoPole("KOMORNIKI", 250, "nieruchomosc", 6),
                new MonoPole("SZANSA", 0, "SZANSA", 7),
                new MonoPole("SZKOLA", 250, "nieruchomosc", 8),
                new MonoPole("HARIBO", 250, "nieruchomosc", 9),
                new MonoPole("WIEZIENIE", 0, "WIEZIENIE", 10),
                new MonoPole("PIES", 320, "nieruchomosc", 11),
                new MonoPole("ELEKTRYKA", 1000, "nieruchomosc", 12),
                new MonoPole("CHOMIK", 350, "nieruchomosc", 13),
                new MonoPole("GRZYBOWO", 350, "nieruchomosc", 14),
                new MonoPole("PERON2", 0, "PERON", 15),
                new MonoPole("FORTNITE", 400, "nieruchomosc", 16),
                new MonoPole("SZANSA", 0, "SZANSA", 17),
                new MonoPole("BAR", 400, "nieruchomosc", 18),
                new MonoPole("LOL", 400, "nieruchomosc", 19),
                new MonoPole("BANK", 0, "BANK", 20),
                new MonoPole("POZNAN", 420, "nieruchomosc", 21),
                new MonoPole("SZANSA", 0, "SZANSA", 22),
                new MonoPole("KON", 450, "nieruchomosc", 23),
                new MonoPole("MORDA", 450, "nieruchomosc", 24),
                new MonoPole("PERON3", 0, "PERON", 25),
                new MonoPole("POLSKA", 500, "nieruchomosc", 26),
                new MonoPole("LEWY", 500, "nieruchomosc", 27),
                new MonoPole("KRAN", 1000, "nieruchomosc", 28),
                new MonoPole("KOT", 520, "nieruchomosc", 29),
                new MonoPole("POLICJA", 0, "POLICJA", 30),
                new MonoPole("HARRY", 550, "nieruchomosc", 31),
                new MonoPole("RUDY", 550, "nieruchomosc", 32),
                new MonoPole("SZANSA", 0, "SZANSA", 33),
                new MonoPole("rzulw", 600, "nieruchomosc", 34),
                new MonoPole("PERON4", 0, "PERON", 35),
                new MonoPole("SZANSA", 0, "SZANSA", 36),
                new MonoPole("SIGMA", 650, "nieruchomosc", 37),
                new MonoPole("PODATEK", 20, "PODATEK", 38),
                new MonoPole("67", 670, "nieruchomosc", 39)
            };

            InitializeBoardLabels();
            UpdateBoardLabels(); //mozna zmieniac nazwy pol na inne
            InitializePositionLabels();
            aktualizacjapozycji();

            monokupuje.Visible = false;
            monoanuluj.Visible = false;
            monokostkabutton.Enabled = true;
            monokostkabutton.Visible = true;
            label60.Text = "Tura: " + monogame.players[0].monoName;
        }

        int kostka()//losulosulosu
        {
            Random rand = new Random();
            int x = rand.Next(1, 6);
            if (x == 6) { x += rand.Next(1, 7); }
            monokostkabutton.Text = "losulosulosu " + x;
            return diceRoll = x;
        }

        private void monokostkabutton_Click(object sender, EventArgs e)//rozpoczecie tury, kostka i bunus za start
        {
            if (koniecgry == true) { return; }
            monocosiestalolabel.Text = " ";
            kostka();
            monokostkabutton.Enabled = false;
            monokostkabutton.Visible = false;
            MonoPlayer currentPlayer = monogame.players[tura];
            int oldpos = currentPlayer.monoPosition;
            currentPlayer.monoPosition = (currentPlayer.monoPosition + diceRoll) % monogame.poles.Count;
            if (oldpos > currentPlayer.monoPosition)
            {
                currentPlayer.monoMoney += 200;
                monocosiestalolabel.Text = "Przeszedles przez START! Otrzymales 200 czegos!";
            }

            WejsciePole(currentPlayer);
        }

        void WejsciePole(MonoPlayer currentPlayer)//wejscia na rozne pola
        {
            MonoPole currentPole = monogame.poles[currentPlayer.monoPosition];

            if (currentPole.monopoletype == "nieruchomosc" &&
                currentPole.monopoleOwner == "None" &&
                currentPlayer.monoMoney >= currentPole.monopolePrice)
            {
                monocosiestalolabel.Text = "Czy chcesz kupic " + currentPole.monopoleName + " za " + currentPole.monopolePrice + "?";
                monokupuje.Visible = true;
                monoanuluj.Visible = true;
                aktualizacjapozycji();
                return;
            }
            else if (currentPole.monopoletype == "nieruchomosc" &&
                     currentPole.monopoleOwner != "None" &&
                     currentPole.monopoleOwner != currentPlayer.monoName)
            {
                // bulisz wlascicielowi
                MonoPlayer owner = null;
                foreach (var p in monogame.players)
                {
                    if (p.monoName == currentPole.monopoleOwner)
                    {
                        owner = p;
                    }
                }
                int rent = currentPole.monopolePrice / 10;
                currentPlayer.monoMoney -= rent;
                owner.monoMoney += rent;
                monocosiestalolabel.Text = "bulisz " + rent + " " + owner.monoName + "!";
            }
            else if (currentPole.monopoletype == "PODATEK")
            {
                monocosiestalolabel.Text = "Zapłaciłeś podatek w wysokości " + currentPole.monopolePrice + "%" + " Pieniądze trafily do BANKU, nastepna osoba ktora wejdzie na pole bank otrzyma pieniadze";
                bankmoney += currentPlayer.monoMoney * currentPole.monopolePrice / 100;
                currentPlayer.monoMoney = currentPlayer.monoMoney - (currentPlayer.monoMoney * currentPole.monopolePrice / 100);
            }
            else if (currentPole.monopoletype == "SZANSA")//narazie nudne
            {
                Random rand = new Random();
                int eventType = rand.Next(1, 7);//do zmiany
                switch (eventType)
                {
                    case 1:
                        Random losu1 = new Random();
                        int gain = losu1.Next(50, 150);
                        currentPlayer.monoMoney += gain;
                        monocosiestalolabel.Text = "Dostales +" + gain + " monet";
                        break;
                    case 2:
                        Random losu2 = new Random();
                        int loss = losu2.Next(50, 150);
                        monocosiestalolabel.Text = "Straciles -" + loss + " monet";
                        currentPlayer.monoMoney -= loss;
                        break;
                    case 3:
                        monocosiestalolabel.Text = "Wrociles na START";
                        currentPlayer.monoPosition = 0;
                        break;
                    case 4:
                        Random losu4 = new Random();
                        int move = losu4.Next(-3, 3);
                        monocosiestalolabel.Text = "Przesunąles sie o " + move + "pola";
                        currentPlayer.monoPosition =
                            (currentPlayer.monoPosition + move) % monogame.poles.Count;
                        break;
                    case 5:
                        monocosiestalolabel.Text = "otzymales ratunek z wiezienia#JP";
                        currentPlayer.iloscbezpiecznychsskipow++;
                        break;
                    case 6:
                        monocosiestalolabel.Text = "jeszcze jedna runda rzuc koscia";
                        tura--;
                        break;
                }
            }
            else if (currentPole.monopoletype == "WIEZIENIE")
            {
                monocosiestalolabel.Text = "jestes w odwiedziny w wiezieniu nic sie nie dzieje";
            }
            else if (currentPole.monopoletype == "BANK")
            {
                monocosiestalolabel.Text = "Otrzymales pieniadze z banku: " + bankmoney + " monet!";
                currentPlayer.monoMoney += bankmoney;
                bankmoney = 0;
            }
            else if (currentPole.monopoletype == "POLICJA")//JP
            {
                if (currentPlayer.iloscbezpiecznychsskipow > 0)
                {
                    monocosiestalolabel.Text = "Uzyles ratunek z wiezienia, nie trafiles do wiezienia!";
                    currentPlayer.iloscbezpiecznychsskipow--;
                    return;
                }
                monocosiestalolabel.Text = "Zostales zlapany przez policję! Idziesz do więzienia i skipujesz ture";
                currentPlayer.monoPosition = 10;
                currentPlayer.skipTura++;
            }
            else if ((currentPole.monopoletype == "PERON"))
            {
                Random rand = new Random();
                int peronMove = rand.Next(1, 4);
                switch (peronMove)//tepa na losowy peron
                {
                    case 1: currentPlayer.monoPosition = 5; break;
                    case 2: currentPlayer.monoPosition = 15; break;
                    case 3: currentPlayer.monoPosition = 25; break;
                    case 4: currentPlayer.monoPosition = 35; break;
                }
                monocosiestalolabel.Text = "Zasnołeś w trakcie transportu obudziles sie w " + monogame.poles[currentPlayer.monoPosition].monopoleName + "!";
            }

            KoniecTury();
        }

        void KoniecTury()//aktualizacja pozycji, pieniedzy, sprawdzenie czy nastepny skipuje ture, sprawdzenie czy koniec gry
        {
            aktualizacjapozycji();
            tura = (tura + 1) % monogame.players.Count;
            MonoPlayer currentPlayer = monogame.players[tura];
            if (currentPlayer.skipTura > 0)
            {
                currentPlayer.skipTura--;
                monocosiestalolabel.Text = currentPlayer.monoName + " pomija turę!";
                aktualizacjapozycji();
            }
            if (currentPlayer.Bankrut == true)
            { KoniecTury(); }
            if (iloscGraczy - liczbabankrutow == 1)
            {
                monokoniecgry();
            }
            monokostkabutton.Enabled = true;
            monokostkabutton.Visible = true;
            label60.Text = "Tura: " + monogame.players[tura].monoName;
            monokostkabutton.Text = "KOSTKA";
        }

        private void monokupuje_Click(object sender, EventArgs e)//wybor kupowanie
        {
            MonoPlayer currentPlayer = monogame.players[tura];
            MonoPole currentPole = monogame.poles[currentPlayer.monoPosition];

            currentPlayer.monoMoney -= currentPole.monopolePrice;
            currentPole.monopoleOwner = currentPlayer.monoName;
            currentPlayer.monoProperties.Add(currentPole.monopoleName);
            monocosiestalolabel.Text = "Kupiłes " + currentPole.monopoleName + "!";
            monokupuje.Visible = false;
            monoanuluj.Visible = false;

            KoniecTury();
        }

        private void monoanuluj_Click(object sender, EventArgs e)//wybor nie kupowanie
        {
            monokupuje.Visible = false;
            monoanuluj.Visible = false;
            monocosiestalolabel.Text = "Nie kupiles " + monogame.poles[monogame.players[tura].monoPosition].monopoleName + "!";
            KoniecTury();
        }

        void InitializeBoardLabels()//ustawia nazwy pol pozniej moze zrobie ceny
        {
            boardLabels = new List<Label>
            {
                label16, label5,  label70, label7,  label18,
                label9,  label8,  label75, label15, label14,
                label67, label11, label74, label10, label21,
                label20, label19, label72, label32, label17,
                label4,  label27, label71, label26, label25,
                label23, label24, label53, label73, label12,
                label66, label35, label30, label69, label28,
                label29, label68, label31, label49, label33
            };
        }

        void UpdateBoardLabels()//wsumie tutaj ustawia
        {
            for (int i = 0; i < monogame.poles.Count && i < boardLabels.Count; i++)
            {
                boardLabels[i].Text = monogame.poles[i].monopoleName;
            }
        }

        void InitializePositionLabels()
        {
            positionLabels = new List<Label>
            {
                label76,  label77,  label78,  label79,  label80,
                label81,  label82,  label83,  label84,  label85,
                label86,  label87,  label88,  label89,  label90,
                label91,  label92,  label93,  label94,  label95,
                label96,  label97,  label98,  label99,  label100,
                label101, label102, label103, label104, label105,
                label106, label107, label108, label109, label110,
                label111, label112, label113, label114, label115
            };
        }

        void aktualizacjapozycji()//pozycja+pieniadze
        {
            foreach (var label in positionLabels)
            {
                label.Text = "";
            }

            foreach (MonoPlayer player in monogame.players)
            {
                positionLabels[player.monoPosition].Text += " " + player.monoName;
            }

            aktualizacjapieniedzy();
        }

        void aktualizacjapieniedzy()//pieniadze
        {
            for (int i = 0; i < monogame.players.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        monopolygraczpieniodzelabel.Text = monogame.players[0].monoMoney.ToString();
                        if (monogame.players[0].Bankrut == true) { break; }
                        if (monogame.players[0].monoMoney < 0)
                        {
                            monogame.players[0].Bankrut = true;
                            liczbabankrutow++;
                        }
                        break;
                    case 1:
                        monopolybotpieniodzelabel.Text = monogame.players[1].monoMoney.ToString();
                        if (monogame.players[1].Bankrut == true) { break; }
                        if (monogame.players[1].monoMoney < 0)
                        {
                            monogame.players[1].Bankrut = true;
                            liczbabankrutow++;
                        }
                        break;
                    case 2:
                        monopolybotpieniodzelabel2.Text = monogame.players[2].monoMoney.ToString();
                        if (monogame.players[2].Bankrut == true) { break; }
                        if (monogame.players[2].monoMoney < 0)
                        {
                            monogame.players[2].Bankrut = true;
                            liczbabankrutow++;
                        }
                        break;
                    case 3:
                        monopolybotpieniodzelabel3.Text = monogame.players[3].monoMoney.ToString();
                        if (monogame.players[3].Bankrut == true) { break; }
                        if (monogame.players[3].monoMoney < 0)
                        {
                            monogame.players[3].Bankrut = true;
                            liczbabankrutow++;
                        }
                        break;
                }
            }
        }

        private void Monopoly_Load(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label33_Click(object sender, EventArgs e) { }

        private void GRACZ3MONEYCHANGED(object sender, EventArgs e)
        {
        }
        private void monokoniecgry()//wlaczenie przyciskow do zapisu i wylaczenie kostki
        {
            koniecgry = true;
            monocosiestalolabel.Text = "Koniec gry!" + monogame.players[1].monoName + "Zbankrutował";
            string monowynik = "";

            foreach (MonoPlayer player in monogame.players)
            {
                if (player.Bankrut == false)
                {
                    monowynik += player.monoName + "," + "Monopoly," + "Wygrana," + player.monoMoney + DateTime.Now.ToString("dd.MM.yyy") + "," + DateTime.Now.ToString("H:mm") + "\n";

                    break;
                }
                else continue;
            }
            File.AppendAllText("wynik.txt", monowynik);
            this.Close();
        }

        private void monozapiszbutton_Click(object sender, EventArgs e)//zapis 
        {
            if (x == 0) { monogame = new MonoGame(); }
            if (monozwyciezcatext.Text == "")
            {
                return;
            }
            MonoPlayer gracz = new MonoPlayer(monopolyMoney);
            gracz.monoName = monozwyciezcatext.Text;
            gracz.monotypgracza = "Czlowiek";
            monogame.players.Add(gracz);
            if (x == 0) { monopolylabel1.Text = gracz.monoName; }
            if(x == 1) { label3.Text = gracz.monoName; }
            if(x == 2) { label64.Text = gracz.monoName; }
            if(x == 3) { label62.Text = gracz.monoName; }
            x++;
            if (x == iloscGraczy)
            {
                monozapiszbutton.Visible = false;
                monozwyciezcatext.Visible = false;
                Startgry();
            }
        }
    }
}