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
            button2.Left = (this.ClientSize.Width - button2.Width) / 2;

            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            label2.Left = (this.ClientSize.Width - label2.Width) / 2;
            label3.Left = (this.ClientSize.Width - label3.Width) / 2;
            label5.Left = (this.ClientSize.Width - label5.Width) / 2;
            label6.Left = (this.ClientSize.Width - label6.Width) / 2;

            button6.Left = (this.ClientSize.Width - button6.Width) / 2;
            label7.Left = (this.ClientSize.Width - label7.Width) / 2;
            textBox1.Left = (this.ClientSize.Width - textBox1.Width) / 2;

        }

        private void FNAPP_Load(object sender, EventArgs e)
        {

        }

        public string dir = Directory.GetCurrentDirectory().Replace("bin\\Debug\\net8.0-windows", "assets");

        public int night = 0;

        private void FNAPP_Start(object sender, EventArgs e)
        {
            button1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;

            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            label4.Visible = true;

            button3.Image = Image.FromFile(dir + "\\cam-main.png");
            button4.Image = Image.FromFile(dir + "\\cam1.png");
            button5.Image = Image.FromFile(dir + "\\cam2.png");
            button7.Image = Image.FromFile(dir + "\\cam5.png");
            button8.Image = Image.FromFile(dir + "\\button.png");
            button9.Image = Image.FromFile(dir + "\\button.png");
            button10.Image = Image.FromFile(dir + "\\button.png");

            Print();
            startGame();
        }

        public bool gameOver = false;

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

        private void Print()
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
            if (isHyraxIn)
            {
                g.DrawImage(hyraxIn, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            if (isSzopIn)
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

            battery();

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
            if (gameOver)
            {
                button6.Visible = true;
                label7.Visible = true;
                textBox1.Visible = true;
            }

        }

        public void battery()
        {
            Image battery100 = Image.FromFile(dir + "\\battery100.png");
            Image battery80 = Image.FromFile(dir + "\\battery80.png");
            Image battery60 = Image.FromFile(dir + "\\battery60.png");
            Image battery40 = Image.FromFile(dir + "\\battery40.png");
            Image battery20 = Image.FromFile(dir + "\\battery20.png");
            Image battery0 = Image.FromFile(dir + "\\battery0.png");

            Graphics g = this.CreateGraphics();

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
        }

        public void buttonsOff()
        {
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
        }

        public void cameraOff()
        {
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button7.Visible = false;
        }

        public bool isHyraxCam1 = false;
        public bool isHyraxCam2 = false;
        public bool isSzopCam1 = false;
        public bool isSzopCam2 = false;

        public int hour = 5;
        public int minute = 55;

        public bool isTimerOn = false;

        public int batteryLevel = 100;

        public bool wasDoorLeft = false;
        public bool wasDoorRight = false;
        public bool wasWindow = false;
        public bool wasCamera1 = false;
        public bool wasCamera2 = false;
        public bool wasCamera5 = false;

        public void timerBatter()
        {
            System.Timers.Timer timer = new System.Timers.Timer(2000);
            timer.Elapsed += (s, e) =>
            {
                if (wasDoorLeft)
                {
                    batteryLevel -= 1;
                    wasDoorLeft = false;
                }
                if (wasDoorRight)
                {
                    batteryLevel -= 1;
                    wasDoorRight = false;
                }
                if (wasWindow)
                {
                    batteryLevel -= 1;
                    wasWindow = false;
                }
                if (wasCamera1 || cam1)
                {
                    batteryLevel -= 1;
                    wasCamera1 = false;
                }
                if (wasCamera2 || cam2)
                {
                    batteryLevel -= 1;
                    wasCamera2 = false;
                }
                if (wasCamera5 || cam5)
                {
                    batteryLevel -= 1;
                    wasCamera5 = false;
                }

                isBattery0 = false;
                isBattery20 = false;
                isBattery40 = false;
                isBattery60 = false;
                isBattery80 = false;
                isBattery100 = false;

                if (batteryLevel == 0)
                {
                    isBattery0 = true;
                }
                else if(batteryLevel <= 20)
                {
                    isBattery20 = true;
                }
                else if(batteryLevel <= 40)
                {
                    isBattery40 = true;
                }
                else if(batteryLevel <= 60)
                {
                    isBattery60 = true;
                }
                else if(batteryLevel <= 80)
                {
                    isBattery80 = true;
                }
                else if(batteryLevel <= 100)
                {
                    isBattery100 = true;
                }

                if (batteryLevel <= 0)
                {
                    button10.Image = Image.FromFile(dir + "\\button.png");
                    isDoorRight = false;
                    button9.Image = Image.FromFile(dir + "\\button.png");
                    isImage2NewVisible = false;
                    isImage2Visible = true;
                    button8.Image = Image.FromFile(dir + "\\button.png");
                    isDoorLeft = false;

                    Print();

                    timer.Stop();
                }

                battery();
            };
            timer.Start();
        }

        public async void startGame()
        {
            if (!isTimerOn)
            {
                isTimerOn = true;
                timerBatter();
            }


            await Task.Delay(5000);

            minute += 5;

            if (minute % 60 == 0)
            {
                hour++;
                minute = 0;
                label4.Text = hour.ToString() + " AM";
            }
            if (hour == 6)
            {
                //gameOver = true;

                buttonsOff();
                cameraOff();

                isHyraxIn = false;
                isSzopIn = false;
                isKrokIn = false;

                Print();

                if (night != 4)
                {
                    button2.Visible = true;
                }

                label6.Visible = true;

                if(night == 4)
                {
                    button6.Visible = true;
                    label7.Visible = true;
                    textBox1.Visible = true;
                }

                return;
            }

            Random rnd = new Random();

            int randomHyrax = 0;
            int randomSzop = 0;
            int randomKrok = 0;
            if (night == 1)
            {
                randomHyrax = rnd.Next(1, 21);
                randomSzop = rnd.Next(1, 21);
            }
            else if (night == 2) {
                randomHyrax = rnd.Next(1, 11);
                randomSzop = rnd.Next(1, 11);
            }
            else if(night == 3)
            {
                randomKrok = rnd.Next(1, 30);

                if(hour == 5 && minute == 40) 
                {
                    randomKrok = 1;
                }
            }
            else if(night == 4)
            {
                randomHyrax = rnd.Next(1, 6);
                randomSzop = rnd.Next(1, 6);
                randomKrok = rnd.Next(1, 16);
            }


            if (hour >= 1 && !isHyraxCam2 && !isHyraxIn)
            {
                if (randomHyrax == 1 && !isHyraxCam1)
                {
                    isHyraxCam1 = true;
                    isHyraxInCam5 = false;
                }
                else if (randomHyrax == 1 && isHyraxCam1)
                {
                    isHyraxCam1 = false;
                    isHyraxCam2 = true;
                }
            }
            else if (hour >= 1 && isHyraxCam2 && !isHyraxIn)
            {
                if (randomHyrax == 1 && !isDoorLeft)
                {
                    isHyraxCam2 = false;
                    isHyraxIn = true;
                }
                else if (randomHyrax == 1 && isDoorLeft)
                {
                    isHyraxCam2 = false;
                    isHyraxInCam5 = true;
                }
            }
            else if (isHyraxIn)
            {
                if (!isDoorLeft)
                {
                    gameOver = true;

                    isHyraxOver = true;
                    Print();

                    return;
                }
                else
                {
                    isHyraxIn = false;
                    isHyraxInCam5 = true;
                    Print();
                }
            }

            if (hour >= 1 && !isSzopCam2 && !isSzopIn)
            {
                if (randomSzop == 1 && !isSzopCam1)
                {
                    isSzopCam1 = true;
                    isSzopInCam5 = false;
                }
                else if (randomSzop == 1 && isSzopCam1)
                {
                    isSzopCam1 = false;
                    isSzopCam2 = true;
                }
            }
            else if (hour >= 1 && isSzopCam2 && !isSzopIn)
            {
                if (randomSzop == 1 && !isDoorRight)
                {
                    isSzopCam2 = false;
                    isSzopIn = true;
                }
                else if (randomSzop == 1 && isDoorRight)
                {
                    isSzopCam2 = false;
                    isSzopInCam5 = true;
                }
            }
            else if (isSzopIn)
            {
                if (!isDoorRight)
                {
                    gameOver = true;

                    isSzopOver = true;
                    Print();

                    return;
                }
                else
                {
                    isSzopIn = false;
                    isSzopInCam5 = true;
                    Print();
                }
            }

            if(hour >= 1 && !isKrokIn)
            {
                if(randomKrok == 1 && isKrokInCam5)
                {
                    isKrokInCam5 = false;
                }
                else if((!isKrokInCam5 && night == 3 && randomKrok > 20) || (!isKrokInCam5 && night == 4 && randomKrok > 9))
                {
                    isKrokIn = true;
                }
            }
            else if(hour >= 1 && isKrokIn)
            {
                if (!isImage2NewVisible)
                {
                    gameOver = true;

                    isKrokOver = true;
                    Print();

                    return;
                }
                else
                {
                    isKrokIn = false;
                    isKrokInCam5 = true;
                    Print();
                }
            }


            if (cam1)
            {
                szop();
                battery();
            }
            else if (cam2)
            {
                hyrax();
                battery();
            }
            else if (cam5)
            {
                back();
                battery();
            }


            if (!gameOver)
            {
                startGame();
            }
        }



        private void button10_Click(object sender, EventArgs e)
        {
            if(batteryLevel > 0)
            {
                if (!isDoorRight)
                {
                    wasDoorRight = true;
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
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(batteryLevel > 0)
            {
                if (!isImage2NewVisible)
                {
                    wasWindow = true;
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
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(batteryLevel > 0)
            {
                if (!isDoorLeft)
                {
                    wasDoorLeft = true;
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
        }

        public bool cam1 = false;
        public bool cam2 = false;
        public bool cam5 = false;

        private void button4_Click(object sender, EventArgs e)
        {
            if (batteryLevel > 0)
            {
                cam1 = true;
                wasCamera1 = true;
                szop();
                battery();
            }
        }

        public void szop()
        {
            buttonsOff();

            Image image1 = Image.FromFile(dir + "\\cam1-main.png");
            Image image2 = Image.FromFile(dir + "\\cam-blur.png");
            Image szop1 = Image.FromFile(dir + "\\cam2-main-szop1.png");
            Image szop2 = Image.FromFile(dir + "\\cam2-main-szop2.png");
            Image szop3 = Image.FromFile(dir + "\\cam2-main-szop3.png");


            Graphics g = this.CreateGraphics();

            g.DrawImage(image1, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            if (isSzopCam1)
            {
                g.DrawImage(szop1, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            if (isSzopCam2)
            {
                g.DrawImage(szop2, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            if (isSzopIn)
            {
                g.DrawImage(szop3, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            g.DrawImage(image2, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (batteryLevel > 0)
            {
                cam2 = true;
                wasCamera2 = true;
                hyrax();
                battery();
            }
        }

        public void hyrax()
        {
            buttonsOff();

            Image image1 = Image.FromFile(dir + "\\cam2-main.png");
            Image image2 = Image.FromFile(dir + "\\cam-blur.png");
            Image hyrax1 = Image.FromFile(dir + "\\cam1-main-hyrax1.png");
            Image hyrax2 = Image.FromFile(dir + "\\cam1-main-hyrax2.png");
            Image hyrax3 = Image.FromFile(dir + "\\cam1-main-hyrax3.png");


            Graphics g = this.CreateGraphics();

            g.DrawImage(image1, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            if (isHyraxCam1)
            {
                g.DrawImage(hyrax1, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            if (isHyraxCam2)
            {
                g.DrawImage(hyrax2, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            if (isHyraxIn)
            {
                g.DrawImage(hyrax3, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            g.DrawImage(image2, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
        }

        public bool isHyraxInCam5 = true;
        public bool isSzopInCam5 = true;
        public bool isKrokInCam5 = true;

        private void button7_Click(object sender, EventArgs e)
        {
            if (batteryLevel > 0)
            {
                cam5 = true;
                wasCamera5 = true;
                back();
                battery();
            }
        }

        public void back()
        {
            buttonsOff();

            Image image1 = Image.FromFile(dir + "\\cam5-main.png");
            Image image2 = Image.FromFile(dir + "\\cam-blur.png");
            Image hyraxIn = Image.FromFile(dir + "\\cam5-hyrax.png");
            Image szopIn = Image.FromFile(dir + "\\cam5-szop.png");
            Image krokIn = Image.FromFile(dir + "\\cam5-krok.png");

            Graphics g = this.CreateGraphics();

            g.DrawImage(image1, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));

            if (isHyraxInCam5)
            {
                g.DrawImage(hyraxIn, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            if (isSzopInCam5)
            {
                g.DrawImage(szopIn, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            if (isKrokInCam5)
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

            cam1 = false;
            cam2 = false;
            cam5 = false;

            Print();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            night++;

            gameOver = false;

            isImage1Visible = true;
            isImage2Visible = true;
            isImage2NewVisible = false;
            isImage3Visible = true;
            isBattery100 = true;
            isBattery80 = false;
            isBattery60 = false;
            isBattery40 = false;
            isBattery20 = false;
            isBattery0 = false;
            isDoorLeft = false;
            isDoorRight = false;

            isHyraxIn = false;
            isSzopIn = false;
            isKrokIn = false;
            isHyraxOver = false;
            isSzopOver = false;
            isKrokOver = false;

            isHyraxCam1 = false;
            isHyraxCam2 = false;
            isSzopCam1 = false;
            isSzopCam2 = false;

            hour = 0;
            minute = 0;

            isTimerOn = false;

            batteryLevel = 100;

            wasDoorLeft = false;
            wasDoorRight = false;
            wasWindow = false;
            wasCamera1 = false;
            wasCamera2 = false;
            wasCamera5 = false;

            cam1 = false;
            cam2 = false;
            cam5 = false;

            isHyraxInCam5 = true;
            isSzopInCam5 = true;
            isKrokInCam5 = true;


            button6.Visible = false;
            label7.Visible = false;
            textBox1.Visible = false;

            button2.Visible = false;
            label6.Visible = false;

            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button7.Visible = true;

            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;

            label4.Text = "12 PM";


            FNAPP_Start(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sciezka = "wynik.txt";
            string nazwagracza = "Anonim";
            if(textBox1.Text != "")
            {
                nazwagracza = textBox1.Text;
            }
            string winlose = "";
            double roznica = night;
            switch (night)
            {
                case < 4:
                    winlose = "Przegrana";
                    break;
                case 4:
                    winlose = "Wygrana";
                    break;
            }
            //wynik jest wyświetlany jako różnica wygrana - zakład
            string tresc = $"{nazwagracza},FNWH,{winlose},{roznica},{DateTime.Now:dd.MM.yyyy},{DateTime.Now:HH:mm}\n";
            File.AppendAllText(sciezka, tresc);

            this.Hide();
            Form1 form = new Form1();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }
    }
}
