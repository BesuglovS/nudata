using nudata.Core;
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
        MarkTypeRepo mtypeRepo;
        MarkTypeOptionRepo mtoRepo;
        TeacherRepo tRepo;

        int currentStudentId;
        int currentSemester;
        LearningPlan currentLearningPlan;
        List<LearningPlanDiscipline> currentLearningPlanDisciplines;
        List<LearningPlanDisciplineSemester> currentLearningPlanDisciplineSemesters;
        List<DisciplineSemesterView> dsViews;

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
            mtypeRepo = new MarkTypeRepo(ApiEndpoint);
            mtoRepo = new MarkTypeOptionRepo(ApiEndpoint);
            tRepo = new TeacherRepo(ApiEndpoint);
        }

        private void MarkList_Load(object sender, EventArgs e)
        {
            IntPtr pIcon = Resources.five.GetHicon();
            Icon = Icon.FromHandle(pIcon);

            LoadStudentList();

            var mTypes = mtypeRepo.all();
            CurrentMarkType.DisplayMember = "name";
            CurrentMarkType.ValueMember = "id";
            CurrentMarkType.DataSource = mTypes;

            var teachers = tRepo.all();
            var teachersView = TeacherView.TeachersToView(teachers).OrderBy(tv => tv.fio).ToList();

            MarkTeacherList.DisplayMember = "fio";
            MarkTeacherList.ValueMember = "id";
            MarkTeacherList.DataSource = teachersView;
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
            currentStudentId = ((List<StudentView>)StudentGrid.DataSource)[e.RowIndex].id;

            ReloadLearningPlanList(currentStudentId);
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

            RightBottomLeftPanel.Width = (int)Math.Floor((double)RightBottomPanel.Width - 200);

            if (MarksGridView.Columns["teachersFio"] != null)
            {
                MarksGridView.Columns["teachersFio"].Width = (MarksGridView.Width - 590 > 250) ? (MarksGridView.Width - 590) : 250;
            }
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
                .ToList();
            dsViews = DisciplineSemesterView.FromLpdsList(studentDisciplineSemesters, discIdDict);

            var semesterIntList = dsViews
                .Select(dsv => dsv.semester)
                .Distinct()
                .OrderBy(s => s)
                .ToList();
            var semesterViews = IntegerView.FromIntegerList(semesterIntList);

            SemestersGrid.DataSource = semesterViews;
            SemestersGrid.Columns["value"].HeaderText = "Семестр";
            SemestersGrid.Columns["value"].Width = SemestersGrid.Width - 20;           
        }

        private void SemestersGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentSemester = ((List<IntegerView>)SemestersGrid.DataSource)[e.RowIndex].value;
            UpdateSemesterDisciplines(currentSemester);
        }

        private void UpdateSemesterDisciplines(int semester)
        {
            var selected = false;
            var selectedRowIndex = -1;
            if (SemesterDisciplinesMarksGrid.SelectedCells.Count > 0)
            {
                selected = true;
                selectedRowIndex = SemesterDisciplinesMarksGrid.SelectedCells[0].RowIndex;
            }

            var dsv = dsViews
                            .Where(ds => ds.semester == semester)
                            .OrderBy(ds => ds.discipline_name)
                            .ToList();

            var splittedDsv = new List<DisciplineSemesterView>();
            foreach (var dsvItem in dsv)
            {
                if (dsvItem.zachet)
                {
                    var item = dsvItem.CloneWithNoAttestation();
                    item.zachet = true;
                    splittedDsv.Add(item);
                }

                if (dsvItem.exam)
                {
                    var item = dsvItem.CloneWithNoAttestation();
                    item.exam = true;
                    splittedDsv.Add(item);
                }

                if (dsvItem.zachet_with_mark)
                {
                    var item = dsvItem.CloneWithNoAttestation();
                    item.zachet_with_mark = true;
                    splittedDsv.Add(item);
                }

                if (dsvItem.course_project)
                {
                    var item = dsvItem.CloneWithNoAttestation();
                    item.course_project = true;
                    splittedDsv.Add(item);
                }

                if (dsvItem.course_task)
                {
                    var item = dsvItem.CloneWithNoAttestation();
                    item.course_task = true;
                    splittedDsv.Add(item);
                }

                if (dsvItem.control_task)
                {
                    var item = dsvItem.CloneWithNoAttestation();
                    item.control_task = true;
                    splittedDsv.Add(item);
                }

                if (dsvItem.referat)
                {
                    var item = dsvItem.CloneWithNoAttestation();
                    item.referat = true;
                    splittedDsv.Add(item);
                }

                if (dsvItem.essay)
                {
                    var item = dsvItem.CloneWithNoAttestation();
                    item.essay = true;
                    splittedDsv.Add(item);
                }
            }

            var markTypes = mtypeRepo.all();
            var markTypeOptions = mtoRepo.all();
            var studentMarks = mRepo.studentAll(currentStudentId);

            var disciplinesWithMarksView = DisciplineWithMark.FromDisciplineSemesterView(splittedDsv, studentMarks, markTypes, markTypeOptions);
            SemesterDisciplinesMarksGrid.DataSource = disciplinesWithMarksView;
            FormatSemesterView();

            if (selected)
            {
                SemesterDisciplinesMarksGrid.ClearSelection();
                SemesterDisciplinesMarksGrid.Rows[selectedRowIndex].Selected = true;
            }
        }

        private void FormatSemesterView()
        {
            SemesterDisciplinesMarksGrid.Columns["id"].Visible = false;
            SemesterDisciplinesMarksGrid.Columns["semester"].HeaderText = "Семестр";
            SemesterDisciplinesMarksGrid.Columns["discipline_name"].HeaderText = "Дисциплина";

            SemesterDisciplinesMarksGrid.Columns["attempt_count"].HeaderText = "Количество оценок";
            SemesterDisciplinesMarksGrid.Columns["final_mark"].HeaderText = "Итоговая оценка";
            SemesterDisciplinesMarksGrid.Columns["final_attestation_mark"].HeaderText = "Контрольный компонент";
            SemesterDisciplinesMarksGrid.Columns["final_semester_rate"].HeaderText = "Семестровый компонент";

            SemesterDisciplinesMarksGrid.Columns["lecture_hours"].HeaderText = "Лекции";
            SemesterDisciplinesMarksGrid.Columns["lab_hours"].HeaderText = "Лабораторные";
            SemesterDisciplinesMarksGrid.Columns["practice_hours"].HeaderText = "Практика";
            SemesterDisciplinesMarksGrid.Columns["independent_work_hours"].HeaderText = "Самостоятельная работа";
            SemesterDisciplinesMarksGrid.Columns["control_hours"].HeaderText = "Контроль";
            SemesterDisciplinesMarksGrid.Columns["z_count"].HeaderText = "Количество ЗЕТ";
            SemesterDisciplinesMarksGrid.Columns["zachet"].HeaderText = "Зачёт";
            SemesterDisciplinesMarksGrid.Columns["exam"].HeaderText = "Экзамен";
            SemesterDisciplinesMarksGrid.Columns["zachet_with_mark"].HeaderText = "Зачёт с оценкой";
            SemesterDisciplinesMarksGrid.Columns["course_project"].HeaderText = "Курсовой проект";
            SemesterDisciplinesMarksGrid.Columns["course_task"].HeaderText = "Курсовая работа";
            SemesterDisciplinesMarksGrid.Columns["control_task"].HeaderText = "Контрольная работа";
            SemesterDisciplinesMarksGrid.Columns["referat"].HeaderText = "Реферат";
            SemesterDisciplinesMarksGrid.Columns["essay"].HeaderText = "Эссе";
            SemesterDisciplinesMarksGrid.Columns["individual_hours"].HeaderText = "Индивидуальные часы";
            SemesterDisciplinesMarksGrid.Columns["learning_plan_discipline_id"].Visible = false;

            SemesterDisciplinesMarksGrid.Columns["semester"].Width = 40;
            SemesterDisciplinesMarksGrid.Columns["discipline_name"].Width = 250;

            SemesterDisciplinesMarksGrid.Columns["attempt_count"].Width = 80;
            SemesterDisciplinesMarksGrid.Columns["final_mark"].Width = 100;
            SemesterDisciplinesMarksGrid.Columns["final_attestation_mark"].Width = 100;
            SemesterDisciplinesMarksGrid.Columns["final_semester_rate"].Width = 100;

            SemesterDisciplinesMarksGrid.Columns["lecture_hours"].Width = 50;
            SemesterDisciplinesMarksGrid.Columns["lab_hours"].Width = 50;
            SemesterDisciplinesMarksGrid.Columns["practice_hours"].Width = 50;
            SemesterDisciplinesMarksGrid.Columns["independent_work_hours"].Width = 50;
            SemesterDisciplinesMarksGrid.Columns["control_hours"].Width = 50;
            SemesterDisciplinesMarksGrid.Columns["z_count"].Width = 50;
            SemesterDisciplinesMarksGrid.Columns["zachet"].Width = 40;
            SemesterDisciplinesMarksGrid.Columns["exam"].Width = 40;
            SemesterDisciplinesMarksGrid.Columns["zachet_with_mark"].Width = 40;
            SemesterDisciplinesMarksGrid.Columns["course_project"].Width = 40;
            SemesterDisciplinesMarksGrid.Columns["course_task"].Width = 40;
            SemesterDisciplinesMarksGrid.Columns["control_task"].Width = 40;
            SemesterDisciplinesMarksGrid.Columns["referat"].Width = 40;
            SemesterDisciplinesMarksGrid.Columns["essay"].Width = 40;
            SemesterDisciplinesMarksGrid.Columns["individual_hours"].Width = 50;
        }

        private void SemesterDisciplinesMarksGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dwm = ((List<DisciplineWithMark>)SemesterDisciplinesMarksGrid.DataSource)[e.RowIndex];

            UpdateSemesterDisciplineMarks(dwm);
        }

        private void UpdateSemesterDisciplineMarks(DisciplineWithMark dwm)
        {
            var marks = mRepo.studentDisciplineSemesterAll(currentStudentId, dwm.id);

            marks = Utilities.ConstrainMarksToOneAttestation(marks, dwm);

            var teachers = tRepo.all().ToDictionary(t => t.id, t => t);
            
            var markTypes = mtypeRepo.all();
            var markTypeOptions = mtoRepo.all();

            SetMarkTypeAndAttestationType(dwm);

            MarksGridView.DataSource = MarkView
                .FromMarkList(marks, markTypes, markTypeOptions, teachers, mtRepo)
                .OrderBy(mv => mv.attempt)
                .ToList();

            FormatMarksGrid();
        }

        private void SetMarkTypeAndAttestationType(DisciplineWithMark dwm)
        {
            var markTypes = mtypeRepo.all().ToDictionary(mt => mt.name, mt => mt);

            if (dwm.zachet) { AttestationType.Text = "Зачёт"; CurrentMarkType.SelectedValue = markTypes[Constants.AttestationMarkType["Зачёт"]].id; }
            if (dwm.exam) { AttestationType.Text = "Экзамен"; CurrentMarkType.SelectedValue = markTypes[Constants.AttestationMarkType["Экзамен"]].id; }
            if (dwm.zachet_with_mark) { AttestationType.Text = "Зачёт с оценкой"; CurrentMarkType.SelectedValue = markTypes[Constants.AttestationMarkType["Зачёт с оценкой"]].id; }
            if (dwm.course_project) { AttestationType.Text = "Курсовой проект"; CurrentMarkType.SelectedValue = markTypes[Constants.AttestationMarkType["Курсовой проект"]].id; }
            if (dwm.course_task) { AttestationType.Text = "Курсовая работа"; CurrentMarkType.SelectedValue = markTypes[Constants.AttestationMarkType["Курсовая работа"]].id; }
            if (dwm.control_task) { AttestationType.Text = "Контрольная работа"; CurrentMarkType.SelectedValue = markTypes[Constants.AttestationMarkType["Контрольная работа"]].id; }
            if (dwm.referat) { AttestationType.Text = "Реферат"; CurrentMarkType.SelectedValue = markTypes[Constants.AttestationMarkType["Реферат"]].id; }
            if (dwm.essay) { AttestationType.Text = "Эссе"; CurrentMarkType.SelectedValue = markTypes[Constants.AttestationMarkType["Эссе"]].id; }            
        }

        private void FormatMarksGrid()
        {
            MarksGridView.Columns["id"].Visible = false;
            MarksGridView.Columns["student_id"].Visible = false;
            MarksGridView.Columns["learning_plan_discipline_semester_id"].Visible = false;            
            MarksGridView.Columns["mark_type_id"].Visible = false;

            MarksGridView.Columns["attestation_type"].HeaderText = "Форма отчётности";
            MarksGridView.Columns["attestation_type"].Width = 140;

            MarksGridView.Columns["mark_type_option_id"].Visible = false;
            MarksGridView.Columns["final_mark"].HeaderText = "Итоговая оценка";
            MarksGridView.Columns["final_mark"].Width = 140;

            MarksGridView.Columns["attestation_mark_type_option_id"].Visible = false;
            MarksGridView.Columns["attestation_mark"].HeaderText = "Контрольный компонент";
            MarksGridView.Columns["attestation_mark"].Width = 80;

            MarksGridView.Columns["semester_rate"].HeaderText = "Семестровый компонент";
            MarksGridView.Columns["semester_rate"].Width = 80;

            MarksGridView.Columns["date"].HeaderText = "Дата";
            MarksGridView.Columns["date"].Width = 70;

            MarksGridView.Columns["attempt"].HeaderText = "Попытка";
            MarksGridView.Columns["attempt"].Width = 60;

            MarksGridView.Columns["teachersFio"].HeaderText = "ФИО";
            MarksGridView.Columns["teachersFio"].Width = (MarksGridView.Width - 590 > 250) ? (MarksGridView.Width - 590) : 250;
        }

        private void addMark_Click(object sender, EventArgs e)
        {
            if (SemesterDisciplinesMarksGrid.SelectedCells.Count > 0 && StudentGrid.SelectedCells.Count > 0)
            {
                currentStudentId = ((List<StudentView>)StudentGrid.DataSource)[StudentGrid.SelectedCells[0].RowIndex].id;

                var dwMark = ((List<DisciplineWithMark>)SemesterDisciplinesMarksGrid.DataSource)
                    [SemesterDisciplinesMarksGrid.SelectedCells[0].RowIndex];

                var newMark = new Mark {
                    student_id = currentStudentId,
                    learning_plan_discipline_semester_id = dwMark.id,
                    attempt = decimal.ToInt32(Attempt.Value),
                    attestation_type = AttestationType.Text,
                    mark_type_id = (int)CurrentMarkType.SelectedValue,
                    date = MarkDate.Value,
                    semester_rate = Utilities.ParseDecOrZero(SemesterRate.Text),
                    mark_type_option_id = (int)FinalMark.SelectedValue,
                    attestation_mark_type_option_id = (int)AttestationMark.SelectedValue
                };

                mRepo.add(newMark);

                if (SemesterDisciplinesMarksGrid.SelectedCells.Count > 0)
                {
                    var dwm = ((List<DisciplineWithMark>)SemesterDisciplinesMarksGrid.DataSource)
                        [SemesterDisciplinesMarksGrid.SelectedCells[0].RowIndex];

                    UpdateSemesterDisciplineMarks(dwm);

                    if (SemestersGrid.SelectedCells.Count > 0)
                    {
                        var semester = ((List<IntegerView>)SemestersGrid.DataSource)
                            [SemestersGrid.SelectedCells[0].RowIndex].value;
                        UpdateSemesterDisciplines(semester);
                    }                    
                }               
            }            
        }

        private void updateMark_Click(object sender, EventArgs e)
        {
            if (MarksGridView.SelectedCells.Count > 0 && SemesterDisciplinesMarksGrid.SelectedCells.Count > 0)
            {
                var dwMark = ((List<DisciplineWithMark>)SemesterDisciplinesMarksGrid.DataSource)
                    [SemesterDisciplinesMarksGrid.SelectedCells[0].RowIndex];

                var markView = ((List<MarkView>)MarksGridView.DataSource)[MarksGridView.SelectedCells[0].RowIndex];

                var mark = mRepo.get(markView.id);

                mark.student_id = currentStudentId;                
                mark.attempt = decimal.ToInt32(Attempt.Value);
                mark.attestation_type = AttestationType.Text;
                mark.mark_type_id = (int)CurrentMarkType.SelectedValue;
                mark.date = MarkDate.Value;
                mark.semester_rate = Utilities.ParseDecOrZero(SemesterRate.Text);
                mark.mark_type_option_id = (int)FinalMark.SelectedValue;
                mark.attestation_mark_type_option_id = (int)AttestationMark.SelectedValue;

                mRepo.update(mark, mark.id);

                UpdateSemesterDisciplineMarks(dwMark);

                if (SemestersGrid.SelectedCells.Count > 0)
                {
                    var semester = ((List<IntegerView>)SemestersGrid.DataSource)
                        [SemestersGrid.SelectedCells[0].RowIndex].value;
                    UpdateSemesterDisciplines(semester);                    
                }
            }
        }

        private void removeMark_Click(object sender, EventArgs e)
        {
            if (MarksGridView.SelectedCells.Count > 0 && SemesterDisciplinesMarksGrid.SelectedCells.Count > 0)
            {
                var markView = ((List<MarkView>)MarksGridView.DataSource)[MarksGridView.SelectedCells[0].RowIndex];

                var dwMark = ((List<DisciplineWithMark>)SemesterDisciplinesMarksGrid.DataSource)
                    [SemesterDisciplinesMarksGrid.SelectedCells[0].RowIndex];

                mtRepo.deleteMarkAll(markView.id);

                mRepo.delete(markView.id);

                UpdateSemesterDisciplineMarks(dwMark);

                if (SemestersGrid.SelectedCells.Count > 0)
                {
                    var semester = ((List<IntegerView>)SemestersGrid.DataSource)
                        [SemestersGrid.SelectedCells[0].RowIndex].value;
                    UpdateSemesterDisciplines(semester);
                }
            }
        }

        private void MarksGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var markView = ((List<MarkView>)MarksGridView.DataSource)[e.RowIndex];

            UpdateMarkTeachersList(markView);

            var markTypes = mtypeRepo.all();
            var markTypeOptions = mtoRepo.all();

            CurrentMarkType.SelectedValue = markView.mark_type_id;
            AttestationType.Text = markView.attestation_type;

            FinalMark.DisplayMember = "mark";
            FinalMark.ValueMember = "id";
            FinalMark.DataSource = markTypeOptions.Where(mto => mto.mark_type_id == markView.mark_type_id).ToList();
            FinalMark.SelectedValue = markView.mark_type_option_id;

            AttestationMark.DisplayMember = "mark";
            AttestationMark.ValueMember = "id";
            AttestationMark.DataSource = markTypeOptions.Where(mto => mto.mark_type_id == markView.mark_type_id).ToList();
            AttestationMark.SelectedValue = markView.attestation_mark_type_option_id;

            SemesterRate.Text = markView.semester_rate.ToString("0.00");
            Attempt.Value = markView.attempt;
            MarkDate.Value = markView.date;
        }

        private void UpdateMarkTeachersList(MarkView markView)
        {
            var marksTeachers = mtRepo.markAll(markView.id);
            var teachers = tRepo.all();

            var markTeachersView = MarkTeacherView.FromMarkTeacherList(marksTeachers, teachers);

            MarksTeachersGrid.DataSource = markTeachersView;

            FormatMarksTeachersGrid();
        }

        private void FormatMarksTeachersGrid()
        {
            MarksTeachersGrid.Columns["Id"].Visible = false;
            MarksTeachersGrid.Columns["MarkId"].Visible = false;
            MarksTeachersGrid.Columns["TeacherId"].Visible = false;
            MarksTeachersGrid.Columns["TeacherFio"].HeaderText = "Преподаватель";
            MarksTeachersGrid.Columns["TeacherFio"].Width = MarksTeachersGrid.Width - 20;
        }

        private void CurrentMarkType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CurrentMarkType.SelectedValue != null)
            {
                var markTypes = mtypeRepo.all();
                var markTypeOptions = mtoRepo.all();

                FinalMark.DisplayMember = "mark";
                FinalMark.ValueMember = "id";
                FinalMark.DataSource = markTypeOptions.Where(mto => mto.mark_type_id == (int)CurrentMarkType.SelectedValue).ToList();

                AttestationMark.DisplayMember = "mark";
                AttestationMark.ValueMember = "id";
                AttestationMark.DataSource = markTypeOptions.Where(mto => mto.mark_type_id == (int)CurrentMarkType.SelectedValue).ToList();
            }
        }

        private void AddMarkTeacher_Click(object sender, EventArgs e)
        {
            if (MarksGridView.SelectedCells.Count > 0)
            {
                var selectedRowIndex = MarksGridView.SelectedCells[0].RowIndex;
                var markView = ((List<MarkView>)MarksGridView.DataSource)[selectedRowIndex];

                var newMarkTeacher = new MarkTeacher {
                    mark_id = markView.id,
                    teacher_id = (int)MarkTeacherList.SelectedValue
                };

                mtRepo.add(newMarkTeacher);

                UpdateMarkTeachersList(markView);

                var dwm = ((List<DisciplineWithMark>)SemesterDisciplinesMarksGrid.DataSource)[SemesterDisciplinesMarksGrid.SelectedCells[0].RowIndex];
                UpdateSemesterDisciplineMarks(dwm);

                if (((List<MarkView>)MarksGridView.DataSource).FirstOrDefault(mv => mv.id == markView.id) != null)
                {
                    MarksGridView.ClearSelection();
                    MarksGridView.Rows[selectedRowIndex].Selected = true;
                }
            }
        }

        private void UpdateMarkTeacher_Click(object sender, EventArgs e)
        {
            if (MarksTeachersGrid.SelectedCells.Count > 0 && MarksGridView.SelectedCells.Count > 0)
            {
                var selectedRowIndex = MarksGridView.SelectedCells[0].RowIndex;
                var markView = ((List<MarkView>)MarksGridView.DataSource)[selectedRowIndex];

                var mtView = ((List<MarkTeacherView>)MarksTeachersGrid.DataSource)[MarksTeachersGrid.SelectedCells[0].RowIndex];

                var markTeacher = mtRepo.get(mtView.Id);

                markTeacher.teacher_id = (int)MarkTeacherList.SelectedValue;

                mtRepo.update(markTeacher, markTeacher.id);

                UpdateMarkTeachersList(markView);

                var dwm = ((List<DisciplineWithMark>)SemesterDisciplinesMarksGrid.DataSource)[SemesterDisciplinesMarksGrid.SelectedCells[0].RowIndex];
                UpdateSemesterDisciplineMarks(dwm);

                if (((List<MarkView>)MarksGridView.DataSource).FirstOrDefault(mv => mv.id == markView.id) != null)
                {
                    MarksGridView.ClearSelection();
                    MarksGridView.Rows[selectedRowIndex].Selected = true;
                }
            }
        }

        private void RemoveMarkTeacher_Click(object sender, EventArgs e)
        {
            if (MarksTeachersGrid.SelectedCells.Count > 0 && MarksGridView.SelectedCells.Count > 0)
            {
                var selectedRowIndex = MarksGridView.SelectedCells[0].RowIndex;
                var markView = ((List<MarkView>)MarksGridView.DataSource)[selectedRowIndex];

                var mtView = ((List<MarkTeacherView>)MarksTeachersGrid.DataSource)[MarksTeachersGrid.SelectedCells[0].RowIndex];

                mtRepo.delete(mtView.Id);

                UpdateMarkTeachersList(markView);

                var dwm = ((List<DisciplineWithMark>)SemesterDisciplinesMarksGrid.DataSource)[SemesterDisciplinesMarksGrid.SelectedCells[0].RowIndex];
                UpdateSemesterDisciplineMarks(dwm);

                if (((List<MarkView>)MarksGridView.DataSource).FirstOrDefault(mv => mv.id == markView.id) != null)
                {
                    MarksGridView.ClearSelection();
                    MarksGridView.Rows[selectedRowIndex].Selected = true;
                }
            }
        }

        private void MarksTeachersGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var teacherView = ((List<MarkTeacherView>)MarksTeachersGrid.DataSource)[e.RowIndex];

            MarkTeacherList.SelectedValue = teacherView.TeacherId;
        }

        private void MarkTeacherList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                AddMarkTeacher.PerformClick();
            }
        }

        private void MarkDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                addMark.PerformClick();

                MarkTeacherList.Focus();
            }
        }
    }
}
