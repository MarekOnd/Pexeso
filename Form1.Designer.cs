namespace Pexeso
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
            this.start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pocetHracu = new System.Windows.Forms.ComboBox();
            this.konec = new System.Windows.Forms.Label();
            this.vyberPoctuHracu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.start.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.start.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.start.Location = new System.Drawing.Point(519, 507);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(279, 120);
            this.start.TabIndex = 0;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 150F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(302, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(721, 265);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pexeso";
            // 
            // pocetHracu
            // 
            this.pocetHracu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pocetHracu.FormattingEnabled = true;
            this.pocetHracu.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.pocetHracu.Location = new System.Drawing.Point(593, 401);
            this.pocetHracu.Name = "pocetHracu";
            this.pocetHracu.Size = new System.Drawing.Size(121, 23);
            this.pocetHracu.TabIndex = 5;
            // 
            // konec
            // 
            this.konec.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.konec.AutoSize = true;
            this.konec.Font = new System.Drawing.Font("Segoe UI", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.konec.Location = new System.Drawing.Point(370, 141);
            this.konec.Name = "konec";
            this.konec.Size = new System.Drawing.Size(591, 159);
            this.konec.TabIndex = 6;
            this.konec.Text = "Konec hry";
            this.konec.Visible = false;
            // 
            // vyberPoctuHracu
            // 
            this.vyberPoctuHracu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.vyberPoctuHracu.AutoSize = true;
            this.vyberPoctuHracu.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.vyberPoctuHracu.Location = new System.Drawing.Point(593, 370);
            this.vyberPoctuHracu.Name = "vyberPoctuHracu";
            this.vyberPoctuHracu.Size = new System.Drawing.Size(113, 28);
            this.vyberPoctuHracu.TabIndex = 7;
            this.vyberPoctuHracu.Text = "Počet hráčů";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(1339, 752);
            this.Controls.Add(this.vyberPoctuHracu);
            this.Controls.Add(this.konec);
            this.Controls.Add(this.pocetHracu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox pocetHracu;
        private System.Windows.Forms.Label konec;
        private System.Windows.Forms.Label vyberPoctuHracu;
    }
}

