using System.ComponentModel;
using System.Windows.Forms;

namespace nudata.Forms
{
    partial class StudentGroupList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.GroupListPanel = new System.Windows.Forms.Panel();
            this.StudentGroupListView = new System.Windows.Forms.DataGridView();
            this.ControlsPanel = new System.Windows.Forms.Panel();
            this.studentGroupbox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toPicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.fromPicker = new System.Windows.Forms.DateTimePicker();
            this.addFromGroup = new System.Windows.Forms.Button();
            this.groupsList = new System.Windows.Forms.ComboBox();
            this.StudentList = new System.Windows.Forms.ComboBox();
            this.removeStudentFromGroup = new System.Windows.Forms.Button();
            this.addStudentToGroup = new System.Windows.Forms.Button();
            this.groupGroupbox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupToPicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.groupFromPicker = new System.Windows.Forms.DateTimePicker();
            this.remove = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.StudentGroupName = new System.Windows.Forms.TextBox();
            this.StudentListPanel = new System.Windows.Forms.Panel();
            this.StudentsInGroupListView = new System.Windows.Forms.DataGridView();
            this.updateStudentInGroup = new System.Windows.Forms.Button();
            this.LeftPanel.SuspendLayout();
            this.GroupListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentGroupListView)).BeginInit();
            this.ControlsPanel.SuspendLayout();
            this.studentGroupbox.SuspendLayout();
            this.groupGroupbox.SuspendLayout();
            this.StudentListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentsInGroupListView)).BeginInit();
            this.SuspendLayout();
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.GroupListPanel);
            this.LeftPanel.Controls.Add(this.ControlsPanel);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(281, 679);
            this.LeftPanel.TabIndex = 16;
            // 
            // GroupListPanel
            // 
            this.GroupListPanel.Controls.Add(this.StudentGroupListView);
            this.GroupListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupListPanel.Location = new System.Drawing.Point(0, 379);
            this.GroupListPanel.Name = "GroupListPanel";
            this.GroupListPanel.Size = new System.Drawing.Size(281, 300);
            this.GroupListPanel.TabIndex = 23;
            // 
            // StudentGroupListView
            // 
            this.StudentGroupListView.AllowUserToAddRows = false;
            this.StudentGroupListView.AllowUserToDeleteRows = false;
            this.StudentGroupListView.AllowUserToResizeColumns = false;
            this.StudentGroupListView.AllowUserToResizeRows = false;
            this.StudentGroupListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentGroupListView.ColumnHeadersVisible = false;
            this.StudentGroupListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentGroupListView.Location = new System.Drawing.Point(0, 0);
            this.StudentGroupListView.Name = "StudentGroupListView";
            this.StudentGroupListView.ReadOnly = true;
            this.StudentGroupListView.RowHeadersVisible = false;
            this.StudentGroupListView.Size = new System.Drawing.Size(281, 300);
            this.StudentGroupListView.TabIndex = 1;
            this.StudentGroupListView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StudentGroupListView_CellClick);
            // 
            // ControlsPanel
            // 
            this.ControlsPanel.Controls.Add(this.studentGroupbox);
            this.ControlsPanel.Controls.Add(this.groupGroupbox);
            this.ControlsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlsPanel.Location = new System.Drawing.Point(0, 0);
            this.ControlsPanel.Name = "ControlsPanel";
            this.ControlsPanel.Size = new System.Drawing.Size(281, 379);
            this.ControlsPanel.TabIndex = 22;
            // 
            // studentGroupbox
            // 
            this.studentGroupbox.Controls.Add(this.updateStudentInGroup);
            this.studentGroupbox.Controls.Add(this.label4);
            this.studentGroupbox.Controls.Add(this.toPicker);
            this.studentGroupbox.Controls.Add(this.label3);
            this.studentGroupbox.Controls.Add(this.fromPicker);
            this.studentGroupbox.Controls.Add(this.addFromGroup);
            this.studentGroupbox.Controls.Add(this.groupsList);
            this.studentGroupbox.Controls.Add(this.StudentList);
            this.studentGroupbox.Controls.Add(this.removeStudentFromGroup);
            this.studentGroupbox.Controls.Add(this.addStudentToGroup);
            this.studentGroupbox.Location = new System.Drawing.Point(16, 158);
            this.studentGroupbox.Name = "studentGroupbox";
            this.studentGroupbox.Size = new System.Drawing.Size(259, 197);
            this.studentGroupbox.TabIndex = 40;
            this.studentGroupbox.TabStop = false;
            this.studentGroupbox.Text = "Студент";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Конец периода";
            // 
            // toPicker
            // 
            this.toPicker.Location = new System.Drawing.Point(104, 75);
            this.toPicker.Name = "toPicker";
            this.toPicker.Size = new System.Drawing.Size(145, 20);
            this.toPicker.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Начало периода";
            // 
            // fromPicker
            // 
            this.fromPicker.Location = new System.Drawing.Point(104, 49);
            this.fromPicker.Name = "fromPicker";
            this.fromPicker.Size = new System.Drawing.Size(145, 20);
            this.fromPicker.TabIndex = 45;
            // 
            // addFromGroup
            // 
            this.addFromGroup.Location = new System.Drawing.Point(12, 136);
            this.addFromGroup.Name = "addFromGroup";
            this.addFromGroup.Size = new System.Drawing.Size(119, 49);
            this.addFromGroup.TabIndex = 44;
            this.addFromGroup.Text = "Добавить всех из группы";
            this.addFromGroup.UseVisualStyleBackColor = true;
            this.addFromGroup.Click += new System.EventHandler(this.addFromGroup_Click);
            // 
            // groupsList
            // 
            this.groupsList.FormattingEnabled = true;
            this.groupsList.Location = new System.Drawing.Point(137, 151);
            this.groupsList.Name = "groupsList";
            this.groupsList.Size = new System.Drawing.Size(112, 21);
            this.groupsList.TabIndex = 43;
            // 
            // StudentList
            // 
            this.StudentList.FormattingEnabled = true;
            this.StudentList.Location = new System.Drawing.Point(12, 19);
            this.StudentList.Name = "StudentList";
            this.StudentList.Size = new System.Drawing.Size(237, 21);
            this.StudentList.TabIndex = 41;
            // 
            // removeStudentFromGroup
            // 
            this.removeStudentFromGroup.Location = new System.Drawing.Point(171, 106);
            this.removeStudentFromGroup.Name = "removeStudentFromGroup";
            this.removeStudentFromGroup.Size = new System.Drawing.Size(75, 23);
            this.removeStudentFromGroup.TabIndex = 40;
            this.removeStudentFromGroup.Text = "Удалить";
            this.removeStudentFromGroup.UseVisualStyleBackColor = true;
            this.removeStudentFromGroup.Click += new System.EventHandler(this.removeStudentFromGroup_Click);
            // 
            // addStudentToGroup
            // 
            this.addStudentToGroup.Location = new System.Drawing.Point(12, 106);
            this.addStudentToGroup.Name = "addStudentToGroup";
            this.addStudentToGroup.Size = new System.Drawing.Size(71, 23);
            this.addStudentToGroup.TabIndex = 39;
            this.addStudentToGroup.Text = "Добавить";
            this.addStudentToGroup.UseVisualStyleBackColor = true;
            this.addStudentToGroup.Click += new System.EventHandler(this.addStudentToGroup_Click);
            // 
            // groupGroupbox
            // 
            this.groupGroupbox.Controls.Add(this.label5);
            this.groupGroupbox.Controls.Add(this.groupToPicker);
            this.groupGroupbox.Controls.Add(this.label6);
            this.groupGroupbox.Controls.Add(this.groupFromPicker);
            this.groupGroupbox.Controls.Add(this.remove);
            this.groupGroupbox.Controls.Add(this.update);
            this.groupGroupbox.Controls.Add(this.add);
            this.groupGroupbox.Controls.Add(this.StudentGroupName);
            this.groupGroupbox.Location = new System.Drawing.Point(16, 12);
            this.groupGroupbox.Name = "groupGroupbox";
            this.groupGroupbox.Size = new System.Drawing.Size(259, 140);
            this.groupGroupbox.TabIndex = 39;
            this.groupGroupbox.TabStop = false;
            this.groupGroupbox.Text = "Группа";
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
            // groupToPicker
            // 
            this.groupToPicker.Location = new System.Drawing.Point(104, 105);
            this.groupToPicker.Name = "groupToPicker";
            this.groupToPicker.Size = new System.Drawing.Size(145, 20);
            this.groupToPicker.TabIndex = 41;
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
            // groupFromPicker
            // 
            this.groupFromPicker.Location = new System.Drawing.Point(104, 79);
            this.groupFromPicker.Name = "groupFromPicker";
            this.groupFromPicker.Size = new System.Drawing.Size(145, 20);
            this.groupFromPicker.TabIndex = 39;
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
            // StudentGroupName
            // 
            this.StudentGroupName.Location = new System.Drawing.Point(8, 18);
            this.StudentGroupName.Name = "StudentGroupName";
            this.StudentGroupName.Size = new System.Drawing.Size(238, 20);
            this.StudentGroupName.TabIndex = 28;
            // 
            // StudentListPanel
            // 
            this.StudentListPanel.Controls.Add(this.StudentsInGroupListView);
            this.StudentListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentListPanel.Location = new System.Drawing.Point(281, 0);
            this.StudentListPanel.Name = "StudentListPanel";
            this.StudentListPanel.Size = new System.Drawing.Size(963, 679);
            this.StudentListPanel.TabIndex = 17;
            // 
            // StudentsInGroupListView
            // 
            this.StudentsInGroupListView.AllowUserToAddRows = false;
            this.StudentsInGroupListView.AllowUserToDeleteRows = false;
            this.StudentsInGroupListView.AllowUserToResizeColumns = false;
            this.StudentsInGroupListView.AllowUserToResizeRows = false;
            this.StudentsInGroupListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentsInGroupListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentsInGroupListView.Location = new System.Drawing.Point(0, 0);
            this.StudentsInGroupListView.Name = "StudentsInGroupListView";
            this.StudentsInGroupListView.ReadOnly = true;
            this.StudentsInGroupListView.RowHeadersVisible = false;
            this.StudentsInGroupListView.Size = new System.Drawing.Size(963, 679);
            this.StudentsInGroupListView.TabIndex = 2;
            this.StudentsInGroupListView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StudentsInGroupListView_CellClick);
            // 
            // updateStudentInGroup
            // 
            this.updateStudentInGroup.Location = new System.Drawing.Point(90, 107);
            this.updateStudentInGroup.Name = "updateStudentInGroup";
            this.updateStudentInGroup.Size = new System.Drawing.Size(75, 23);
            this.updateStudentInGroup.TabIndex = 49;
            this.updateStudentInGroup.Text = "Изменить";
            this.updateStudentInGroup.UseVisualStyleBackColor = true;
            this.updateStudentInGroup.Click += new System.EventHandler(this.updateStudentInGroup_Click);
            // 
            // StudentGroupList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 679);
            this.Controls.Add(this.StudentListPanel);
            this.Controls.Add(this.LeftPanel);
            this.Name = "StudentGroupList";
            this.Text = "Группы студентов";
            this.Load += new System.EventHandler(this.StudentGroupListLoad);
            this.Resize += new System.EventHandler(this.StudentGroupList_Resize);
            this.LeftPanel.ResumeLayout(false);
            this.GroupListPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StudentGroupListView)).EndInit();
            this.ControlsPanel.ResumeLayout(false);
            this.studentGroupbox.ResumeLayout(false);
            this.studentGroupbox.PerformLayout();
            this.groupGroupbox.ResumeLayout(false);
            this.groupGroupbox.PerformLayout();
            this.StudentListPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StudentsInGroupListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel LeftPanel;
        private Panel GroupListPanel;
        private Panel ControlsPanel;
        private DataGridView StudentGroupListView;
        private Panel StudentListPanel;
        private DataGridView StudentsInGroupListView;
        private GroupBox studentGroupbox;
        private Label label4;
        private DateTimePicker toPicker;
        private Label label3;
        private DateTimePicker fromPicker;
        private Button addFromGroup;
        private ComboBox groupsList;
        private ComboBox StudentList;
        private Button removeStudentFromGroup;
        private Button addStudentToGroup;
        private GroupBox groupGroupbox;
        private Label label5;
        private DateTimePicker groupToPicker;
        private Label label6;
        private DateTimePicker groupFromPicker;
        private Button remove;
        private Button update;
        private Button add;
        private TextBox StudentGroupName;
        private Button updateStudentInGroup;
    }
}