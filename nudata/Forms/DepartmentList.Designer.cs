namespace nudata.Forms
{
    partial class DepartmentList
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
            this.FacultyListPanel = new System.Windows.Forms.Panel();
            this.DepartmentListView = new System.Windows.Forms.DataGridView();
            this.ControlsPanel = new System.Windows.Forms.Panel();
            this.remove = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.DepartmentName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DepartmentHeadPanel = new System.Windows.Forms.Panel();
            this.DepartmentHeadControlsPanel = new System.Windows.Forms.Panel();
            this.DepartmentHeadViewPanel = new System.Windows.Forms.Panel();
            this.DepartmentHeadListView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.headList = new System.Windows.Forms.ComboBox();
            this.headFromPicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.headToPicker = new System.Windows.Forms.DateTimePicker();
            this.dHeadRemove = new System.Windows.Forms.Button();
            this.dHeadUpdate = new System.Windows.Forms.Button();
            this.dHeadAdd = new System.Windows.Forms.Button();
            this.LeftPanel.SuspendLayout();
            this.FacultyListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentListView)).BeginInit();
            this.ControlsPanel.SuspendLayout();
            this.DepartmentHeadPanel.SuspendLayout();
            this.DepartmentHeadControlsPanel.SuspendLayout();
            this.DepartmentHeadViewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentHeadListView)).BeginInit();
            this.SuspendLayout();
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.FacultyListPanel);
            this.LeftPanel.Controls.Add(this.ControlsPanel);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(383, 718);
            this.LeftPanel.TabIndex = 24;
            // 
            // FacultyListPanel
            // 
            this.FacultyListPanel.Controls.Add(this.DepartmentListView);
            this.FacultyListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FacultyListPanel.Location = new System.Drawing.Point(0, 100);
            this.FacultyListPanel.Name = "FacultyListPanel";
            this.FacultyListPanel.Size = new System.Drawing.Size(383, 618);
            this.FacultyListPanel.TabIndex = 23;
            // 
            // DepartmentListView
            // 
            this.DepartmentListView.AllowUserToAddRows = false;
            this.DepartmentListView.AllowUserToDeleteRows = false;
            this.DepartmentListView.AllowUserToResizeColumns = false;
            this.DepartmentListView.AllowUserToResizeRows = false;
            this.DepartmentListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DepartmentListView.ColumnHeadersVisible = false;
            this.DepartmentListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DepartmentListView.Location = new System.Drawing.Point(0, 0);
            this.DepartmentListView.Name = "DepartmentListView";
            this.DepartmentListView.ReadOnly = true;
            this.DepartmentListView.RowHeadersVisible = false;
            this.DepartmentListView.Size = new System.Drawing.Size(383, 618);
            this.DepartmentListView.TabIndex = 1;
            this.DepartmentListView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DepartmentListView_CellClick);
            // 
            // ControlsPanel
            // 
            this.ControlsPanel.Controls.Add(this.remove);
            this.ControlsPanel.Controls.Add(this.update);
            this.ControlsPanel.Controls.Add(this.add);
            this.ControlsPanel.Controls.Add(this.DepartmentName);
            this.ControlsPanel.Controls.Add(this.label1);
            this.ControlsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlsPanel.Location = new System.Drawing.Point(0, 0);
            this.ControlsPanel.Name = "ControlsPanel";
            this.ControlsPanel.Size = new System.Drawing.Size(383, 100);
            this.ControlsPanel.TabIndex = 22;
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(169, 60);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(69, 23);
            this.remove.TabIndex = 5;
            this.remove.Text = "Удалить";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(92, 60);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(71, 23);
            this.update.TabIndex = 4;
            this.update.Text = "Изменить";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(15, 60);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(71, 23);
            this.add.TabIndex = 3;
            this.add.Text = "Добавить";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // DepartmentName
            // 
            this.DepartmentName.Location = new System.Drawing.Point(15, 34);
            this.DepartmentName.Name = "DepartmentName";
            this.DepartmentName.Size = new System.Drawing.Size(353, 20);
            this.DepartmentName.TabIndex = 0;
            this.DepartmentName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DepartmentName_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Название кафедры";
            // 
            // DepartmentHeadPanel
            // 
            this.DepartmentHeadPanel.Controls.Add(this.DepartmentHeadViewPanel);
            this.DepartmentHeadPanel.Controls.Add(this.DepartmentHeadControlsPanel);
            this.DepartmentHeadPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DepartmentHeadPanel.Location = new System.Drawing.Point(383, 0);
            this.DepartmentHeadPanel.Name = "DepartmentHeadPanel";
            this.DepartmentHeadPanel.Size = new System.Drawing.Size(543, 718);
            this.DepartmentHeadPanel.TabIndex = 25;
            // 
            // DepartmentHeadControlsPanel
            // 
            this.DepartmentHeadControlsPanel.Controls.Add(this.dHeadRemove);
            this.DepartmentHeadControlsPanel.Controls.Add(this.dHeadUpdate);
            this.DepartmentHeadControlsPanel.Controls.Add(this.dHeadAdd);
            this.DepartmentHeadControlsPanel.Controls.Add(this.label4);
            this.DepartmentHeadControlsPanel.Controls.Add(this.headToPicker);
            this.DepartmentHeadControlsPanel.Controls.Add(this.label3);
            this.DepartmentHeadControlsPanel.Controls.Add(this.headFromPicker);
            this.DepartmentHeadControlsPanel.Controls.Add(this.headList);
            this.DepartmentHeadControlsPanel.Controls.Add(this.label2);
            this.DepartmentHeadControlsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DepartmentHeadControlsPanel.Location = new System.Drawing.Point(0, 0);
            this.DepartmentHeadControlsPanel.Name = "DepartmentHeadControlsPanel";
            this.DepartmentHeadControlsPanel.Size = new System.Drawing.Size(543, 128);
            this.DepartmentHeadControlsPanel.TabIndex = 0;
            // 
            // DepartmentHeadViewPanel
            // 
            this.DepartmentHeadViewPanel.Controls.Add(this.DepartmentHeadListView);
            this.DepartmentHeadViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DepartmentHeadViewPanel.Location = new System.Drawing.Point(0, 128);
            this.DepartmentHeadViewPanel.Name = "DepartmentHeadViewPanel";
            this.DepartmentHeadViewPanel.Size = new System.Drawing.Size(543, 590);
            this.DepartmentHeadViewPanel.TabIndex = 1;
            // 
            // DepartmentHeadListView
            // 
            this.DepartmentHeadListView.AllowUserToAddRows = false;
            this.DepartmentHeadListView.AllowUserToDeleteRows = false;
            this.DepartmentHeadListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DepartmentHeadListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DepartmentHeadListView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DepartmentHeadListView.Location = new System.Drawing.Point(0, 0);
            this.DepartmentHeadListView.Name = "DepartmentHeadListView";
            this.DepartmentHeadListView.ReadOnly = true;
            this.DepartmentHeadListView.RowHeadersVisible = false;
            this.DepartmentHeadListView.Size = new System.Drawing.Size(543, 590);
            this.DepartmentHeadListView.TabIndex = 0;
            this.DepartmentHeadListView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DepartmentHeadListView_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Заведующий кафедрой";
            // 
            // headList
            // 
            this.headList.FormattingEnabled = true;
            this.headList.Location = new System.Drawing.Point(9, 25);
            this.headList.Name = "headList";
            this.headList.Size = new System.Drawing.Size(522, 21);
            this.headList.TabIndex = 1;
            // 
            // headFromPicker
            // 
            this.headFromPicker.Location = new System.Drawing.Point(26, 54);
            this.headFromPicker.Name = "headFromPicker";
            this.headFromPicker.Size = new System.Drawing.Size(230, 20);
            this.headFromPicker.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "С";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "по";
            // 
            // headToPicker
            // 
            this.headToPicker.Location = new System.Drawing.Point(301, 54);
            this.headToPicker.Name = "headToPicker";
            this.headToPicker.Size = new System.Drawing.Size(230, 20);
            this.headToPicker.TabIndex = 4;
            // 
            // dHeadRemove
            // 
            this.dHeadRemove.Location = new System.Drawing.Point(166, 89);
            this.dHeadRemove.Name = "dHeadRemove";
            this.dHeadRemove.Size = new System.Drawing.Size(69, 23);
            this.dHeadRemove.TabIndex = 8;
            this.dHeadRemove.Text = "Удалить";
            this.dHeadRemove.UseVisualStyleBackColor = true;
            this.dHeadRemove.Click += new System.EventHandler(this.dHeadRemove_Click);
            // 
            // dHeadUpdate
            // 
            this.dHeadUpdate.Location = new System.Drawing.Point(89, 89);
            this.dHeadUpdate.Name = "dHeadUpdate";
            this.dHeadUpdate.Size = new System.Drawing.Size(71, 23);
            this.dHeadUpdate.TabIndex = 7;
            this.dHeadUpdate.Text = "Изменить";
            this.dHeadUpdate.UseVisualStyleBackColor = true;
            this.dHeadUpdate.Click += new System.EventHandler(this.dHeadUpdate_Click);
            // 
            // dHeadAdd
            // 
            this.dHeadAdd.Location = new System.Drawing.Point(12, 89);
            this.dHeadAdd.Name = "dHeadAdd";
            this.dHeadAdd.Size = new System.Drawing.Size(71, 23);
            this.dHeadAdd.TabIndex = 6;
            this.dHeadAdd.Text = "Добавить";
            this.dHeadAdd.UseVisualStyleBackColor = true;
            this.dHeadAdd.Click += new System.EventHandler(this.dHeadAdd_Click);
            // 
            // DepartmentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 718);
            this.Controls.Add(this.DepartmentHeadPanel);
            this.Controls.Add(this.LeftPanel);
            this.Name = "DepartmentList";
            this.Text = "Кафедры";
            this.Load += new System.EventHandler(this.DepartmentList_Load);
            this.LeftPanel.ResumeLayout(false);
            this.FacultyListPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentListView)).EndInit();
            this.ControlsPanel.ResumeLayout(false);
            this.ControlsPanel.PerformLayout();
            this.DepartmentHeadPanel.ResumeLayout(false);
            this.DepartmentHeadControlsPanel.ResumeLayout(false);
            this.DepartmentHeadControlsPanel.PerformLayout();
            this.DepartmentHeadViewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentHeadListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Panel FacultyListPanel;
        private System.Windows.Forms.DataGridView DepartmentListView;
        private System.Windows.Forms.Panel ControlsPanel;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.TextBox DepartmentName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel DepartmentHeadPanel;
        private System.Windows.Forms.Panel DepartmentHeadViewPanel;
        private System.Windows.Forms.DataGridView DepartmentHeadListView;
        private System.Windows.Forms.Panel DepartmentHeadControlsPanel;
        private System.Windows.Forms.Button dHeadRemove;
        private System.Windows.Forms.Button dHeadUpdate;
        private System.Windows.Forms.Button dHeadAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker headToPicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker headFromPicker;
        private System.Windows.Forms.ComboBox headList;
        private System.Windows.Forms.Label label2;
    }
}