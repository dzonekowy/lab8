namespace WinFormsApp1
{
    partial class Form2
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
            gridview_wyniki = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridview_wyniki).BeginInit();
            SuspendLayout();
            // 
            // gridview_wyniki
            // 
            gridview_wyniki.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridview_wyniki.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridview_wyniki.Location = new Point(85, 53);
            gridview_wyniki.Name = "gridview_wyniki";
            gridview_wyniki.ReadOnly = true;
            gridview_wyniki.RowHeadersVisible = false;
            gridview_wyniki.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridview_wyniki.Size = new Size(643, 332);
            gridview_wyniki.TabIndex = 0;
            gridview_wyniki.CellContentClick += gridview_wyniki_CellContentClick;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(842, 450);
            Controls.Add(gridview_wyniki);
            Name = "Form2";
            Text = "Tabela Wyników";
            ((System.ComponentModel.ISupportInitialize)gridview_wyniki).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridview_wyniki;
    }
}