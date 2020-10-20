namespace RG_Projekat_Milica_Vukovic
{
    partial class Form1
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl9 = new System.Windows.Forms.Label();
            this.lbl8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNivo = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 393);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(452, 25);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLbl
            // 
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(355, 20);
            this.statusLbl.Text = "Milica_Vukovic_1809_projekat_13_računarska_grafika";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl9);
            this.panel1.Controls.Add(this.lbl8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblNivo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 393);
            this.panel1.TabIndex = 2;
            // 
            // lbl9
            // 
            this.lbl9.AutoSize = true;
            this.lbl9.BackColor = System.Drawing.Color.Transparent;
            this.lbl9.Font = new System.Drawing.Font("Monotype Corsiva", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl9.Location = new System.Drawing.Point(132, 289);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(149, 97);
            this.lbl9.TabIndex = 7;
            this.lbl9.Text = "9x9";
            this.lbl9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl9.Click += new System.EventHandler(this.lbl9_Click);
            this.lbl9.MouseEnter += new System.EventHandler(this.lbl9_MouseEnter);
            this.lbl9.MouseLeave += new System.EventHandler(this.lbl9_MouseLeave);
            // 
            // lbl8
            // 
            this.lbl8.AutoSize = true;
            this.lbl8.BackColor = System.Drawing.Color.Transparent;
            this.lbl8.Font = new System.Drawing.Font("Monotype Corsiva", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl8.Location = new System.Drawing.Point(132, 182);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(149, 97);
            this.lbl8.TabIndex = 6;
            this.lbl8.Text = "8x8";
            this.lbl8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl8.Click += new System.EventHandler(this.lbl8_Click);
            this.lbl8.MouseEnter += new System.EventHandler(this.lbl8_MouseEnter);
            this.lbl8.MouseLeave += new System.EventHandler(this.lbl8_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(132, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 97);
            this.label1.TabIndex = 5;
            this.label1.Text = "7x7";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // lblNivo
            // 
            this.lblNivo.AutoSize = true;
            this.lblNivo.BackColor = System.Drawing.Color.Transparent;
            this.lblNivo.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNivo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblNivo.Location = new System.Drawing.Point(61, 18);
            this.lblNivo.Name = "lblNivo";
            this.lblNivo.Size = new System.Drawing.Size(315, 72);
            this.lblNivo.TabIndex = 4;
            this.lblNivo.Text = "Izaberi nivo:";
            this.lblNivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(452, 418);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Spajanje tačaka";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl9;
        private System.Windows.Forms.Label lbl8;
    }
}

