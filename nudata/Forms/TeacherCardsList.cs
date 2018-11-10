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

        int currentYear = -1;
        List<int> currentYears = new List<int>();
        Department currentDepartment = null;
        TeacherCardJoined currectCardJoined = null;

        public TeacherCardsList(string apiEndpoint)
        {
            InitializeComponent();

            ApiEndpoint = apiEndpoint;

            tcRepo = new TeacherCardRepo(ApiEndpoint);
            tciRepo = new TeacherCardItemRepo(ApiEndpoint);
            dRepo = new DepartmentRepo(ApiEndpoint);
            tRepo = new TeacherRepo(ApiEndpoint);
        }
        
        private void TeacherCardsList_Load(object sender, EventArgs e)
        {
            LoadYearsList();

            LoadTeacherList();

            LoadDepartmentList();
        }

        private void LoadDepartmentList()
        {
            var departments = dRepo.all();

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
            
            var departmentIds = tcRepo.yearDepartmentIds(currentYear);

            var allDepartments = dRepo.all();

            var departments = allDepartments
                .Where(d => departmentIds.Contains(d.id))
                .ToList();

            departmentGridView.DataSource = departments;

            departmentGridView.Columns["id"].Visible = false;
            departmentGridView.Columns["name"].Width = departmentGridView.Width - 20;
            departmentGridView.Columns["name"].HeaderText = "Кафедры";
        }

        private void departmentGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentDepartment = ((List<Department>)departmentGridView.DataSource)[e.RowIndex];
            UpdateTeacherCardsList();
        }

        private void UpdateTeacherCardsList()
        {
            var departmentYearCards = tcRepo.yearDepartmentIdJoined(currentYear, currentDepartment.id);

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
        }

        private void add_Click(object sender, EventArgs e)
        {
            var newYear = ParseIntOrZero(startingYear.Text.Split('-')[0]);

            var newTeacherCard = new TeacherCard {
                teacher_id = (int)teacherList.SelectedValue,
                position = position.Text,
                academic_degree = academicDegree.Text,
                academic_rank = academicRank.Text,
                department_rank = departmentRank.Text,
                position_type = positionType.Text,
                department_id = (int)departmentList.SelectedValue,
                starting_year = newYear
            };

            tcRepo.add(newTeacherCard);

            UpdateTeacherCardsList();

            if (!currentYears.Contains(newYear))
            {
                LoadYearsList();
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (cardsGridView.SelectedCells.Count > 0)
            {
                var cardJoined = ((List<TeacherCardJoined>)cardsGridView.DataSource)[cardsGridView.SelectedCells[0].RowIndex];

                var newYear = ParseIntOrZero(startingYear.Text.Split('-')[0]);

                var TeacherCardUpdated = new TeacherCard
                {
                    id = cardJoined.id,
                    teacher_id = (int)teacherList.SelectedValue,
                    position = position.Text,
                    academic_degree = academicDegree.Text,
                    academic_rank = academicRank.Text,
                    department_rank = departmentRank.Text,
                    position_type = positionType.Text,
                    department_id = (int)departmentList.SelectedValue,
                    starting_year = newYear
                };

                tcRepo.update(TeacherCardUpdated, TeacherCardUpdated.id);

                UpdateTeacherCardsList();

                if (!currentYears.Contains(newYear))
                {
                    LoadYearsList();
                }
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            if (cardsGridView.SelectedCells.Count > 0)
            {
                var cardJoined = ((List<TeacherCardJoined>)cardsGridView.DataSource)[cardsGridView.SelectedCells[0].RowIndex];

                tcRepo.delete(cardJoined.id);

                UpdateTeacherCardsList();

                LoadYearsList();
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

            startingYear.Text = currectCardJoined.starting_year.ToString() + " - " + (currectCardJoined.starting_year + 1).ToString();
            departmentList.SelectedValue = currectCardJoined.department_id;

            UpdateTeacherCardItemsList();
        }

        private void UpdateTeacherCardItemsList()
        {
            var cardItems = tciRepo.teacherCardAll(currectCardJoined.id);

            cardItemsGridView.DataSource = cardItems;

            cardItemsGridView.Columns["id"].Visible = false;
            cardItemsGridView.Columns["teacher_card_id"].Visible = false;

            cardItemsGridView.Columns["semester"].HeaderText = "Семестр";
            cardItemsGridView.Columns["semester"].Width = 60;

            cardItemsGridView.Columns["code"].HeaderText = "Код";
            cardItemsGridView.Columns["code"].Width = 60;

            cardItemsGridView.Columns["discipline_name"].HeaderText = "Название дисциплины";
            cardItemsGridView.Columns["discipline_name"].Width = 150;

            cardItemsGridView.Columns["group_name"].HeaderText = "Группа";
            cardItemsGridView.Columns["group_name"].Width = 60;
                        
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
            cardItemsGridView.Columns["zach_hours"].Width = 60;

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
            cardItemsGridView.Columns["essay_hours"].Width = 60;

            cardItemsGridView.Columns["head_of_practice_hours"].HeaderText = "Руководство практикой";
            cardItemsGridView.Columns["head_of_practice_hours"].Width = 80;

            cardItemsGridView.Columns["head_of_vkr_hours"].HeaderText = "Руководство ВКР";
            cardItemsGridView.Columns["head_of_vkr_hours"].Width = 80;

            cardItemsGridView.Columns["iga_hours"].HeaderText = "ИГА";
            cardItemsGridView.Columns["iga_hours"].Width = 60;

            cardItemsGridView.Columns["nra_hours"].HeaderText = "НРА";
            cardItemsGridView.Columns["nra_hours"].Width = 60;

            cardItemsGridView.Columns["nrm_hours"].HeaderText = "НРМ";
            cardItemsGridView.Columns["nrm_hours"].Width = 60;
        }

        private int ParseIntOrZero(string str)
        {
            int result = 0;
            int.TryParse(str, out result);

            return result;
        }

        private decimal ParseDecOrZero(string str)
        {
            decimal result = 0;
            decimal.TryParse(str, out result);

            return result;
        }

        private void tciAdd_Click(object sender, EventArgs e)
        {
            var newTeacherCardItem = new TeacherCardItem
            {
                semester = ParseIntOrZero(tciSemester.Text),
                code = tciCode.Text,
                discipline_name = tciDiscipline_name.Text,
                group_name = tciGroup_name.Text,
                group_count = ParseIntOrZero(tciGroup_count.Text),
                group_students_count = ParseIntOrZero(tciGroup_students_count.Text),
                lecture_hours = ParseDecOrZero(tciLecture_hours.Text),
                lab_hours = ParseDecOrZero(tciLab_hours.Text),
                practice_hours = ParseDecOrZero(tciPractice_hours.Text),
                exam_hours = ParseDecOrZero(tciExam_hours.Text),
                zach_hours = ParseDecOrZero(tciZach_hours.Text),
                zach_with_mark_hours = ParseDecOrZero(tciZach_with_mark_hours.Text),
                course_project_hours = ParseDecOrZero(tciCourse_project_hours.Text),
                course_task_hours = ParseDecOrZero(tciCourse_task_hours.Text),
                control_task_hours = ParseDecOrZero(tciControl_task_hours.Text),
                referat_hours = ParseDecOrZero(tciReferat_hours.Text),
                essay_hours = ParseDecOrZero(tciEssay_hours.Text),
                head_of_practice_hours = ParseDecOrZero(tciHead_of_practice_hours.Text),
                head_of_vkr_hours = ParseDecOrZero(tciHead_of_vkr_hours.Text),
                iga_hours = ParseDecOrZero(tciIga_hours.Text),
                nra_hours = ParseDecOrZero(tciNra_hours.Text),
                nrm_hours = ParseDecOrZero(tciNrm_hours.Text),
                teacher_card_id = currectCardJoined.id
            };

            tciRepo.add(newTeacherCardItem);

            UpdateTeacherCardItemsList();
        }

        private void tciUpdate_Click(object sender, EventArgs e)
        {
            if (cardItemsGridView.SelectedCells.Count > 0)
            {
                var cardItem = ((List<TeacherCardItem>)cardItemsGridView.DataSource)[cardItemsGridView.SelectedCells[0].RowIndex];

                cardItem.semester = ParseIntOrZero(tciSemester.Text);
                cardItem.code = tciCode.Text;
                cardItem.discipline_name = tciDiscipline_name.Text;
                cardItem.group_name = tciGroup_name.Text;
                cardItem.group_count = ParseIntOrZero(tciGroup_count.Text);
                cardItem.group_students_count = ParseIntOrZero(tciGroup_students_count.Text);
                cardItem.lecture_hours = ParseDecOrZero(tciLecture_hours.Text);
                cardItem.lab_hours = ParseDecOrZero(tciLab_hours.Text);
                cardItem.practice_hours = ParseDecOrZero(tciPractice_hours.Text);
                cardItem.exam_hours = ParseDecOrZero(tciExam_hours.Text);
                cardItem.zach_hours = ParseDecOrZero(tciZach_hours.Text);
                cardItem.zach_with_mark_hours = ParseDecOrZero(tciZach_with_mark_hours.Text);
                cardItem.course_project_hours = ParseDecOrZero(tciCourse_project_hours.Text);
                cardItem.course_task_hours = ParseDecOrZero(tciCourse_task_hours.Text);
                cardItem.control_task_hours = ParseDecOrZero(tciControl_task_hours.Text);
                cardItem.referat_hours = ParseDecOrZero(tciReferat_hours.Text);
                cardItem.essay_hours = ParseDecOrZero(tciEssay_hours.Text);
                cardItem.head_of_practice_hours = ParseDecOrZero(tciHead_of_practice_hours.Text);
                cardItem.head_of_vkr_hours = ParseDecOrZero(tciHead_of_vkr_hours.Text);
                cardItem.iga_hours = ParseDecOrZero(tciIga_hours.Text);
                cardItem.nra_hours = ParseDecOrZero(tciNra_hours.Text);
                cardItem.nrm_hours = ParseDecOrZero(tciNrm_hours.Text);

                tciRepo.update(cardItem, cardItem.id);

                UpdateTeacherCardItemsList();
            }
        }

        private void tciRemove_Click(object sender, EventArgs e)
        {
            if (cardItemsGridView.SelectedCells.Count > 0)
            {
                var cardItem = ((List<TeacherCardItem>)cardItemsGridView.DataSource)[cardItemsGridView.SelectedCells[0].RowIndex];

                tciRepo.delete(cardItem.id);

                UpdateTeacherCardItemsList();
            }
        }

        private void cardItemsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var cardItem = ((List<TeacherCardItem>)cardItemsGridView.DataSource)[e.RowIndex];

            tciSemester.Text = cardItem.semester.ToString();
            tciCode.Text = cardItem.code;
            tciDiscipline_name.Text = cardItem.discipline_name;
            tciGroup_name.Text = cardItem.group_name;
            tciGroup_count.Text = cardItem.group_count.ToString();
            tciGroup_students_count.Text = cardItem.group_students_count.ToString();
            tciLecture_hours.Text = cardItem.lecture_hours.ToString();
            tciLab_hours.Text = cardItem.lab_hours.ToString();
            tciPractice_hours.Text = cardItem.practice_hours.ToString();
            tciExam_hours.Text = cardItem.exam_hours.ToString();
            tciZach_hours.Text = cardItem.zach_hours.ToString();
            tciZach_with_mark_hours.Text = cardItem.zach_with_mark_hours.ToString();
            tciCourse_project_hours.Text = cardItem.course_project_hours.ToString();
            tciCourse_task_hours.Text = cardItem.course_task_hours.ToString();
            tciControl_task_hours.Text = cardItem.control_task_hours.ToString();
            tciReferat_hours.Text = cardItem.referat_hours.ToString();
            tciEssay_hours.Text = cardItem.essay_hours.ToString();
            tciHead_of_practice_hours.Text = cardItem.head_of_practice_hours.ToString();
            tciHead_of_vkr_hours.Text = cardItem.head_of_vkr_hours.ToString();
            tciIga_hours.Text = cardItem.iga_hours.ToString();
            tciNra_hours.Text = cardItem.nra_hours.ToString();
            tciNrm_hours.Text = cardItem.nrm_hours.ToString();
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
        }

        private void cardItemsGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string stringValue = e.Value.ToString();

            if (stringValue == "0" ||  stringValue == "0.00" || stringValue == "0,00")
            {
                e.CellStyle.ForeColor = Color.FromArgb(200, 200, 200);
            }
        }

        private void tciLecture_hours_TextChanged(object sender, EventArgs e)
        {
            ChangeGroupColor(tciLecture_hours, LtciLecture_hours);
        }

        private void ChangeGroupColor(TextBox textBox, Label labelForTextBox)
        {
            if (ParseDecOrZero(textBox.Text) == 0)
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
    }
}
