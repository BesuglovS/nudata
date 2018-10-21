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
    public partial class LearningPlanList : Form
    {
        private string ApiEndpoint;
        LearningPlanRepo lpRepo;
        LearningPlanDisciplineRepo lpdRepo;
        LearningPlanDisciplineSemesterRepo lpdsRepo;

        FacultyRepo fRepo;

        List<Faculty> Faculties;
        List<LearningPlan> LearningPlans;
        public LearningPlanList(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
            InitializeComponent();                             
        }

        private void RefreshLearningPlanList()
        {
            LearningPlans = lpRepo.all()
                .OrderBy(lp => lp.starting_year)
                .ThenBy(lp => lp.speciality_code)
                .ThenBy(lp => lp.speciality_name)
                .ToList();

            LearningPlanGridView.DataSource = LearningPlans;
            LearningPlanGridView.Columns["id"].Visible = false;
            LearningPlanGridView.Columns["speciality_code"].HeaderText = "Код направления/специальности";
            LearningPlanGridView.Columns["speciality_name"].HeaderText = "Название направления/специальности";
            LearningPlanGridView.Columns["profile"].Visible = false;
            LearningPlanGridView.Columns["starting_year"].HeaderText = "Год начала обучения";
            LearningPlanGridView.Columns["education_standard"].Visible = false;
            LearningPlanGridView.Columns["faculty_id"].Visible = false;
        }

        private void LearningPlanList_Load(object sender, EventArgs e)
        {
            IntPtr pIcon = Resources.applebooks.GetHicon();
            Icon = Icon.FromHandle(pIcon);

            lpRepo = new LearningPlanRepo(ApiEndpoint);
            lpdRepo = new LearningPlanDisciplineRepo(ApiEndpoint);
            lpdsRepo = new LearningPlanDisciplineSemesterRepo(ApiEndpoint);
            fRepo = new FacultyRepo(ApiEndpoint);

            Faculties = fRepo.all().OrderBy(f => f.sorting_order).ToList();
            lpFaculty.DisplayMember = "name";
            lpFaculty.ValueMember = "id";
            lpFaculty.DataSource = Faculties;

            RefreshLearningPlanList();
        }

        private void addLP_Click(object sender, EventArgs e)
        {
            var startingYear = 0;
            try
            {
                startingYear = int.Parse(lpStartingYear.Text);
            }
            catch{}

            var newLearningPlan = new LearningPlan()
            {
                speciality_code = lpSpecialityCode.Text,
                speciality_name = lpSpecialityName.Text,
                profile = lpProfile.Text,
                starting_year = startingYear,
                education_standard = lpEducationStandard.Text,
                faculty_id = (int)lpFaculty.SelectedValue
            };
            lpRepo.add(newLearningPlan);

            RefreshLearningPlanList();
        }

        private void updateLP_Click(object sender, EventArgs e)
        {
            if (LearningPlanGridView.SelectedCells.Count > 0)
            {
                var startingYear = 0;
                try
                {
                    startingYear = int.Parse(lpStartingYear.Text);
                }
                catch { }

                var plan = ((List<LearningPlan>)LearningPlanGridView.DataSource)[LearningPlanGridView.SelectedCells[0].RowIndex];


                plan.speciality_code = lpSpecialityCode.Text;
                plan.speciality_name = lpSpecialityName.Text;
                plan.profile = lpProfile.Text;
                plan.starting_year = startingYear;
                plan.education_standard = lpEducationStandard.Text;
                plan.faculty_id = (int)lpFaculty.SelectedValue;

                lpRepo.update(plan, plan.id);

                RefreshLearningPlanList();
            }
        }

        private void removeLP_Click(object sender, EventArgs e)
        {
            if (LearningPlanGridView.SelectedCells.Count > 0)
            {
                var plan = ((List<LearningPlan>)LearningPlanGridView.DataSource)[LearningPlanGridView.SelectedCells[0].RowIndex];

                lpRepo.delete(plan.id);

                RefreshLearningPlanList();
            }
        }

        private void LearningPlanGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var plan = ((List<LearningPlan>)LearningPlanGridView.DataSource)[LearningPlanGridView.SelectedCells[0].RowIndex];

            lpSpecialityCode.Text = plan.speciality_code;
            lpSpecialityName.Text = plan.speciality_name;
            lpProfile.Text = plan.profile;
            lpStartingYear.Text = plan.starting_year.ToString();
            lpEducationStandard.Text = plan.education_standard;
            lpFaculty.SelectedValue = plan.faculty_id;

            RefreshLearningPlanDisciplinesList(plan.id);
        }

        private void RefreshLearningPlanDisciplinesList(int planId)
        {
            var disciplines = lpdRepo.learningPlanAll(planId);

            DisciplinesDataGrid.DataSource = disciplines;

            DisciplinesDataGrid.Columns["id"].Visible = false;
            DisciplinesDataGrid.Columns["code"].HeaderText = "Код";
            DisciplinesDataGrid.Columns["name"].HeaderText = "Наименование";
            DisciplinesDataGrid.Columns["total_hours"].HeaderText = "Общее количество часов";
            DisciplinesDataGrid.Columns["contact_work_hours"].HeaderText = "Контактная работа";
            DisciplinesDataGrid.Columns["independent_work_hours"].HeaderText = "Саомстоятельная работа";
            DisciplinesDataGrid.Columns["control_hours"].HeaderText = "Контроль";
            DisciplinesDataGrid.Columns["z_count"].HeaderText = "Количество ЗЕТ";
            DisciplinesDataGrid.Columns["learning_plan_id"].Visible = false;
        }

        private void addLPD_Click(object sender, EventArgs e)
        {
            var total_hours = 0;
            var contact_work_hours = 0;
            var independent_work_hours = 0;
            var control_hours = 0;
            var z_count = 0;

            try
            {
                total_hours = int.Parse(lpdTotalHours.Text);
                contact_work_hours = int.Parse(lpdContactWorkHours.Text);
                independent_work_hours = int.Parse(lpdIndependentWorkHours.Text);
                control_hours = int.Parse(lpdControlHours.Text);
                z_count = int.Parse(lpdZCount.Text);
            }
            catch { }

            if (LearningPlanGridView.SelectedCells.Count > 0)
            {
                var planId = ((List<LearningPlan>)LearningPlanGridView.DataSource)[LearningPlanGridView.SelectedCells[0].RowIndex].id;

                var newLearningPlanDiscipline = new LearningPlanDiscipline()
                {
                    code = lpdCode.Text,
                    name = lpdName.Text,
                    total_hours = total_hours,
                    contact_work_hours = contact_work_hours,
                    independent_work_hours = independent_work_hours,
                    control_hours = control_hours,
                    z_count = z_count,
                    learning_plan_id = planId
                };

                lpdRepo.add(newLearningPlanDiscipline);

                RefreshLearningPlanDisciplinesList(planId);
            }
        }

        private void updateLPD_Click(object sender, EventArgs e)
        {
            if (DisciplinesDataGrid.SelectedCells.Count > 0)
            {
                var total_hours = 0;
                var contact_work_hours = 0;
                var independent_work_hours = 0;
                var control_hours = 0;
                var z_count = 0;

                try
                {
                    total_hours = int.Parse(lpdTotalHours.Text);
                    contact_work_hours = int.Parse(lpdContactWorkHours.Text);
                    independent_work_hours = int.Parse(lpdIndependentWorkHours.Text);
                    control_hours = int.Parse(lpdControlHours.Text);
                    z_count = int.Parse(lpdZCount.Text);
                }
                catch { }

                var discipline = ((List<LearningPlanDiscipline>)DisciplinesDataGrid.DataSource)[DisciplinesDataGrid.SelectedCells[0].RowIndex];

                discipline.code = lpdCode.Text;
                discipline.name = lpdName.Text;
                discipline.total_hours = total_hours;
                discipline.contact_work_hours = contact_work_hours;
                discipline.independent_work_hours = independent_work_hours;
                discipline.control_hours = control_hours;
                discipline.z_count = z_count;

                lpdRepo.update(discipline, discipline.id);

                var planId = ((List<LearningPlan>)LearningPlanGridView.DataSource)[LearningPlanGridView.SelectedCells[0].RowIndex].id;

                RefreshLearningPlanDisciplinesList(planId);
            }
        }

        private void removeLPD_Click(object sender, EventArgs e)
        {
            if (DisciplinesDataGrid.SelectedCells.Count > 0)
            {
                var discipline = ((List<LearningPlanDiscipline>)DisciplinesDataGrid.DataSource)[DisciplinesDataGrid.SelectedCells[0].RowIndex];

                lpdRepo.delete(discipline.id);

                var planId = ((List<LearningPlan>)LearningPlanGridView.DataSource)[LearningPlanGridView.SelectedCells[0].RowIndex].id;

                RefreshLearningPlanDisciplinesList(planId);
            }
        }

        private void DisciplinesGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var discipline = ((List<LearningPlanDiscipline>)DisciplinesDataGrid.DataSource)[DisciplinesDataGrid.SelectedCells[0].RowIndex];

            lpdCode.Text = discipline.code;
            lpdName.Text = discipline.name;
            lpdTotalHours.Text = discipline.total_hours.ToString();
            lpdContactWorkHours.Text = discipline.contact_work_hours.ToString();
            lpdIndependentWorkHours.Text = discipline.independent_work_hours.ToString();
            lpdControlHours.Text = discipline.control_hours.ToString();
            lpdZCount.Text = discipline.z_count.ToString();

            RefreshLearningPlanDisciplineSemesterList(discipline.id);
        }

        private void RefreshLearningPlanDisciplineSemesterList(int disciplineId)
        {
            var semesters = lpdsRepo.learningPlanDisciplineAll(disciplineId);

            DisciplineSemestersDataGrid.DataSource = semesters;

            DisciplineSemestersDataGrid.Columns["id"].Visible = false;
            DisciplineSemestersDataGrid.Columns["semester"].HeaderText = "Семестр";
            DisciplineSemestersDataGrid.Columns["lecture_hours"].HeaderText = "Лекции";
            DisciplineSemestersDataGrid.Columns["lab_hours"].HeaderText = "Лабораторные";
            DisciplineSemestersDataGrid.Columns["practice_hours"].HeaderText = "Практика";
            DisciplineSemestersDataGrid.Columns["independent_work_hours"].HeaderText = "Саомстоятельная работа";
            DisciplineSemestersDataGrid.Columns["control_hours"].HeaderText = "Контроль";
            DisciplineSemestersDataGrid.Columns["z_count"].HeaderText = "Количество ЗЕТ";
            DisciplineSemestersDataGrid.Columns["zachet"].HeaderText = "Зачёт";
            DisciplineSemestersDataGrid.Columns["exam"].HeaderText = "Экзамен";
            DisciplineSemestersDataGrid.Columns["zachet_with_mark"].HeaderText = "Зачёт с оценкой";
            DisciplineSemestersDataGrid.Columns["course_project"].HeaderText = "Курсовой проект";
            DisciplineSemestersDataGrid.Columns["course_task"].HeaderText = "Курсовая работа";
            DisciplineSemestersDataGrid.Columns["control_task"].HeaderText = "Контрольная работа";
            DisciplineSemestersDataGrid.Columns["learning_plan_discipline_id"].Visible = false;
        }

        private void addLPDS_Click(object sender, EventArgs e)
        {
            var semester = 0;
            var lecture_hours = 0;
            var lab_hours = 0;
            var practice_hours = 0;
            var independent_work_hours = 0;
            var control_hours = 0;
            var z_count = 0;

            try
            {
                semester = int.Parse(lpdsSemester.Text);
                lecture_hours = int.Parse(lpdsLectureHours.Text);
                lab_hours = int.Parse(lpdsLabHours.Text);
                practice_hours = int.Parse(lpdsPracticeHours.Text);
                independent_work_hours = int.Parse(lpdsIndependentWorkHours.Text);
                control_hours = int.Parse(lpdsControlHours.Text);
                z_count = int.Parse(lpdsZCount.Text);
            }
            catch { }

            if (LearningPlanGridView.SelectedCells.Count > 0)
            {
                var discipline = ((List<LearningPlanDiscipline>)DisciplinesDataGrid.DataSource)[DisciplinesDataGrid.SelectedCells[0].RowIndex];

                var newLearningPlanDisciplineSemester = new LearningPlanDisciplineSemester()
                {
                    semester = semester,
                    lecture_hours = lecture_hours,
                    lab_hours = lab_hours,
                    practice_hours = practice_hours,
                    independent_work_hours = independent_work_hours,
                    control_hours = control_hours,
                    z_count = z_count,
                    zachet = lpdsZachet.Checked,
                    exam = lpdsExam.Checked,
                    zachet_with_mark = lpdsZachetWithMark.Checked,
                    course_project = lpdsCourseProject.Checked,
                    course_task = lpdsCourseTask.Checked,
                    control_task = lpdsControlTask.Checked,
                    learning_plan_discipline_id = discipline.id
                };

                lpdsRepo.add(newLearningPlanDisciplineSemester);                
            }
        }

        private void updateLPDS_Click(object sender, EventArgs e)
        {
            if (DisciplineSemestersDataGrid.SelectedCells.Count > 0)
            {
                var semester = 0;
                var lecture_hours = 0;
                var lab_hours = 0;
                var practice_hours = 0;
                var independent_work_hours = 0;
                var control_hours = 0;
                var z_count = 0;

                try
                {
                    semester = int.Parse(lpdsSemester.Text);
                    lecture_hours = int.Parse(lpdsLectureHours.Text);
                    lab_hours = int.Parse(lpdsLabHours.Text);
                    practice_hours = int.Parse(lpdsPracticeHours.Text);
                    independent_work_hours = int.Parse(lpdsIndependentWorkHours.Text);
                    control_hours = int.Parse(lpdsControlHours.Text);
                    z_count = int.Parse(lpdsZCount.Text);
                }
                catch { }

                var DisciplineSemester = ((List<LearningPlanDisciplineSemester>)DisciplineSemestersDataGrid.DataSource)[DisciplineSemestersDataGrid.SelectedCells[0].RowIndex];

                DisciplineSemester.semester = semester;
                DisciplineSemester.lecture_hours = lecture_hours;
                DisciplineSemester.lab_hours = lab_hours;
                DisciplineSemester.practice_hours = practice_hours;
                DisciplineSemester.independent_work_hours = independent_work_hours;
                DisciplineSemester.control_hours = control_hours;
                DisciplineSemester.z_count = z_count;
                DisciplineSemester.zachet = lpdsZachet.Checked;
                DisciplineSemester.exam = lpdsExam.Checked;
                DisciplineSemester.zachet_with_mark = lpdsZachetWithMark.Checked;
                DisciplineSemester.course_project = lpdsCourseProject.Checked;
                DisciplineSemester.course_task = lpdsCourseTask.Checked;
                DisciplineSemester.control_task = lpdsControlTask.Checked;

                lpdsRepo.update(DisciplineSemester, DisciplineSemester.id);

                var discipline = ((List<LearningPlanDiscipline>)DisciplinesDataGrid.DataSource)[DisciplinesDataGrid.SelectedCells[0].RowIndex];

                RefreshLearningPlanDisciplineSemesterList(discipline.id);
            }
        }

        private void removeLPDS_Click(object sender, EventArgs e)
        {
            if (DisciplineSemestersDataGrid.SelectedCells.Count > 0)
            {
                var semester = ((List<LearningPlanDisciplineSemester>)DisciplineSemestersDataGrid.DataSource)[DisciplineSemestersDataGrid.SelectedCells[0].RowIndex];

                lpdsRepo.delete(semester.id);

                var discipline = ((List<LearningPlanDiscipline>)DisciplinesDataGrid.DataSource)[DisciplinesDataGrid.SelectedCells[0].RowIndex];

                RefreshLearningPlanDisciplineSemesterList(discipline.id);
            }
        }

        private void DisciplineSemestersDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var DisciplineSemester = ((List<LearningPlanDisciplineSemester>)DisciplineSemestersDataGrid.DataSource)[DisciplineSemestersDataGrid.SelectedCells[0].RowIndex];

            lpdsSemester.Text = DisciplineSemester.semester.ToString();
            lpdsLectureHours.Text = DisciplineSemester.lecture_hours.ToString();
            lpdsLabHours.Text = DisciplineSemester.lab_hours.ToString();
            lpdsPracticeHours.Text = DisciplineSemester.practice_hours.ToString();
            lpdsIndependentWorkHours.Text = DisciplineSemester.independent_work_hours.ToString();
            lpdsControlHours.Text = DisciplineSemester.control_hours.ToString();
            lpdsZCount.Text = DisciplineSemester.z_count.ToString();
            lpdsZachet.Checked = DisciplineSemester.zachet;
            lpdsExam.Checked = DisciplineSemester.exam;
            lpdsZachetWithMark.Checked = DisciplineSemester.zachet_with_mark;
            lpdsCourseProject.Checked = DisciplineSemester.course_project;
            lpdsCourseProject.Checked = DisciplineSemester.course_task;
            lpdsControlTask.Checked = DisciplineSemester.control_task;
        }
    }
}
