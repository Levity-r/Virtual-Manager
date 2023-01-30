
namespace VirtualManagerWF
{
    partial class AdminLoginForm
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиСетиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиДоступаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.демонстрацияЭкранаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мониторингПользователейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.usersToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(821, 24);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip2_ItemClicked);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиСетиToolStripMenuItem,
            this.настройкиДоступаToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.settingsToolStripMenuItem.Text = "Настройки";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // настройкиСетиToolStripMenuItem
            // 
            this.настройкиСетиToolStripMenuItem.Name = "настройкиСетиToolStripMenuItem";
            this.настройкиСетиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.настройкиСетиToolStripMenuItem.Text = "Настройки сети";
            // 
            // настройкиДоступаToolStripMenuItem
            // 
            this.настройкиДоступаToolStripMenuItem.Name = "настройкиДоступаToolStripMenuItem";
            this.настройкиДоступаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.настройкиДоступаToolStripMenuItem.Text = "Настройки доступа";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.демонстрацияЭкранаToolStripMenuItem,
            this.мониторингПользователейToolStripMenuItem});
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.usersToolStripMenuItem.Text = "Пользователи";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // демонстрацияЭкранаToolStripMenuItem
            // 
            this.демонстрацияЭкранаToolStripMenuItem.Name = "демонстрацияЭкранаToolStripMenuItem";
            this.демонстрацияЭкранаToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.демонстрацияЭкранаToolStripMenuItem.Text = "Статистика онлайна пользователей";
            this.демонстрацияЭкранаToolStripMenuItem.Click += new System.EventHandler(this.демонстрацияЭкранаToolStripMenuItem_Click);
            // 
            // мониторингПользователейToolStripMenuItem
            // 
            this.мониторингПользователейToolStripMenuItem.Name = "мониторингПользователейToolStripMenuItem";
            this.мониторингПользователейToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.мониторингПользователейToolStripMenuItem.Text = "Мониторинг пользователей";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // AdminLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 394);
            this.Controls.Add(this.menuStrip2);
            this.Name = "AdminLoginForm";
            this.Text = "AdminLogin";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиСетиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиДоступаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem демонстрацияЭкранаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem мониторингПользователейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
    }
}