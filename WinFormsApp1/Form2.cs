using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace WinFormsApp1
{
    public partial class FNAPP : Form
    {
        public FNAPP()
        {
            InitializeComponent();


            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
            button1.Top = (this.ClientSize.Height - button1.Height) / 2;

            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            label2.Left = (this.ClientSize.Width - label2.Width) / 2;
            label3.Left = (this.ClientSize.Width - label3.Width) / 2;

        }

        private void FNAPP_Load(object sender, EventArgs e)
        {

        }

        private void FNAPP_Start(object sender, EventArgs e)
        {
            button1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;

            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;

            var dir = Directory.GetCurrentDirectory();
            dir = dir.Replace("bin\\Debug\\net8.0-windows", "assets");

            button2.Image = Image.FromFile(dir + "\\cam3.png");
            button3.Image = Image.FromFile(dir + "\\cam-main.png");
            button4.Image = Image.FromFile(dir + "\\cam1.png");
            button5.Image = Image.FromFile(dir + "\\cam2.png");
            button6.Image = Image.FromFile(dir + "\\cam4.png");
            button7.Image = Image.FromFile(dir + "\\cam5.png");
            button8.Image = Image.FromFile(dir + "\\button.png");
            button9.Image = Image.FromFile(dir + "\\button.png");
            button10.Image = Image.FromFile(dir + "\\button.png");

            print();
        }

        public bool isImage1Visible = true;
        public bool isImage2Visible = true;
        public bool isImage3Visible = true;

        private void print()
        {
            var dir = Directory.GetCurrentDirectory();
            dir = dir.Replace("bin\\Debug\\net8.0-windows", "assets");

            Image image1 = Image.FromFile(dir + "\\main1.png");
            Image image2 = Image.FromFile(dir + "\\main2-dark.png");
            Image image3 = Image.FromFile(dir + "\\main3.png");

            Graphics g = this.CreateGraphics();

            if (isImage2Visible)
            {
                g.DrawImage(image2, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            if(isImage1Visible)
            {
                g.DrawImage(image1, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            if(isImage3Visible)
            {
                g.DrawImage(image3, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            var dir = Directory.GetCurrentDirectory();
            dir = dir.Replace("bin\\Debug\\net8.0-windows", "assets");
            Image image1 = Image.FromFile(dir + "\\door-right.png");

            button10.Image = Image.FromFile(dir + "\\button-active.png");

            Graphics g = this.CreateGraphics();

            g.DrawImage(image1, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
        }
    }
}
