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
    public partial class Blackjack : Form
    {
        private Form1 okno1;
        public Blackjack(Form1 form1)
        {
            InitializeComponent();
            this.okno1 = form1;
        }
    }
}
