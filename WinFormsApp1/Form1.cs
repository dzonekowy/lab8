namespace WinFormsApp1
{

    public partial class Form1 : Form
    {




        public Blackjack blackjack;
        public Form2 wyniki;
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FNAPP fnaf = new FNAPP();
            fnaf.Closed += (s, args) => this.Close();
            fnaf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nazwa = textbox_nazwa_gracza.Text;
            makao oknoGry = new makao(nazwa);
            this.Hide();
            oknoGry.ShowDialog();
            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void blackjack_button_Click(object sender, EventArgs e)
        {
            string nazwa = textbox_nazwa_gracza.Text;
            blackjack = new Blackjack(this, nazwa);
            blackjack.Show();
        }

        private void button_tablica_Click(object sender, EventArgs e)
        {
            wyniki = new Form2();
            wyniki.Show();
        }
    }
}
