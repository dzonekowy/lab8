namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
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
    }
}
