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
    public partial class TeacherCardsList : Form
    {
        private string ApiEndpoint;

        TeacherCardRepo tcRepo;
        TeacherCardItemRepo tciRepo;
        DepartmentRepo dRepo;
        TeacherRepo tRepo;
        PositionYearRateHoursRepo pyrhRepo;

        int currentYear = -1;
        List<int> currentYears = new List<int>();
        List<Department> currentDepartments = new List<Department>();
        Department currentDepartment = null;
        TeacherCardJoined currectCardJoined = null;
        List<PositionYearRateHours> rates;

        public TeacherCardsList(string apiEndpoint)
        {
            InitializeComponent();

            ApiEndpoint = apiEndpoint;

            tcRepo = new TeacherCardRepo(ApiEndpoint);
            tciRepo = new TeacherCardItemRepo(ApiEndpoint);
            dRepo = new DepartmentRepo(ApiEndpoint);
            tRepo = new TeacherRepo(ApiEndpoint);
            pyrhRepo = new PositionYearRateHoursRepo(ApiEndpoint);
        }
        
        private void TeacherCardsList_Load(object sender, EventArgs e)
        {
            LoadYearsList();

            LoadTeacherList();

            LoadDepartmentList();

            GrayOutControls();

            rates = pyrhRepo.year(currentYear);
        }

        private void GrayOutControls()
        {
            tciLecture_hours_TextChanged(null, null);
            tciLab_hours_TextChanged(null, null);
            tciPractice_hours_TextChanged(null, null);
            tciExam_hours_TextChanged(null, null);
            tciZach_hours_TextChanged(null, null);
            tciZach_with_mark_hours_TextChanged(null, null);
            tciCourse_project_hours_TextChanged(null, null);
            tciCourse_task_hours_TextChanged(null, null);
            tciControl_task_hours_TextChanged(null, null);
            tciReferat_hours_TextChanged(null, null);
            tciEssay_hours_TextChanged(null, null);
            tciHead_of_practice_hours_TextChanged(null, null);
            tciHead_of_vkr_hours_TextChanged(null, null);
            tciIga_hours_TextChanged(null, null);
            tciNra_hours_TextChanged(null, null);
            tciNrm_hours_TextChanged(null, null);
            tciIndividual_hours_TextChanged(null, null);
        }

        private void LoadDepartmentList()
        {
            var departments = dRepo.all().OrderBy(d => d.name).ToList();

            departmentList.DataSource = departments;
            departmentList.ValueMember = "id";
            departmentList.DisplayMember = "name";
        }

        private void LoadTeacherList()
        {
            var teachers = tRepo.all();

            var teacherViews = TeacherView
                .TeachersToView(teachers)
                .OrderBy(tv => tv.fio)
                .ToList();

            teacherList.DataSource = teacherViews;
            teacherList.DisplayMember = "fio";
            teacherList.ValueMember = "id";
        }

        private void LoadYearsList()
        {
            currentYears = tcRepo.allYears();

            var yearViews = currentYears
                .OrderBy(y => y)
                .Select(year => new YearView { year = year })
                .ToList();

            yearsGridView.DataSource = yearViews;

            yearsGridView.Columns["year"].Visible = false;
            yearsGridView.Columns["yearString"].Width = yearsGridView.Width - 20;
            yearsGridView.Columns["yearString"].HeaderText = "Учебный год";
        }

        private void yearsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentYear = ((List<YearView>)yearsGridView.DataSource)[e.RowIndex].year;

            UpdateDepartmentList();
        }

        private void UpdateDepartmentList()
        {
            var departmentSelected = false;
            var departmentId = -1;
            if (departmentGridView.SelectedCells.Count > 0)
            {
                departmentSelected = true;
                departmentId = ((List<Department>)departmentGridView.DataSource)[departmentGridView.SelectedCells[0].RowIndex].id;
            }

            var departmentIds = tcRepo.yearDepartmentIds(currentYear);

            currentDepartments = dRepo.all();

            var departments = currentDepartments
                .Where(d => departmentIds.Contains(d.id))
                .OrderBy(d => d.name)
                .ToList();

            departmentGridView.DataSource = departments;

            departmentGridView.Columns["id"].Visible = false;
            departmentGridView.Columns["name"].Width = departmentGridView.Width - 20;
            departmentGridView.Columns["name"].HeaderText = "Кафедры";

            if (departmentSelected)
            {
                for (int i = 0; i < departments.Count; i++)
                {
                    if (departments[i].id == departmentId)
                    {
                        departmentGridView.ClearSelection();
                        departmentGridView.Rows[i].Cells[0].Selected = true;
                        break;
                    }
                }
            }
        }

        private void departmentGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentDepartment = ((List<Department>)departmentGridView.DataSource)[e.RowIndex];

            rates = pyrhRepo.year(currentYear);

            UpdateTeacherCardsList(rates);
            UpdateRatesList(rates);
        }

        private void UpdateRatesList(List<PositionYearRateHours> yearRates)
        {
            var rates = dRepo.rateHours(currentYear, currentDepartment.id);
            var ratesDict = yearRates.ToDictionary(r => r.position, r => r.rate_hours);

            var sortedRates = rates.rate_values
                .OrderBy(r => ratesDict.ContainsKey(r.position) ? ratesDict[r.position] : 0)
                .ToList();

            departmentDataGrid.DataSource = sortedRates;

            departmentDataGrid.Columns["position"].HeaderText = "Должность";
            departmentDataGrid.Columns["position"].Width = 130;
            departmentDataGrid.Columns["r2"].HeaderText = "Ставки" + Environment.NewLine + "(2 знака)";
            departmentDataGrid.Columns["r2"].Width = 60;
            departmentDataGrid.Columns["r3"].HeaderText = "Ставки" + Environment.NewLine + "(3 знака)";
            departmentDataGrid.Columns["r3"].Width = 60;
            departmentDataGrid.Columns["rCard"].HeaderText = "По карточкам";
            departmentDataGrid.Columns["rCard"].Width = 65;
        }

        private void UpdateTeacherCardsList(List<PositionYearRateHours> rates)
        {
            var currentDepartmentId = -1;
            if (currentYear == -1)
            {
                currentYear = Utilities.ParseIntOrZero(startingYear.Text.Split('-')[0]);
            }

            if (currentDepartment == null)
            {                
                currentDepartmentId = (int)departmentList.SelectedValue;
            } else
            {
                currentDepartmentId = currentDepartment.id;
            }

            var departmentYearCards = tcRepo.yearDepartmentIdJoined(currentYear, currentDepartmentId);
            
            var positionRates = rates.ToDictionary(r => r.position, r => r.rate_hours);

            departmentYearCards = departmentYearCards
                .OrderBy(tc => positionRates.ContainsKey(tc.position) ? positionRates[tc.position] : 0)
                .ThenBy(tc => tc.f)
                .ThenBy(tc => tc.i)
                .ThenBy(tc => tc.o)
                .ToList();

            cardsGridView.DataSource = departmentYearCards;

            cardsGridView.Columns["id"].Visible = false;
            cardsGridView.Columns["teacher_id"].Visible = false;
            cardsGridView.Columns["department_id"].Visible = false;
            cardsGridView.Columns["starting_year"].Visible = false;

            cardsGridView.Columns["f"].HeaderText = "Фамилия";
            cardsGridView.Columns["i"].HeaderText = "Имя";
            cardsGridView.Columns["o"].HeaderText = "Отчество";

            cardsGridView.Columns["position"].HeaderText = "Должность";
            cardsGridView.Columns["academic_degree"].HeaderText = "Учёная степень";
            cardsGridView.Columns["academic_rank"].HeaderText = "Учёное звание";
            cardsGridView.Columns["department_rank"].HeaderText = "Должность на кафедре";
            cardsGridView.Columns["position_type"].HeaderText = "Условие привлечения";
            cardsGridView.Columns["rate_multiplier"].HeaderText = "Доля ставки";
        }

        private void add_Click(object sender, EventArgs e)
        {
            var newYear = Utilities.ParseIntOrZero(startingYear.Text.Split('-')[0]);
            var newDepartmentId = (int)departmentList.SelectedValue;

            var newTeacherCard = new TeacherCard {
                teacher_id = (int)teacherList.SelectedValue,
                position = position.Text,
                academic_degree = academicDegree.Text,
                academic_rank = academicRank.Text,
                department_rank = departmentRank.Text,
                position_type = positionType.Text,
                department_id = newDepartmentId,
                starting_year = newYear,
                rate_multiplier = rateMultiplier.Text
            };

            tcRepo.add(newTeacherCard);

            UpdateTeacherCardsList(rates);

            if (!currentYears.Contains(newYear))
            {
                LoadYearsList();
            }

            if (!currentDepartments.Select(d => d.id).Contains(newDepartmentId))
            {
                UpdateDepartmentList();
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (cardsGridView.SelectedCells.Count > 0)
            {
                var cardJoined = ((List<TeacherCardJoined>)cardsGridView.DataSource)[cardsGridView.SelectedCells[0].RowIndex];

                var newYear = Utilities.ParseIntOrZero(startingYear.Text.Split('-')[0]);
                var newDepartmentId = (int)departmentList.SelectedValue;

                var TeacherCardUpdated = new TeacherCard
                {
                    id = cardJoined.id,
                    teacher_id = (int)teacherList.SelectedValue,
                    position = position.Text,
                    academic_degree = academicDegree.Text,
                    academic_rank = academicRank.Text,
                    department_rank = departmentRank.Text,
                    position_type = positionType.Text,
                    department_id = newDepartmentId,
                    starting_year = newYear,
                    rate_multiplier = rateMultiplier.Text

                };

                tcRepo.update(TeacherCardUpdated, TeacherCardUpdated.id);

                UpdateTeacherCardsList(rates);

                if (!currentYears.Contains(newYear))
                {
                    LoadYearsList();
                }

                UpdateDepartmentList();
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            if (cardsGridView.SelectedCells.Count > 0)
            {
                var cardJoined = ((List<TeacherCardJoined>)cardsGridView.DataSource)[cardsGridView.SelectedCells[0].RowIndex];

                tcRepo.delete(cardJoined.id);

                UpdateTeacherCardsList(rates);

                LoadYearsList();

                UpdateDepartmentList();
            }
        }

        private void cardsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currectCardJoined = ((List<TeacherCardJoined>)cardsGridView.DataSource)[e.RowIndex];

            teacherList.SelectedValue = currectCardJoined.teacher_id;
            position.Text = currectCardJoined.position;
            academicDegree.Text = currectCardJoined.academic_degree;
            academicRank.Text = currectCardJoined.academic_rank;
            departmentRank.Text = currectCardJoined.department_rank;
            positionType.Text = currectCardJoined.position_type;
            rateMultiplier.Text = currectCardJoined.rate_multiplier;

            startingYear.Text = currectCardJoined.starting_year.ToString() + " - " + (currectCardJoined.starting_year + 1).ToString();
            departmentList.SelectedValue = currectCardJoined.department_id;

            UpdateTeacherCardItemsList();
        }

        private void UpdateTeacherCardItemsList()
        {
            var cardItems = tciRepo.teacherCardAll(currectCardJoined.id);

            var cardItemViews = TeacherCardItemView.FromList(cardItems);

            cardItemViews = cardItemViews
                .OrderBy(tci => tci.semester)
                .ThenBy(tci => tci.code)
                .ThenBy(tci => tci.discipline_name)
                .ToList();

            var tcTotalHours = cardItemViews.Select(civ => civ.total_hours).Sum();
            LtcTotalHours.Text = tcTotalHours.ToString("0.00");

            var tcTotalHours1 = cardItemViews.Where(civ => civ.semester == 1).Select(civ => civ.total_hours).Sum();
            LtcTotalHours1.Text = tcTotalHours1.ToString("0.00");

            var tcTotalHours2 = cardItemViews.Where(civ => civ.semester == 2).Select(civ => civ.total_hours).Sum();
            LtcTotalHours2.Text = tcTotalHours2.ToString("0.00");

            var rateHoursList = pyrhRepo.year(currectCardJoined.starting_year);
            var rateHours = rateHoursList.FirstOrDefault(rhi => rhi.position == currectCardJoined.position);
            if (rateHours != null)
            {
                decimal rateMultiplier = tcTotalHours / rateHours.rate_hours;
                var rateMultiplier2 = Math.Round(rateMultiplier, 2);
                var rateMultiplier3 = Math.Round(rateMultiplier, 3);
                LtcRateMultiplier3.Text = rateMultiplier3.ToString("0.000");
                LtcRateMultiplier2.Text = rateMultiplier2.ToString("0.00");
            }

            cardItemsGridView.DataSource = cardItemViews;

            cardItemsGridView.Columns["id"].Visible = false;
            cardItemsGridView.Columns["teacher_card_id"].Visible = false;

            cardItemsGridView.Columns["semester"].HeaderText = "Семестр";
            cardItemsGridView.Columns["semester"].Width = 50;

            cardItemsGridView.Columns["code"].HeaderText = "Код";
            cardItemsGridView.Columns["code"].Width = 80;

            cardItemsGridView.Columns["discipline_name"].HeaderText = "Название дисциплины";
            cardItemsGridView.Columns["discipline_name"].Width = 150;

            cardItemsGridView.Columns["group_name"].HeaderText = "Группа";
            cardItemsGridView.Columns["group_name"].Width = 50;
                        
            cardItemsGridView.Columns["group_count"].HeaderText = "Количество групп";
            cardItemsGridView.Columns["group_count"].Width = 70;

            cardItemsGridView.Columns["group_students_count"].HeaderText = "Количество студентов";
            cardItemsGridView.Columns["group_students_count"].Width = 70;

            cardItemsGridView.Columns["lecture_hours"].HeaderText = "Лекции";
            cardItemsGridView.Columns["lecture_hours"].Width = 60;

            cardItemsGridView.Columns["lab_hours"].HeaderText = "Лабораторные";
            cardItemsGridView.Columns["lab_hours"].Width = 85;

            cardItemsGridView.Columns["practice_hours"].HeaderText = "Практика";
            cardItemsGridView.Columns["practice_hours"].Width = 60;

            cardItemsGridView.Columns["exam_hours"].HeaderText = "Экзамен";
            cardItemsGridView.Columns["exam_hours"].Width = 60;

            cardItemsGridView.Columns["zach_hours"].HeaderText = "Зачёт";
            cardItemsGridView.Columns["zach_hours"].Width = 50;

            cardItemsGridView.Columns["zach_with_mark_hours"].HeaderText = "Зачёт с оценкой";
            cardItemsGridView.Columns["zach_with_mark_hours"].Width = 60;

            cardItemsGridView.Columns["course_project_hours"].HeaderText = "Курсовой проект";
            cardItemsGridView.Columns["course_project_hours"].Width = 60;

            cardItemsGridView.Columns["course_task_hours"].HeaderText = "Курсовая работа";
            cardItemsGridView.Columns["course_task_hours"].Width = 60;

            cardItemsGridView.Columns["control_task_hours"].HeaderText = "Контрольная работа";
            cardItemsGridView.Columns["control_task_hours"].Width = 80;

            cardItemsGridView.Columns["referat_hours"].HeaderText = "Реферат";
            cardItemsGridView.Columns["referat_hours"].Width = 60;

            cardItemsGridView.Columns["essay_hours"].HeaderText = "Эссе";
            cardItemsGridView.Columns["essay_hours"].Width = 50;

            cardItemsGridView.Columns["head_of_practice_hours"].HeaderText = "Руководство практикой";
            cardItemsGridView.Columns["head_of_practice_hours"].Width = 80;

            cardItemsGridView.Columns["head_of_vkr_hours"].HeaderText = "Руководство ВКР";
            cardItemsGridView.Columns["head_of_vkr_hours"].Width = 80;

            cardItemsGridView.Columns["iga_hours"].HeaderText = "ИГА";
            cardItemsGridView.Columns["iga_hours"].Width = 40;

            cardItemsGridView.Columns["nra_hours"].HeaderText = "НРА";
            cardItemsGridView.Columns["nra_hours"].Width = 40;

            cardItemsGridView.Columns["nrm_hours"].HeaderText = "НРМ";
            cardItemsGridView.Columns["nrm_hours"].Width = 40;

            cardItemsGridView.Columns["individual_hours"].HeaderText = "Индивидуальные занятия";
            cardItemsGridView.Columns["individual_hours"].Width = 100;

            cardItemsGridView.Columns["total_hours"].HeaderText = "Итого";
            cardItemsGridView.Columns["total_hours"].Width = 60;
        }
        
        private void tciAdd_Click(object sender, EventArgs e)
        {
            var newTeacherCardItem = new TeacherCardItem
            {
                semester = Utilities.ParseIntOrZero(tciSemester.Text),
                code = tciCode.Text,
                discipline_name = tciDiscipline_name.Text,
                group_name = tciGroup_name.Text,
                group_count = Utilities.ParseIntOrZero(tciGroup_count.Text),
                group_students_count = Utilities.ParseIntOrZero(tciGroup_students_count.Text),
                lecture_hours = Utilities.ParseDecOrZero(tciLecture_hours.Text),
                lab_hours = Utilities.ParseDecOrZero(tciLab_hours.Text),
                practice_hours = Utilities.ParseDecOrZero(tciPractice_hours.Text),
                exam_hours = Utilities.ParseDecOrZero(tciExam_hours.Text),
                zach_hours = Utilities.ParseDecOrZero(tciZach_hours.Text),
                zach_with_mark_hours = Utilities.ParseDecOrZero(tciZach_with_mark_hours.Text),
                course_project_hours = Utilities.ParseDecOrZero(tciCourse_project_hours.Text),
                course_task_hours = Utilities.ParseDecOrZero(tciCourse_task_hours.Text),
                control_task_hours = Utilities.ParseDecOrZero(tciControl_task_hours.Text),
                referat_hours = Utilities.ParseDecOrZero(tciReferat_hours.Text),
                essay_hours = Utilities.ParseDecOrZero(tciEssay_hours.Text),
                head_of_practice_hours = Utilities.ParseDecOrZero(tciHead_of_practice_hours.Text),
                head_of_vkr_hours = Utilities.ParseDecOrZero(tciHead_of_vkr_hours.Text),
                iga_hours = Utilities.ParseDecOrZero(tciIga_hours.Text),
                nra_hours = Utilities.ParseDecOrZero(tciNra_hours.Text),
                nrm_hours = Utilities.ParseDecOrZero(tciNrm_hours.Text),
                individual_hours = Utilities.ParseDecOrZero(tciIndividual_hours.Text),
                teacher_card_id = currectCardJoined.id
            };

            tciRepo.add(newTeacherCardItem);

            UpdateTeacherCardItemsList();
        }

        private void tciUpdate_Click(object sender, EventArgs e)
        {
            if (cardItemsGridView.SelectedCells.Count > 0)
            {
                var cardItemView = ((List<TeacherCardItemView>)cardItemsGridView.DataSource)[cardItemsGridView.SelectedCells[0].RowIndex];

                var cardItem = new TeacherCardItem { id = cardItemView.id, teacher_card_id = cardItemView.teacher_card_id };

                cardItem.semester = Utilities.ParseIntOrZero(tciSemester.Text);
                cardItem.code = tciCode.Text;
                cardItem.discipline_name = tciDiscipline_name.Text;
                cardItem.group_name = tciGroup_name.Text;
                cardItem.group_count = Utilities.ParseIntOrZero(tciGroup_count.Text);
                cardItem.group_students_count = Utilities.ParseIntOrZero(tciGroup_students_count.Text);
                cardItem.lecture_hours = Utilities.ParseDecOrZero(tciLecture_hours.Text);
                cardItem.lab_hours = Utilities.ParseDecOrZero(tciLab_hours.Text);
                cardItem.practice_hours = Utilities.ParseDecOrZero(tciPractice_hours.Text);
                cardItem.exam_hours = Utilities.ParseDecOrZero(tciExam_hours.Text);
                cardItem.zach_hours = Utilities.ParseDecOrZero(tciZach_hours.Text);
                cardItem.zach_with_mark_hours = Utilities.ParseDecOrZero(tciZach_with_mark_hours.Text);
                cardItem.course_project_hours = Utilities.ParseDecOrZero(tciCourse_project_hours.Text);
                cardItem.course_task_hours = Utilities.ParseDecOrZero(tciCourse_task_hours.Text);
                cardItem.control_task_hours = Utilities.ParseDecOrZero(tciControl_task_hours.Text);
                cardItem.referat_hours = Utilities.ParseDecOrZero(tciReferat_hours.Text);
                cardItem.essay_hours = Utilities.ParseDecOrZero(tciEssay_hours.Text);
                cardItem.head_of_practice_hours = Utilities.ParseDecOrZero(tciHead_of_practice_hours.Text);
                cardItem.head_of_vkr_hours = Utilities.ParseDecOrZero(tciHead_of_vkr_hours.Text);
                cardItem.iga_hours = Utilities.ParseDecOrZero(tciIga_hours.Text);
                cardItem.nra_hours = Utilities.ParseDecOrZero(tciNra_hours.Text);
                cardItem.nrm_hours = Utilities.ParseDecOrZero(tciNrm_hours.Text);
                cardItem.individual_hours = Utilities.ParseDecOrZero(tciIndividual_hours.Text);

                tciRepo.update(cardItem, cardItem.id);

                UpdateTeacherCardItemsList();
            }
        }

        private void tciRemove_Click(object sender, EventArgs e)
        {
            if (cardItemsGridView.SelectedCells.Count > 0)
            {
                var cardItemView = ((List<TeacherCardItemView>)cardItemsGridView.DataSource)[cardItemsGridView.SelectedCells[0].RowIndex];

                tciRepo.delete(cardItemView.id);

                UpdateTeacherCardItemsList();
            }
        }

        private void cardItemsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var cardItemView = ((List<TeacherCardItemView>)cardItemsGridView.DataSource)[e.RowIndex];

            tciSemester.Text = cardItemView.semester.ToString();
            tciCode.Text = cardItemView.code;
            tciDiscipline_name.Text = cardItemView.discipline_name;
            tciGroup_name.Text = cardItemView.group_name;
            tciGroup_count.Text = cardItemView.group_count.ToString();
            tciGroup_students_count.Text = cardItemView.group_students_count.ToString();
            tciLecture_hours.Text = cardItemView.lecture_hours.ToString();
            tciLab_hours.Text = cardItemView.lab_hours.ToString();
            tciPractice_hours.Text = cardItemView.practice_hours.ToString();
            tciExam_hours.Text = cardItemView.exam_hours.ToString();
            tciZach_hours.Text = cardItemView.zach_hours.ToString();
            tciZach_with_mark_hours.Text = cardItemView.zach_with_mark_hours.ToString();
            tciCourse_project_hours.Text = cardItemView.course_project_hours.ToString();
            tciCourse_task_hours.Text = cardItemView.course_task_hours.ToString();
            tciControl_task_hours.Text = cardItemView.control_task_hours.ToString();
            tciReferat_hours.Text = cardItemView.referat_hours.ToString();
            tciEssay_hours.Text = cardItemView.essay_hours.ToString();
            tciHead_of_practice_hours.Text = cardItemView.head_of_practice_hours.ToString();
            tciHead_of_vkr_hours.Text = cardItemView.head_of_vkr_hours.ToString();
            tciIga_hours.Text = cardItemView.iga_hours.ToString();
            tciNra_hours.Text = cardItemView.nra_hours.ToString();
            tciNrm_hours.Text = cardItemView.nrm_hours.ToString();
            tciIndividual_hours.Text = cardItemView.individual_hours.ToString();

            LtciTotalHours.Text = cardItemView.total_hours.ToString("0.00");
        }

        private void clearFields_Click(object sender, EventArgs e)
        {
            tciSemester.Text = "";
            tciCode.Text = "";
            tciDiscipline_name.Text = "";
            tciGroup_name.Text = "";
            tciGroup_count.Text = "";
            tciGroup_students_count.Text = "";
            tciLecture_hours.Text = "";
            tciLab_hours.Text = "";
            tciPractice_hours.Text = "";
            tciExam_hours.Text = "";
            tciZach_hours.Text = "";
            tciZach_with_mark_hours.Text = "";
            tciCourse_project_hours.Text = "";
            tciCourse_task_hours.Text = "";
            tciControl_task_hours.Text = "";
            tciReferat_hours.Text = "";
            tciEssay_hours.Text = "";
            tciHead_of_practice_hours.Text = "";
            tciHead_of_vkr_hours.Text = "";
            tciIga_hours.Text = "";
            tciNra_hours.Text = "";
            tciNrm_hours.Text = "";
            LtciTotalHours.Text = "000.00";

            tciSemester.Focus();
        }

        private void cardItemsGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string stringValue = e.Value.ToString();

            if (stringValue == "0" ||  stringValue == "0.00" || stringValue == "0,00")
            {
                e.CellStyle.ForeColor = Color.FromArgb(200, 200, 200);
            }

            if (e.ColumnIndex != 2 && e.ColumnIndex != 3)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void tciLecture_hours_TextChanged(object sender, EventArgs e)
        {
            ChangeGroupColor(tciLecture_hours, LtciLecture_hours);
        }

        private void ChangeGroupColor(TextBox textBox, Label labelForTextBox)
        {
            if (Utilities.ParseDecOrZero(textBox.Text) == 0)
            {
                textBox.ForeColor = Color.FromArgb(200, 200, 200);
                labelForTextBox.ForeColor = Color.FromArgb(200, 200, 200);
            }
            else
            {
                textBox.ForeColor = Color.FromArgb(0, 0, 0);
                labelForTextBox.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void tciLab_hours_TextChanged(object sender, EventArgs e)
        {
            ChangeGroupColor(tciLab_hours, LtciLab_hours);
        }

        private void tciPractice_hours_TextChanged(object sender, EventArgs e)
        {
            ChangeGroupColor(tciPractice_hours, LtciPractice_hours);
        }

        private void tciExam_hours_TextChanged(object sender, EventArgs e)
        {
            ChangeGroupColor(tciExam_hours, LtciExam_hours);
        }

        private void tciZach_hours_TextChanged(object sender, EventArgs e)
        {
            ChangeGroupColor(tciZach_hours, LtciZach_hours);
        }

        private void tciZach_with_mark_hours_TextChanged(object sender, EventArgs e)
        {
            ChangeGroupColor(tciZach_with_mark_hours, LtciZach_with_mark_hours);
        }

        private void tciCourse_project_hours_TextChanged(object sender, EventArgs e)
        {
            ChangeGroupColor(tciCourse_project_hours, LtciCourse_project_hours);
        }

        private void tciCourse_task_hours_TextChanged(object sender, EventArgs e)
        {
            ChangeGroupColor(tciCourse_task_hours, LtciCourse_task_hours);
        }

        private void tciControl_task_hours_TextChanged(object sender, EventArgs e)
        {
            ChangeGroupColor(tciControl_task_hours, LtciControl_task_hours);
        }

        private void tciReferat_hours_TextChanged(object sender, EventArgs e)
        {
            ChangeGroupColor(tciReferat_hours, LtciReferat_hours);
        }

        private void tciEssay_hours_TextChanged(object sender, EventArgs e)
        {
            ChangeGroupColor(tciEssay_hours, LtciEssay_hours);
        }

        private void tciHead_of_practice_hours_TextChanged(object sender, EventArgs e)
        {
            ChangeGroupColor(tciHead_of_practice_hours, LtciHead_of_practice_hours);
        }

        private void tciHead_of_vkr_hours_TextChanged(object sender, EventArgs e)
        {
            ChangeGroupColor(tciHead_of_vkr_hours, LtciHead_of_vkr_hours);
        }

        private void tciIga_hours_TextChanged(object sender, EventArgs e)
        {
            ChangeGroupColor(tciIga_hours, LtciIga_hours);
        }

        private void tciNra_hours_TextChanged(object sender, EventArgs e)
        {
            ChangeGroupColor(tciNra_hours, LtciNra_hours);
        }

        private void tciNrm_hours_TextChanged(object sender, EventArgs e)
        {
            ChangeGroupColor(tciNrm_hours, LtciNrm_hours);
        }

        private void tciIndividual_hours_TextChanged(object sender, EventArgs e)
        {
            ChangeGroupColor(tciIndividual_hours, LtciIndividual_hours);
        }

        private void KeyDown_Add_Click(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tciAdd.PerformClick();
                clearFields.Focus();
            }
        }
    }
}
