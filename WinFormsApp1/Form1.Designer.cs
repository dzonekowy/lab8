namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            blackjack_button = new Button();
            textbox_nazwa_gracza = new TextBox();
            label_nazwa_gracza = new Label();
            button_tablica = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(213, 39);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(78, 35);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(213, 76);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(78, 35);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(213, 115);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(78, 35);
            button3.TabIndex = 2;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(213, 151);
            button4.Margin = new Padding(2);
            button4.Name = "button4";
            button4.Size = new Size(78, 35);
            button4.TabIndex = 3;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // blackjack_button
            // 
            blackjack_button.Location = new Point(213, 190);
            blackjack_button.Margin = new Padding(2);
            blackjack_button.Name = "blackjack_button";
            blackjack_button.Size = new Size(78, 35);
            blackjack_button.TabIndex = 4;
            blackjack_button.Text = "Blackjack";
            blackjack_button.UseVisualStyleBackColor = true;
            blackjack_button.Click += blackjack_button_Click;
            // 
            // textbox_nazwa_gracza
            // 
            textbox_nazwa_gracza.Location = new Point(202, 283);
            textbox_nazwa_gracza.Name = "textbox_nazwa_gracza";
            textbox_nazwa_gracza.Size = new Size(100, 23);
            textbox_nazwa_gracza.TabIndex = 5;
            textbox_nazwa_gracza.Text = "Gość";
            // 
            // label_nazwa_gracza
            // 
            label_nazwa_gracza.AutoSize = true;
            label_nazwa_gracza.Location = new Point(149, 286);
            label_nazwa_gracza.Name = "label_nazwa_gracza";
            label_nazwa_gracza.Size = new Size(45, 15);
            label_nazwa_gracza.TabIndex = 6;
            label_nazwa_gracza.Text = "Nazwa:";
            // 
            // button_tablica
            // 
            button_tablica.Location = new Point(213, 320);
            button_tablica.Name = "button_tablica";
            button_tablica.Size = new Size(78, 35);
            button_tablica.TabIndex = 7;
            button_tablica.Text = "Wyniki";
            button_tablica.UseVisualStyleBackColor = true;
            button_tablica.Click += button_tablica_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 430);
            Controls.Add(button_tablica);
            Controls.Add(label_nazwa_gracza);
            Controls.Add(textbox_nazwa_gracza);
            Controls.Add(blackjack_button);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button blackjack_button;
        private TextBox textbox_nazwa_gracza;
        private Label label_nazwa_gracza;
        private Button button_tablica;
    }
}
