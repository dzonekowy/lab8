namespace WinFormsApp1
{
    partial class Blackjack
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
            dealer_label = new Label();
            gracz_label = new Label();
            start_button = new Button();
            zaklad_numeric = new NumericUpDown();
            saldo_label = new Label();
            saldo_ilosc = new Label();
            suma_dealer = new TextBox();
            suma_gracz = new TextBox();
            suma_label = new Label();
            reka_dealer = new FlowLayoutPanel();
            reka_gracz = new FlowLayoutPanel();
            button_hit = new Button();
            button_hold = new Button();
            suma_label2 = new Label();
            log_box = new RichTextBox();
            double_down_button = new Button();
            ((System.ComponentModel.ISupportInitialize)zaklad_numeric).BeginInit();
            SuspendLayout();
            // 
            // dealer_label
            // 
            dealer_label.AutoSize = true;
            dealer_label.Location = new Point(49, 173);
            dealer_label.Margin = new Padding(2, 0, 2, 0);
            dealer_label.Name = "dealer_label";
            dealer_label.Size = new Size(40, 15);
            dealer_label.TabIndex = 0;
            dealer_label.Text = "Dealer";
            dealer_label.Click += dealer_label_Click;
            // 
            // gracz_label
            // 
            gracz_label.AutoSize = true;
            gracz_label.Location = new Point(49, 558);
            gracz_label.Margin = new Padding(2, 0, 2, 0);
            gracz_label.Name = "gracz_label";
            gracz_label.Size = new Size(38, 15);
            gracz_label.TabIndex = 1;
            gracz_label.Text = "label2";
            // 
            // start_button
            // 
            start_button.Location = new Point(752, 681);
            start_button.Margin = new Padding(2);
            start_button.Name = "start_button";
            start_button.Size = new Size(78, 23);
            start_button.TabIndex = 2;
            start_button.Text = "Start";
            start_button.UseVisualStyleBackColor = true;
            start_button.Click += start_button_Click;
            // 
            // zaklad_numeric
            // 
            zaklad_numeric.Location = new Point(727, 645);
            zaklad_numeric.Margin = new Padding(2);
            zaklad_numeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            zaklad_numeric.Name = "zaklad_numeric";
            zaklad_numeric.Size = new Size(126, 23);
            zaklad_numeric.TabIndex = 4;
            zaklad_numeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // saldo_label
            // 
            saldo_label.AutoSize = true;
            saldo_label.Location = new Point(752, 615);
            saldo_label.Margin = new Padding(2, 0, 2, 0);
            saldo_label.Name = "saldo_label";
            saldo_label.Size = new Size(39, 15);
            saldo_label.TabIndex = 5;
            saldo_label.Text = "Saldo:";
            saldo_label.Click += saldo_label_Click;
            // 
            // saldo_ilosc
            // 
            saldo_ilosc.AutoSize = true;
            saldo_ilosc.Location = new Point(795, 615);
            saldo_ilosc.Margin = new Padding(2, 0, 2, 0);
            saldo_ilosc.Name = "saldo_ilosc";
            saldo_ilosc.Size = new Size(19, 15);
            saldo_ilosc.TabIndex = 6;
            saldo_ilosc.Text = "50";
            // 
            // suma_dealer
            // 
            suma_dealer.Location = new Point(460, 173);
            suma_dealer.Margin = new Padding(2);
            suma_dealer.Name = "suma_dealer";
            suma_dealer.ReadOnly = true;
            suma_dealer.Size = new Size(47, 23);
            suma_dealer.TabIndex = 9;
            // 
            // suma_gracz
            // 
            suma_gracz.Location = new Point(460, 558);
            suma_gracz.Margin = new Padding(2);
            suma_gracz.Name = "suma_gracz";
            suma_gracz.ReadOnly = true;
            suma_gracz.Size = new Size(47, 23);
            suma_gracz.TabIndex = 10;
            // 
            // suma_label
            // 
            suma_label.AutoSize = true;
            suma_label.Location = new Point(460, 156);
            suma_label.Margin = new Padding(2, 0, 2, 0);
            suma_label.Name = "suma_label";
            suma_label.Size = new Size(37, 15);
            suma_label.TabIndex = 11;
            suma_label.Text = "Suma";
            // 
            // reka_dealer
            // 
            reka_dealer.AutoScroll = true;
            reka_dealer.Location = new Point(111, 31);
            reka_dealer.Name = "reka_dealer";
            reka_dealer.Size = new Size(321, 314);
            reka_dealer.TabIndex = 12;
            reka_dealer.Paint += flowLayoutPanel1_Paint;
            // 
            // reka_gracz
            // 
            reka_gracz.AutoScroll = true;
            reka_gracz.Location = new Point(111, 405);
            reka_gracz.Name = "reka_gracz";
            reka_gracz.Size = new Size(321, 314);
            reka_gracz.TabIndex = 13;
            // 
            // button_hit
            // 
            button_hit.Enabled = false;
            button_hit.Location = new Point(111, 740);
            button_hit.Name = "button_hit";
            button_hit.Size = new Size(75, 49);
            button_hit.TabIndex = 14;
            button_hit.Text = "Dobierz";
            button_hit.UseVisualStyleBackColor = true;
            button_hit.Click += button_hit_Click;
            // 
            // button_hold
            // 
            button_hold.Enabled = false;
            button_hold.Location = new Point(192, 740);
            button_hold.Name = "button_hold";
            button_hold.Size = new Size(75, 49);
            button_hold.TabIndex = 15;
            button_hold.Text = "Pas";
            button_hold.UseVisualStyleBackColor = true;
            button_hold.Click += button_hold_Click;
            // 
            // suma_label2
            // 
            suma_label2.AutoSize = true;
            suma_label2.Location = new Point(460, 541);
            suma_label2.Margin = new Padding(2, 0, 2, 0);
            suma_label2.Name = "suma_label2";
            suma_label2.Size = new Size(37, 15);
            suma_label2.TabIndex = 16;
            suma_label2.Text = "Suma";
            // 
            // log_box
            // 
            log_box.Location = new Point(599, 31);
            log_box.Name = "log_box";
            log_box.ReadOnly = true;
            log_box.Size = new Size(365, 550);
            log_box.TabIndex = 17;
            log_box.Text = "";
            // 
            // double_down_button
            // 
            double_down_button.Enabled = false;
            double_down_button.Location = new Point(273, 740);
            double_down_button.Name = "double_down_button";
            double_down_button.Size = new Size(75, 49);
            double_down_button.TabIndex = 18;
            double_down_button.Text = "Double Down";
            double_down_button.UseVisualStyleBackColor = true;
            double_down_button.Click += double_down_button_Click;
            // 
            // Blackjack
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 839);
            Controls.Add(double_down_button);
            Controls.Add(log_box);
            Controls.Add(suma_label2);
            Controls.Add(button_hold);
            Controls.Add(button_hit);
            Controls.Add(reka_gracz);
            Controls.Add(reka_dealer);
            Controls.Add(suma_label);
            Controls.Add(suma_gracz);
            Controls.Add(suma_dealer);
            Controls.Add(saldo_ilosc);
            Controls.Add(saldo_label);
            Controls.Add(zaklad_numeric);
            Controls.Add(start_button);
            Controls.Add(gracz_label);
            Controls.Add(dealer_label);
            Margin = new Padding(2);
            Name = "Blackjack";
            Text = "Blackjack";
            ((System.ComponentModel.ISupportInitialize)zaklad_numeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label dealer_label;
        private Label gracz_label;
        private Button start_button;
        private NumericUpDown zaklad_numeric;
        private Label saldo_label;
        private Label saldo_ilosc;
        private TextBox suma_dealer;
        private TextBox suma_gracz;
        private Label suma_label;
        private FlowLayoutPanel reka_dealer;
        private FlowLayoutPanel reka_gracz;
        private Button button_hit;
        private Button button_hold;
        private Label suma_label2;
        private RichTextBox log_box;
        private Button double_down_button;
    }
}