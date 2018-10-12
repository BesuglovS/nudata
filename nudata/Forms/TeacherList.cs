using nudata.AccessPps.AccessClasses;
using nudata.AccessPps.PpsDataSetTableAdapters;
using nudata.DomainClasses.Main;
using nudata.nubackRepos;
using nudata.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static nudata.AccessPps.PpsDataSet;

namespace nudata.Forms
{
    public partial class TeacherList : Form
    {
        enum RefreshType { TeachersOnly = 1, DisciplinesOnly, FullRefresh };

        private string ApiEndpoint;
        TeacherRepo tRepo;
        PositionRepo pRepo;
        ExperienceRepo expRepo;
        EducationRepo eduRepo;
        AcademicDegreeRepo adRepo;
        AcademicRankRepo arRepo;

        Timer searchTimer;

        public TeacherList(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
            InitializeComponent();

            tRepo = new TeacherRepo(ApiEndpoint);
            pRepo = new PositionRepo(ApiEndpoint);
            expRepo = new ExperienceRepo(ApiEndpoint);
            eduRepo = new EducationRepo(ApiEndpoint);
            adRepo = new AcademicDegreeRepo(ApiEndpoint);
            arRepo = new AcademicRankRepo(ApiEndpoint);
        }

        private void TeacherList_Load(object sender, EventArgs e)
        {
            IntPtr pIcon = Resources.teacher.GetHicon();
            Icon = Icon.FromHandle(pIcon);

            RefreshView((int)RefreshType.FullRefresh);

            searchTimer = new Timer();
            searchTimer.Interval = 1000;
            searchTimer.Tick += new EventHandler(searchTimer_Tick);
        }

        private void searchTimer_Tick(object sender, EventArgs e)
        {
            if (fioFilter.Focused)
            {
                var teachers = tRepo.all()
                    .Where(t => (t.f + " " + t.i + " " + t.o).ToLower()
                        .Contains(fioFilter.Text.ToLower()))
                    .OrderBy(t => t.f)
                    .ThenBy(t => t.i)
                    .ThenBy(t => t.o)
                    .ThenBy(t => t.birth_date)
                    .ToList();

                TeacherListView.DataSource = teachers;
                FromatTeacherList();

                searchTimer.Stop(); //No disposing required, just stop the timer.
            }
        }

        private void RefreshView(int refreshType)
        {
            if ((refreshType == 1) || (refreshType == 3))
            {
                var teachersList = tRepo.all();
                teachersList = teachersList.OrderBy(t => t.f).ThenBy(t => t.i).ThenBy(t => t.o).ToList();

                TeacherListView.DataSource = teachersList;
                FromatTeacherList();

                //TeacherListView.ClearSelection();
            }
            if ((refreshType == 2) || (refreshType == 3))
            {
                //FillDicsiplinesList(true);
            }
        }

        private void FromatTeacherList()
        {
            TeacherListView.Columns["id"].Visible = false;
            TeacherListView.Columns["f"].Width = 100;
            TeacherListView.Columns["i"].Width = 100;
            TeacherListView.Columns["o"].Width = 100;
            TeacherListView.Columns["phone"].Visible = false;
            TeacherListView.Columns["birth_date"].Visible = false;
        }

        private async void TeacherListView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var teacher = ((List<Teacher>)TeacherListView.DataSource)[e.RowIndex];

            teacherF.Text = teacher.f;
            teacherI.Text = teacher.i;
            teacherO.Text = teacher.o;
            teacherPhone.Text = teacher.phone;
            teacherBirthDate.Value = teacher.birth_date;

            UpdatePositionsList(teacher.id);
            UpdateExperienceList(teacher.id);
            UpdateEducationList(teacher.id);
            UpdateAcademicDegreeList(teacher.id);
            UpdateAcademicRankList(teacher.id);
        }

