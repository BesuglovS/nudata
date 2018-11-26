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
            this.RefreshStudentListPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.StudentListPanel = new System.Windows.Forms.Panel();
            this.StudentGrid = new System.Windows.Forms.DataGridView();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.RightMiddleSemesterDisciplinesMarksPanel = new System.Windows.Forms.Panel();
            this.SemesterDisciplinesMarksGrid = new System.Windows.Forms.DataGridView();
            this.RightTopPanel = new System.Windows.Forms.Panel();
            this.RightTopRightSemesterPanel = new System.Windows.Forms.Panel();
            this.SemestersGrid = new System.Windows.Forms.DataGridView();
            this.RightTopLeftPlanPanel = new System.Windows.Forms.Panel();
            this.PlansGrid = new System.Windows.Forms.DataGridView();
            this.RightBottomPanel = new System.Windows.Forms.Panel();
            this.RightBottomLeftPanel = new System.Windows.Forms.Panel();
            this.RightBottomRightPanel = new System.Windows.Forms.Panel();
            this.MarksGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.FinalMark = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SemesterRate = new System.Windows.Forms.TextBox();
            this.AttestationMark = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MarkDate = new System.Windows.Forms.DateTimePicker();
            this.Attempt = new System.Windows.Forms.NumericUpDown();
            this.addMark = new System.Windows.Forms.Button();
            this.updateMark = new System.Windows.Forms.Button();
            this.removeMark = new System.Windows.Forms.Button();
            this.CurrentMarkType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.AttestationType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.LeftPanel.SuspendLayout();
            this.RefreshStudentListPanel.SuspendLayout();
            this.StudentListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentGrid)).BeginInit();
            this.RightPanel.SuspendLayout();
            this.RightMiddleSemesterDisciplinesMarksPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SemesterDisciplinesMarksGrid)).BeginInit();
            this.RightTopPanel.SuspendLayout();
            this.RightTopRightSemesterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SemestersGrid)).BeginInit();
            this.RightTopLeftPlanPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlansGrid)).BeginInit();
            this.RightBottomPanel.SuspendLayout();
            this.RightBottomLeftPanel.SuspendLayout();
            this.RightBottomRightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MarksGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Attempt)).BeginInit();
            this.SuspendLayout();
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.RefreshStudentListPanel);
            this.LeftPanel.Controls.Add(this.StudentListPanel);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(288, 805);
            this.LeftPanel.TabIndex = 0;
            // 
            // RefreshStudentListPanel
            // 
            this.RefreshStudentListPanel.Controls.Add(this.button1);
            this.RefreshStudentListPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RefreshStudentListPanel.Location = new System.Drawing.Point(0, 745);
            this.RefreshStudentListPanel.Name = "RefreshStudentListPanel";
            this.RefreshStudentListPanel.Size = new System.Drawing.Size(288, 60);
            this.RefreshStudentListPanel.TabIndex = 1;
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
            // StudentListPanel
            // 
            this.StudentListPanel.Controls.Add(this.StudentGrid);
            this.StudentListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentListPanel.Location = new System.Drawing.Point(0, 0);
            this.StudentListPanel.Name = "StudentListPanel";
            this.StudentListPanel.Size = new System.Drawing.Size(288, 805);
            this.StudentListPanel.TabIndex = 0;
            // 
            // StudentGrid
            // 
            this.StudentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentGrid.Location = new System.Drawing.Point(0, 0);
            this.StudentGrid.Name = "StudentGrid";
            this.StudentGrid.ReadOnly = true;
            this.StudentGrid.RowHeadersVisible = false;
            this.StudentGrid.Size = new System.Drawing.Size(288, 805);
            this.StudentGrid.TabIndex = 0;
            this.StudentGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StudentGrid_CellClick);
            // 
            // RightPanel
            // 
            this.RightPanel.Controls.Add(this.RightBottomPanel);
            this.RightPanel.Controls.Add(this.RightMiddleSemesterDisciplinesMarksPanel);
            this.RightPanel.Controls.Add(this.RightTopPanel);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightPanel.Location = new System.Drawing.Point(288, 0);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(803, 805);
            this.RightPanel.TabIndex = 1;
            // 
            // RightMiddleSemesterDisciplinesMarksPanel
            // 
            this.RightMiddleSemesterDisciplinesMarksPanel.Controls.Add(this.SemesterDisciplinesMarksGrid);
            this.RightMiddleSemesterDisciplinesMarksPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.RightMiddleSemesterDisciplinesMarksPanel.Location = new System.Drawing.Point(0, 199);
            this.RightMiddleSemesterDisciplinesMarksPanel.Name = "RightMiddleSemesterDisciplinesMarksPanel";
            this.RightMiddleSemesterDisciplinesMarksPanel.Size = new System.Drawing.Size(803, 389);
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
            this.SemesterDisciplinesMarksGrid.Size = new System.Drawing.Size(803, 389);
            this.SemesterDisciplinesMarksGrid.TabIndex = 0;
            this.SemesterDisciplinesMarksGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SemesterDisciplinesMarksGrid_CellClick);
            // 
            // RightTopPanel
            // 
            this.RightTopPanel.Controls.Add(this.RightTopRightSemesterPanel);
            this.RightTopPanel.Controls.Add(this.RightTopLeftPlanPanel);
            this.RightTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.RightTopPanel.Location = new System.Drawing.Point(0, 0);
            this.RightTopPanel.Name = "RightTopPanel";
            this.RightTopPanel.Size = new System.Drawing.Size(803, 199);
            this.RightTopPanel.TabIndex = 0;
            // 
            // RightTopRightSemesterPanel
            // 
            this.RightTopRightSemesterPanel.Controls.Add(this.SemestersGrid);
            this.RightTopRightSemesterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightTopRightSemesterPanel.Location = new System.Drawing.Point(590, 0);
            this.RightTopRightSemesterPanel.Name = "RightTopRightSemesterPanel";
            this.RightTopRightSemesterPanel.Size = new System.Drawing.Size(213, 199);
            this.RightTopRightSemesterPanel.TabIndex = 1;
            // 
            // SemestersGrid
            // 
            this.SemestersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SemestersGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SemestersGrid.Location = new System.Drawing.Point(0, 0);
            this.SemestersGrid.Name = "SemestersGrid";
            this.SemestersGrid.ReadOnly = true;
            this.SemestersGrid.RowHeadersVisible = false;
            this.SemestersGrid.Size = new System.Drawing.Size(213, 199);
            this.SemestersGrid.TabIndex = 0;
            this.SemestersGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SemestersGrid_CellClick);
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
            // RightBottomPanel
            // 
            this.RightBottomPanel.Controls.Add(this.RightBottomRightPanel);
            this.RightBottomPanel.Controls.Add(this.RightBottomLeftPanel);
            this.RightBottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightBottomPanel.Location = new System.Drawing.Point(0, 588);
            this.RightBottomPanel.Name = "RightBottomPanel";
            this.RightBottomPanel.Size = new System.Drawing.Size(803, 217);
            this.RightBottomPanel.TabIndex = 2;
            // 
            // RightBottomLeftPanel
            // 
            this.RightBottomLeftPanel.Controls.Add(this.MarksGridView);
            this.RightBottomLeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.RightBottomLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.RightBottomLeftPanel.Name = "RightBottomLeftPanel";
            this.RightBottomLeftPanel.Size = new System.Drawing.Size(453, 217);
            this.RightBottomLeftPanel.TabIndex = 0;
            // 
            // RightBottomRightPanel
            // 
            this.RightBottomRightPanel.Controls.Add(this.AttestationType);
            this.RightBottomRightPanel.Controls.Add(this.label7);
            this.RightBottomRightPanel.Controls.Add(this.CurrentMarkType);
            this.RightBottomRightPanel.Controls.Add(this.label6);
            this.RightBottomRightPanel.Controls.Add(this.removeMark);
            this.RightBottomRightPanel.Controls.Add(this.updateMark);
            this.RightBottomRightPanel.Controls.Add(this.addMark);
            this.RightBottomRightPanel.Controls.Add(this.Attempt);
            this.RightBottomRightPanel.Controls.Add(this.MarkDate);
            this.RightBottomRightPanel.Controls.Add(this.label5);
            this.RightBottomRightPanel.Controls.Add(this.label4);
            this.RightBottomRightPanel.Controls.Add(this.AttestationMark);
            this.RightBottomRightPanel.Controls.Add(this.label3);
            this.RightBottomRightPanel.Controls.Add(this.SemesterRate);
            this.RightBottomRightPanel.Controls.Add(this.label2);
            this.RightBottomRightPanel.Controls.Add(this.FinalMark);
            this.RightBottomRightPanel.Controls.Add(this.label1);
            this.RightBottomRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightBottomRightPanel.Location = new System.Drawing.Point(453, 0);
            this.RightBottomRightPanel.Name = "RightBottomRightPanel";
            this.RightBottomRightPanel.Size = new System.Drawing.Size(350, 217);
            this.RightBottomRightPanel.TabIndex = 1;
            // 
            // MarksGridView
            // 
            this.MarksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MarksGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MarksGridView.Location = new System.Drawing.Point(0, 0);
            this.MarksGridView.Name = "MarksGridView";
            this.MarksGridView.ReadOnly = true;
            this.MarksGridView.RowHeadersVisible = false;
            this.MarksGridView.Size = new System.Drawing.Size(453, 217);
            this.MarksGridView.TabIndex = 0;
            this.MarksGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MarksGridView_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Итоговая оценка";
            // 
            // FinalMark
            // 
            this.FinalMark.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FinalMark.FormattingEnabled = true;
            this.FinalMark.Location = new System.Drawing.Point(116, 26);
            this.FinalMark.Name = "FinalMark";
            this.FinalMark.Size = new System.Drawing.Size(121, 21);
            this.FinalMark.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Семестровый компонент";
            // 
            // SemesterRate
            // 
            this.SemesterRate.Location = new System.Drawing.Point(15, 115);
            this.SemesterRate.Name = "SemesterRate";
            this.SemesterRate.Size = new System.Drawing.Size(121, 20);
            this.SemesterRate.TabIndex = 3;
            // 
            // AttestationMark
            // 
            this.AttestationMark.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AttestationMark.FormattingEnabled = true;
            this.AttestationMark.Location = new System.Drawing.Point(156, 114);
            this.AttestationMark.Name = "AttestationMark";
            this.AttestationMark.Size = new System.Drawing.Size(182, 21);
            this.AttestationMark.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Контрольный компонент";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Попытка";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Дата";
            // 
            // MarkDate
            // 
            this.MarkDate.Location = new System.Drawing.Point(156, 156);
            this.MarkDate.Name = "MarkDate";
            this.MarkDate.Size = new System.Drawing.Size(182, 20);
            this.MarkDate.TabIndex = 9;
            // 
            // Attempt
            // 
            this.Attempt.Location = new System.Drawing.Point(15, 155);
            this.Attempt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Attempt.Name = "Attempt";
            this.Attempt.Size = new System.Drawing.Size(121, 20);
            this.Attempt.TabIndex = 10;
            this.Attempt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // addMark
            // 
            this.addMark.Location = new System.Drawing.Point(15, 182);
            this.addMark.Name = "addMark";
            this.addMark.Size = new System.Drawing.Size(90, 23);
            this.addMark.TabIndex = 11;
            this.addMark.Text = "Добавить";
            this.addMark.UseVisualStyleBackColor = true;
            this.addMark.Click += new System.EventHandler(this.addMark_Click);
            // 
            // updateMark
            // 
            this.updateMark.Location = new System.Drawing.Point(137, 182);
            this.updateMark.Name = "updateMark";
            this.updateMark.Size = new System.Drawing.Size(90, 23);
            this.updateMark.TabIndex = 12;
            this.updateMark.Text = "Изменить";
            this.updateMark.UseVisualStyleBackColor = true;
            this.updateMark.Click += new System.EventHandler(this.updateMark_Click);
            // 
            // removeMark
            // 
            this.removeMark.Location = new System.Drawing.Point(248, 182);
            this.removeMark.Name = "removeMark";
            this.removeMark.Size = new System.Drawing.Size(90, 23);
            this.removeMark.TabIndex = 13;
            this.removeMark.Text = "Удалить";
            this.removeMark.UseVisualStyleBackColor = true;
            this.removeMark.Click += new System.EventHandler(this.removeMark_Click);
            // 
            // CurrentMarkType
            // 
            this.CurrentMarkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CurrentMarkType.FormattingEnabled = true;
            this.CurrentMarkType.Location = new System.Drawing.Point(156, 72);
            this.CurrentMarkType.Name = "CurrentMarkType";
            this.CurrentMarkType.Size = new System.Drawing.Size(182, 21);
            this.CurrentMarkType.TabIndex = 15;
            this.CurrentMarkType.SelectedValueChanged += new System.EventHandler(this.CurrentMarkType_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(153, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Тип оценки";
            // 
            // AttestationType
            // 
            this.AttestationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AttestationType.FormattingEnabled = true;
            this.AttestationType.Items.AddRange(new object[] {
            "Зачёт",
            "Зачёт с оценкой",
            "Контрольная работа",
            "Курсовая работа",
            "Курсовой проект",
            "Реферат",
            "Экзамен",
            "Эссе"});
            this.AttestationType.Location = new System.Drawing.Point(15, 72);
            this.AttestationType.Name = "AttestationType";
            this.AttestationType.Size = new System.Drawing.Size(121, 21);
            this.AttestationType.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Форма отчётности";
            // 
            // MarkList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 805);
            this.Controls.Add(this.RightPanel);
            this.Controls.Add(this.LeftPanel);
            this.Name = "MarkList";
            this.Text = "Оценки студентов";
            this.Load += new System.EventHandler(this.MarkList_Load);
            this.Resize += new System.EventHandler(this.MarkList_Resize);
            this.LeftPanel.ResumeLayout(false);
            this.RefreshStudentListPanel.ResumeLayout(false);
            this.StudentListPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StudentGrid)).EndInit();
            this.RightPanel.ResumeLayout(false);
            this.RightMiddleSemesterDisciplinesMarksPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SemesterDisciplinesMarksGrid)).EndInit();
            this.RightTopPanel.ResumeLayout(false);
            this.RightTopRightSemesterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SemestersGrid)).EndInit();
            this.RightTopLeftPlanPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PlansGrid)).EndInit();
            this.RightBottomPanel.ResumeLayout(false);
            this.RightBottomLeftPanel.ResumeLayout(false);
            this.RightBottomRightPanel.ResumeLayout(false);
            this.RightBottomRightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MarksGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Attempt)).EndInit();
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
        private System.Windows.Forms.Panel RightBottomPanel;
        private System.Windows.Forms.Panel RightBottomRightPanel;
        private System.Windows.Forms.Panel RightBottomLeftPanel;
        private System.Windows.Forms.DataGridView MarksGridView;
        private System.Windows.Forms.NumericUpDown Attempt;
        private System.Windows.Forms.DateTimePicker MarkDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox AttestationMark;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SemesterRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox FinalMark;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button removeMark;
        private System.Windows.Forms.Button updateMark;
        private System.Windows.Forms.Button addMark;
        private System.Windows.Forms.ComboBox CurrentMarkType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox AttestationType;
        private System.Windows.Forms.Label label7;
    }
}