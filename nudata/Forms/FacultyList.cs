using nudata.DomainClasses.Main;
using nudata.nubackRepos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nudata.Forms
{
    public partial class FacultyList : Form
    {
        enum RefreshType { FacultiesOnly = 1, GroupsOnly, FullRefresh };

        private string ApiEndpoint;
        FacultyRepo fRepo;
        StudentGroupRepo sgRepo;
        FacultyStudentGroupRepo fsgRepo;

        public FacultyList(string apiEndpoint)
        {
            InitializeComponent();

            ApiEndpoint = apiEndpoint;

            fRepo = new FacultyRepo(ApiEndpoint);
            sgRepo = new StudentGroupRepo(ApiEndpoint);
            fsgRepo = new FacultyStudentGroupRepo(ApiEndpoint);
        }

        private void FacultyListLoad(object sender, EventArgs e)
        {
            LoadStudentGroupList();

            RefreshView(RefreshType.FullRefresh);
        }

        private void RefreshView(RefreshType refreshType)
        {
            if (refreshType == RefreshType.FacultiesOnly || refreshType == RefreshType.FullRefresh)
            {
                var faculties = fRepo
                    .all()                    
                    .OrderBy(f => f.sorting_order)
                    .ToList();

                FacultiesListView.DataSource = faculties;

                FacultiesListView.Columns["id"].Visible = false;
                FacultiesListView.Columns["sorting_order"].Visible = false;
                FacultiesListView.Columns["name"].Width = FacultiesListView.Width - 30;
                FacultiesListView.Columns["letter"].Width = 30;
            }

            if (refreshType == RefreshType.GroupsOnly || refreshType == RefreshType.FullRefresh)
            {
                Faculty faculty = null;
                if (FacultiesListView.SelectedCells.Count > 0)
                {
                    faculty = ((List<Faculty>)FacultiesListView.DataSource)[FacultiesListView.SelectedCells[0].RowIndex];
                }

                if (faculty == null)
                {
                    return;
                }

                var facultyGroups = sgRepo.facultyAll(faculty.id);

                GroupsView.DataSource = facultyGroups;

                GroupsView.Columns["id"].Visible = false;
                GroupsView.Columns["name"].Width = GroupsView.Width - 200;
                GroupsView.Columns["from"].Width = 80;
                GroupsView.Columns["to"].Width = 80;
            }
        }

        private void LoadStudentGroupList()
        {
            var studentGroupList = sgRepo.all().OrderBy(sg => sg.name).ToList();

            GroupList.DisplayMember = "name";
            GroupList.ValueMember = "id";
            GroupList.DataSource = studentGroupList;
        }

        private void FacultiesListView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var faculty = ((List<Faculty>)FacultiesListView.DataSource)[e.RowIndex];

            FacultyName.Text = faculty.name;
            FacultyLetter.Text = faculty.letter;
            SortingOrder.Text = faculty.sorting_order.ToString(CultureInfo.InvariantCulture);

            var facultyGroups = sgRepo
                .facultyAll(faculty.id)
                .OrderBy(sg => sg.name)
                .ToList();

            GroupsView.DataSource = facultyGroups;

            GroupsView.Columns["id"].Visible = false;
            GroupsView.Columns["name"].Width = GroupsView.Width - 200;
            GroupsView.Columns["from"].Width = 80;
            GroupsView.Columns["to"].Width = 80;
        }

        private void AddClick(object sender, EventArgs e)
        {
            int sOrder;
            int.TryParse(SortingOrder.Text, out sOrder);

            var newFaculty = new Faculty() {
                name = FacultyName.Text,
                letter = FacultyLetter.Text,
                sorting_order = sOrder
            };
            fRepo.add(newFaculty);

            RefreshView(RefreshType.FacultiesOnly);
        }

        private void UpdateClick(object sender, EventArgs e)
        {
            if (FacultiesListView.SelectedCells.Count > 0)
            {
                var faculty = ((List<Faculty>)FacultiesListView.DataSource)[FacultiesListView.SelectedCells[0].RowIndex];

                faculty.name = FacultyName.Text;
                faculty.letter = FacultyLetter.Text;
                int sOrder;
                int.TryParse(SortingOrder.Text, out sOrder);
                faculty.sorting_order = sOrder;


                fRepo.update(faculty, faculty.id);

                RefreshView(RefreshType.FacultiesOnly);
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            if (FacultiesListView.SelectedCells.Count > 0)
            {
                var faculty = ((List<Faculty>)FacultiesListView.DataSource)[FacultiesListView.SelectedCells[0].RowIndex];

                if (sgRepo.facultyAll(faculty.id).Any())
                {
                    MessageBox.Show("К факультету привязаны группы.");
                    return;
                }

                fRepo.delete(faculty.id);

                RefreshView(RefreshType.FullRefresh);
            }
        }

        private void cascadeDelete_Click(object sender, EventArgs e)
        {
            if (FacultiesListView.SelectedCells.Count > 0)
            {
                var faculty = ((List<Faculty>)FacultiesListView.DataSource)[FacultiesListView.SelectedCells[0].RowIndex];

                var gifIds = sgRepo.facultyAll(faculty.id);

                foreach (var gifId in gifIds)
                {
                    fsgRepo.delete(gifId.id);
                }

                fRepo.delete(faculty.id);
            }
        }

        private void addGroupToFaculty_Click(object sender, EventArgs e)
        {
            if (GroupList.SelectedValue == null)
            {
                return;
            }

            var groupToAdd = sgRepo.get((int)GroupList.SelectedValue);

            if (FacultiesListView.SelectedCells.Count > 0)
            {
                var faculty = ((List<Faculty>)FacultiesListView.DataSource)[FacultiesListView.SelectedCells[0].RowIndex];

                var fsg = new FacultyStudentGroup { student_group_id = groupToAdd.id, faculty_id = faculty.id };

                fsgRepo.add(fsg);

                RefreshView(RefreshType.GroupsOnly);
            }
            else
            {
                MessageBox.Show("Не выбран факультет.");
            }
        }

        private void removeGroupFromFaculty_Click(object sender, EventArgs e)
        {
            if (FacultiesListView.SelectedCells.Count == 0)
            {
                MessageBox.Show("Не выбран факультет.");
            }

            if ((FacultiesListView.SelectedCells.Count > 0) && (GroupsView.SelectedCells.Count > 0))
            {
                var faculty = ((List<Faculty>)FacultiesListView.DataSource)[FacultiesListView.SelectedCells[0].RowIndex];

                var studentGroup = ((List<StudentGroup>)GroupsView.DataSource)[GroupsView.SelectedCells[0].RowIndex];

                var fsg = fsgRepo.all().FirstOrDefault(fg => fg.student_group_id == studentGroup.id && fg.faculty_id == faculty.id);

                if (fsg != null)
                {
                    fsgRepo.delete(fsg.id);
                }                

                RefreshView(RefreshType.GroupsOnly);
            }
        }

        private void GroupList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                addGroupToFaculty.PerformClick();
            }
        }        
    }
}
