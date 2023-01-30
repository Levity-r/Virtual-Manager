
namespace VirualManagerUI
{
    partial class MainComputerMenu
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
            this.сотрудникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видеомониторингToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.уведомленияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыУчетныхЗаписейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сотрудникиToolStripMenuItem,
            this.видеомониторингToolStripMenuItem,
            this.уведомленияToolStripMenuItem,
            this.параметрыУчетныхЗаписейToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1472, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // сотрудникиToolStripMenuItem
            // 
            this.сотрудникиToolStripMenuItem.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.сотрудникиToolStripMenuItem.Name = "сотрудникиToolStripMenuItem";
            this.сотрудникиToolStripMenuItem.Size = new System.Drawing.Size(167, 23);
            this.сотрудникиToolStripMenuItem.Text = "Компьютеры в сети";
            this.сотрудникиToolStripMenuItem.Click += new System.EventHandler(this.сотрудникиToolStripMenuItem_Click);
            // 
            // видеомониторингToolStripMenuItem
            // 
            this.видеомониторингToolStripMenuItem.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.видеомониторингToolStripMenuItem.Name = "видеомониторингToolStripMenuItem";
            this.видеомониторингToolStripMenuItem.Size = new System.Drawing.Size(152, 23);
            this.видеомониторингToolStripMenuItem.Text = "Видеомониторинг ";
            // 
            // уведомленияToolStripMenuItem
            // 
            this.уведомленияToolStripMenuItem.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.уведомленияToolStripMenuItem.Name = "уведомленияToolStripMenuItem";
            this.уведомленияToolStripMenuItem.Size = new System.Drawing.Size(112, 23);
            this.уведомленияToolStripMenuItem.Text = "Уведомления";
            // 
            // параметрыУчетныхЗаписейToolStripMenuItem
            // 
            this.параметрыУчетныхЗаписейToolStripMenuItem.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.параметрыУчетныхЗаписейToolStripMenuItem.Name = "параметрыУчетныхЗаписейToolStripMenuItem";
            this.параметрыУчетныхЗаписейToolStripMenuItem.Size = new System.Drawing.Size(227, 23);
            this.параметрыУчетныхЗаписейToolStripMenuItem.Text = "Параметры учетных записей";
            // 
            // MainComputerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1472, 641);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainComputerMenu";
            this.Text = "MainComputerMenu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сотрудникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видеомониторингToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem уведомленияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem параметрыУчетныхЗаписейToolStripMenuItem;
    }
}