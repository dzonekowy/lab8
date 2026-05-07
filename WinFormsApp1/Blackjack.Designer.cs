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
            dealer_karty = new DataGridView();
            gracz_karty = new DataGridView();
            suma_dealer = new TextBox();
            suma_gracz = new TextBox();
            suma_label = new Label();
            ((System.ComponentModel.ISupportInitialize)zaklad_numeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dealer_karty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gracz_karty).BeginInit();
            SuspendLayout();
            // 
            // dealer_label
            // 
            dealer_label.AutoSize = true;
            dealer_label.Location = new Point(94, 88);
            dealer_label.Name = "dealer_label";
            dealer_label.Size = new Size(62, 25);
            dealer_label.TabIndex = 0;
            dealer_label.Text = "Dealer";
            // 
            // gracz_label
            // 
            gracz_label.AutoSize = true;
            gracz_label.Location = new Point(94, 210);
            gracz_label.Name = "gracz_label";
            gracz_label.Size = new Size(59, 25);
            gracz_label.TabIndex = 1;
            gracz_label.Text = "label2";
            // 
            // start_button
            // 
            start_button.Location = new Point(775, 491);
            start_button.Name = "start_button";
            start_button.Size = new Size(112, 34);
            start_button.TabIndex = 2;
            start_button.Text = "Start";
            start_button.UseVisualStyleBackColor = true;
            // 
            // zaklad_numeric
            // 
            zaklad_numeric.Location = new Point(745, 439);
            zaklad_numeric.Name = "zaklad_numeric";
            zaklad_numeric.Size = new Size(180, 31);
            zaklad_numeric.TabIndex = 4;
            // 
            // saldo_label
            // 
            saldo_label.AutoSize = true;
            saldo_label.Location = new Point(788, 400);
            saldo_label.Name = "saldo_label";
            saldo_label.Size = new Size(61, 25);
            saldo_label.TabIndex = 5;
            saldo_label.Text = "Saldo:";
            // 
            // saldo_ilosc
            // 
            saldo_ilosc.AutoSize = true;
            saldo_ilosc.Location = new Point(842, 400);
            saldo_ilosc.Name = "saldo_ilosc";
            saldo_ilosc.Size = new Size(32, 25);
            saldo_ilosc.TabIndex = 6;
            saldo_ilosc.Text = "20";
            // 
            // dealer_karty
            // 
            dealer_karty.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dealer_karty.Location = new Point(189, 65);
            dealer_karty.Name = "dealer_karty";
            dealer_karty.RowHeadersWidth = 62;
            dealer_karty.Size = new Size(441, 73);
            dealer_karty.TabIndex = 7;
            // 
            // gracz_karty
            // 
            gracz_karty.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gracz_karty.Location = new Point(189, 195);
            gracz_karty.Name = "gracz_karty";
            gracz_karty.RowHeadersWidth = 62;
            gracz_karty.Size = new Size(441, 73);
            gracz_karty.TabIndex = 8;
            // 
            // suma_dealer
            // 
            suma_dealer.Location = new Point(657, 88);
            suma_dealer.Name = "suma_dealer";
            suma_dealer.Size = new Size(66, 31);
            suma_dealer.TabIndex = 9;
            // 
            // suma_gracz
            // 
            suma_gracz.Location = new Point(657, 210);
            suma_gracz.Name = "suma_gracz";
            suma_gracz.Size = new Size(66, 31);
            suma_gracz.TabIndex = 10;
            // 
            // suma_label
            // 
            suma_label.AutoSize = true;
            suma_label.Location = new Point(657, 21);
            suma_label.Name = "suma_label";
            suma_label.Size = new Size(57, 25);
            suma_label.TabIndex = 11;
            suma_label.Text = "Suma";
            // 
            // Blackjack
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(961, 569);
            Controls.Add(suma_label);
            Controls.Add(suma_gracz);
            Controls.Add(suma_dealer);
            Controls.Add(gracz_karty);
            Controls.Add(dealer_karty);
            Controls.Add(saldo_ilosc);
            Controls.Add(saldo_label);
            Controls.Add(zaklad_numeric);
            Controls.Add(start_button);
            Controls.Add(gracz_label);
            Controls.Add(dealer_label);
            Name = "Blackjack";
            Text = "Blackjack";
            ((System.ComponentModel.ISupportInitialize)zaklad_numeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)dealer_karty).EndInit();
            ((System.ComponentModel.ISupportInitialize)gracz_karty).EndInit();
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
        private DataGridView dealer_karty;
        private DataGridView gracz_karty;
        private TextBox suma_dealer;
        private TextBox suma_gracz;
        private Label suma_label;
    }
}