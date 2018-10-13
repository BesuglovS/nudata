using nudata.DomainClasses.Extra;
using nudata.DomainClasses.Main;
using nudata.nubackRepos;
using nudata.Properties;
using nudata.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nudata.Forms
{
    public partial class DepartmentList : Form
    {
        private string ApiEndpoint;
        DepartmentRepo dRepo;
        DepartmentHeadRepo dhRepo;
        TeacherRepo tRepo;

        public DepartmentList(string apiEndpoint)
        {
            InitializeComponent();

            ApiEndpoint = apiEndpoint;

            dRepo = new DepartmentRepo(ApiEndpoint);
            dhRepo = new DepartmentHeadRepo(ApiEndpoint);
            tRepo = new TeacherRepo(ApiEndpoint);
        }

        private void DepartmentList_Load(object sender, EventArgs e)
        {
            IntPtr pIcon = Resources.dept.GetHicon();
            Icon = Icon.FromHandle(pIcon);

            RefreshDepartmentList();

            var teacherViews = TeacherView.TeachersToView(tRepo.all().OrderBy(t => t.f).ThenBy(t => t.i).ThenBy(t => t.o).ToList());
            headList.DisplayMember = "fio";
            headList.ValueMember = "id";
            headList.DataSource = teacherViews;

        }

        private void RefreshDepartmentList()
        {
            var departments = dRepo.all()
                .OrderBy(d => d.name)
                .ToList();

            DepartmentListView.DataSource = departments;

            DepartmentListView.Columns["id"].Visible = false;
            DepartmentListView.Columns["name"].HeaderText = "Название кафедры";
            DepartmentListView.Columns["name"].Width = DepartmentListView.Width - 10;
        }

        private void add_Click(object sender, EventArgs e)
        {
            var newDepartmnent = new Department()
            {
                name = DepartmentName.Text
            };
            dRepo.add(newDepartmnent);

            RefreshDepartmentList();
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (DepartmentListView.SelectedCells.Count > 0)
            {
                var department = ((List<Department>)DepartmentListView.DataSource)[DepartmentListView.SelectedCells[0].RowIndex];

                department.name = DepartmentName.Text;

                dRepo.update(department, department.id);

                RefreshDepartmentList();
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            if (DepartmentListView.SelectedCells.Count > 0)
            {
                var department = ((List<Department>)DepartmentListView.DataSource)[DepartmentListView.SelectedCells[0].RowIndex];

                dRepo.delete(department.id);

                RefreshDepartmentList();
            }
        }

        private void DepartmentName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                add.PerformClick();
            }
        }

        private void DepartmentListView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var department = ((List<Department>)DepartmentListView.DataSource)[e.RowIndex];

            DepartmentName.Text = department.name;

            RefreshHeadsList();
        }

        private void RefreshHeadsList()
        {
            if (DepartmentListView.SelectedCells.Count > 0)
            {
                var department = ((List<Department>)DepartmentListView.DataSource)[DepartmentListView.SelectedCells[0].RowIndex];

                var heads = dhRepo.departmentAll(department.id);

                DepartmentHeadListView.DataSource = heads;
                DepartmentHeadListView.Columns["id"].Visible = false;
                DepartmentHeadListView.Columns["department_id"].Visible = false;
                DepartmentHeadListView.Columns["teacher_id"].Visible = false;
                DepartmentHeadListView.Columns["f"].HeaderText = "Фамилия";
                DepartmentHeadListView.Columns["i"].HeaderText = "Имя";
                DepartmentHeadListView.Columns["o"].HeaderText = "Отчество";
                DepartmentHeadListView.Columns["from"].HeaderText = "Начало периода";
                DepartmentHeadListView.Columns["to"].HeaderText = "Конец периода";
            }
        }

        private void DepartmentHeadListView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var departmentHead = ((List<DepartmentHeadWithTeacherFio>)DepartmentHeadListView.DataSource)[e.RowIndex];

            headList.SelectedValue = departmentHead.teacher_id;
            headFromPicker.Value = departmentHead.from;
            headToPicker.Value = departmentHead.to;

            RefreshHeadsList();
        }

        private void dHeadAdd_Click(object sender, EventArgs e)
        {
            if (DepartmentListView.SelectedCells.Count > 0)
            {
                var department = ((List<Department>)DepartmentListView.DataSource)[DepartmentListView.SelectedCells[0].RowIndex];
                var teacherId = (int)headList.SelectedValue;

                var dhItem = new DepartmentHead {
                    department_id = department.id,
                    teacher_id = teacherId,
                    from = headFromPicker.Value,
                    to = headToPicker.Value
                };

                dhRepo.add(dhItem);

                RefreshHeadsList();
            }
        }

        private void dHeadUpdate_Click(object sender, EventArgs e)
        {
            if (DepartmentHeadListView.SelectedCells.Count > 0)
            {
                var departmentHeadView = ((List<DepartmentHeadWithTeacherFio>)DepartmentHeadListView.DataSource)[DepartmentHeadListView.SelectedCells[0].RowIndex];
                var departmentHead = dhRepo.get(departmentHeadView.id);

                departmentHead.teacher_id = (int)headList.SelectedValue;
                departmentHead.from = headFromPicker.Value;
                departmentHead.to = headToPicker.Value;

                dhRepo.update(departmentHead, departmentHead.id);

                RefreshHeadsList();
            }            
        }

        private void dHeadRemove_Click(object sender, EventArgs e)
        {
            if (DepartmentListView.SelectedCells.Count > 0)
            {
                var departmentHeadView = ((List<DepartmentHeadWithTeacherFio>)DepartmentHeadListView.DataSource)[DepartmentHeadListView.SelectedCells[0].RowIndex];

                dhRepo.delete(departmentHeadView.id);

                RefreshHeadsList();
            }
        }
    }
}