        private void add_Click(object sender, EventArgs e)
        {
            var newTeacher = new Teacher {
                f = teacherF.Text,
                i = teacherI.Text,
                o = teacherO.Text,
                phone = teacherPhone.Text,
                birth_date = teacherBirthDate.Value
            };
            tRepo.add(newTeacher);

            RefreshView((int)RefreshType.TeachersOnly);

            var teacherList = (List<Teacher>)TeacherListView.DataSource;
            var addedTeacher = teacherList.FirstOrDefault(t => t.f == newTeacher.f && t.i == newTeacher.i && t.o == newTeacher.o);

            var newIndex = -1;
            for (int i = 0; i < teacherList.Count; i++)
            {
                if (teacherList[i].f == newTeacher.f &&
                    teacherList[i].i == newTeacher.i &&
                    teacherList[i].o == newTeacher.o)
                {
                    newIndex = i;
                }
            }

            if (newIndex != -1)
            {
                TeacherListView.ClearSelection();
                TeacherListView.Rows[newIndex].Selected = true;
                TeacherListView.FirstDisplayedScrollingRowIndex = newIndex;
            }            
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (TeacherListView.SelectedCells.Count > 0)
            {
                var teacher = ((List<Teacher>)TeacherListView.DataSource)[TeacherListView.SelectedCells[0].RowIndex];

                teacher.f = teacherF.Text;
                teacher.i = teacherI.Text;
                teacher.o = teacherO.Text;
                teacher.phone = teacherPhone.Text;
                teacher.birth_date = teacherBirthDate.Value;

                tRepo.update(teacher, teacher.id);

                RefreshView((int)RefreshType.TeachersOnly);
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            if (TeacherListView.SelectedCells.Count > 0)
            {
                var teacher = ((List<Teacher>)TeacherListView.DataSource)[TeacherListView.SelectedCells[0].RowIndex];

                tRepo.delete(teacher.id);

                RefreshView((int)RefreshType.TeachersOnly);
            }
        }

        private void teacherF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (teacherF.Text.Contains('*'))
                {
                    var split1 = teacherF.Text.Split(new char[] { '*' }, 2);
                    if (split1.Count() == 2)
                    {
                        var split2 = split1[0].Split(new char[] { ' ' }, 3);

                        if (split2.Count() == 3)
                        {
                            teacherF.Text = split2[0];
                            teacherI.Text = split2[1];
                            teacherO.Text = split2[2];

                            teacherPhone.Text = split1[1];

                            teacherBirthDate.Focus();
                        }
                    }
                }
            }
        }

        private void positionGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var position = ((List<Position>)positionGridView.DataSource)[e.RowIndex];

            positionType.Text = position.type;
            positionPosition.Text = position.position;
            positionDepartment.Text = position.department;
            positionOrder.Text = position.order;
            positionIsElected.Checked = position.elected;
            positionElectionProtocol.Text = position.election_protocol;
        }

        private void experienceGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var experience = ((List<Experience>)experienceGridView.DataSource)[e.RowIndex];

            experienceType.Text = experience.type;
            var y = experience.duration / 12;
            var m = experience.duration - y * 12;
            experienceDurationYears.Value = y;
            experienceDurationMonths.Value = m;
            experienceDate.Value = experience.date;
        }

        private void educationGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var education = ((List<DomainClasses.Main.Education>)educationGridView.DataSource)[e.RowIndex];

            educationLevel.Text = education.level;
            educationSpeciality.Text = education.specialty;
            educationQualification.Text = education.qualification;
            educationYear.Text = education.year.ToString();
        }

        private void academicDegreeGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var academicDegree = ((List<AcademicDegree>)academicDegreeGridView.DataSource)[e.RowIndex];

            academicDegreeDegree.Text = academicDegree.degree;
            academicDegreeScienceField.Text = academicDegree.science_field;
            academicDegreeDate.Value = academicDegree.date;
        }

        private void academicRankGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var academicRank = ((List<AcademicRank>)academicRankGridView.DataSource)[e.RowIndex];
            academicRankRank.Text = academicRank.rank;
            academicRankDate.Value = academicRank.date;
        }

        private async void positionAdd_Click(object sender, EventArgs e)
        {
            if (TeacherListView.SelectedCells.Count == 0)
            {
                return;
            }
            var teacher = ((List<Teacher>)TeacherListView.DataSource)[TeacherListView.SelectedCells[0].RowIndex];

            var position = new Position();

            position.type = positionType.Text;
            position.position = positionPosition.Text;
            position.department = positionDepartment.Text;
            position.order = positionOrder.Text;
            position.elected = positionIsElected.Checked;
            position.election_protocol = positionElectionProtocol.Text;

            position.teacher_id = teacher.id;

            pRepo.add(position);

            UpdatePositionsList(teacher.id);
        }

        private async void UpdatePositionsList(int teacherId)
        {
            var positions = await Task.Run(() => pRepo.teacherAll(teacherId));
            positionGridView.DataSource = positions;

            positionGridView.Columns["id"].Visible = false;

            positionGridView.Columns["type"].HeaderText = "Условие привлечения";
            positionGridView.Columns["position"].HeaderText = "Должность";
            positionGridView.Columns["department"].HeaderText = "Кафедра";
            positionGridView.Columns["order"].HeaderText = "Приказ";
            positionGridView.Columns["elected"].HeaderText = "По конкурсу?";
            positionGridView.Columns["election_protocol"].HeaderText = "Протокол избрания";

            positionGridView.Columns["teacher_id"].Visible = false;
        }

        private async void positionUpdate_Click(object sender, EventArgs e)
        {
            if (TeacherListView.SelectedCells.Count == 0)
            {
                return;
            }
            var teacher = ((List<Teacher>)TeacherListView.DataSource)[TeacherListView.SelectedCells[0].RowIndex];

            if (positionGridView.SelectedCells.Count == 0)
            {
                return;
            }
            var position = ((List<Position>)positionGridView.DataSource)[positionGridView.SelectedCells[0].RowIndex];

            position.type = positionType.Text;
            position.position = positionPosition.Text;
            position.department = positionDepartment.Text;
            position.order = positionOrder.Text;
            position.elected = positionIsElected.Checked;
            position.election_protocol = positionElectionProtocol.Text;

            pRepo.update(position, position.id);

            UpdatePositionsList(teacher.id);
        }

        private async void positionRemove_Click(object sender, EventArgs e)
        {
            if (TeacherListView.SelectedCells.Count == 0)
            {
                return;
            }
            var teacher = ((List<Teacher>)TeacherListView.DataSource)[TeacherListView.SelectedCells[0].RowIndex];

            if (positionGridView.SelectedCells.Count == 0)
            {
                return;
            }
            var position = ((List<Position>)positionGridView.DataSource)[positionGridView.SelectedCells[0].RowIndex];

            pRepo.delete(position.id);

            UpdatePositionsList(teacher.id);
        }

        private async void experienceAdd_Click(object sender, EventArgs e)
        {
            if (TeacherListView.SelectedCells.Count == 0)
            {
                return;
            }
            var teacher = ((List<Teacher>)TeacherListView.DataSource)[TeacherListView.SelectedCells[0].RowIndex];

            var experience = new Experience();

            experience.type = experienceType.Text;            
            experience.duration = (int)experienceDurationYears.Value * 12 + (int)experienceDurationMonths.Value;
            experience.date = experienceDate.Value;

            experience.teacher_id = teacher.id;

            expRepo.add(experience);

            UpdateExperienceList(teacher.id);
        }

        private async void UpdateExperienceList(int teacherId)
        {
            var experiences = await Task.Run(() => expRepo.teacherAll(teacherId));
            experienceGridView.DataSource = experiences;

            experienceGridView.Columns["id"].Visible = false;

            experienceGridView.Columns["type"].HeaderText = "Вид стажа";
            experienceGridView.Columns["duration"].HeaderText = "Продолжительность (месяцев)";
            experienceGridView.Columns["date"].HeaderText = "Дата";

            experienceGridView.Columns["teacher_id"].Visible = false;
        }

        private async void experienceUpdate_Click(object sender, EventArgs e)
        {
            if (TeacherListView.SelectedCells.Count == 0)
            {
                return;
            }
            var teacher = ((List<Teacher>)TeacherListView.DataSource)[TeacherListView.SelectedCells[0].RowIndex];
            if (experienceGridView.SelectedCells.Count == 0)
            {
                return;
            }
            var experience = ((List<Experience>)experienceGridView.DataSource)[experienceGridView.SelectedCells[0].RowIndex];

            experience.type = experienceType.Text;
            experience.duration = (int)experienceDurationYears.Value * 12 + (int)experienceDurationMonths.Value;
            experience.date = experienceDate.Value;

            experience.teacher_id = teacher.id;

            expRepo.update(experience, experience.id);

            UpdateExperienceList(teacher.id);
        }

        private async void experienceRemove_Click(object sender, EventArgs e)
        {
            if (TeacherListView.SelectedCells.Count == 0)
            {
                return;
            }
            var teacher = ((List<Teacher>)TeacherListView.DataSource)[TeacherListView.SelectedCells[0].RowIndex];

            if (experienceGridView.SelectedCells.Count == 0)
            {
                return;
            }
            var experience = ((List<Experience>)experienceGridView.DataSource)[experienceGridView.SelectedCells[0].RowIndex];

            expRepo.delete(experience.id);

            UpdateExperienceList(teacher.id);
        }

        private async void educationAdd_Click(object sender, EventArgs e)
        {
            if (TeacherListView.SelectedCells.Count == 0)
            {
                return;
            }
            var teacher = ((List<Teacher>)TeacherListView.DataSource)[TeacherListView.SelectedCells[0].RowIndex];

            var education = new DomainClasses.Main.Education();

            education.level = educationLevel.Text;
            education.specialty = educationSpeciality.Text;
            education.qualification = educationQualification.Text;
            education.year = int.Parse(educationYear.Text);

            education.teacher_id = teacher.id;

            eduRepo.add(education);

            UpdateEducationList(teacher.id);
        }

        private async void UpdateEducationList(int teacherId)
        {
            var educations = await Task.Run(() => eduRepo.teacherAll(teacherId));
            educationGridView.DataSource = educations;

            educationGridView.Columns["id"].Visible = false;

            educationGridView.Columns["level"].HeaderText = "Уровень";
            educationGridView.Columns["specialty"].HeaderText = "Специальность/направление";
            educationGridView.Columns["qualification"].HeaderText = "Квалификация";
            educationGridView.Columns["year"].HeaderText = "Год";

            educationGridView.Columns["teacher_id"].Visible = false;
        }

        private async void educationUpdate_Click(object sender, EventArgs e)
        {
            if (TeacherListView.SelectedCells.Count == 0)
            {
                return;
            }
            var teacher = ((List<Teacher>)TeacherListView.DataSource)[TeacherListView.SelectedCells[0].RowIndex];

            if (educationGridView.SelectedCells.Count == 0)
            {
                return;
            }
            var education = ((List<DomainClasses.Main.Education>)educationGridView.DataSource)[educationGridView.SelectedCells[0].RowIndex];

            education.level = educationLevel.Text;
            education.specialty = educationSpeciality.Text;
            education.qualification = educationQualification.Text;
            education.year = int.Parse(educationYear.Text);
            
            eduRepo.update(education, education.id);

            UpdateEducationList(teacher.id);
        }

        private async void educationRemove_Click(object sender, EventArgs e)
        {
            if (TeacherListView.SelectedCells.Count == 0)
            {
                return;
            }
            var teacher = ((List<Teacher>)TeacherListView.DataSource)[TeacherListView.SelectedCells[0].RowIndex];

            if (educationGridView.SelectedCells.Count == 0)
            {
                return;
            }
            var education = ((List<DomainClasses.Main.Education>)educationGridView.DataSource)[educationGridView.SelectedCells[0].RowIndex];

            eduRepo.delete(education.id);

            UpdateEducationList(teacher.id);
        }

        private async void academicDegreeAdd_Click(object sender, EventArgs e)
        {
            if (TeacherListView.SelectedCells.Count == 0)
            {
                return;
            }
            var teacher = ((List<Teacher>)TeacherListView.DataSource)[TeacherListView.SelectedCells[0].RowIndex];

            var academicDegree = new AcademicDegree();

            academicDegree.degree = academicDegreeDegree.Text;
            academicDegree.science_field = academicDegreeScienceField.Text;
            academicDegree.date = academicDegreeDate.Value;

            academicDegree.teacher_id = teacher.id;

            adRepo.add(academicDegree);

            UpdateAcademicDegreeList(teacher.id);
        }

        private async void UpdateAcademicDegreeList(int teacherId)
        {
            var academicDegrees = await Task.Run(() => adRepo.teacherAll(teacherId));
            academicDegreeGridView.DataSource = academicDegrees;

            academicDegreeGridView.Columns["id"].Visible = false;

            academicDegreeGridView.Columns["degree"].HeaderText = "Учёная степень";
            academicDegreeGridView.Columns["science_field"].HeaderText = "Область наук";
            academicDegreeGridView.Columns["date"].HeaderText = "Дата";

            academicDegreeGridView.Columns["teacher_id"].Visible = false;
        }

        private async void academicDegreeUpdate_Click(object sender, EventArgs e)
        {
            if (TeacherListView.SelectedCells.Count == 0)
            {
                return;
            }
            var teacher = ((List<Teacher>)TeacherListView.DataSource)[TeacherListView.SelectedCells[0].RowIndex];
            if (academicDegreeGridView.SelectedCells.Count == 0)
            {
                return;
            }
            var academicDegree = ((List<AcademicDegree>)academicDegreeGridView.DataSource)[academicDegreeGridView.SelectedCells[0].RowIndex];

            academicDegree.degree = academicDegreeDegree.Text;
            academicDegree.science_field = academicDegreeScienceField.Text;
            academicDegree.date = academicDegreeDate.Value;

            adRepo.update(academicDegree, academicDegree.id);

            UpdateAcademicDegreeList(teacher.id);
        }

        private async void academicDegreeRemove_Click(object sender, EventArgs e)
        {
            if (TeacherListView.SelectedCells.Count == 0)
            {
                return;
            }
            var teacher = ((List<Teacher>)TeacherListView.DataSource)[TeacherListView.SelectedCells[0].RowIndex];
            if (academicDegreeGridView.SelectedCells.Count == 0)
            {
                return;
            }
            var academicDegree = ((List<AcademicDegree>)academicDegreeGridView.DataSource)[academicDegreeGridView.SelectedCells[0].RowIndex];

            adRepo.delete(academicDegree.id);

            UpdateAcademicDegreeList(teacher.id);
        }

        private async void academicRankAdd_Click(object sender, EventArgs e)
        {
            if (TeacherListView.SelectedCells.Count == 0)
            {
                return;
            }
            var teacher = ((List<Teacher>)TeacherListView.DataSource)[TeacherListView.SelectedCells[0].RowIndex];

            var academicRank = new AcademicRank();

            academicRank.rank = academicRankRank.Text;            
            academicRank.date = academicRankDate.Value;

            academicRank.teacher_id = teacher.id;

            arRepo.add(academicRank);

            UpdateAcademicRankList(teacher.id);
        }

        private async void UpdateAcademicRankList(int teacherId)
        {
            var academicRanks = await Task.Run(() => arRepo.teacherAll(teacherId));
            academicRankGridView.DataSource = academicRanks;

            academicRankGridView.Columns["id"].Visible = false;

            academicRankGridView.Columns["rank"].HeaderText = "Учёное звание";
            academicRankGridView.Columns["date"].HeaderText = "Дата";

            academicRankGridView.Columns["teacher_id"].Visible = false;
        }

        private async void academicRankUpdate_Click(object sender, EventArgs e)
        {
            if (TeacherListView.SelectedCells.Count == 0)
            {
                return;
            }
            var teacher = ((List<Teacher>)TeacherListView.DataSource)[TeacherListView.SelectedCells[0].RowIndex];
            if (academicRankGridView.SelectedCells.Count == 0)
            {
                return;
            }
            var academicRank = ((List<AcademicRank>)academicRankGridView.DataSource)[academicRankGridView.SelectedCells[0].RowIndex];

            academicRank.rank = academicRankRank.Text;            
            academicRank.date = academicRankDate.Value;

            arRepo.update(academicRank, academicRank.id);

            UpdateAcademicRankList(teacher.id);
        }

        private async void academicRankRemove_Click(object sender, EventArgs e)
        {
            if (TeacherListView.SelectedCells.Count == 0)
            {
                return;
            }
            var teacher = ((List<Teacher>)TeacherListView.DataSource)[TeacherListView.SelectedCells[0].RowIndex];
            if (academicRankGridView.SelectedCells.Count == 0)
            {
                return;
            }
            var academicRank = ((List<AcademicRank>)academicRankGridView.DataSource)[academicRankGridView.SelectedCells[0].RowIndex];

            arRepo.delete(academicRank.id);

            UpdateAcademicRankList(teacher.id);
        }

        private void importAccessData_Click(object sender, EventArgs e)
        {
            // Person
            var PersonList = new List<Person>();            
            var personsData = new PersonsTableAdapter().GetData().Rows;
            foreach (var person in personsData)
            {
                var row = (PersonsRow)person;
                PersonList.Add(new Person {
                    Person_ID = row.Person_ID,
                    Person_FIO = row.Person_FIO
                });
            }

            // Dolgnost
            var DolgnostList = new List<Dolgnost>();
            var dolgnostData = new DolgnostTableAdapter().GetData().Rows;
            foreach (var dolgnost in dolgnostData)
            {
                var row = (DolgnostRow)dolgnost;
                DolgnostList.Add(new Dolgnost
                {
                    Dolg_Person_ID = row.Dolg_Person_ID,
                    DolgnostName = row.Dolgnost,
                    Uslovie_ID = row.Uslovie,
                    Prikaz = row.Prikaz,
                    Pokonkursu = row.Pokonkursu.ToString(),
                    Konkurs = row.Konkurs,
                    KafID = row.KafID
                });
            }

            // DolgnostUsl
            var DolgUslList = new List<DolgUsl>();
            var duData = new DolgUslTableAdapter().GetData().Rows;
            foreach (var du in duData)
            {
                var row = (DolgUslRow)du;
                DolgUslList.Add(new DolgUsl
                {
                    DolgUsl_ID = row.DolgUslovija_ID,
                    DolgUsl_Desc = row.DolgUslovija_Desc,
                    DolgUsl_Desc2 = row.DolgUslovija_Desc2
                });
            }

            // Education
            var EducationList = new List<AccessPps.AccessClasses.Education>();
            var edData = new EducationTableAdapter().GetData().Rows;
            foreach (var ed in edData)
            {
                var row = (EducationRow)ed;
                EducationList.Add(new AccessPps.AccessClasses.Education
                {
                    Edu_Person_ID = row.Edu_Person_ID,
                    Edu_Counter = row.Edu_Counter,
                    Edu_Level = row.Edu_Level,
                    Edu_Year = row.Edu_Year,
                    Edu_Kval = row.Edu_Kval,
                    Edu_Spec = row.Edu_Spec
                });
            }

            // EduLevel
            var EduLevelList = new List<AccessPps.AccessClasses.EduLevel>();
            var elData = new EduLevelsTableAdapter().GetData().Rows;
            foreach (var el in elData)
            {
                var row = (EduLevelsRow)el;
                EduLevelList.Add(new EduLevel
                {
                    Edu_Level_ID = row.Edu_Level_ID,
                    Edu_Level_Desc = row.Edu_Level_Disc
                });
            }

            // Stage
            var StageList = new List<Stage>();
            var stData = new StageTableAdapter().GetData().Rows;
            foreach (var st in stData)
            {
                var row = (StageRow)st;
                StageList.Add(new Stage
                {
                    Stage_Person_ID = row.Stage_Person_ID,
                    Stage_Typ_ID = row.Stage_Typ,
                    Stage_Years = row.Stage_Years,
                    Stage_Months = row.Stage_Months
                });
            }

            // StageTyp
            var StageTypList = new List<StageTyp>();
            var sttData = new StageTypsTableAdapter().GetData().Rows;
            foreach (var stt in sttData)
            {
                var row = (StageTypsRow)stt;
                StageTypList.Add(new StageTyp
                {
                   StageTyp_ID = row.StageTyp_ID,
                   StageTyp_Desc = row.StageTyp_Desc
                });
            }

            // Zvanije
            var ZvanijeList = new List<Zvanije>();
            var zData = new ZvanijaTableAdapter().GetData().Rows;
            foreach (var z in zData)
            {
                var row = (ZvanijaRow)z;
                ZvanijeList.Add(new Zvanije
                {
                    Zvanije_Person_ID = row.Zvan_Person_ID,
                    Zvanije_Counter = row.ZvanCounter,
                    Zvanije_Typ_ID = row.Zvan_ZvanID
                });
            }

            // ZvanTyp
            var ZvanijeTypList = new List<ZvanijeTyp>();
            var ztData = new ZvanTypsTableAdapter().GetData().Rows;
            foreach (var zt in ztData)
            {
                var row = (ZvanTypsRow)zt;
                ZvanijeTypList.Add(new ZvanijeTyp
                {
                    ZvanijeTyp_ID = row.ZvanTyp_ID,
                    ZvanijeTyp_Desc = row.ZvanTyp_Desc
                });
            }

            // Stepeni
            var StepenList = new List<Stepen>();
            var sData = new StepeniTableAdapter().GetData().Rows;
            foreach (var s in sData)
            {
                var row = (StepeniRow)s;
                StepenList.Add(new Stepen
                {
                    Step_Person_ID = row.Step_Person_ID,
                    Step_Counter = row.Step_Counter,
                    Step_TypID = row.Step_TypID,
                    Step_Nayk = row.Step_Nauk
                });
            }

            // StepTyps
            var StepTypList = new List<StepTyp>();
            var stypsData = new StepTypsTableAdapter().GetData().Rows;
            foreach (var styp in stypsData)
            {
                var row = (StepTypsRow)styp;
                StepTypList.Add(new StepTyp
                {
                    StepTyp_ID = row.StepTyp_ID,
                    StepTyp_Desc = row.StepTyp_Desc
                });
            }

            // StepNauki
            var StepNaukiList = new List<StepNauki>();
            var snData = new StepNaukiTableAdapter().GetData().Rows;
            foreach (var sn in snData)
            {
                var row = (StepNaukiRow)sn;
                StepNaukiList.Add(new StepNauki
                {
                    StepNayki_ID = row.StepNauki_ID,
                    StepNayki_Full = row.StepNauki_Full,
                    StepNayki_Short = row.StepNauki_Short
                });
            }

            // Kaf
            var KafList = new List<Kaf>();
            var kData = new KafTableAdapter().GetData().Rows;
            foreach (var k in kData)
            {
                var row = (KafRow)k;
                KafList.Add(new Kaf
                {
                    Kaf_ID = row.Kaf_ID,
                    Kaf_Im = row.Kaf_Im,
                    Kaf_Rd = row.Kaf_Rd,
                    Kaf_Src = row.Kaf_Src
                });
            }

            var teachers = tRepo.all()
                .OrderBy(t => t.f)
                .ThenBy(t => t.i)
                .ThenBy(t => t.o)
                .ThenBy(t => t.birth_date)
                .ToList();

            var personTeacherIdDict = new Dictionary<int, int>();

            for (int i = 0; i < teachers.Count; i++)
            {
                var teacher = teachers[i];

                var p = PersonList.FirstOrDefault(per => per.Person_FIO == teacher.f + " " + teacher.i + " " + teacher.o);
                if (p != null)
                {
                    personTeacherIdDict.Add(p.Person_ID, teacher.id);

                    // Dolgnost
                    var dolList = DolgnostList
                        .Where(d => d.Dolg_Person_ID == p.Person_ID)
                        .ToList();
                    var positions = Position.FromAccessList(dolList, DolgUslList, KafList, teacher.id);
                    foreach (var pos in positions)
                    {
                        pRepo.add(pos);
                    }

                    // Education
                    var eduList = EducationList
                        .Where(ed => ed.Edu_Person_ID == p.Person_ID)
                        .ToList();
                    var educations = DomainClasses.Main.Education.FromAccessList(eduList, EduLevelList, teacher.id);
                    foreach (var education in educations)
                    {
                        eduRepo.add(education);
                    }

                    // Stage
                    var stList = StageList
                        .Where(st => st.Stage_Person_ID == p.Person_ID)
                        .ToList();
                    var experiences = Experience.FromAccessList(stList, StageTypList, teacher.id);
                    foreach (var experience in experiences)
                    {
                        expRepo.add(experience);
                    }

                    // Zavinija
                    var ZvanList = ZvanijeList
                        .Where(zv => zv.Zvanije_Person_ID == p.Person_ID)
                        .ToList();
                    var academicRanks = AcademicRank.FromAccessList(ZvanList, ZvanijeTypList, teacher.id);
                    foreach (var academicRank in academicRanks)
                    {
                        arRepo.add(academicRank);
                    }

                    //Steneni
                    var StepList = StepenList
                        .Where(st => st.Step_Person_ID == p.Person_ID)
                        .ToList();
                    var academicDegrees = AcademicDegree.FromAccessList(StepList, StepTypList, StepNaukiList, teacher.id);
                    foreach (var academicDegree in academicDegrees)
                    {
                        adRepo.add(academicDegree);
                    }
                }                
            }            
        }

        private void fioFilter_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Start();
        }
    }
}
