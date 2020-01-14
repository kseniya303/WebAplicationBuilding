namespace WindowsFormsBuilding
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.materialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ucGreetings1 = new WindowsFormsBuilding.UserControls.ucGreetings();
            this.ucUsers1 = new WindowsFormsBuilding.UserControls.ucUsers();
            this.ucFL1 = new WindowsFormsBuilding.UserControls.ucFL();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.materialToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.fLToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(793, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem1});
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "File";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // materialToolStripMenuItem
            // 
            this.materialToolStripMenuItem.Name = "materialToolStripMenuItem";
            this.materialToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.materialToolStripMenuItem.Text = "Material";
            this.materialToolStripMenuItem.Click += new System.EventHandler(this.materialToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // fLToolStripMenuItem
            // 
            this.fLToolStripMenuItem.Name = "fLToolStripMenuItem";
            this.fLToolStripMenuItem.Size = new System.Drawing.Size(31, 20);
            this.fLToolStripMenuItem.Text = "FL";
            this.fLToolStripMenuItem.Click += new System.EventHandler(this.fLToolStripMenuItem_Click);
            // 
            // ucGreetings1
            // 
            this.ucGreetings1.CausesValidation = false;
            this.ucGreetings1.Location = new System.Drawing.Point(690, 88);
            this.ucGreetings1.Name = "ucGreetings1";
            this.ucGreetings1.Size = new System.Drawing.Size(52, 32);
            this.ucGreetings1.TabIndex = 4;
            this.ucGreetings1.Visible = false;
            // 
            // ucUsers1
            // 
            this.ucUsers1.Location = new System.Drawing.Point(22, 38);
            this.ucUsers1.Name = "ucUsers1";
            this.ucUsers1.Size = new System.Drawing.Size(748, 426);
            this.ucUsers1.TabIndex = 3;
            this.ucUsers1.Visible = false;
            // 
            // ucFL1
            // 
            this.ucFL1.Location = new System.Drawing.Point(50, 56);
            this.ucFL1.Name = "ucFL1";
            this.ucFL1.Size = new System.Drawing.Size(566, 348);
            this.ucFL1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 527);
            this.Controls.Add(this.ucFL1);
            this.Controls.Add(this.ucGreetings1);
            this.Controls.Add(this.ucUsers1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem materialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private UserControls.ucUsers ucUsers1;
        private UserControls.ucGreetings ucGreetings1; 
        private System.Windows.Forms.ToolStripMenuItem fLToolStripMenuItem;
        private UserControls.ucFL ucFL1;
    }
}

