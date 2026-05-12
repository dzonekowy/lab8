namespace WinFormsApp1
{
    partial class FNAPP
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 20F);
            button1.Location = new Point(608, 237);
            button1.Name = "button1";
            button1.Size = new Size(125, 51);
            button1.TabIndex = 5;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += FNAPP_Start;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Location = new Point(983, 570);
            button2.Name = "button2";
            button2.Size = new Size(70, 45);
            button2.TabIndex = 5;
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Location = new Point(895, 630);
            button3.Name = "button3";
            button3.Size = new Size(65, 45);
            button3.TabIndex = 5;
            button3.UseVisualStyleBackColor = true;
            button3.Visible = false;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Location = new Point(968, 620);
            button4.Name = "button4";
            button4.Size = new Size(70, 45);
            button4.TabIndex = 5;
            button4.UseVisualStyleBackColor = true;
            button4.Visible = false;
            // 
            // button5
            // 
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Popup;
            button5.Location = new Point(819, 624);
            button5.Name = "button5";
            button5.Size = new Size(70, 45);
            button5.TabIndex = 5;
            button5.UseVisualStyleBackColor = true;
            button5.Visible = false;
            // 
            // button6
            // 
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Location = new Point(809, 570);
            button6.Name = "button6";
            button6.Size = new Size(70, 45);
            button6.TabIndex = 5;
            button6.UseVisualStyleBackColor = true;
            button6.Visible = false;
            // 
            // button7
            // 
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Popup;
            button7.Location = new Point(892, 536);
            button7.Name = "button7";
            button7.Size = new Size(85, 50);
            button7.TabIndex = 5;
            button7.UseVisualStyleBackColor = true;
            button7.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 39.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(492, 48);
            label1.Name = "label1";
            label1.Size = new Size(369, 66);
            label1.TabIndex = 6;
            label1.Text = "FOUR NIGHTS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Showcard Gothic", 25F);
            label2.Location = new Point(608, 114);
            label2.Name = "label2";
            label2.Size = new Size(116, 43);
            label2.TabIndex = 7;
            label2.Text = "WITH";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Showcard Gothic", 39.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(544, 157);
            label3.Name = "label3";
            label3.Size = new Size(271, 66);
            label3.TabIndex = 8;
            label3.Text = "HYRAXES";
            // 
            // button8
            // 
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Popup;
            button8.Location = new Point(414, 446);
            button8.Name = "button8";
            button8.Size = new Size(115, 110);
            button8.TabIndex = 4;
            button8.UseVisualStyleBackColor = true;
            button8.Visible = false;
            // 
            // button9
            // 
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatStyle = FlatStyle.Popup;
            button9.Location = new Point(584, 446);
            button9.Name = "button9";
            button9.Size = new Size(115, 110);
            button9.TabIndex = 4;
            button9.UseVisualStyleBackColor = true;
            button9.Visible = false;
            // 
            // button10
            // 
            button10.FlatAppearance.BorderSize = 0;
            button10.FlatStyle = FlatStyle.Popup;
            button10.Location = new Point(747, 446);
            button10.Name = "button10";
            button10.Size = new Size(115, 110);
            button10.TabIndex = 4;
            button10.UseVisualStyleBackColor = true;
            button10.Visible = false;
            button10.Click += button10_Click;
            // 
            // FNAPP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(2);
            Name = "FNAPP";
            Text = "FNAPP";
            Load += FNAPP_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button8;
        private Button button9;
        private Button button10;
    }
}