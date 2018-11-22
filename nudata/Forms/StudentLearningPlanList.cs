using nudata.Core;
using nudata.DomainClasses.Main;
using nudata.nubackRepos;
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
    public partial class StudentLearningPlanList : Form
    {
        private string ApiEndpoint;
        StudentRepo sRepo;
        LearningPlanRepo lpRepo;
        StudentLearningPlanRepo slpRepo;

        public StudentLearningPlanList(string apiEndpoint)
        {
            InitializeComponent();

            ApiEndpoint = apiEndpoint;

            sRepo = new StudentRepo(ApiEndpoint);
            lpRepo = new LearningPlanRepo(ApiEndpoint);
            slpRepo = new StudentLearningPlanRepo(ApiEndpoint);
        }

        private void StudentLearningPlanList_Load(object sender, EventArgs e)
        {
            ReloadStudentList();

            LoadLearningPlanList();
        }

        private void LoadLearningPlanList()
        {
            var plans = lpRepo.all();
            var plansView = LearningPlanView.FromLearningPlanList(plans);

            LearningPlanList.DataSource = plansView;
            LearningPlanList.ValueMember = "id";
            LearningPlanList.DisplayMember = "summary";
        }

        private void ReloadStudentList()
        {
            var studentList = sRepo
                            .all()
                            .Where(st => st.expelled != "1")
                            .OrderBy(st => st.f)
                            .ThenBy(st => st.i)
                            .ToList();

            var studentView = StudentView.StudentsToView(studentList);

            StudentListView.DataSource = studentView;
            FormatStudentsView();
        }

        private void FormatStudentsView()
        {
            StudentListView.Columns["id"].Visible = false;
            StudentListView.Columns["birth_date"].Visible = false;
            StudentListView.Columns["address"].Visible = false;
            StudentListView.Columns["phone"].Visible = false;
            StudentListView.Columns["orders"].Visible = false;
            StudentListView.Columns["starosta"].Visible = false;
            StudentListView.Columns["n_factor"].Visible = false;
            StudentListView.Columns["paid_edu"].Visible = false;
            StudentListView.Columns["expelled"].Visible = false;
            StudentListView.Columns["summary"].Visible = false;

            StudentListView.Columns["fio"].Width = StudentListView.Width - 80;
            StudentListView.Columns["fio"].HeaderText = "ФИО";

            StudentListView.Columns["zach_number"].Width = 55;
            StudentListView.Columns["zach_number"].HeaderText = "№ зачётки";
        }

        private void StudentListView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var studentId = ((List<StudentView>)StudentListView.DataSource)[e.RowIndex].id;

            ReloadLearningPlanList(studentId);
        }

        private void ReloadLearningPlanList(int studentId)
        {
            var plans = sRepo.learningPlans(studentId);
            var planView = StudentLearningPlanWithPeriodsView.fromNetData(plans);

            StudentLearningPlanListView.DataSource = planView;
            FormatPlansView();
        }

        private void FormatPlansView()
        {
            StudentLearningPlanListView.Columns["id"].Visible = false;
            StudentLearningPlanListView.Columns["student_id"].Visible = false;
            StudentLearningPlanListView.Columns["learning_plan_id"].Visible = false;
            StudentLearningPlanListView.Columns["plan_desc"].HeaderText = "Учебный план";
            StudentLearningPlanListView.Columns["plan_desc"].Width = StudentLearningPlanListView.Width - 200;
            StudentLearningPlanListView.Columns["from"].HeaderText = "Начало периода";
            StudentLearningPlanListView.Columns["from"].Width = 80;
            StudentLearningPlanListView.Columns["to"].HeaderText = "Конец периода";
            StudentLearningPlanListView.Columns["to"].Width = 80;
        }

        private void StudentLearningPlanList_Resize(object sender, EventArgs e)
        {
            FormatPlansView();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (StudentListView.SelectedCells.Count > 0)
            {
                var studentId = ((List<StudentView>)StudentListView.DataSource)[StudentListView.SelectedCells[0].RowIndex].id;

                var newStudentLearningPlan = new StudentLearningPlan
                {
                    student_id = studentId,
                    learning_plan_id = (int) LearningPlanList.SelectedValue,
                    from = planFromPicker.Value,
                    to = planToPicker.Value                    
                };

                slpRepo.add(newStudentLearningPlan);

                ReloadLearningPlanList(studentId);
            }
                
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (StudentLearningPlanListView.SelectedCells.Count > 0)
            {
                var slp = ((List<StudentLearningPlanWithPeriodsView>)StudentLearningPlanListView.DataSource)[StudentLearningPlanListView.SelectedCells[0].RowIndex];

                var realSlp = slpRepo.get(slp.id);

                realSlp.learning_plan_id = (int)LearningPlanList.SelectedValue;
                realSlp.from = planFromPicker.Value;
                realSlp.to = planToPicker.Value;

                slpRepo.update(realSlp, realSlp.id);

                if (StudentListView.SelectedCells.Count > 0)
                {
                    var studentId = ((List<StudentView>)StudentListView.DataSource)[StudentListView.SelectedCells[0].RowIndex].id;

                    ReloadLearningPlanList(studentId);
                }
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            if (StudentLearningPlanListView.SelectedCells.Count > 0)
            {
                var slpId = ((List<StudentLearningPlanWithPeriodsView>)StudentLearningPlanListView.DataSource)[StudentLearningPlanListView.SelectedCells[0].RowIndex].id;

                slpRepo.delete(slpId);

                if (StudentListView.SelectedCells.Count > 0)
                {
                    var studentId = ((List<StudentView>)StudentListView.DataSource)[StudentListView.SelectedCells[0].RowIndex].id;

                    ReloadLearningPlanList(studentId);
                }                    
            }
        }

        private void StudentLearningPlanListView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (StudentLearningPlanListView.SelectedCells.Count > 0)
            {
                var slp = ((List<StudentLearningPlanWithPeriodsView>)StudentLearningPlanListView.DataSource)[StudentLearningPlanListView.SelectedCells[0].RowIndex];
                               
                LearningPlanList.SelectedValue = slp.learning_plan_id;
                planFromPicker.Value = slp.from;
                planToPicker.Value = slp.to;
            }
        }
    }
}
