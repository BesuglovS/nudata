﻿using nudata.DomainClasses.Extra;
using nudata.DomainClasses.Main;
using nudata.nubackRepos;
using nudata.Properties;
using nudata.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace nudata.Forms
{
    public partial class StudentList : Form
    {
        private string ApiEndpoint;
        StudentRepo sRepo;
        StudentGroupRepo sgRepo;
        List<Student> Students;

        public StudentList(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
            InitializeComponent();

            Students = new List<Student>();
            sRepo = new StudentRepo(ApiEndpoint);
            sgRepo = new StudentGroupRepo(ApiEndpoint);
        }

        private void StudentListLoad(object sender, EventArgs e)
        {
            IntPtr pIcon = Resources.people.GetHicon();            
            Icon = Icon.FromHandle(pIcon);
                        
            Students = sRepo.all();

            UpdateSearchBoxItems();
        }

        public void UpdateSearchBoxItems()
        {
            searchBox.DataSource = null;

            var groups = sgRepo.all()
                .OrderBy(g => g.name)
                .ToList();
            var searchList = StudentListView.FromGroupList(groups);

            Students = sRepo.all();            
            searchList.AddRange(StudentListView.FromStudentList(Students));

            searchBox.DisplayMember = "dataString";
            searchBox.ValueMember = "idString";
            searchBox.DataSource = searchList;
        }

        private void StudentListResize(object sender, EventArgs e)
        {
            searchBox.Width = Width - 40;
        }

        private void SearchBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (searchBox.SelectedValue == null)
                {
                    return;
                }

                var keyword = ((string)searchBox.SelectedValue).Split('@')[0];
                var id = int.Parse(((string)searchBox.SelectedValue).Split('@')[1]);

                switch (keyword)
                {
                    case "student":
                        var studentDetailsForm = new StudentProperties(this, id, StudentDetailsMode.Edit, ApiEndpoint);
                        studentDetailsForm.Show();
                        Height = 85;
                        Width = 670;
                        break;
                    case "studentGroup":
                        var groupStudents = sRepo
                            .groupAll(id)
                            .Select(sig => new Student(sig))
                            .OrderBy(s => s.expelled)
                            .ThenBy(s => s.f)
                            .ThenBy(s => s.i)
                            .ToList();
                        viewGrid.DataSource = groupStudents;
                        FormatGroupView();
                        Height = 540;
                        Width = 1090;
                        break;
                }

                Left = (Screen.PrimaryScreen.Bounds.Width - Width) / 2;
                Top = (Screen.PrimaryScreen.Bounds.Height - Height) / 2;
            }

            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void FormatGroupView()
        {
            viewGrid.Columns[0].Visible = false;
            viewGrid.Columns[0].Width = 0;

            viewGrid.Columns[1].HeaderText = "Фамилия";
            viewGrid.Columns[1].Width = 80;

            viewGrid.Columns[2].HeaderText = "Имя";
            viewGrid.Columns[2].Width = 80;

            viewGrid.Columns[3].HeaderText = "Отчество";
            viewGrid.Columns[3].Width = 80;

            viewGrid.Columns[4].HeaderText = "№ зачётной книжки";
            viewGrid.Columns[4].Width = 70;
            viewGrid.Columns[4].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            viewGrid.Columns[5].HeaderText = "Дата рождения";
            viewGrid.Columns[5].Width = 70;
            viewGrid.Columns[5].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            viewGrid.Columns[6].HeaderText = "Адрес";
            viewGrid.Columns[6].Width = 180;

            viewGrid.Columns[7].HeaderText = "Телефон";
            viewGrid.Columns[7].Width = 100;
            viewGrid.Columns[7].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            viewGrid.Columns[8].HeaderText = "Приказы";
            viewGrid.Columns[8].Width = 150;

            viewGrid.Columns[9].HeaderText = "Староста";
            viewGrid.Columns[9].Width = 60;

            viewGrid.Columns[10].HeaderText = "Наяновец";
            viewGrid.Columns[10].Width = 60;

            viewGrid.Columns[11].HeaderText = "Платное обучение";
            viewGrid.Columns[11].Width = 60;

            viewGrid.Columns[12].HeaderText = "Отчислен";
            viewGrid.Columns[12].Width = 60;

            viewGrid.ClearSelection();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var studentDetailsForm = new StudentProperties(this, 0, StudentDetailsMode.New, ApiEndpoint);
            studentDetailsForm.Show();
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewGrid.SelectedCells.Count == 0) return;

            var studentId = (int)viewGrid.Rows[viewGrid.SelectedCells[0].RowIndex].Cells["id"].Value;
            var groupName = searchBox.Text;

            var studentDetailsForm = new StudentProperties(this, studentId, StudentDetailsMode.Edit, ApiEndpoint);
            var result = studentDetailsForm.ShowDialog();

            searchBox.Text = groupName;
            if (result == DialogResult.OK)
            {
                SearchBoxKeyDown(this, new KeyEventArgs(Keys.Enter));
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewGrid.SelectedCells.Count == 0) return;

            var fioDeleted =
                ((viewGrid.Rows[viewGrid.SelectedCells[0].RowIndex].Cells["F"].Value as string) ?? "") + " " +
                ((viewGrid.Rows[viewGrid.SelectedCells[0].RowIndex].Cells["I"].Value as string) ?? "") + " " +
                ((viewGrid.Rows[viewGrid.SelectedCells[0].RowIndex].Cells["O"].Value as string) ?? "");
            if (MessageBox.Show(
                    caption: "Точно удалить студента?",
                    text: fioDeleted,
                    buttons: MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }

            var studentId = (int)viewGrid.Rows[viewGrid.SelectedCells[0].RowIndex].Cells["StudentId"].Value;

            sRepo.delete(studentId);
        }

        private void viewGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditToolStripMenuItem_Click(this, e);
        }

        private void copyListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var students = (List<Student>)viewGrid.DataSource;

            var stString = students
                .Select(s => s.f + " " + s.i + " " + s.o)
                .Aggregate((a, b) => a + Environment.NewLine + b);

            Clipboard.SetText(stString);
        }
    }
}

