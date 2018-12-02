using nudata.DomainClasses.Main;
using nudata.nubackRepos;
using nudata.Properties;
using nudata.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
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
            LearningPlanGridView.Columns["name"].HeaderText = "Название";
            LearningPlanGridView.Columns["speciality_code"].HeaderText = "Код направления / специальности";
            LearningPlanGridView.Columns["speciality_code"].Width = 60;
            LearningPlanGridView.Columns["speciality_name"].HeaderText = "Название направления / специальности";
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
                name = lpName.Text,
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

                plan.name = lpName.Text;
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

            lpName.Text = plan.name;
            lpSpecialityCode.Text = plan.speciality_code;
            lpSpecialityName.Text = plan.speciality_name;
            lpProfile.Text = plan.profile;
            lpStartingYear.Text = plan.starting_year.ToString();
            lpEducationStandard.Text = plan.education_standard;
            lpFaculty.SelectedValue = plan.faculty_id;

            DisciplineSemestersDataGrid.DataSource = null;

            RefreshLearningPlanDisciplinesList(plan.id);
        }

        private void RefreshLearningPlanDisciplinesList(int planId)
        {
            var disciplines = lpdRepo.learningPlanAll(planId)
                .OrderBy(d => d.order)
                .ThenBy(d => d.name)
                .ToList();

            DisciplinesDataGrid.DataSource = disciplines;

            DisciplinesDataGrid.Columns["id"].Visible = false;
            DisciplinesDataGrid.Columns["order"].HeaderText = "№";
            DisciplinesDataGrid.Columns["order"].Width = 30;
            DisciplinesDataGrid.Columns["code"].HeaderText = "Код";
            DisciplinesDataGrid.Columns["name"].HeaderText = "Наименование";
            DisciplinesDataGrid.Columns["total_hours"].HeaderText = "Общее количество часов";
            DisciplinesDataGrid.Columns["contact_work_hours"].HeaderText = "Контактная работа";
            DisciplinesDataGrid.Columns["independent_work_hours"].HeaderText = "Самостоятельная работа";
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
                    learning_plan_id = planId,
                    order = decimal.ToInt32(order.Value)
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
                discipline.order = decimal.ToInt32(order.Value);

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
            order.Value = discipline.order;

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
            DisciplineSemestersDataGrid.Columns["independent_work_hours"].HeaderText = "Самостоятельная работа";
            DisciplineSemestersDataGrid.Columns["control_hours"].HeaderText = "Контроль";
            DisciplineSemestersDataGrid.Columns["z_count"].HeaderText = "Количество ЗЕТ";
            DisciplineSemestersDataGrid.Columns["zachet"].HeaderText = "Зачёт";
            DisciplineSemestersDataGrid.Columns["exam"].HeaderText = "Экзамен";
            DisciplineSemestersDataGrid.Columns["zachet_with_mark"].HeaderText = "Зачёт с оценкой";
            DisciplineSemestersDataGrid.Columns["course_project"].HeaderText = "Курсовой проект";
            DisciplineSemestersDataGrid.Columns["course_task"].HeaderText = "Курсовая работа";
            DisciplineSemestersDataGrid.Columns["control_task"].HeaderText = "Контрольная работа";
            DisciplineSemestersDataGrid.Columns["referat"].HeaderText = "Реферат";
            DisciplineSemestersDataGrid.Columns["essay"].HeaderText = "Эссе";
            DisciplineSemestersDataGrid.Columns["individual_hours"].HeaderText = "Индивидуальные часы";
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
            var individual_hours = 0;
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
                individual_hours = int.Parse(lpdsIndividualHours.Text);
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
                    referat = lpdsReferat.Checked,
                    essay = lpdsEssay.Checked,
                    individual_hours = individual_hours,
                    learning_plan_discipline_id = discipline.id
                };

                lpdsRepo.add(newLearningPlanDisciplineSemester);

                RefreshLearningPlanDisciplineSemesterList(discipline.id);
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
                var individual_hours = 0;
                var z_count = 0;

                try
                {
                    semester = int.Parse(lpdsSemester.Text);
                    lecture_hours = int.Parse(lpdsLectureHours.Text);
                    lab_hours = int.Parse(lpdsLabHours.Text);
                    practice_hours = int.Parse(lpdsPracticeHours.Text);
                    independent_work_hours = int.Parse(lpdsIndependentWorkHours.Text);
                    control_hours = int.Parse(lpdsControlHours.Text);
                    individual_hours = int.Parse(lpdsIndividualHours.Text);
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
                DisciplineSemester.referat = lpdsReferat.Checked;
                DisciplineSemester.essay = lpdsEssay.Checked;
                DisciplineSemester.individual_hours = individual_hours;

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
            lpdsReferat.Checked = DisciplineSemester.referat;
            lpdsEssay.Checked = DisciplineSemester.essay;
            lpdsIndividualHours.Text = DisciplineSemester.individual_hours.ToString();
        }

        private void importXMLPlanDisciplines_Click(object sender, EventArgs e)
        {
            var text = Clipboard.GetText(TextDataFormat.UnicodeText);

            var controlTask = ControlTaskExists.Checked;

            var split = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None)
                .Select(line => line.Split('\t').ToList())
                .Where(line => line.Count == 73 + (controlTask ? 1 : 0))
                .ToList();

            var cti = controlTask ? 1 : 0;

            int planId = -1;
            if (LearningPlanGridView.SelectedCells.Count > 0)
            {
                planId = ((List<LearningPlan>)LearningPlanGridView.DataSource)[LearningPlanGridView.SelectedCells[0].RowIndex].id;
            } else
            {
                return;
            }

            for (int i = 0; i < split.Count; i++)
            {
                var disSplit = split[i];

                if (disSplit[2].Trim() == "")
                {
                    continue;
                }
                                    

                var newLearningPlanDiscipline = new LearningPlanDiscipline()
                {
                    code = disSplit[1],
                    name = disSplit[2],
                    total_hours = string.IsNullOrEmpty(disSplit[10 + cti]) ? 0 : int.Parse(disSplit[10 + cti]),
                    contact_work_hours = string.IsNullOrEmpty(disSplit[12 + cti]) ? 0 : int.Parse(disSplit[12 + cti]),
                    independent_work_hours = string.IsNullOrEmpty(disSplit[13 + cti]) ? 0 : int.Parse(disSplit[13 + cti]),
                    control_hours = string.IsNullOrEmpty(disSplit[14 + cti]) ? 0 : int.Parse(disSplit[14 + cti]),
                    z_count = string.IsNullOrEmpty(disSplit[16 + cti]) ? 0 : int.Parse(disSplit[16 + cti]),
                    learning_plan_id = planId
                };

                var examSemesterList = ParseAttestationSemesters(disSplit[5]);
                var zachSemesterList = ParseAttestationSemesters(disSplit[6]);
                var zachWithMarkSemesterList = ParseAttestationSemesters(disSplit[7]);
                var courseProjectSemesterList = ParseAttestationSemesters(disSplit[8]);
                var courseTaskSemesterList = ParseAttestationSemesters(disSplit[9]);
                var controlTaskList = new List<int>();
                if (controlTask)
                {
                    controlTaskList = ParseAttestationSemesters(disSplit[10]);
                }

                var discIdString = lpdRepo.add(newLearningPlanDiscipline);
                var disciplineId = int.Parse(discIdString);
                int currentSemester;

                var SemesterFieldsDict = new Dictionary<int, List<int>> {
                    { 1, new List<int> { 17 + cti, 18 + cti, 19 + cti, 20 + cti, 21 + cti, 22 + cti } },
                    { 2, new List<int> { 23 + cti, 24 + cti, 25 + cti, 26 + cti, 27 + cti, 28 + cti } },
                    { 3, new List<int> { 29 + cti, 30 + cti, 31 + cti, 32 + cti, 33 + cti, 34 + cti } },
                    { 4, new List<int> { 35 + cti, 36 + cti, 37 + cti, 38 + cti, 39 + cti, 40 + cti } },
                    { 5, new List<int> { 41 + cti, 42 + cti, 43 + cti, 44 + cti, 45 + cti, 46 + cti } },
                    { 6, new List<int> { 47 + cti, 48 + cti, 49 + cti, 50 + cti, 51 + cti, 52 + cti } },
                    { 7, new List<int> { 53 + cti, 54 + cti, 55 + cti, 56 + cti, 57 + cti, 58 + cti } },
                    { 8, new List<int> { 59 + cti, 60 + cti, 61 + cti, 62 + cti, 63 + cti, 64 + cti } },
                };

                for (int j = 1; j <= 8; j++)
                {
                    currentSemester = j;
                    var semesterFields = SemesterFieldsDict[j];
                    if (disSplit[semesterFields[5]] != "") // Z count
                    {
                        var newLearningPlanDisciplineSemester = new LearningPlanDisciplineSemester()
                        {
                            semester = currentSemester,
                            lecture_hours = IntParseOrZero(disSplit[semesterFields[0]]),
                            lab_hours = IntParseOrZero(disSplit[semesterFields[1]]),
                            practice_hours = IntParseOrZero(disSplit[semesterFields[2]]),
                            independent_work_hours = IntParseOrZero(disSplit[semesterFields[3]]),
                            control_hours = IntParseOrZero(disSplit[semesterFields[4]]),
                            z_count = IntParseOrZero(disSplit[semesterFields[5]]),
                            zachet = zachSemesterList.Contains(currentSemester),
                            exam = examSemesterList.Contains(currentSemester),
                            zachet_with_mark = zachWithMarkSemesterList.Contains(currentSemester),
                            course_project = courseProjectSemesterList.Contains(currentSemester),
                            course_task = courseTaskSemesterList.Contains(currentSemester),
                            control_task = controlTaskList.Contains(currentSemester),
                            learning_plan_discipline_id = disciplineId
                        };

                        lpdsRepo.add(newLearningPlanDisciplineSemester);
                    }
                }
                
            }

            RefreshLearningPlanDisciplinesList(planId);

            var eprst = 999;
        }

        private int IntParseOrZero(string s)
        {
            try
            {
                return int.Parse(s);
            }
            catch {
                return 0;
            }            
        }

        private List<int> ParseAttestationSemesters(string sems)
        {
            var result = new List<int>();
            while(sems.Contains('-'))
            {
                var dashIndex = sems.IndexOf('-');
                if (dashIndex == 0 || dashIndex != sems.Length-1)
                {
                    sems = sems.Remove(dashIndex, 1);
                } else
                {
                    var start = int.Parse(sems[dashIndex - 1].ToString());
                    var end = int.Parse(sems[dashIndex + 1].ToString());
                    
                    if (end>= start)
                    {
                        int ii = start;
                        while (ii <= end)
                        {
                            result.Add(ii);
                            ii++;
                        }
                    }
                }
            }

            result.AddRange(sems.Select(ch => int.Parse(ch.ToString())));

            return result;
        }

        private void importXLSPlanMag_Click(object sender, EventArgs e)
        {
            var text = Clipboard.GetText(TextDataFormat.UnicodeText);

            var Essay = EssayExists.Checked;
            var LawM = lawDM.Checked;

            var split = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None)
                .Select(line => line.Split('\t').ToList())
                .Where(line => line.Count > 2)
                .ToList();

            var essayI = Essay ? 1 : 0;
            var lawI = LawM ? -1 : 0;

            int planId = -1;
            if (LearningPlanGridView.SelectedCells.Count > 0)
            {
                planId = ((List<LearningPlan>)LearningPlanGridView.DataSource)[LearningPlanGridView.SelectedCells[0].RowIndex].id;
            }
            else
            {
                return;
            }

            for (int i = 0; i < split.Count; i++)
            {
                var disSplit = split[i];

                if (disSplit[2].Trim() == "")
                {
                    continue;
                }


                var newLearningPlanDiscipline = new LearningPlanDiscipline()
                {
                    code = disSplit[1],
                    name = disSplit[2],
                    total_hours = string.IsNullOrEmpty(disSplit[13 + essayI + lawI]) ? 0 : int.Parse(disSplit[13 + essayI + lawI]),
                    contact_work_hours = string.IsNullOrEmpty(disSplit[14 + essayI + lawI]) ? 0 : int.Parse(disSplit[14 + essayI + lawI]),
                    independent_work_hours = string.IsNullOrEmpty(disSplit[15 + essayI + lawI]) ? 0 : int.Parse(disSplit[15 + essayI + lawI]),
                    control_hours = string.IsNullOrEmpty(disSplit[16 + essayI + lawI]) ? 0 : int.Parse(disSplit[16 + essayI + lawI]),
                    z_count = string.IsNullOrEmpty(disSplit[18 + essayI + lawI]) ? 0 : int.Parse(disSplit[18 + essayI + lawI]),
                    learning_plan_id = planId
                };

                var examSemesterList = ParseAttestationSemesters(disSplit[5 + lawI]);
                var zachSemesterList = ParseAttestationSemesters(disSplit[6 + lawI]);
                var zachWithMarkSemesterList = ParseAttestationSemesters(disSplit[7 + lawI]);
                var courseProjectSemesterList = ParseAttestationSemesters(disSplit[8 + lawI]);
                var courseTaskSemesterList = ParseAttestationSemesters(disSplit[9 + lawI]);
                var controlTaskList = ParseAttestationSemesters(disSplit[10 + lawI]);
                var referatSemesterList = ParseAttestationSemesters(disSplit[11 + lawI]);
                var essayTaskList = new List<int>();
                if (Essay)
                {
                    essayTaskList = ParseAttestationSemesters(disSplit[12]);
                }

                var discIdString = lpdRepo.add(newLearningPlanDiscipline);
                var disciplineId = int.Parse(discIdString);
                int currentSemester;

                var SemesterFieldsDict = new Dictionary<int, List<int>> {
                    { 1, new List<int> { 19 + essayI + lawI, 20 + essayI + lawI, 21 + essayI + lawI, 22 + essayI + lawI, 23 + essayI + lawI, 24 + essayI + lawI } },
                    { 2, new List<int> { 25 + essayI + lawI, 26 + essayI + lawI, 27 + essayI + lawI, 28 + essayI + lawI, 29 + essayI + lawI, 30 + essayI + lawI } },
                    { 3, new List<int> { 31 + essayI + lawI, 32 + essayI + lawI, 33 + essayI + lawI, 34 + essayI + lawI, 35 + essayI + lawI, 36 + essayI + lawI } },
                    { 4, new List<int> { 37 + essayI + lawI, 38 + essayI + lawI, 39 + essayI + lawI, 40 + essayI + lawI, 41 + essayI + lawI, 42 + essayI + lawI } }
                };

                for (int j = 1; j <= 4; j++)
                {
                    currentSemester = j;
                    var semesterFields = SemesterFieldsDict[j];
                    if (disSplit[semesterFields[5]] != "") // Z count
                    {
                        var newLearningPlanDisciplineSemester = new LearningPlanDisciplineSemester()
                        {
                            semester = currentSemester,
                            lecture_hours = IntParseOrZero(disSplit[semesterFields[0]]),
                            lab_hours = IntParseOrZero(disSplit[semesterFields[1]]),
                            practice_hours = IntParseOrZero(disSplit[semesterFields[2]]),
                            independent_work_hours = IntParseOrZero(disSplit[semesterFields[3]]),
                            control_hours = IntParseOrZero(disSplit[semesterFields[4]]),
                            z_count = IntParseOrZero(disSplit[semesterFields[5]]),
                            zachet = zachSemesterList.Contains(currentSemester),
                            exam = examSemesterList.Contains(currentSemester),
                            zachet_with_mark = zachWithMarkSemesterList.Contains(currentSemester),
                            course_project = courseProjectSemesterList.Contains(currentSemester),
                            course_task = courseTaskSemesterList.Contains(currentSemester),
                            control_task = controlTaskList.Contains(currentSemester),
                            referat = referatSemesterList.Contains(currentSemester),
                            essay = essayTaskList.Contains(currentSemester),
                            learning_plan_discipline_id = disciplineId                            
                        };

                        lpdsRepo.add(newLearningPlanDisciplineSemester);
                    }
                }

            }

            RefreshLearningPlanDisciplinesList(planId);

            var eprst = 999;
        }

        private void importXLSPlanSpec_Click(object sender, EventArgs e)
        {
            var text = Clipboard.GetText(TextDataFormat.UnicodeText);

            var controlTask = ControlTaskExists.Checked;

            var split = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None)
                .Select(line => line.Split('\t').ToList())
                .Where(line => line.Count > 2)
                .ToList();

            var cti = 0;

            int planId = -1;
            if (LearningPlanGridView.SelectedCells.Count > 0)
            {
                planId = ((List<LearningPlan>)LearningPlanGridView.DataSource)[LearningPlanGridView.SelectedCells[0].RowIndex].id;
            }
            else
            {
                return;
            }

            for (int i = 0; i < split.Count; i++)
            {
                var disSplit = split[i];

                if (disSplit[2].Trim() == "")
                {
                    continue;
                }


                var newLearningPlanDiscipline = new LearningPlanDiscipline()
                {
                    code = disSplit[1],
                    name = disSplit[2],
                    total_hours = string.IsNullOrEmpty(disSplit[10 + cti]) ? 0 : int.Parse(disSplit[10 + cti]),
                    contact_work_hours = string.IsNullOrEmpty(disSplit[12 + cti]) ? 0 : int.Parse(disSplit[12 + cti]),
                    independent_work_hours = string.IsNullOrEmpty(disSplit[13 + cti]) ? 0 : int.Parse(disSplit[13 + cti]),
                    control_hours = string.IsNullOrEmpty(disSplit[14 + cti]) ? 0 : int.Parse(disSplit[14 + cti]),
                    z_count = string.IsNullOrEmpty(disSplit[16 + cti]) ? 0 : int.Parse(disSplit[16 + cti]),
                    learning_plan_id = planId
                };

                var examSemesterList = ParseAttestationSemesters(disSplit[5]);
                var zachSemesterList = ParseAttestationSemesters(disSplit[6]);
                var zachWithMarkSemesterList = ParseAttestationSemesters(disSplit[7]);
                var courseProjectSemesterList = ParseAttestationSemesters(disSplit[8]);
                var courseTaskSemesterList = ParseAttestationSemesters(disSplit[9]);
                var controlTaskList = new List<int>();
                if (controlTask)
                {
                    controlTaskList = ParseAttestationSemesters(disSplit[10]);
                }

                var discIdString = lpdRepo.add(newLearningPlanDiscipline);
                var disciplineId = int.Parse(discIdString);
                int currentSemester;

                var SemesterFieldsDict = new Dictionary<int, List<int>> {
                    { 1, new List<int> { 17 + cti, 18 + cti, 19 + cti, 20 + cti, 21 + cti, 22 + cti, 23 + cti } },
                    { 2, new List<int> { 24 + cti, 25 + cti, 26 + cti, 27 + cti, 28 + cti, 29 + cti, 30 + cti } },
                    { 3, new List<int> { 31 + cti, 32 + cti, 33 + cti, 34 + cti, 35 + cti, 36 + cti, 37 + cti } },
                    { 4, new List<int> { 38 + cti, 39 + cti, 40 + cti, 41 + cti, 42 + cti, 43 + cti, 44 + cti } },
                    { 5, new List<int> { 45 + cti, 46 + cti, 47 + cti, 48 + cti, 49 + cti, 50 + cti, 51 + cti } },
                    { 6, new List<int> { 52 + cti, 53 + cti, 54 + cti, 55 + cti, 56 + cti, 57 + cti, 58 + cti } },
                    { 7, new List<int> { 59 + cti, 60 + cti, 61 + cti, 62 + cti, 63 + cti, 64 + cti, 65 + cti } },
                    { 8, new List<int> { 66 + cti, 67 + cti, 68 + cti, 69 + cti, 70 + cti, 71 + cti, 72 + cti } },
                };

                for (int j = 1; j <= 8; j++)
                {
                    currentSemester = j;
                    var semesterFields = SemesterFieldsDict[j];
                    if (disSplit[semesterFields[6]] != "") // Z count
                    {
                        var newLearningPlanDisciplineSemester = new LearningPlanDisciplineSemester()
                        {
                            semester = currentSemester,
                            lecture_hours = IntParseOrZero(disSplit[semesterFields[0]]),
                            lab_hours = IntParseOrZero(disSplit[semesterFields[1]]),
                            practice_hours = IntParseOrZero(disSplit[semesterFields[2]]),
                            individual_hours = IntParseOrZero(disSplit[semesterFields[3]]),
                            independent_work_hours = IntParseOrZero(disSplit[semesterFields[4]]),
                            control_hours = IntParseOrZero(disSplit[semesterFields[5]]),
                            z_count = IntParseOrZero(disSplit[semesterFields[6]]),
                            zachet = zachSemesterList.Contains(currentSemester),
                            exam = examSemesterList.Contains(currentSemester),
                            zachet_with_mark = zachWithMarkSemesterList.Contains(currentSemester),
                            course_project = courseProjectSemesterList.Contains(currentSemester),
                            course_task = courseTaskSemesterList.Contains(currentSemester),
                            control_task = controlTaskList.Contains(currentSemester),
                            learning_plan_discipline_id = disciplineId                            
                        };

                        lpdsRepo.add(newLearningPlanDisciplineSemester);
                    }
                }

            }

            RefreshLearningPlanDisciplinesList(planId);

            var eprst = 999;
        }

        private void RenumeratePlan_Click(object sender, EventArgs e)
        {
            var discList = Clipboard.GetText()
                .Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();            
            
            var plan = ((List<LearningPlan>)LearningPlanGridView.DataSource)[LearningPlanGridView.SelectedCells[0].RowIndex];

            var disciplines = lpdRepo.learningPlanAll(plan.id);

            int newIndex = 1;
            for (int i = 0; i < discList.Count; i++)
            {
                LearningPlanDiscipline disc = null;
                do
                { 
                    disc = disciplines.FirstOrDefault(d => d.name == discList[i] && d.order == 0);

                    if (disc != null)
                    {
                        disc.order = newIndex;
                        lpdRepo.update(disc, disc.id);
                        newIndex++;
                    }
                } while (disc != null);
            }

            MessageBox.Show("Done");
        }
    }
}
