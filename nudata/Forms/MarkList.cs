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
    public partial class MarkList : Form
    {
        private string ApiEndpoint;

        MarkRepo mRepo;
        MarkTeacherRepo mtRepo;
        StudentRepo sRepo;
        LearningPlanRepo lpRepo;
        LearningPlanDisciplineRepo lpdRepo;
        LearningPlanDisciplineSemesterRepo lpdsRepo;

        LearningPlan currentLearningPlan;
        List<LearningPlanDiscipline> currentLearningPlanDisciplines;
        List<LearningPlanDisciplineSemester> currentLearningPlanDisciplineSemesters;

        public MarkList(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
            InitializeComponent();

            mRepo = new MarkRepo(ApiEndpoint);
            mtRepo = new MarkTeacherRepo(ApiEndpoint);
            sRepo = new StudentRepo(ApiEndpoint);
            lpRepo = new LearningPlanRepo(ApiEndpoint);
            lpdRepo = new LearningPlanDisciplineRepo(ApiEndpoint);
            lpdsRepo = new LearningPlanDisciplineSemesterRepo(ApiEndpoint);
        }

        private void MarkList_Load(object sender, EventArgs e)
        {
            IntPtr pIcon = Resources.five.GetHicon();
            Icon = Icon.FromHandle(pIcon);

            LoadStudentList();
        }

        private void LoadStudentList()
        {
            var students = sRepo.all()
                            .OrderBy(s => s.f)
                            .ThenBy(s => s.i)
                            .ThenBy(s => s.o)
                            .ToList();
            var stView = StudentView.StudentsToView(students);

            StudentGrid.DataSource = stView;

            StudentGrid.Columns["id"].Visible = false;
            StudentGrid.Columns["fio"].Visible = false;
            StudentGrid.Columns["zach_number"].Visible = false;
            StudentGrid.Columns["birth_date"].Visible = false;
            StudentGrid.Columns["address"].Visible = false;
            StudentGrid.Columns["phone"].Visible = false;
            StudentGrid.Columns["orders"].Visible = false;
            StudentGrid.Columns["starosta"].Visible = false;
            StudentGrid.Columns["n_factor"].Visible = false;
            StudentGrid.Columns["paid_edu"].Visible = false;
            StudentGrid.Columns["expelled"].Visible = false;

            StudentGrid.Columns["summary"].HeaderText = "Студенты";
            StudentGrid.Columns["summary"].Width = StudentGrid.Width - 20;
        }

        private void StudentGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var studentId = ((List<StudentView>)StudentGrid.DataSource)[e.RowIndex].id;

            ReloadLearningPlanList(studentId);
        }

        private void ReloadLearningPlanList(int studentId)
        {
            var plans = sRepo.learningPlans(studentId);
            var planView = StudentLearningPlanWithPeriodsView.fromNetData(plans);

            PlansGrid.DataSource = planView;
            FormatPlansView();
        }

        private void FormatPlansView()
        {
            PlansGrid.Columns["id"].Visible = false;
            PlansGrid.Columns["student_id"].Visible = false;
            PlansGrid.Columns["learning_plan_id"].Visible = false;
            PlansGrid.Columns["plan_desc"].HeaderText = "Учебный план";
            PlansGrid.Columns["plan_desc"].Width = PlansGrid.Width - 200;
            PlansGrid.Columns["from"].HeaderText = "Начало периода";
            PlansGrid.Columns["from"].Width = 80;
            PlansGrid.Columns["to"].HeaderText = "Конец периода";
            PlansGrid.Columns["to"].Width = 80;
        }

        private void MarkList_Resize(object sender, EventArgs e)
        {
            RightTopLeftPlanPanel.Width = (int)Math.Floor((double)RightTopPanel.Width - 200);
        }

        private void PlansGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var studentPlanPeriod = ((List<StudentLearningPlanWithPeriodsView>)PlansGrid.DataSource)[e.RowIndex];

            currentLearningPlan = lpRepo.get(studentPlanPeriod.learning_plan_id);
            currentLearningPlanDisciplines = lpdRepo.learningPlanAll(currentLearningPlan.id);
            var discIdDict = currentLearningPlanDisciplines.ToDictionary(d => d.id, d => d.name);
            currentLearningPlanDisciplineSemesters = lpdsRepo.learningPlanAll(studentPlanPeriod.learning_plan_id);

            var semesters = currentLearningPlanDisciplineSemesters
                .Select(lpds => lpds.semester)
                .OrderBy(sn => sn)
                .Distinct()
                .ToList();
            var semesterSpans = semesters.ToDictionary(s => s, s => new Tuple<DateTime, DateTime>(
                    new DateTime(currentLearningPlan.starting_year + ((s % 2 == 0) ? 1 : 0) + (int)Math.Floor((double)(s - 1) / 2), (s % 2 == 0) ? 2 : 9, 1),
                    new DateTime(currentLearningPlan.starting_year + 1 + (int)Math.Floor((double)(s - 1) / 2), (s % 2 == 0) ? 8 : 1, 31)
                ));

            var studentSemestersWithYear = new List<Tuple<int, int>>();
            var studentSemesters = new List<int>();
            for (int i = 0; i < semesters.Count; i++)
            {
                var semester = semesters[i];
                if (studentPlanPeriod.from <= semesterSpans[semester].Item2 &&
                    semesterSpans[semester].Item1 <= studentPlanPeriod.to)
                {
                    studentSemesters.Add(semester);
                    studentSemestersWithYear.Add(
                        new Tuple<int, int>(currentLearningPlan.starting_year + (int)Math.Floor((double)(semester - 1) / 2),
                        (semester % 2 == 1) ? 1 : 2));
                }
            }

            var studentDisciplineSemesters = currentLearningPlanDisciplineSemesters
                .Where(sm => studentSemesters.Contains(sm.semester))
                .OrderBy(s => s.semester)
                .ThenBy(s => discIdDict[s.learning_plan_discipline_id])
                .ToList();
            var dsViews = DisciplineSemesterView.FromLpdsList(studentDisciplineSemesters, discIdDict);

            var semesterIntList = dsViews
                .Select(dsv => dsv.semester)
                .Distinct()
                .OrderBy(s => s)
                .ToList();
            var semesterViews = IntegerView.FromIntegerList(semesterIntList);

            SemestersGrid.DataSource = semesterViews;
            SemestersGrid.Columns["value"].HeaderText = "Семестр";
            SemestersGrid.Columns["value"].Width = SemestersGrid.Width - 20;
            //PlanGridView.DataSource = dsViews;
            //FormatSemesterView();
        }
    }
}
