namespace nudata.Forms
{
    partial class MarkList
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
            this.StudentListPanel = new System.Windows.Forms.Panel();
            this.RefreshStudentListPanel = new System.Windows.Forms.Panel();
            this.StudentGrid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.RightTopPanel = new System.Windows.Forms.Panel();
            this.RightTopLeftPlanPanel = new System.Windows.Forms.Panel();
            this.RightTopRightSemesterPanel = new System.Windows.Forms.Panel();
            this.PlansGrid = new System.Windows.Forms.DataGridView();
            this.SemestersGrid = new System.Windows.Forms.DataGridView();
            this.RightMiddleSemesterDisciplinesMarksPanel = new System.Windows.Forms.Panel();
            this.SemesterDisciplinesMarksGrid = new System.Windows.Forms.DataGridView();
            this.LeftPanel.SuspendLayout();
            this.StudentListPanel.SuspendLayout();
            this.RefreshStudentListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentGrid)).BeginInit();
            this.RightPanel.SuspendLayout();
            this.RightTopPanel.SuspendLayout();
            this.RightTopLeftPlanPanel.SuspendLayout();
            this.RightTopRightSemesterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlansGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SemestersGrid)).BeginInit();
            this.RightMiddleSemesterDisciplinesMarksPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SemesterDisciplinesMarksGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.RefreshStudentListPanel);
            this.LeftPanel.Controls.Add(this.StudentListPanel);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(288, 735);
            this.LeftPanel.TabIndex = 0;
            // 
            // StudentListPanel
            // 
            this.StudentListPanel.Controls.Add(this.StudentGrid);
            this.StudentListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentListPanel.Location = new System.Drawing.Point(0, 0);
            this.StudentListPanel.Name = "StudentListPanel";
            this.StudentListPanel.Size = new System.Drawing.Size(288, 735);
            this.StudentListPanel.TabIndex = 0;
            // 
            // RefreshStudentListPanel
            // 
            this.RefreshStudentListPanel.Controls.Add(this.button1);
            this.RefreshStudentListPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RefreshStudentListPanel.Location = new System.Drawing.Point(0, 675);
            this.RefreshStudentListPanel.Name = "RefreshStudentListPanel";
            this.RefreshStudentListPanel.Size = new System.Drawing.Size(288, 60);
            this.RefreshStudentListPanel.TabIndex = 1;
            // 
            // StudentGrid
            // 
            this.StudentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentGrid.Location = new System.Drawing.Point(0, 0);
            this.StudentGrid.Name = "StudentGrid";
            this.StudentGrid.ReadOnly = true;
            this.StudentGrid.RowHeadersVisible = false;
            this.StudentGrid.Size = new System.Drawing.Size(288, 735);
            this.StudentGrid.TabIndex = 0;
            this.StudentGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StudentGrid_CellClick);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(288, 60);
            this.button1.TabIndex = 0;
            this.button1.Text = "Обновить список студентов";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // RightPanel
            // 
            this.RightPanel.Controls.Add(this.RightMiddleSemesterDisciplinesMarksPanel);
            this.RightPanel.Controls.Add(this.RightTopPanel);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightPanel.Location = new System.Drawing.Point(288, 0);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(790, 735);
            this.RightPanel.TabIndex = 1;
            // 
            // RightTopPanel
            // 
            this.RightTopPanel.Controls.Add(this.RightTopRightSemesterPanel);
            this.RightTopPanel.Controls.Add(this.RightTopLeftPlanPanel);
            this.RightTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.RightTopPanel.Location = new System.Drawing.Point(0, 0);
            this.RightTopPanel.Name = "RightTopPanel";
            this.RightTopPanel.Size = new System.Drawing.Size(790, 199);
            this.RightTopPanel.TabIndex = 0;
            // 
            // RightTopLeftPlanPanel
            // 
            this.RightTopLeftPlanPanel.Controls.Add(this.PlansGrid);
            this.RightTopLeftPlanPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.RightTopLeftPlanPanel.Location = new System.Drawing.Point(0, 0);
            this.RightTopLeftPlanPanel.Name = "RightTopLeftPlanPanel";
            this.RightTopLeftPlanPanel.Size = new System.Drawing.Size(590, 199);
            this.RightTopLeftPlanPanel.TabIndex = 0;
            // 
            // RightTopRightSemesterPanel
            // 
            this.RightTopRightSemesterPanel.Controls.Add(this.SemestersGrid);
            this.RightTopRightSemesterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightTopRightSemesterPanel.Location = new System.Drawing.Point(590, 0);
            this.RightTopRightSemesterPanel.Name = "RightTopRightSemesterPanel";
            this.RightTopRightSemesterPanel.Size = new System.Drawing.Size(200, 199);
            this.RightTopRightSemesterPanel.TabIndex = 1;
            // 
            // PlansGrid
            // 
            this.PlansGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PlansGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlansGrid.Location = new System.Drawing.Point(0, 0);
            this.PlansGrid.Name = "PlansGrid";
            this.PlansGrid.ReadOnly = true;
            this.PlansGrid.RowHeadersVisible = false;
            this.PlansGrid.Size = new System.Drawing.Size(590, 199);
            this.PlansGrid.TabIndex = 0;
            this.PlansGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PlansGrid_CellClick);
            // 
            // SemestersGrid
            // 
            this.SemestersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SemestersGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SemestersGrid.Location = new System.Drawing.Point(0, 0);
            this.SemestersGrid.Name = "SemestersGrid";
            this.SemestersGrid.ReadOnly = true;
            this.SemestersGrid.RowHeadersVisible = false;
            this.SemestersGrid.Size = new System.Drawing.Size(200, 199);
            this.SemestersGrid.TabIndex = 0;
            // 
            // RightMiddleSemesterDisciplinesMarksPanel
            // 
            this.RightMiddleSemesterDisciplinesMarksPanel.Controls.Add(this.SemesterDisciplinesMarksGrid);
            this.RightMiddleSemesterDisciplinesMarksPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.RightMiddleSemesterDisciplinesMarksPanel.Location = new System.Drawing.Point(0, 199);
            this.RightMiddleSemesterDisciplinesMarksPanel.Name = "RightMiddleSemesterDisciplinesMarksPanel";
            this.RightMiddleSemesterDisciplinesMarksPanel.Size = new System.Drawing.Size(790, 248);
            this.RightMiddleSemesterDisciplinesMarksPanel.TabIndex = 1;
            // 
            // SemesterDisciplinesMarksGrid
            // 
            this.SemesterDisciplinesMarksGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SemesterDisciplinesMarksGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SemesterDisciplinesMarksGrid.Location = new System.Drawing.Point(0, 0);
            this.SemesterDisciplinesMarksGrid.Name = "SemesterDisciplinesMarksGrid";
            this.SemesterDisciplinesMarksGrid.ReadOnly = true;
            this.SemesterDisciplinesMarksGrid.RowHeadersVisible = false;
            this.SemesterDisciplinesMarksGrid.Size = new System.Drawing.Size(790, 248);
            this.SemesterDisciplinesMarksGrid.TabIndex = 0;
            // 
            // MarkList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 735);
            this.Controls.Add(this.RightPanel);
            this.Controls.Add(this.LeftPanel);
            this.Name = "MarkList";
            this.Text = "Оценки студентов";
            this.Load += new System.EventHandler(this.MarkList_Load);
            this.Resize += new System.EventHandler(this.MarkList_Resize);
            this.LeftPanel.ResumeLayout(false);
            this.StudentListPanel.ResumeLayout(false);
            this.RefreshStudentListPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StudentGrid)).EndInit();
            this.RightPanel.ResumeLayout(false);
            this.RightTopPanel.ResumeLayout(false);
            this.RightTopLeftPlanPanel.ResumeLayout(false);
            this.RightTopRightSemesterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PlansGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SemestersGrid)).EndInit();
            this.RightMiddleSemesterDisciplinesMarksPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SemesterDisciplinesMarksGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Panel RefreshStudentListPanel;
        private System.Windows.Forms.Panel StudentListPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView StudentGrid;
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.Panel RightTopPanel;
        private System.Windows.Forms.Panel RightTopRightSemesterPanel;
        private System.Windows.Forms.DataGridView SemestersGrid;
        private System.Windows.Forms.Panel RightTopLeftPlanPanel;
        private System.Windows.Forms.DataGridView PlansGrid;
        private System.Windows.Forms.Panel RightMiddleSemesterDisciplinesMarksPanel;
        private System.Windows.Forms.DataGridView SemesterDisciplinesMarksGrid;
    }
}