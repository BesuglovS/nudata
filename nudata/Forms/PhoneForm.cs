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
    public partial class PhoneForm : Form
    {
        private string ApiEndpoint;

        StudentRepo sRepo;
        TeacherRepo tRepo;
        List<Student> Students;
        List<Teacher> Teachers;
        List<PhoneItem> PhoneItems;

        Timer textTimer;

        public PhoneForm(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
            InitializeComponent();            
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            textTimer.Start();
        }

        private void PhoneForm_Load(object sender, EventArgs e)
        {
            IntPtr pIcon = Resources.phone.GetHicon();
            Icon = Icon.FromHandle(pIcon);

            textTimer = new Timer();
            textTimer.Interval = 1000;
            textTimer.Tick += new EventHandler(textTimer_Tick);

            Task.Run(() => {
                sRepo = new StudentRepo(ApiEndpoint);
                tRepo = new TeacherRepo(ApiEndpoint);

                Students = sRepo.all();
                Teachers = tRepo.all();

                var sItems = PhoneItem.FromStudentList(Students);
                var tItems = PhoneItem.FromTeacherList(Teachers);

                PhoneItems = new List<PhoneItem>();
                PhoneItems.AddRange(sItems);
                PhoneItems.AddRange(tItems);

                PhoneItems = PhoneItems.OrderBy(pi => pi.Name).ToList();
            });
        }

        private void textTimer_Tick(object sender, EventArgs e)
        {
            if (SearchBox.Focused)
            {
                var items = PhoneItems.Where(pi => pi.Name.ToLower().Contains(SearchBox.Text.ToLower())).ToList();

                phonesGrid.DataSource = items;

                phonesGrid.Columns["StudentId"].Visible = false;
                phonesGrid.Columns["TeacherId"].Visible = false;
                phonesGrid.Columns["PhoneType"].Width = 100;
                phonesGrid.Columns["PhoneType"].HeaderText = "Тип телефона";
                phonesGrid.Columns["Name"].Width = 200;
                phonesGrid.Columns["Name"].HeaderText = "ФИО";
                phonesGrid.Columns["Phone"].Width = 300;
                phonesGrid.Columns["Phone"].HeaderText = "Телефон";

                textTimer.Stop(); //No disposing required, just stop the timer.
            }
        }
    }
}
