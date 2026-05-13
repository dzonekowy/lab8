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
            this.SuspendLayout();
            // 
            // lblTable (Karta na stole) <3
            // 
            this.lblTable.BackColor = System.Drawing.Color.White;
            this.lblTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTable.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold);
            this.lblTable.Location = new System.Drawing.Point(340, 40);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(120, 160);
            this.lblTable.TabIndex = 0;
            this.lblTable.Text = "??";
            this.lblTable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowHand (karty) <3
            // 
            this.flowHand.AutoScroll = true;
            this.flowHand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.flowHand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowHand.Location = new System.Drawing.Point(0, 311);
            this.flowHand.Name = "flowHand";
            this.flowHand.Padding = new System.Windows.Forms.Padding(10);
            this.flowHand.Size = new System.Drawing.Size(800, 150);
            this.flowHand.TabIndex = 1;
            // 
            // btnDraw (Przycisk dobierania) <3
            // 
            this.btnDraw.BackColor = System.Drawing.Color.Gold;
            this.btnDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDraw.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDraw.Location = new System.Drawing.Point(340, 220);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(120, 45);
            this.btnDraw.TabIndex = 2;
            this.btnDraw.Text = "DOBIERZ";
            this.btnDraw.UseVisualStyleBackColor = false;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // makao <3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.flowHand);
            this.Controls.Add(this.lblTable);
            this.Name = "makao";
            this.Text = "Makao Game";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.FlowLayoutPanel flowHand;
        private System.Windows.Forms.Button btnDraw;
    }
}