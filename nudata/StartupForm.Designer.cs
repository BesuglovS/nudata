namespace nudata
{
    partial class StartupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartupForm));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.кафедрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.преподавателиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.телефоныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.контингентAltSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.группыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.факультетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.аутентификацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.trayIconMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayIconMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Учебный отдел";
            // 
            // trayIconMenu
            // 
            this.trayIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.телефоныToolStripMenuItem,
            this.toolStripMenuItem3,
            this.кафедрыToolStripMenuItem,
            this.преподавателиToolStripMenuItem,
            this.toolStripMenuItem4,
            this.контингентAltSToolStripMenuItem,
            this.группыToolStripMenuItem,
            this.факультетыToolStripMenuItem,
            this.toolStripMenuItem2,
            this.аутентификацияToolStripMenuItem,
            this.toolStripMenuItem1,
            this.выходToolStripMenuItem});
            this.trayIconMenu.Name = "trayIconMenu";
            this.trayIconMenu.Size = new System.Drawing.Size(241, 204);
            // 
            // кафедрыToolStripMenuItem
            // 
            this.кафедрыToolStripMenuItem.Image = global::nudata.Properties.Resources.dept;
            this.кафедрыToolStripMenuItem.Name = "кафедрыToolStripMenuItem";
            this.кафедрыToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.кафедрыToolStripMenuItem.Text = "Кафедры (Alt+D)";
            this.кафедрыToolStripMenuItem.Click += new System.EventHandler(this.кафедрыToolStripMenuItem_Click);
            // 
            // преподавателиToolStripMenuItem
            // 
            this.преподавателиToolStripMenuItem.Image = global::nudata.Properties.Resources.teacher;
            this.преподавателиToolStripMenuItem.Name = "преподавателиToolStripMenuItem";
            this.преподавателиToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.преподавателиToolStripMenuItem.Text = "Преподаватели (Ctrl+Alt+T)";
            this.преподавателиToolStripMenuItem.Click += new System.EventHandler(this.преподавателиToolStripMenuItem_Click);
            // 
            // телефоныToolStripMenuItem
            // 
            this.телефоныToolStripMenuItem.Image = global::nudata.Properties.Resources.phone;
            this.телефоныToolStripMenuItem.Name = "телефоныToolStripMenuItem";
            this.телефоныToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.телефоныToolStripMenuItem.Text = "Телефоны (Alt+P)";
            this.телефоныToolStripMenuItem.Click += new System.EventHandler(this.телефоныToolStripMenuItem_Click);
            // 
            // контингентAltSToolStripMenuItem
            // 
            this.контингентAltSToolStripMenuItem.Image = global::nudata.Properties.Resources.people;
            this.контингентAltSToolStripMenuItem.Name = "контингентAltSToolStripMenuItem";
            this.контингентAltSToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.контингентAltSToolStripMenuItem.Text = "Контингент (Alt+S)";
            this.контингентAltSToolStripMenuItem.Click += new System.EventHandler(this.контингентAltSToolStripMenuItem_Click);
            // 
            // группыToolStripMenuItem
            // 
            this.группыToolStripMenuItem.Image = global::nudata.Properties.Resources.people;
            this.группыToolStripMenuItem.Name = "группыToolStripMenuItem";
            this.группыToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.группыToolStripMenuItem.Text = "Группы студентов (Ctrl+Alt+S)";
            this.группыToolStripMenuItem.Click += new System.EventHandler(this.группыToolStripMenuItem_Click);
            // 
            // факультетыToolStripMenuItem
            // 
            this.факультетыToolStripMenuItem.Image = global::nudata.Properties.Resources.people;
            this.факультетыToolStripMenuItem.Name = "факультетыToolStripMenuItem";
            this.факультетыToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.факультетыToolStripMenuItem.Text = "Факультеты (Alt+F)";
            this.факультетыToolStripMenuItem.Click += new System.EventHandler(this.факультетыToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(237, 6);
            // 
            // аутентификацияToolStripMenuItem
            // 
            this.аутентификацияToolStripMenuItem.Image = global::nudata.Properties.Resources.Login;
            this.аутентификацияToolStripMenuItem.Name = "аутентификацияToolStripMenuItem";
            this.аутентификацияToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.аутентификацияToolStripMenuItem.Text = "Логин (Alt+A)";
            this.аутентификацияToolStripMenuItem.Click += new System.EventHandler(this.аутентификацияToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(237, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Image = global::nudata.Properties.Resources.exit;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(237, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(237, 6);
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "StartupForm";
            this.Text = "Form1";
            this.trayIconMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayIconMenu;
        private System.Windows.Forms.ToolStripMenuItem контингентAltSToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem группыToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem аутентификацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem факультетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem преподавателиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem телефоныToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кафедрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
    }
}

