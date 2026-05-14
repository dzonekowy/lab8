namespace WinFormsApp1
{
    partial class makao
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTable = new System.Windows.Forms.Label();
            this.flowHand = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnMakao = new System.Windows.Forms.Button();
            this.lblStats = new System.Windows.Forms.Label();
            this.flowComputerHand = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();

            this.lblTable.BackColor = System.Drawing.Color.White;
            this.lblTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTable.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold);
            this.lblTable.Location = new System.Drawing.Point(340, 140);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(120, 160);
            this.lblTable.TabIndex = 0;
            this.lblTable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.flowHand.AutoScroll = true;
            this.flowHand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.flowHand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowHand.Location = new System.Drawing.Point(0, 311);
            this.flowHand.Name = "flowHand";
            this.flowHand.Padding = new System.Windows.Forms.Padding(10);
            this.flowHand.Size = new System.Drawing.Size(800, 150);
            this.flowHand.TabIndex = 1;

            this.btnDraw.BackColor = System.Drawing.Color.Gold;
            this.btnDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDraw.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDraw.Location = new System.Drawing.Point(12, 180);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(120, 45);
            this.btnDraw.TabIndex = 2;
            this.btnDraw.Text = "DOBIERZ";
            this.btnDraw.UseVisualStyleBackColor = false;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);

            this.btnMakao.BackColor = System.Drawing.Color.OrangeRed;
            this.btnMakao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnMakao.Location = new System.Drawing.Point(12, 231);
            this.btnMakao.Name = "btnMakao";
            this.btnMakao.Size = new System.Drawing.Size(120, 45);
            this.btnMakao.TabIndex = 3;
            this.btnMakao.Text = "MAKAO!";
            this.btnMakao.UseVisualStyleBackColor = false;
            this.btnMakao.Click += new System.EventHandler(this.btnMakao_Click);

            this.lblStats.AutoSize = true;
            this.lblStats.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStats.ForeColor = System.Drawing.Color.White;
            this.lblStats.Location = new System.Drawing.Point(12, 110);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(150, 21);
            this.lblStats.TabIndex = 4;

            this.flowComputerHand.AutoScroll = true;
            this.flowComputerHand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.flowComputerHand.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowComputerHand.Location = new System.Drawing.Point(0, 0);
            this.flowComputerHand.Name = "flowComputerHand";
            this.flowComputerHand.Padding = new System.Windows.Forms.Padding(10);
            this.flowComputerHand.Size = new System.Drawing.Size(800, 110);
            this.flowComputerHand.TabIndex = 5;

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.flowComputerHand);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.btnMakao);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.flowHand);
            this.Controls.Add(this.lblTable);
            this.Name = "makao";
            this.Text = "Makao Game";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.FlowLayoutPanel flowHand;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnMakao;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.FlowLayoutPanel flowComputerHand;
    }
}