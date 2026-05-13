namespace WinFormsApp1
{
    partial class Speed
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Stack1 = new Button();
            Stack2 = new Button();
            Slap = new Button();
            Card1 = new Button();
            Card2 = new Button();
            Card3 = new Button();
            Card4 = new Button();
            Card5 = new Button();
            LeftCards = new Button();
            NumOfLeftCards = new Label();
            InfoBar = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            Time = new Label();
            EnemyCard1 = new Button();
            EnemyCard2 = new Button();
            EnemyCard3 = new Button();
            EnemyCard4 = new Button();
            EnemyCard5 = new Button();
            EnemLeftCards = new Button();
            NumOfEnemyCards = new Label();
            Start = new Button();
            SuspendLayout();
            // 
            // Stack1
            // 
            Stack1.Location = new Point(168, 240);
            Stack1.Name = "Stack1";
            Stack1.Size = new Size(150, 150);
            Stack1.TabIndex = 0;
            Stack1.Text = "Stack1";
            Stack1.UseVisualStyleBackColor = true;
            Stack1.Click += Stack1_Click;
            // 
            // Stack2
            // 
            Stack2.Location = new Point(636, 240);
            Stack2.Name = "Stack2";
            Stack2.Size = new Size(150, 150);
            Stack2.TabIndex = 1;
            Stack2.Text = "Stack2";
            Stack2.UseVisualStyleBackColor = true;
            Stack2.Click += Stack2_Click;
            // 
            // Slap
            // 
            Slap.Location = new Point(417, 551);
            Slap.Name = "Slap";
            Slap.Size = new Size(120, 60);
            Slap.TabIndex = 2;
            Slap.Text = "Slap";
            Slap.UseVisualStyleBackColor = true;
            Slap.Click += Slap_Click;
            // 
            // Card1
            // 
            Card1.Location = new Point(168, 629);
            Card1.Name = "Card1";
            Card1.Size = new Size(150, 150);
            Card1.TabIndex = 3;
            Card1.Text = "Card1";
            Card1.UseVisualStyleBackColor = true;
            Card1.Click += Card1_Click;
            // 
            // Card2
            // 
            Card2.Location = new Point(324, 629);
            Card2.Name = "Card2";
            Card2.Size = new Size(150, 150);
            Card2.TabIndex = 4;
            Card2.Text = "Card2";
            Card2.UseVisualStyleBackColor = true;
            Card2.Click += Card2_Click;
            // 
            // Card3
            // 
            Card3.Location = new Point(480, 630);
            Card3.Name = "Card3";
            Card3.Size = new Size(150, 150);
            Card3.TabIndex = 5;
            Card3.Text = "Card3";
            Card3.UseVisualStyleBackColor = true;
            Card3.Click += Card3_Click;
            // 
            // Card4
            // 
            Card4.Location = new Point(636, 630);
            Card4.Name = "Card4";
            Card4.Size = new Size(150, 150);
            Card4.TabIndex = 6;
            Card4.Text = "Card4";
            Card4.UseVisualStyleBackColor = true;
            Card4.Click += Card4_Click;
            // 
            // Card5
            // 
            Card5.Location = new Point(792, 629);
            Card5.Name = "Card5";
            Card5.Size = new Size(150, 150);
            Card5.TabIndex = 7;
            Card5.Text = "Card5";
            Card5.UseVisualStyleBackColor = true;
            Card5.Click += Card5_Click;
            // 
            // LeftCards
            // 
            LeftCards.Location = new Point(31, 654);
            LeftCards.Name = "LeftCards";
            LeftCards.Size = new Size(100, 100);
            LeftCards.TabIndex = 8;
            LeftCards.Text = "LeftCards";
            LeftCards.UseVisualStyleBackColor = true;
            // 
            // NumOfLeftCards
            // 
            NumOfLeftCards.AutoSize = true;
            NumOfLeftCards.Location = new Point(17, 626);
            NumOfLeftCards.Name = "NumOfLeftCards";
            NumOfLeftCards.Size = new Size(145, 25);
            NumOfLeftCards.TabIndex = 9;
            NumOfLeftCards.Text = "NumOfLeftCards";
            NumOfLeftCards.TextAlign = ContentAlignment.MiddleCenter;
            NumOfLeftCards.Click += NumOfLeftCards_Click;
            // 
            // InfoBar
            // 
            InfoBar.AutoSize = true;
            InfoBar.Location = new Point(442, 365);
            InfoBar.Name = "InfoBar";
            InfoBar.Size = new Size(69, 25);
            InfoBar.TabIndex = 10;
            InfoBar.Text = "InfoBar";
            InfoBar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // Time
            // 
            Time.AutoSize = true;
            Time.Location = new Point(451, 240);
            Time.Name = "Time";
            Time.Size = new Size(50, 25);
            Time.TabIndex = 11;
            Time.Text = "Time";
            Time.TextAlign = ContentAlignment.MiddleCenter;
            Time.Click += Time_Click;
            // 
            // EnemyCard1
            // 
            EnemyCard1.Location = new Point(168, 9);
            EnemyCard1.Name = "EnemyCard1";
            EnemyCard1.Size = new Size(150, 150);
            EnemyCard1.TabIndex = 12;
            EnemyCard1.Text = "EnemyCard1";
            EnemyCard1.UseVisualStyleBackColor = true;
            EnemyCard1.Click += EnemyCard1_Click;
            // 
            // EnemyCard2
            // 
            EnemyCard2.Location = new Point(324, 12);
            EnemyCard2.Name = "EnemyCard2";
            EnemyCard2.Size = new Size(150, 150);
            EnemyCard2.TabIndex = 13;
            EnemyCard2.Text = "EnemyCard2";
            EnemyCard2.UseVisualStyleBackColor = true;
            EnemyCard2.Click += EnemyCard2_Click;
            // 
            // EnemyCard3
            // 
            EnemyCard3.Location = new Point(480, 12);
            EnemyCard3.Name = "EnemyCard3";
            EnemyCard3.Size = new Size(150, 150);
            EnemyCard3.TabIndex = 14;
            EnemyCard3.Text = "EnemyCard3";
            EnemyCard3.UseVisualStyleBackColor = true;
            EnemyCard3.Click += EnemyCard3_Click;
            // 
            // EnemyCard4
            // 
            EnemyCard4.Location = new Point(636, 9);
            EnemyCard4.Name = "EnemyCard4";
            EnemyCard4.Size = new Size(150, 150);
            EnemyCard4.TabIndex = 15;
            EnemyCard4.Text = "EnemyCard4";
            EnemyCard4.UseVisualStyleBackColor = true;
            EnemyCard4.Click += EnemyCard4_Click;
            // 
            // EnemyCard5
            // 
            EnemyCard5.Location = new Point(792, 9);
            EnemyCard5.Name = "EnemyCard5";
            EnemyCard5.Size = new Size(150, 150);
            EnemyCard5.TabIndex = 16;
            EnemyCard5.Text = "EnemyCard5";
            EnemyCard5.UseVisualStyleBackColor = true;
            EnemyCard5.Click += EnemyCard5_Click;
            // 
            // EnemLeftCards
            // 
            EnemLeftCards.Location = new Point(31, 34);
            EnemLeftCards.Name = "EnemLeftCards";
            EnemLeftCards.Size = new Size(100, 100);
            EnemLeftCards.TabIndex = 17;
            EnemLeftCards.Text = "EnemLeftCards";
            EnemLeftCards.UseVisualStyleBackColor = true;
            // 
            // NumOfEnemyCards
            // 
            NumOfEnemyCards.AutoSize = true;
            NumOfEnemyCards.Location = new Point(31, 134);
            NumOfEnemyCards.Name = "NumOfEnemyCards";
            NumOfEnemyCards.Size = new Size(116, 25);
            NumOfEnemyCards.TabIndex = 18;
            NumOfEnemyCards.Text = "NumOfCards";
            NumOfEnemyCards.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Start
            // 
            Start.Location = new Point(417, 285);
            Start.Name = "Start";
            Start.Size = new Size(120, 60);
            Start.TabIndex = 19;
            Start.Text = "Start";
            Start.UseVisualStyleBackColor = true;
            Start.Click += Start_Click;
            // 
            // Speed
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(952, 789);
            Controls.Add(Start);
            Controls.Add(NumOfEnemyCards);
            Controls.Add(EnemLeftCards);
            Controls.Add(EnemyCard5);
            Controls.Add(EnemyCard4);
            Controls.Add(EnemyCard3);
            Controls.Add(EnemyCard2);
            Controls.Add(EnemyCard1);
            Controls.Add(Time);
            Controls.Add(InfoBar);
            Controls.Add(NumOfLeftCards);
            Controls.Add(LeftCards);
            Controls.Add(Card5);
            Controls.Add(Card4);
            Controls.Add(Card3);
            Controls.Add(Card2);
            Controls.Add(Card1);
            Controls.Add(Slap);
            Controls.Add(Stack2);
            Controls.Add(Stack1);
            Name = "Speed";
            Text = "Speed";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Stack1;
        private Button Stack2;
        private Button Slap;
        private Button Card1;
        private Button Card2;
        private Button Card3;
        private Button Card4;
        private Button Card5;
        private Button LeftCards;
        private Label NumOfLeftCards;
        private Label InfoBar;
        private System.Windows.Forms.Timer timer1;
        private Label Time;
        private Button EnemyCard1;
        private Button EnemyCard2;
        private Button EnemyCard3;
        private Button EnemyCard4;
        private Button EnemyCard5;
        private Button EnemLeftCards;
        private Label NumOfEnemyCards;
        private Button Start;
    }
}