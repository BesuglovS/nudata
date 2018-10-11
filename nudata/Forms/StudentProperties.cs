using nudata.DomainClasses.Extra;
using nudata.DomainClasses.Main;
using nudata.nubackRepos;
using System;
using System.Linq;
using System.Windows.Forms;

namespace nudata.Forms
{
    public partial class StudentProperties : Form
    {
        private Student Student;        
        private readonly StudentDetailsMode Mode;
        StudentList StudentList;
        string ApiEndpoint;

        StudentRepo sRepo;
        StudentGroupRepo sgRepo;
        StudentStudentGroupRepo ssgRepo;

        public StudentProperties(StudentList studentList, int id, StudentDetailsMode mode, string apiEndpoint)
        {
            InitializeComponent();
            ApiEndpoint = apiEndpoint;

            Mode = mode;
            StudentList = studentList;
            sRepo = new StudentRepo(ApiEndpoint);
            sgRepo = new StudentGroupRepo(ApiEndpoint);
            ssgRepo = new StudentStudentGroupRepo(ApiEndpoint);
            Student = sRepo.get(id);

            if (mode == StudentDetailsMode.New)
            {
                DeleteStudent.Enabled = false;
            }
        }

        private void StudentPropertiesLoad(object sender, EventArgs e)
        {
            SetControlsFromStudent(Student);
        }

        private void SetControlsFromStudent(Student studentToSet)
        {
            FamilyBox.Text = studentToSet?.f;
            NameBox.Text = studentToSet?.i;
            PatronymicBox.Text = studentToSet?.o;
            IdNumBox.Text = studentToSet?.zach_number;
            if (studentToSet != null)
            {
                BirthDateBox.Value = studentToSet.birth_date;
            }
            AddressBox.Text = studentToSet?.address;
            PhoneBox.Text = studentToSet?.phone;
            OrdersBox.Text = studentToSet?.orders;
            StarostaBox.Checked = studentToSet?.starosta == "1";
            FromSchoolBox.Checked = studentToSet?.n_factor == "1";
            PaidLearningBox.Checked = studentToSet?.paid_edu == "1";
            ExpelledBox.Checked = studentToSet?.expelled == "1";

            if (Student != null) {
                var groups = sRepo.groups(Student.id);
                var groupsString = ((groups == null) || (groups.Count == 0)) ? "" :
                    groups
                    .Select(sg => sg.name)
                    .OrderBy(a => a)
                    .Aggregate((a, b) => a + ", " + b);

                StudentGroupBox.Text = groupsString;
            }

            StudentGroupBox.ReadOnly = true;
        }

        private void CancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SaveClick(object sender, EventArgs e)
        {
            if (Mode == StudentDetailsMode.New)
            {
                var s = new Student
                {
                    address = AddressBox.Text,
                    birth_date = BirthDateBox.Value,
                    expelled = ExpelledBox.Checked ? "1" : "0",
                    f = FamilyBox.Text,
                    i = NameBox.Text,
                    n_factor = FromSchoolBox.Checked ? "1" : "0",
                    o = PatronymicBox.Text,
                    orders = OrdersBox.Text,
                    paid_edu = PaidLearningBox.Checked ? "1" : "0",
                    phone = PhoneBox.Text,
                    starosta = StarostaBox.Checked ? "1" : "0",
                    zach_number = IdNumBox.Text
                };

                sRepo.add(s);               

                StudentList.UpdateSearchBoxItems();
                DialogResult = DialogResult.OK;
                Close();
            }

            if (Mode == StudentDetailsMode.Edit)
            {                
                Student.address = AddressBox.Text;
                Student.birth_date = BirthDateBox.Value;
                Student.expelled = ExpelledBox.Checked ? "1" : "0";
                Student.f = FamilyBox.Text;
                Student.i = NameBox.Text;
                Student.n_factor = FromSchoolBox.Checked ? "1" : "0";
                Student.o = PatronymicBox.Text;
                Student.orders = OrdersBox.Text;
                Student.paid_edu = PaidLearningBox.Checked ? "1" : "0";
                Student.phone = PhoneBox.Text;
                Student.starosta = StarostaBox.Checked ? "1" : "0";
                Student.zach_number = IdNumBox.Text;

                sRepo.update(Student, Student.id);

                StudentList.UpdateSearchBoxItems();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void FamilyBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void DeleteStudent_Click(object sender, EventArgs e)
        {
            sRepo.delete(Student.id);

            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
