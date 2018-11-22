namespace nudata.Forms
{
    partial class PlanVsCardList
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
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.studentList = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reloadStudentList = new System.Windows.Forms.Button();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.RightBottomPanel = new System.Windows.Forms.Panel();
            this.RightRightPanel = new System.Windows.Forms.Panel();
            this.CardsGridView = new System.Windows.Forms.DataGridView();
            this.RightLeftPanel = new System.Windows.Forms.Panel();
            this.PlanGridView = new System.Windows.Forms.DataGridView();
            this.SemesterPanel = new System.Windows.Forms.Panel();
            this.PlansGridView = new System.Windows.Forms.DataGridView();
            this.LeftPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentList)).BeginInit();
            this.panel1.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.RightBottomPanel.SuspendLayout();
            this.RightRightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CardsGridView)).BeginInit();
            this.RightLeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlanGridView)).BeginInit();
            this.SemesterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlansGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.panel2);
            this.LeftPanel.Controls.Add(this.panel1);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(234, 782);
            this.LeftPanel.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.studentList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 729);
            this.panel2.TabIndex = 1;
            // 
            // studentList
            // 
            this.studentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentList.Location = new System.Drawing.Point(0, 0);
            this.studentList.Name = "studentList";
            this.studentList.ReadOnly = true;
            this.studentList.RowHeadersVisible = false;
            this.studentList.Size = new System.Drawing.Size(234, 729);
            this.studentList.TabIndex = 0;
            this.studentList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.studentList_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reloadStudentList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 729);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 53);
            this.panel1.TabIndex = 0;
            // 
            // reloadStudentList
            // 
            this.reloadStudentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reloadStudentList.Location = new System.Drawing.Point(0, 0);
            this.reloadStudentList.Name = "reloadStudentList";
            this.reloadStudentList.Size = new System.Drawing.Size(234, 53);
            this.reloadStudentList.TabIndex = 0;
            this.reloadStudentList.Text = "Перезагрузить список студентов";
            this.reloadStudentList.UseVisualStyleBackColor = true;
            this.reloadStudentList.Click += new System.EventHandler(this.reloadStudentList_Click);
            // 
            // RightPanel
            // 
            this.RightPanel.Controls.Add(this.RightBottomPanel);
            this.RightPanel.Controls.Add(this.SemesterPanel);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightPanel.Location = new System.Drawing.Point(234, 0);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(913, 782);
            this.RightPanel.TabIndex = 1;
            // 
            // RightBottomPanel
            // 
            this.RightBottomPanel.Controls.Add(this.RightRightPanel);
            this.RightBottomPanel.Controls.Add(this.RightLeftPanel);
            this.RightBottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightBottomPanel.Location = new System.Drawing.Point(0, 100);
            this.RightBottomPanel.Name = "RightBottomPanel";
            this.RightBottomPanel.Size = new System.Drawing.Size(913, 682);
            this.RightBottomPanel.TabIndex = 1;
            // 
            // RightRightPanel
            // 
            this.RightRightPanel.Controls.Add(this.CardsGridView);
            this.RightRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightRightPanel.Location = new System.Drawing.Point(445, 0);
            this.RightRightPanel.Name = "RightRightPanel";
            this.RightRightPanel.Size = new System.Drawing.Size(468, 682);
            this.RightRightPanel.TabIndex = 1;
            // 
            // CardsGridView
            // 
            this.CardsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CardsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CardsGridView.Location = new System.Drawing.Point(0, 0);
            this.CardsGridView.Name = "CardsGridView";
            this.CardsGridView.ReadOnly = true;
            this.CardsGridView.RowHeadersVisible = false;
            this.CardsGridView.Size = new System.Drawing.Size(468, 682);
            this.CardsGridView.TabIndex = 0;
            this.CardsGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.CardsGridView_CellFormatting);
            // 
            // RightLeftPanel
            // 
            this.RightLeftPanel.Controls.Add(this.PlanGridView);
            this.RightLeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.RightLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.RightLeftPanel.Name = "RightLeftPanel";
            this.RightLeftPanel.Size = new System.Drawing.Size(445, 682);
            this.RightLeftPanel.TabIndex = 0;
            // 
            // PlanGridView
            // 
            this.PlanGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PlanGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlanGridView.Location = new System.Drawing.Point(0, 0);
            this.PlanGridView.Name = "PlanGridView";
            this.PlanGridView.ReadOnly = true;
            this.PlanGridView.RowHeadersVisible = false;
            this.PlanGridView.Size = new System.Drawing.Size(445, 682);
            this.PlanGridView.TabIndex = 0;
            // 
            // SemesterPanel
            // 
            this.SemesterPanel.Controls.Add(this.PlansGridView);
            this.SemesterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SemesterPanel.Location = new System.Drawing.Point(0, 0);
            this.SemesterPanel.Name = "SemesterPanel";
            this.SemesterPanel.Size = new System.Drawing.Size(913, 100);
            this.SemesterPanel.TabIndex = 0;
            // 
            // PlansGridView
            // 
            this.PlansGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PlansGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlansGridView.Location = new System.Drawing.Point(0, 0);
            this.PlansGridView.Name = "PlansGridView";
            this.PlansGridView.ReadOnly = true;
            this.PlansGridView.RowHeadersVisible = false;
            this.PlansGridView.Size = new System.Drawing.Size(913, 100);
            this.PlansGridView.TabIndex = 0;
            this.PlansGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PlansGridView_CellClick);
            // 
            // PlanVsCardList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 782);
            this.Controls.Add(this.RightPanel);
            this.Controls.Add(this.LeftPanel);
            this.Name = "PlanVsCardList";
            this.Text = "План и нагрузка студента";
            this.Load += new System.EventHandler(this.PlanVsCardList_Load);
            this.Resize += new System.EventHandler(this.PlanVsCardList_Resize);
            this.LeftPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.studentList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.RightPanel.ResumeLayout(false);
            this.RightBottomPanel.ResumeLayout(false);
            this.RightRightPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CardsGridView)).EndInit();
            this.RightLeftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PlanGridView)).EndInit();
            this.SemesterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PlansGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView studentList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button reloadStudentList;
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.Panel RightBottomPanel;
        private System.Windows.Forms.Panel RightRightPanel;
        private System.Windows.Forms.DataGridView CardsGridView;
        private System.Windows.Forms.Panel RightLeftPanel;
        private System.Windows.Forms.DataGridView PlanGridView;
        private System.Windows.Forms.Panel SemesterPanel;
        private System.Windows.Forms.DataGridView PlansGridView;
    }
}