namespace nudata.Forms
{
    partial class StudentLearningPlanList
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
            this.StudentListPanel = new System.Windows.Forms.Panel();
            this.StudentLearningPlanListView = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.planFromPicker = new System.Windows.Forms.DateTimePicker();
            this.remove = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.planToPicker = new System.Windows.Forms.DateTimePicker();
            this.learningPlanbox = new System.Windows.Forms.GroupBox();
            this.ControlsPanel = new System.Windows.Forms.Panel();
            this.StudentListView = new System.Windows.Forms.DataGridView();
            this.GroupListPanel = new System.Windows.Forms.Panel();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.LearningPlanList = new System.Windows.Forms.ComboBox();
            this.StudentListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentLearningPlanListView)).BeginInit();
            this.learningPlanbox.SuspendLayout();
            this.ControlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentListView)).BeginInit();
            this.GroupListPanel.SuspendLayout();
            this.LeftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // StudentListPanel
            // 
            this.StudentListPanel.Controls.Add(this.StudentLearningPlanListView);
            this.StudentListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentListPanel.Location = new System.Drawing.Point(281, 0);
            this.StudentListPanel.Name = "StudentListPanel";
            this.StudentListPanel.Size = new System.Drawing.Size(960, 709);
            this.StudentListPanel.TabIndex = 19;
            // 
            // StudentLearningPlanListView
            // 
            this.StudentLearningPlanListView.AllowUserToAddRows = false;
            this.StudentLearningPlanListView.AllowUserToDeleteRows = false;
            this.StudentLearningPlanListView.AllowUserToResizeColumns = false;
            this.StudentLearningPlanListView.AllowUserToResizeRows = false;
            this.StudentLearningPlanListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentLearningPlanListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentLearningPlanListView.Location = new System.Drawing.Point(0, 0);
            this.StudentLearningPlanListView.Name = "StudentLearningPlanListView";
            this.StudentLearningPlanListView.ReadOnly = true;
            this.StudentLearningPlanListView.RowHeadersVisible = false;
            this.StudentLearningPlanListView.Size = new System.Drawing.Size(960, 709);
            this.StudentLearningPlanListView.TabIndex = 2;
            this.StudentLearningPlanListView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StudentLearningPlanListView_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Начало периода";
            // 
            // planFromPicker
            // 
            this.planFromPicker.Location = new System.Drawing.Point(104, 79);
            this.planFromPicker.Name = "planFromPicker";
            this.planFromPicker.Size = new System.Drawing.Size(145, 20);
            this.planFromPicker.TabIndex = 39;
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(171, 44);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(75, 23);
            this.remove.TabIndex = 31;
            this.remove.Text = "Удалить";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(89, 44);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 23);
            this.update.TabIndex = 30;
            this.update.Text = "Изменить";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(8, 44);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 29;
            this.add.Text = "Добавить";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Конец периода";
            // 
            // planToPicker
            // 
            this.planToPicker.Location = new System.Drawing.Point(104, 105);
            this.planToPicker.Name = "planToPicker";
            this.planToPicker.Size = new System.Drawing.Size(145, 20);
            this.planToPicker.TabIndex = 41;
            // 
            // learningPlanbox
            // 
            this.learningPlanbox.Controls.Add(this.LearningPlanList);
            this.learningPlanbox.Controls.Add(this.label5);
            this.learningPlanbox.Controls.Add(this.planToPicker);
            this.learningPlanbox.Controls.Add(this.label6);
            this.learningPlanbox.Controls.Add(this.planFromPicker);
            this.learningPlanbox.Controls.Add(this.remove);
            this.learningPlanbox.Controls.Add(this.update);
            this.learningPlanbox.Controls.Add(this.add);
            this.learningPlanbox.Location = new System.Drawing.Point(16, 12);
            this.learningPlanbox.Name = "learningPlanbox";
            this.learningPlanbox.Size = new System.Drawing.Size(259, 140);
            this.learningPlanbox.TabIndex = 39;
            this.learningPlanbox.TabStop = false;
            this.learningPlanbox.Text = "Учкбный план";
            // 
            // ControlsPanel
            // 
            this.ControlsPanel.Controls.Add(this.learningPlanbox);
            this.ControlsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlsPanel.Location = new System.Drawing.Point(0, 0);
            this.ControlsPanel.Name = "ControlsPanel";
            this.ControlsPanel.Size = new System.Drawing.Size(281, 173);
            this.ControlsPanel.TabIndex = 22;
            // 
            // StudentListView
            // 
            this.StudentListView.AllowUserToAddRows = false;
            this.StudentListView.AllowUserToDeleteRows = false;
            this.StudentListView.AllowUserToResizeColumns = false;
            this.StudentListView.AllowUserToResizeRows = false;
            this.StudentListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentListView.ColumnHeadersVisible = false;
            this.StudentListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentListView.Location = new System.Drawing.Point(0, 0);
            this.StudentListView.Name = "StudentListView";
            this.StudentListView.ReadOnly = true;
            this.StudentListView.RowHeadersVisible = false;
            this.StudentListView.Size = new System.Drawing.Size(281, 536);
            this.StudentListView.TabIndex = 1;
            this.StudentListView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StudentListView_CellClick);
            // 
            // GroupListPanel
            // 
            this.GroupListPanel.Controls.Add(this.StudentListView);
            this.GroupListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupListPanel.Location = new System.Drawing.Point(0, 173);
            this.GroupListPanel.Name = "GroupListPanel";
            this.GroupListPanel.Size = new System.Drawing.Size(281, 536);
            this.GroupListPanel.TabIndex = 23;
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.GroupListPanel);
            this.LeftPanel.Controls.Add(this.ControlsPanel);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(281, 709);
            this.LeftPanel.TabIndex = 18;
            // 
            // LearningPlanList
            // 
            this.LearningPlanList.FormattingEnabled = true;
            this.LearningPlanList.Location = new System.Drawing.Point(8, 18);
            this.LearningPlanList.Name = "LearningPlanList";
            this.LearningPlanList.Size = new System.Drawing.Size(238, 21);
            this.LearningPlanList.TabIndex = 43;
            // 
            // StudentLearningPlanList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 709);
            this.Controls.Add(this.StudentListPanel);
            this.Controls.Add(this.LeftPanel);
            this.Name = "StudentLearningPlanList";
            this.Text = "Учебные планы студентов";
            this.Load += new System.EventHandler(this.StudentLearningPlanList_Load);
            this.Resize += new System.EventHandler(this.StudentLearningPlanList_Resize);
            this.StudentListPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StudentLearningPlanListView)).EndInit();
            this.learningPlanbox.ResumeLayout(false);
            this.learningPlanbox.PerformLayout();
            this.ControlsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StudentListView)).EndInit();
            this.GroupListPanel.ResumeLayout(false);
            this.LeftPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel StudentListPanel;
        private System.Windows.Forms.DataGridView StudentLearningPlanListView;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker planFromPicker;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker planToPicker;
        private System.Windows.Forms.GroupBox learningPlanbox;
        private System.Windows.Forms.Panel ControlsPanel;
        private System.Windows.Forms.DataGridView StudentListView;
        private System.Windows.Forms.Panel GroupListPanel;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.ComboBox LearningPlanList;
    }
}