namespace GameOfLife
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testCasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.steadyStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalOscillationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rPertominoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userDefinedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textCounts = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.testCasesToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1022, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(115, 26);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(115, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // testCasesToolStripMenuItem
            // 
            this.testCasesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.steadyStateToolStripMenuItem,
            this.verticalOscillationToolStripMenuItem,
            this.rPertominoToolStripMenuItem,
            this.userDefinedToolStripMenuItem});
            this.testCasesToolStripMenuItem.Name = "testCasesToolStripMenuItem";
            this.testCasesToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.testCasesToolStripMenuItem.Text = "Test Cases";
            // 
            // steadyStateToolStripMenuItem
            // 
            this.steadyStateToolStripMenuItem.Name = "steadyStateToolStripMenuItem";
            this.steadyStateToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.steadyStateToolStripMenuItem.Text = "Steady State";
            this.steadyStateToolStripMenuItem.Click += new System.EventHandler(this.steadyStateToolStripMenuItem_Click);
            // 
            // verticalOscillationToolStripMenuItem
            // 
            this.verticalOscillationToolStripMenuItem.Name = "verticalOscillationToolStripMenuItem";
            this.verticalOscillationToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.verticalOscillationToolStripMenuItem.Text = "Vertical Oscillation";
            this.verticalOscillationToolStripMenuItem.Click += new System.EventHandler(this.verticalOscillationToolStripMenuItem_Click);
            // 
            // rPertominoToolStripMenuItem
            // 
            this.rPertominoToolStripMenuItem.Name = "rPertominoToolStripMenuItem";
            this.rPertominoToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.rPertominoToolStripMenuItem.Text = "R-Pentomino";
            this.rPertominoToolStripMenuItem.Click += new System.EventHandler(this.rPertominoToolStripMenuItem_Click);
            // 
            // userDefinedToolStripMenuItem
            // 
            this.userDefinedToolStripMenuItem.Name = "userDefinedToolStripMenuItem";
            this.userDefinedToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.userDefinedToolStripMenuItem.Text = "User Defined";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GameOfLife.Properties.Resources.life_empty;
            this.pictureBox1.Location = new System.Drawing.Point(12, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(135, 69);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // textCounts
            // 
            this.textCounts.Location = new System.Drawing.Point(12, 159);
            this.textCounts.Multiline = true;
            this.textCounts.Name = "textCounts";
            this.textCounts.Size = new System.Drawing.Size(349, 203);
            this.textCounts.TabIndex = 2;
            this.textCounts.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 618);
            this.Controls.Add(this.textCounts);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Life - Stan Turovsky";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testCasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem steadyStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalOscillationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rPertominoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userDefinedToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox textCounts;
    }
}

