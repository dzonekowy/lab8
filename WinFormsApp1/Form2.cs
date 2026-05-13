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




    public partial class Form2 : Form
    {
        public class WynikGry
        {
            public string Nazwa { get; set; }
            public string Gra { get; set; }
            public string Status { get; set; }    // wygrana,przegerana,remis
            public int Wynik { get; set; }
            public string Data { get; set; }
            public string Godzina { get; set; }
        }
        private void WczytajHistorie()
        {
            List<WynikGry> historia = new List<WynikGry>();
            string sciezka = "wynik.txt";

            if (!File.Exists(sciezka)) return;

            string[] linie = File.ReadAllLines(sciezka);

            foreach (string linia in linie)
            {
                string[] kolumny = linia.Split(',');
                if (kolumny.Length == 6)
                {
                    historia.Add(new WynikGry
                    {
                        Nazwa = kolumny[0],
                        Gra = kolumny[1],
                        Status = kolumny[2],
                        Wynik = int.Parse(kolumny[3]),
                        Data = kolumny[4],
                        Godzina = kolumny[5]
                    });
                }
            }

            // Przypisanie do GridView
            gridview_wyniki.DataSource = historia;
        }
        public Form2()
        {
            InitializeComponent();
            WczytajHistorie();
        }

        private void gridview_wyniki_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}