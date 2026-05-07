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
            Stack1 = new Button();
            Stack2 = new Button();
            Slap = new Button();
            Card1 = new Button();
            Card2 = new Button();
            Card3 = new Button();
            Card4 = new Button();
            Card5 = new Button();
            SuspendLayout();
            // 
            // Stack1
            // 
            Stack1.Location = new Point(474, 206);
            Stack1.Name = "Stack1";
            Stack1.Size = new Size(127, 126);
            Stack1.TabIndex = 0;
            Stack1.Text = "Stack1";
            Stack1.UseVisualStyleBackColor = true;
            Stack1.Click += Stack1_Click;
            // 
            // Stack2
            // 
            Stack2.Location = new Point(189, 206);
            Stack2.Name = "Stack2";
            Stack2.Size = new Size(127, 126);
            Stack2.TabIndex = 1;
            Stack2.Text = "Stack2";
            Stack2.UseVisualStyleBackColor = true;
            Stack2.Click += Stack2_Click;
            // 
            // Slap
            // 
            Slap.Location = new Point(330, 518);
            Slap.Name = "Slap";
            Slap.Size = new Size(112, 34);
            Slap.TabIndex = 2;
            Slap.Text = "Slap";
            Slap.UseVisualStyleBackColor = true;
            Slap.Visible = false;
            Slap.Click += Slap_Click;
            // 
            // Card1
            // 
            Card1.Location = new Point(59, 640);
            Card1.Name = "Card1";
            Card1.Size = new Size(101, 96);
            Card1.TabIndex = 3;
            Card1.Text = "Card1";
            Card1.UseVisualStyleBackColor = true;
            Card1.Click += Card1_Click;
            // 
            // Card2
            // 
            Card2.Location = new Point(189, 642);
            Card2.Name = "Card2";
            Card2.Size = new Size(101, 94);
            Card2.TabIndex = 4;
            Card2.Text = "Card2";
            Card2.UseVisualStyleBackColor = true;
            Card2.Click += Card2_Click;
            // 
            // Card3
            // 
            Card3.Location = new Point(330, 640);
            Card3.Name = "Card3";
            Card3.Size = new Size(101, 96);
            Card3.TabIndex = 5;
            Card3.Text = "Card3";
            Card3.UseVisualStyleBackColor = true;
            Card3.Click += Card3_Click;
            // 
            // Card4
            // 
            Card4.Location = new Point(465, 642);
            Card4.Name = "Card4";
            Card4.Size = new Size(101, 94);
            Card4.TabIndex = 6;
            Card4.Text = "Card4";
            Card4.UseVisualStyleBackColor = true;
            Card4.Click += Card4_Click;
            // 
            // Card5
            // 
            Card5.Location = new Point(615, 642);
            Card5.Name = "Card5";
            Card5.Size = new Size(101, 94);
            Card5.TabIndex = 7;
            Card5.Text = "Card5";
            Card5.UseVisualStyleBackColor = true;
            // 
            // Speed
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(862, 789);
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
    }
}