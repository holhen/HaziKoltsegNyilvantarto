namespace HáziKöltségNyilvántartó.Forms
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opciókToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.költségvetésMegjelenítéseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.termékekFelviteleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisztikákToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opciókToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(770, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opciókToolStripMenuItem
            // 
            this.opciókToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.költségvetésMegjelenítéseToolStripMenuItem,
            this.termékekFelviteleToolStripMenuItem,
            this.statisztikákToolStripMenuItem});
            this.opciókToolStripMenuItem.Name = "opciókToolStripMenuItem";
            this.opciókToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.opciókToolStripMenuItem.Text = "Opciók";
            // 
            // költségvetésMegjelenítéseToolStripMenuItem
            // 
            this.költségvetésMegjelenítéseToolStripMenuItem.Name = "költségvetésMegjelenítéseToolStripMenuItem";
            this.költségvetésMegjelenítéseToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.költségvetésMegjelenítéseToolStripMenuItem.Text = "Költségvetés megjelenítése";
            this.költségvetésMegjelenítéseToolStripMenuItem.Click += new System.EventHandler(this.költségvetésMegjelenítéseToolStripMenuItem_Click);
            // 
            // termékekFelviteleToolStripMenuItem
            // 
            this.termékekFelviteleToolStripMenuItem.Name = "termékekFelviteleToolStripMenuItem";
            this.termékekFelviteleToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.termékekFelviteleToolStripMenuItem.Text = "Termékek felvitele";
            this.termékekFelviteleToolStripMenuItem.Click += new System.EventHandler(this.termékekFelviteleToolStripMenuItem_Click);
            // 
            // statisztikákToolStripMenuItem
            // 
            this.statisztikákToolStripMenuItem.Name = "statisztikákToolStripMenuItem";
            this.statisztikákToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.statisztikákToolStripMenuItem.Text = "Statisztikák";
            this.statisztikákToolStripMenuItem.Click += new System.EventHandler(this.statisztikákToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(770, 416);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opciókToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem költségvetésMegjelenítéseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem termékekFelviteleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisztikákToolStripMenuItem;
    }
}