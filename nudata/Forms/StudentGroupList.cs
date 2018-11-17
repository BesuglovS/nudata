using nudata.DomainClasses.Main;
using nudata.nubackRepos;
using nudata.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace nudata.Forms
{
    public partial class StudentGroupList : Form
    {
        enum RefreshType { GroupsOnly = 1, StudentsOnly, FullRefresh };

        private string ApiEndpoint;
        StudentRepo sRepo;
        StudentGroupRepo sgRepo;
        StudentStudentGroupRepo ssgRepo;

        public StudentGroupList(string apiEndpoint)
        {
            InitializeComponent();

            ApiEndpoint = apiEndpoint;

            sRepo = new StudentRepo(ApiEndpoint);
            sgRepo = new StudentGroupRepo(ApiEndpoint);
            ssgRepo = new StudentStudentGroupRepo(ApiEndpoint);
        }

        private void LoadStudentsList()
        {
            var studentList = sRepo                
                .all()
                .Where(st => st.expelled != "1")
                .OrderBy(st => st.f)
                .ThenBy(st => st.i)
                .ToList();

            var studentView = StudentView.StudentsToView(studentList);

            StudentList.DataSource = studentView;
            StudentList.ValueMember = "id";
            StudentList.DisplayMember = "summary";
        }

        private void StudentGroupListLoad(object sender, EventArgs e)
        {
            RefreshView((int)RefreshType.FullRefresh);

            LoadStudentsList();

            LoadGroupList();
        }

        private void LoadGroupList()
        {
            var studentGroupList = sgRepo.all().OrderBy(sg => sg.name).ToList();

            groupsList.DataSource = studentGroupList;
            groupsList.DisplayMember = "name";
            groupsList.ValueMember = "id";
        }

        private void RefreshView(int refreshType)
        {
            // 1 - groups only
            // 2 - students only
            // 3 - full refresh

            if ((refreshType == 1) || (refreshType == 3))
            {
                var studentGroupList = sgRepo.all();
                studentGroupList = studentGroupList.OrderBy(sg => sg.name).ToList();

                StudentGroupListView.DataSource = studentGroupList;

                StudentGroupListView.Columns["id"].Visible = false;
                StudentGroupListView.Columns["name"].Width = 80;
                StudentGroupListView.Columns["from"].Width = 80;
                StudentGroupListView.Columns["to"].Width = 80;
            }

            StudentGroupListView.ClearSelection();

            if ((refreshType == 2) || (refreshType == 3))
            {
                var group = sgRepo.all().FirstOrDefault(sg => sg.name == StudentGroupName.Text);
                if (group == null) return;

                var groupStudents = sRepo.groupAll(group.id);

                if (groupStudents != null)
                {
                    var studentsView = StudentInGroupView.StudentsInGroupToView(groupStudents);
                    studentsView = studentsView
                        .OrderBy(s => s.expelled)
                        .ThenBy(s => s.fio)
                        .ToList();

                    StudentsInGroupListView.DataSource = studentsView;

                    StudentsInGroupListView.Columns["id"].Visible = false;
                    StudentsInGroupListView.Columns["fio"].Width = 200;
                    StudentsInGroupListView.Columns["fio"].HeaderText = "Ф.И.О.";
                    StudentsInGroupListView.Columns["zach_number"].Width = 80;
                    StudentsInGroupListView.Columns["zach_number"].HeaderText = "№ зачётки";
                    StudentsInGroupListView.Columns["birth_date"].Width = 80;
                    StudentsInGroupListView.Columns["birth_date"].HeaderText = "Дата рождения";
                    StudentsInGroupListView.Columns["address"].Width = 150;
                    StudentsInGroupListView.Columns["address"].HeaderText = "Адрес";
                    StudentsInGroupListView.Columns["phone"].Width = 80;
                    StudentsInGroupListView.Columns["phone"].HeaderText = "Телефон";
                    StudentsInGroupListView.Columns["orders"].Width = 150;
                    StudentsInGroupListView.Columns["orders"].HeaderText = "Приказы";
                    StudentsInGroupListView.Columns["starosta"].Width = 50;
                    StudentsInGroupListView.Columns["starosta"].HeaderText = "Староста";
                    StudentsInGroupListView.Columns["n_factor"].Width = 50;
                    StudentsInGroupListView.Columns["n_factor"].HeaderText = "Наяновец";
                    StudentsInGroupListView.Columns["paid_edu"].Width = 50;
                    StudentsInGroupListView.Columns["paid_edu"].HeaderText = "Платное обучение";
                    StudentsInGroupListView.Columns["expelled"].Width = 50;
                    StudentsInGroupListView.Columns["expelled"].HeaderText = "Отчислен";

                    //StudentsInGroupListView.ClearSelection();
                }
            }
        }

        private void StudentGroupListView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var studentGroup = ((List<StudentGroup>)StudentGroupListView.DataSource)[e.RowIndex];

            StudentGroupName.Text = studentGroup.name;
            groupFromPicker.Value = studentGroup.from;
            groupToPicker.Value = studentGroup.to;

            var group = sgRepo.all().FirstOrDefault(sg => sg.name == StudentGroupName.Text);
            if (group == null) return;

            var groupStudents = sRepo.groupAll(group.id);

            var studentsView = StudentInGroupView.StudentsInGroupToView(groupStudents)
                .OrderBy(s => s.fio)
                .ThenBy(s => s.from)
                .ToList();

            StudentsInGroupListView.DataSource = studentsView;

            StudentsInGroupListView.Columns["id"].Visible = false;
            StudentsInGroupListView.Columns["student_id"].Visible = false;
            StudentsInGroupListView.Columns["fio"].Width = 200;
            StudentsInGroupListView.Columns["fio"].HeaderText = "Ф.И.О.";
            StudentsInGroupListView.Columns["from"].Width = 80;
            StudentsInGroupListView.Columns["from"].HeaderText = "Начало периода";
            StudentsInGroupListView.Columns["to"].Width = 80;
            StudentsInGroupListView.Columns["to"].HeaderText = "Конец периода";
            StudentsInGroupListView.Columns["zach_number"].Width = 80;
            StudentsInGroupListView.Columns["zach_number"].HeaderText = "№ зачётки";
            StudentsInGroupListView.Columns["birth_date"].Width = 80;
            StudentsInGroupListView.Columns["birth_date"].HeaderText = "Дата рождения";
            StudentsInGroupListView.Columns["address"].Width = 150;
            StudentsInGroupListView.Columns["address"].HeaderText = "Адрес";
            StudentsInGroupListView.Columns["phone"].Width = 80;
            StudentsInGroupListView.Columns["phone"].HeaderText = "Телефон";
            StudentsInGroupListView.Columns["orders"].Width = 150;
            StudentsInGroupListView.Columns["orders"].HeaderText = "Приказы";
            StudentsInGroupListView.Columns["starosta"].Width = 50;
            StudentsInGroupListView.Columns["starosta"].HeaderText = "Староста";
            StudentsInGroupListView.Columns["n_factor"].Width = 50;
            StudentsInGroupListView.Columns["n_factor"].HeaderText = "Наяновец";
            StudentsInGroupListView.Columns["paid_edu"].Width = 50;
            StudentsInGroupListView.Columns["paid_edu"].HeaderText = "Платное обучение";
            StudentsInGroupListView.Columns["expelled"].Width = 50;
            StudentsInGroupListView.Columns["expelled"].HeaderText = "Отчислен";
            StudentsInGroupListView.Columns["summary"].Visible = false;

            StudentsInGroupListView.ClearSelection();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (sgRepo.all().Select(sg => sg.name).ToList().Contains(StudentGroupName.Text))                
            {
                MessageBox.Show("Такая группа уже есть.");
                return;
            }

            var newStudentGroup = new StudentGroup {
                name = StudentGroupName.Text,
                from = groupFromPicker.Value,
                to = groupToPicker.Value
            };
            sgRepo.add(newStudentGroup);

            RefreshView((int)RefreshType.GroupsOnly);
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (StudentGroupListView.SelectedCells.Count > 0)
            {
                var studentGroup = ((List<StudentGroup>)StudentGroupListView.DataSource)[StudentGroupListView.SelectedCells[0].RowIndex];

                studentGroup.name = StudentGroupName.Text;
                studentGroup.from = groupFromPicker.Value;
                studentGroup.to = groupToPicker.Value;

                sgRepo.update(studentGroup, studentGroup.id);

                RefreshView((int)RefreshType.GroupsOnly);
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            if (StudentGroupListView.SelectedCells.Count > 0)
            {
                var studentGroup = ((List<StudentGroup>)StudentGroupListView.DataSource)[StudentGroupListView.SelectedCells[0].RowIndex];

                if (ssgRepo.all().Where(sig => sig.student_group_id == studentGroup.id).Count() > 0)
                {
                    MessageBox.Show("В группе есть студенты.");
                    return;
                }

                //if (_repo.Disciplines.GetFiltredDisciplines(d => d.StudentGroup.StudentGroupId == studentGroup.StudentGroupId).Count > 0)
                //{
                //    MessageBox.Show("Группа есть в учебном плане.");
                //    return;
                //}

                //if (_repo
                //    .GroupsInFaculties
                //    .GetFiltredGroupsInFaculty(gif => gif.StudentGroup.StudentGroupId == studentGroup.StudentGroupId).Count > 0)
                //{
                //    MessageBox.Show("Группа есть в списке факультета.");
                //    return;
                //}

                sgRepo.delete(studentGroup.id);

                RefreshView((int)RefreshType.GroupsOnly);
            }
        }
                

        private void StudentGroupList_Resize(object sender, EventArgs e)
        {
            
        }

        private void addStudentToGroup_Click(object sender, EventArgs e)
        {
            if (StudentList.SelectedValue == null)
            {
                return;
            }

            var studentToAdd = sRepo.get((int)StudentList.SelectedValue);

            if (StudentGroupListView.SelectedCells.Count > 0)
            {
                var studentGroup = ((List<StudentGroup>)StudentGroupListView.DataSource)[StudentGroupListView.SelectedCells[0].RowIndex];

                var sig = new StudentStudentGroup {
                    student_id = studentToAdd.id,
                    student_group_id = studentGroup.id,
                    from = fromPicker.Value,
                    to = toPicker.Value
                };

                ssgRepo.add(sig);

                RefreshView((int)RefreshType.StudentsOnly);
            }
            else
            {
                MessageBox.Show("Ни одна группа не выделена.");
            }
        }

        private void removeStudentFromGroup_Click(object sender, EventArgs e)
        {
            if (StudentGroupListView.SelectedCells.Count == 0)
            {
                MessageBox.Show("Ни одна группа не выделена.");
            }

            if ((StudentsInGroupListView.SelectedCells.Count > 0) && (StudentGroupListView.SelectedCells.Count > 0))
            {
                var studentInGroupView = ((List<StudentInGroupView>)StudentsInGroupListView.DataSource)[StudentsInGroupListView.SelectedCells[0].RowIndex];
                var student = sRepo.get(studentInGroupView.id);

                var studentGroup = ((List<StudentGroup>)StudentGroupListView.DataSource)[StudentGroupListView.SelectedCells[0].RowIndex];

                var ssg = ssgRepo.all().FirstOrDefault(stsg => stsg.student_id == student.id && stsg.student_group_id == studentGroup.id);
                if (ssg == null) return;

                ssgRepo.delete(ssg.id);

                RefreshView((int)RefreshType.StudentsOnly);
            }
        }

        private void addFromGroup_Click(object sender, EventArgs e)
        {
            var groupToAdd = sgRepo.get((int)groupsList.SelectedValue);

            var studentsToAdd = sRepo
                .groupAll(groupToAdd.id)
                .Where(st => st.expelled == "0");

            if (StudentGroupListView.SelectedCells.Count > 0)
            {
                var studentGroup = ((List<StudentGroup>)StudentGroupListView.DataSource)[StudentGroupListView.SelectedCells[0].RowIndex];

                foreach (var studentToAdd in studentsToAdd)
                {
                    var ssg = new StudentStudentGroup {
                        student_id = studentToAdd.id,
                        student_group_id = studentGroup.id,
                        from = studentToAdd.from,
                        to = studentToAdd.to
                    };
                    ssgRepo.add(ssg);
                }

                RefreshView((int)RefreshType.StudentsOnly);
            }
            else
            {
                MessageBox.Show("Ни одна группа не выделена.");
            }
        }

        private void StudentList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                addStudentToGroup.PerformClick();
            }
        }

        private void StudentGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                add.PerformClick();
            }
        }

        private void StudentsInGroupListView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var studentView = ((List<StudentInGroupView>)StudentsInGroupListView.DataSource)[e.RowIndex];

            StudentList.SelectedValue = studentView.student_id;
            fromPicker.Value = studentView.from;
            toPicker.Value = studentView.to;
        }

        private void updateStudentInGroup_Click(object sender, EventArgs e)
        {
            if (StudentsInGroupListView.SelectedCells.Count > 0)
            {
                var studentView = ((List<StudentInGroupView>)StudentsInGroupListView.DataSource)
                    [StudentsInGroupListView.SelectedCells[0].RowIndex];

                var ssg = ssgRepo.get(studentView.id);
                ssg.student_id = (int)StudentList.SelectedValue;
                ssg.from = fromPicker.Value;
                ssg.to = toPicker.Value;

                ssgRepo.update(ssg, ssg.id);

                RefreshView((int)RefreshType.StudentsOnly);
            }
        }
    }
}
