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
            label5.Left = (this.ClientSize.Width - label5.Width) / 2;

        }

        private void FNAPP_Load(object sender, EventArgs e)
        {

        }

        public string dir = Directory.GetCurrentDirectory().Replace("bin\\Debug\\net8.0-windows", "assets");

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
            label4.Visible = true;

            button2.Image = Image.FromFile(dir + "\\cam3.png");
            button3.Image = Image.FromFile(dir + "\\cam-main.png");
            button4.Image = Image.FromFile(dir + "\\cam1.png");
            button5.Image = Image.FromFile(dir + "\\cam2.png");
            button6.Image = Image.FromFile(dir + "\\cam4.png");
            button7.Image = Image.FromFile(dir + "\\cam5.png");
            button8.Image = Image.FromFile(dir + "\\button.png");
            button9.Image = Image.FromFile(dir + "\\button.png");
            button10.Image = Image.FromFile(dir + "\\button.png");

            Print();
        }

        public bool isImage1Visible = true;
        public bool isImage2Visible = true;
        public bool isImage2NewVisible = false;
        public bool isImage3Visible = true;
        public bool isBattery100 = true;
        public bool isBattery80 = false;
        public bool isBattery60 = false;
        public bool isBattery40 = false;
        public bool isBattery20 = false;
        public bool isBattery0 = false;
        public bool isDoorLeft = false;
        public bool isDoorRight = false;

        public bool isHyraxIn = false;
        public bool isSzopIn = false;
        public bool isKrokIn = false;
        public bool isHyraxOver = false;
        public bool isSzopOver = false;
        public bool isKrokOver = false;

        private async void Print()
        {
            //
            // worst possible code here
            //


            Image image1 = Image.FromFile(dir + "\\main1.png");
            Image image2 = Image.FromFile(dir + "\\main2-dark.png");
            Image window = Image.FromFile(dir + "\\main3.png");
            Image image2new = Image.FromFile(dir + "\\main2.png");
            Image doorLeft = Image.FromFile(dir + "\\door-left.png");
            Image doorRight = Image.FromFile(dir + "\\door-right.png");
            Image battery100 = Image.FromFile(dir + "\\battery100.png");
            Image battery80 = Image.FromFile(dir + "\\battery80.png");
            Image battery60 = Image.FromFile(dir + "\\battery60.png");
            Image battery40 = Image.FromFile(dir + "\\battery40.png");
            Image battery20 = Image.FromFile(dir + "\\battery20.png");
            Image battery0 = Image.FromFile(dir + "\\battery0.png");

            Image hyraxIn = Image.FromFile(dir + "\\hyrax-in.png");
            Image shopIn = Image.FromFile(dir + "\\szop-in.png");
            Image krokIn = Image.FromFile(dir + "\\krok-in.png");
            Image krokInDark = Image.FromFile(dir + "\\krok-in-dark.png");
            Image hyraxOver = Image.FromFile(dir + "\\hyrax1.png");
            Image szopOver = Image.FromFile(dir + "\\szop1.png");
            Image krokOver = Image.FromFile(dir + "\\krok1.png");

            Graphics g = this.CreateGraphics();

            if (isImage2Visible)
            {
                g.DrawImage(image2, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));

                if (isKrokIn)
                {
                    g.DrawImage(krokInDark, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
                }
            }
            if (isImage2NewVisible)
            {
                g.DrawImage(image2new, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));

                if (isKrokIn)
                {
                    g.DrawImage(krokIn, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
                }
            }
            if (isImage1Visible)
            {
                g.DrawImage(image1, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            if (isImage3Visible)
            {
                g.DrawImage(window, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            if(isHyraxIn)
            {
                g.DrawImage(hyraxIn, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            if(isSzopIn)
            {
                g.DrawImage(shopIn, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            if (isDoorLeft)
            {
                g.DrawImage(doorLeft, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            if (isDoorRight)
            {
                g.DrawImage(doorRight, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            if (isBattery100)
            {
                g.DrawImage(battery100, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            if (isBattery80)
            {
                g.DrawImage(battery80, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            if (isBattery60)
            {
                g.DrawImage(battery60, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            if (isBattery40)
            {
                g.DrawImage(battery40, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            if (isBattery20)
            {
                g.DrawImage(battery20, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            if (isBattery0)
            {
                g.DrawImage(battery0, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            if (isHyraxOver)
            {
                buttonsOff();
                cameraOff();

                g.DrawImage(image2, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
                g.DrawImage(image1, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
                g.DrawImage(window, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));


                g.DrawImage(hyraxOver, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));

                label5.Visible = true;
            }
            if (isSzopOver)
            {
                buttonsOff();
                cameraOff();

                g.DrawImage(image2, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
                g.DrawImage(image1, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
                g.DrawImage(window, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));

                g.DrawImage(szopOver, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));

                label5.Visible = true;
            }
            if (isKrokOver)
            {
                buttonsOff();
                cameraOff();

                g.DrawImage(image2, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
                g.DrawImage(image1, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
                g.DrawImage(window, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));

                g.DrawImage(krokOver, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));

                label5.Visible = true;
            }

        }

        public void buttonsOff()
        {
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
        }

        public void cameraOff()
        {
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
        }




        private void button10_Click(object sender, EventArgs e)
        {
            if (!isDoorRight)
            {
                Image image1 = Image.FromFile(dir + "\\door-right.png");

                button10.Image = Image.FromFile(dir + "\\button-active.png");

                Graphics g = this.CreateGraphics();

                g.DrawImage(image1, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));

                isDoorRight = true;
            }
            else
            {
                button10.Image = Image.FromFile(dir + "\\button.png");
                isDoorRight = false;
                Print();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!isImage2NewVisible)
            {
                button9.Image = Image.FromFile(dir + "\\button-active.png");

                isImage2NewVisible = true;
                isImage2Visible = false;
                Print();
            }
            else
            {
                button9.Image = Image.FromFile(dir + "\\button.png");
                isImage2NewVisible = false;
                isImage2Visible = true;
                Print();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!isDoorLeft)
            {
                Image image1 = Image.FromFile(dir + "\\door-left.png");

                button8.Image = Image.FromFile(dir + "\\button-active.png");

                Graphics g = this.CreateGraphics();

                g.DrawImage(image1, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));

                isDoorLeft = true;
            }
            else
            {
                button8.Image = Image.FromFile(dir + "\\button.png");
                isDoorLeft = false;
                Print();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            buttonsOff();

            Image image1 = Image.FromFile(dir + "\\cam1-main.png");
            Image image2 = Image.FromFile(dir + "\\cam-blur.png");


            Graphics g = this.CreateGraphics();

            g.DrawImage(image1, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            g.DrawImage(image2, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            buttonsOff();

            Image image1 = Image.FromFile(dir + "\\cam2-main.png");
            Image image2 = Image.FromFile(dir + "\\cam-blur.png");


            Graphics g = this.CreateGraphics();

            g.DrawImage(image1, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            g.DrawImage(image2, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        public bool isHyraxInCam5 = true;
        public bool isSzopInCam5 = true;
        public bool isKrokInCam5 = true;

        private void button7_Click(object sender, EventArgs e)
        {
            buttonsOff();

            Image image1 = Image.FromFile(dir + "\\cam5-main.png");
            Image image2 = Image.FromFile(dir + "\\cam-blur.png");
            Image hyraxIn = Image.FromFile(dir + "\\cam5-hyrax.png");
            Image szopIn = Image.FromFile(dir + "\\cam5-szop.png");
            Image krokIn = Image.FromFile(dir + "\\cam5-krok.png");

            Graphics g = this.CreateGraphics();

            g.DrawImage(image1, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));

            if(isHyraxInCam5)
            {
                g.DrawImage(hyraxIn, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            if(isSzopInCam5)
            {
                g.DrawImage(szopIn, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            if(isKrokInCam5)
            {
                g.DrawImage(krokIn, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }

            g.DrawImage(image2, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
        }

        private void button3_Click(object sender, EventArgs e)
        {

            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;

            Print();
        }
    }
}
