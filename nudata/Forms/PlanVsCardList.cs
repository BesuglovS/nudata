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
    public partial class PlanVsCardList : Form
    {
        private string ApiEndpoint;

        StudentRepo sRepo;
        LearningPlanRepo lpRepo;
        LearningPlanDisciplineRepo lpdRepo;
        LearningPlanDisciplineSemesterRepo lpdsRepo;
        TeacherCardItemRepo tciRepo;

        LearningPlan currentLearningPlan;
        List<LearningPlanDiscipline> currentLearningPlanDisciplines;
        List<LearningPlanDisciplineSemester> currentLearningPlanDisciplineSemesters;

        public PlanVsCardList(string apiEndpoint)
        {
            InitializeComponent();

            ApiEndpoint = apiEndpoint;

            sRepo = new StudentRepo(ApiEndpoint);
            lpRepo = new LearningPlanRepo(ApiEndpoint);
            lpdRepo = new LearningPlanDisciplineRepo(ApiEndpoint);
            lpdsRepo = new LearningPlanDisciplineSemesterRepo(ApiEndpoint);
            tciRepo = new TeacherCardItemRepo(ApiEndpoint);
        }

        private void PlanVsCardList_Load(object sender, EventArgs e)
        {
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

            studentList.DataSource = stView;

            studentList.Columns["id"].Visible = false;
            studentList.Columns["fio"].Visible = false;
            studentList.Columns["zach_number"].Visible = false;
            studentList.Columns["birth_date"].Visible = false;
            studentList.Columns["address"].Visible = false;
            studentList.Columns["phone"].Visible = false;
            studentList.Columns["orders"].Visible = false;
            studentList.Columns["starosta"].Visible = false;
            studentList.Columns["n_factor"].Visible = false;
            studentList.Columns["paid_edu"].Visible = false;
            studentList.Columns["expelled"].Visible = false;

            studentList.Columns["summary"].HeaderText = "Студенты";
            studentList.Columns["summary"].Width = studentList.Width - 20;
        }

        private void reloadStudentList_Click(object sender, EventArgs e)
        {
            LoadStudentList();
        }

        private void studentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var studentId = ((List<StudentView>)studentList.DataSource)[e.RowIndex].id;

            ReloadLearningPlanList(studentId);
        }

        private void ReloadLearningPlanList(int studentId)
        {
            var plans = sRepo.learningPlans(studentId);
            var planView = StudentLearningPlanWithPeriodsView.fromNetData(plans);

            PlansGridView.DataSource = planView;
            FormatPlansView();
        }

        private void FormatPlansView()
        {
            PlansGridView.Columns["id"].Visible = false;
            PlansGridView.Columns["student_id"].Visible = false;
            PlansGridView.Columns["learning_plan_id"].Visible = false;
            PlansGridView.Columns["plan_desc"].HeaderText = "Учебный план";
            PlansGridView.Columns["plan_desc"].Width = PlansGridView.Width - 200;
            PlansGridView.Columns["from"].HeaderText = "Начало периода";
            PlansGridView.Columns["from"].Width = 80;
            PlansGridView.Columns["to"].HeaderText = "Конец периода";
            PlansGridView.Columns["to"].Width = 80;
        }

        private void PlansGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var studentPlanPeriod = ((List<StudentLearningPlanWithPeriodsView>)PlansGridView.DataSource)[e.RowIndex];

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
                    new DateTime(currentLearningPlan.starting_year + ((s % 2 == 0) ? 1 : 0) + (int)Math.Floor((double)(s-1) / 2), (s % 2 == 0) ? 2 : 9, 1),
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
            PlanGridView.DataSource = dsViews;
            FormatSemesterView();

            var studentCardItems = new List<TeacherCardAndItem>();
            for (int i = 0; i < studentSemestersWithYear.Count; i++)
            {
                var semesterStudentCardItems = tciRepo.yearSemesterStudentIdAll(
                    studentSemestersWithYear[i].Item1, 
                    studentSemestersWithYear[i].Item2,
                    studentPlanPeriod.student_id);

                studentCardItems.AddRange(semesterStudentCardItems);
            }

            for (int i = 0; i < studentCardItems.Count; i++)
            {
                studentCardItems[i].semester = studentCardItems[i].semester + (studentCardItems[i].starting_year - currentLearningPlan.starting_year) * 2;
            }

            studentCardItems = studentCardItems
                .OrderBy(i => i.semester)
                .ThenBy(i => i.discipline_name)
                .ToList();

            CardsGridView.DataSource = studentCardItems;

            FormatCardsView();

            var eprst = 999;
        }

        private void FormatCardsView()
        {
            //CardsGridView

            CardsGridView.Columns["id"].Visible = false;
            CardsGridView.Columns["semester"].HeaderText = "Семестр";
            CardsGridView.Columns["semester"].Width = 40;

            CardsGridView.Columns["code"].HeaderText = "Код";
            CardsGridView.Columns["code"].Width = 40;

            CardsGridView.Columns["discipline_name"].HeaderText = "Дисциплина";
            CardsGridView.Columns["discipline_name"].Width = 100;

            CardsGridView.Columns["group_name"].HeaderText = "Группа";
            CardsGridView.Columns["group_name"].Width = 40;

            CardsGridView.Columns["group_count"].HeaderText = "Кол-во групп";
            CardsGridView.Columns["group_count"].Width = 40;

            CardsGridView.Columns["group_students_count"].HeaderText = "Кол-во студентов";
            CardsGridView.Columns["group_students_count"].Width = 40;

            CardsGridView.Columns["lecture_hours"].HeaderText = "Лекции";
            CardsGridView.Columns["lecture_hours"].Width = 40;

            CardsGridView.Columns["lab_hours"].HeaderText = "Лабораторные";
            CardsGridView.Columns["lab_hours"].Width = 40;

            CardsGridView.Columns["practice_hours"].HeaderText = "Практика";
            CardsGridView.Columns["practice_hours"].Width = 40;

            CardsGridView.Columns["exam_hours"].HeaderText = "Экзамен";
            CardsGridView.Columns["exam_hours"].Width = 40;

            CardsGridView.Columns["zach_hours"].HeaderText = "Зачёт";
            CardsGridView.Columns["zach_hours"].Width = 40;

            CardsGridView.Columns["zach_with_mark_hours"].HeaderText = "Зачёт с оценкой";
            CardsGridView.Columns["zach_with_mark_hours"].Width = 40;

            CardsGridView.Columns["course_project_hours"].HeaderText = "Курсовой проект";
            CardsGridView.Columns["course_project_hours"].Width = 40;

            CardsGridView.Columns["course_task_hours"].HeaderText = "Курсовая работа";
            CardsGridView.Columns["course_task_hours"].Width = 40;

            CardsGridView.Columns["control_task_hours"].HeaderText = "Контрольная работа";
            CardsGridView.Columns["control_task_hours"].Width = 40;

            CardsGridView.Columns["referat_hours"].HeaderText = "Реферат";
            CardsGridView.Columns["referat_hours"].Width = 40;

            CardsGridView.Columns["essay_hours"].HeaderText = "Эссе";
            CardsGridView.Columns["essay_hours"].Width = 40;

            CardsGridView.Columns["head_of_practice_hours"].HeaderText = "Руководство практикой";
            CardsGridView.Columns["head_of_practice_hours"].Width = 40;

            CardsGridView.Columns["head_of_vkr_hours"].HeaderText = "Руководство ВКР";
            CardsGridView.Columns["head_of_vkr_hours"].Width = 40;

            CardsGridView.Columns["iga_hours"].HeaderText = "ИГА";
            CardsGridView.Columns["iga_hours"].Width = 40;

            CardsGridView.Columns["nra_hours"].HeaderText = "НРА";
            CardsGridView.Columns["nra_hours"].Width = 40;

            CardsGridView.Columns["nrm_hours"].HeaderText = "НРМ";
            CardsGridView.Columns["nrm_hours"].Width = 40;

            CardsGridView.Columns["individual_hours"].HeaderText = "Инд. часы";
            CardsGridView.Columns["individual_hours"].Width = 40;

            CardsGridView.Columns["teacher_card_id"].Visible = false;

            CardsGridView.Columns["real_teacher_id"].Visible = false;

            CardsGridView.Columns["teacher_id"].Visible = false;

            CardsGridView.Columns["position"].HeaderText = "Должность";
            CardsGridView.Columns["position"].Width = 40;

            CardsGridView.Columns["rate_multiplier"].HeaderText = "Доля ставки";
            CardsGridView.Columns["rate_multiplier"].Width = 40;

            CardsGridView.Columns["academic_degree"].HeaderText = "Учёная степень";
            CardsGridView.Columns["academic_degree"].Width = 40;

            CardsGridView.Columns["academic_rank"].HeaderText = "Учёное звание";
            CardsGridView.Columns["academic_rank"].Width = 40;

            CardsGridView.Columns["department_rank"].HeaderText = "Должность на кафедре";
            CardsGridView.Columns["department_rank"].Width = 40;

            CardsGridView.Columns["department_id"].Visible = false;

            CardsGridView.Columns["position_type"].HeaderText = "Условие привелчения";
            CardsGridView.Columns["position_type"].Width = 40;

            CardsGridView.Columns["starting_year"].HeaderText = "Начало учебного года";
            CardsGridView.Columns["starting_year"].Width = 40;
        }

        private void FormatSemesterView()
        {
            PlanGridView.Columns["id"].Visible = false;
            PlanGridView.Columns["semester"].HeaderText = "Семестр";
            PlanGridView.Columns["discipline_name"].HeaderText = "Дисциплина";
            PlanGridView.Columns["lecture_hours"].HeaderText = "Лекции";
            PlanGridView.Columns["lab_hours"].HeaderText = "Лабораторные";
            PlanGridView.Columns["practice_hours"].HeaderText = "Практика";
            PlanGridView.Columns["independent_work_hours"].HeaderText = "Самостоятельная работа";
            PlanGridView.Columns["control_hours"].HeaderText = "Контроль";
            PlanGridView.Columns["z_count"].HeaderText = "Количество ЗЕТ";
            PlanGridView.Columns["zachet"].HeaderText = "Зачёт";
            PlanGridView.Columns["exam"].HeaderText = "Экзамен";
            PlanGridView.Columns["zachet_with_mark"].HeaderText = "Зачёт с оценкой";
            PlanGridView.Columns["course_project"].HeaderText = "Курсовой проект";
            PlanGridView.Columns["course_task"].HeaderText = "Курсовая работа";
            PlanGridView.Columns["control_task"].HeaderText = "Контрольная работа";
            PlanGridView.Columns["referat"].HeaderText = "Реферат";
            PlanGridView.Columns["essay"].HeaderText = "Эссе";
            PlanGridView.Columns["individual_hours"].HeaderText = "Индивидуальные часы";
            PlanGridView.Columns["learning_plan_discipline_id"].Visible = false;

            PlanGridView.Columns["semester"].Width = 40;
            PlanGridView.Columns["discipline_name"].Width = 100;
            PlanGridView.Columns["lecture_hours"].Width = 50;
            PlanGridView.Columns["lab_hours"].Width = 50;
            PlanGridView.Columns["practice_hours"].Width = 50;
            PlanGridView.Columns["independent_work_hours"].Width = 50;
            PlanGridView.Columns["control_hours"].Width = 50;
            PlanGridView.Columns["z_count"].Width = 50;
            PlanGridView.Columns["zachet"].Width = 40;
            PlanGridView.Columns["exam"].Width = 40;
            PlanGridView.Columns["zachet_with_mark"].Width = 40;
            PlanGridView.Columns["course_project"].Width = 40;
            PlanGridView.Columns["course_task"].Width = 40;
            PlanGridView.Columns["control_task"].Width = 40;
            PlanGridView.Columns["referat"].Width = 40;
            PlanGridView.Columns["essay"].Width = 40;
            PlanGridView.Columns["individual_hours"].Width = 50;            
        }

        private void PlanVsCardList_Resize(object sender, EventArgs e)
        {
            RightLeftPanel.Width = (int)Math.Floor((double)RightPanel.Width / 2);
        }

        private void CardsGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string stringValue = e.Value.ToString();

            if (stringValue == "0" || stringValue == "0.00" || stringValue == "0,00")
            {
                e.CellStyle.ForeColor = Color.FromArgb(200, 200, 200);
            }

            if (e.ColumnIndex != 2 && e.ColumnIndex != 3)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
}
