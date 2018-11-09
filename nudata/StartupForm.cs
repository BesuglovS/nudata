﻿using nudata.Core;
using nudata.Forms;
using nudata.nubackRepos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace nudata
{
    public partial class StartupForm : Form
    {
        public const string ApiEndpoint = "http://wiki.nayanova.edu/dataapi";
        //public const string ApiEndpoint = "http://127.0.0.1:8000";

        public static string username = "admin";
        public static string password = "admin";
        private UserPermissionRepo upRepo;

        public static List<string> Permissions = new List<string>();

        bool _studentListFormOpened;
        public StudentList StudentListForm;

        bool _studentGroupsFormOpened;
        public StudentGroupList StudentGroupsForm;

        bool _authFormOpened;
        public AuthForm AuthForm;

        bool _facultyFormOpened;
        public FacultyList FacultyForm;

        bool _teacherFormOpened;
        public TeacherList TeacherForm;

        bool _phoneFormOpened;
        public PhoneForm PhoneForm;

        bool _departmentFormOpened;
        public DepartmentList DepartmentForm;

        bool _noteFormOpened;
        public NoteList NoteForm;

        bool _learningPlanFormOpened;
        public LearningPlanList LearningPlanForm;

        bool _studentLearningPlanOpened;
        public StudentLearningPlanList StudentLearningPlanForm;

        bool _teacherCardsListOpened;
        public TeacherCardsList TeacherCardsForm;

        public StartupForm()
        {
            InitializeComponent();

            // Контингент - Alt-S
            HotKeyManager.RegisterHotKey(Keys.S, (uint)KeyModifiers.Alt);

            // Аутентификация - Alt-A
            HotKeyManager.RegisterHotKey(Keys.A, (uint)KeyModifiers.Alt);

            // Группы студентов - Ctrl-Alt-S
            HotKeyManager.RegisterHotKey(Keys.S, (uint)(KeyModifiers.Control | KeyModifiers.Alt));

            // Факультеты - Alt-F
            HotKeyManager.RegisterHotKey(Keys.F, (uint)KeyModifiers.Alt);

            // Телефоны - Alt-P
            HotKeyManager.RegisterHotKey(Keys.P, (uint)KeyModifiers.Alt);

            // Кафедры - Alt-D
            HotKeyManager.RegisterHotKey(Keys.D, (uint)KeyModifiers.Alt);

            // Заметки - Alt-N
            HotKeyManager.RegisterHotKey(Keys.N, (uint)KeyModifiers.Alt);

            // Учебные планы - Alt-L
            HotKeyManager.RegisterHotKey(Keys.L, (uint)KeyModifiers.Alt);

            // Учебные планы студентов - Ctrl-Alt-L
            HotKeyManager.RegisterHotKey(Keys.L, (uint)(KeyModifiers.Control | KeyModifiers.Alt));

            // Карточки учебных поручений - Alt-C
            HotKeyManager.RegisterHotKey(Keys.C, (uint)KeyModifiers.Alt);

            HotKeyManager.HotKeyPressed += ManageHotKeys;

            trayIcon.Visible = true;

            upRepo = new UserPermissionRepo(ApiEndpoint);

            ShowAuthForm();
        }

        protected override void SetVisibleCore(bool value)
        {
            // Quick and dirty to keep the main window invisible
            base.SetVisibleCore(false);
        }

        private void ManageHotKeys(object sender, HotKeyEventArgs e)
        {
            if (e.Modifiers == KeyModifiers.Alt)
            {
                if (e.Key == Keys.S)
                {
                    ShowStudentListForm();
                }

                if (e.Key == Keys.A)
                {
                    ShowAuthForm();
                }

                if (e.Key == Keys.F)
                {
                    ShowFacultyForm();
                }

                if (e.Key == Keys.P)
                {
                    ShowPhoneForm();
                }

                if (e.Key == Keys.D)
                {
                    ShowDepartmentForm();
                }

                if (e.Key == Keys.N)
                {
                    ShowNoteForm();
                }

                if (e.Key == Keys.L)
                {
                    ShowLearningPlanForm();
                }

                if (e.Key == Keys.C)
                {
                    ShowTeacherCardsForm();
                }
            }

            if (e.Modifiers == (KeyModifiers.Control | KeyModifiers.Alt))
            {
                if (e.Key == Keys.S)
                {
                    ShowStudentGroupsForm();
                }

                if (e.Key == Keys.T)
                {
                    ShowTeacherForm();
                }

                if (e.Key == Keys.L)
                {
                    ShowStudentLearningPlanForm();
                }
            }
        }

        private void ShowTeacherCardsForm()
        {
            if (!AppPermissions.Check("TeacherCardsList"))
            {
                MessageBox.Show("У вас нет разрешения на использование этой части приложения.");

                return;
            }

            if (_teacherCardsListOpened)
            {
                TeacherCardsForm.Activate();
                TeacherCardsForm.Focus();
                return;
            }

            TeacherCardsForm = new TeacherCardsList(ApiEndpoint);
            _teacherCardsListOpened = true;
            TeacherCardsForm.Show();
            _teacherCardsListOpened = false;
        }

        private void ShowStudentLearningPlanForm()
        {
            if (!AppPermissions.Check("StudentLearningPlanList"))
            {
                MessageBox.Show("У вас нет разрешения на использование этой части приложения.");

                return;
            }

            if (_studentLearningPlanOpened)
            {
                StudentLearningPlanForm.Activate();
                StudentLearningPlanForm.Focus();
                return;
            }

            StudentLearningPlanForm = new StudentLearningPlanList(ApiEndpoint);
            _studentLearningPlanOpened = true;
            StudentLearningPlanForm.Show();
            _studentLearningPlanOpened = false;
        }

        private void ShowPhoneForm()
        {
            if (!AppPermissions.Check("PhoneForm"))
            {
                MessageBox.Show("У вас нет разрешения на использование этой части приложения.");

                return;
            }

            if (_phoneFormOpened)
            {
                PhoneForm.Activate();
                PhoneForm.Focus();
                return;
            }

            PhoneForm = new PhoneForm(ApiEndpoint);
            _phoneFormOpened = true;
            PhoneForm.Show();
            _phoneFormOpened = false;
        }

        private void ShowAuthForm()
        {
            if (_authFormOpened)
            {
                AuthForm.Activate();
                AuthForm.Focus();
                return;
            }

            AuthForm = new AuthForm(ApiEndpoint);
            _authFormOpened = true;
            AuthForm.Show();
            _authFormOpened = false;
        }        

        private void контингентAltSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowStudentListForm();
        }

        private void ShowStudentListForm()
        {
            if (!AppPermissions.Check("StudentListForm"))
            {
                MessageBox.Show("У вас нет разрешения на использование этой части приложения.");

                return;
            }

            if (_studentListFormOpened)
            {
                StudentListForm.Activate();
                StudentListForm.Focus();
                return;
            }

            StudentListForm = new StudentList(ApiEndpoint);
            _studentListFormOpened = true;
            StudentListForm.Show();
            _studentListFormOpened = false;
        }

        private void ShowStudentGroupsForm()
        {
            if (!AppPermissions.Check("StudentGroupsForm"))
            {
                MessageBox.Show("У вас нет разрешения на использование этой части приложения.");

                return;
            }

            if (_studentGroupsFormOpened)
            {
                StudentGroupsForm.Activate();
                StudentGroupsForm.Focus();
                return;
            }

            StudentGroupsForm = new StudentGroupList(ApiEndpoint);
            _studentGroupsFormOpened = true;
            StudentGroupsForm.Show();
            _studentGroupsFormOpened = false;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void группыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowStudentGroupsForm();
        }

        private void аутентификацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAuthForm(); 
        }

        private void факультетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFacultyForm();
        }

        private void ShowFacultyForm()
        {
            if (!AppPermissions.Check("FacultyForm"))
            {
                MessageBox.Show("У вас нет разрешения на использование этой части приложения.");

                return;
            }

            if (_facultyFormOpened)
            {
                FacultyForm.Activate();
                FacultyForm.Focus();
                return;
            }

            FacultyForm = new FacultyList(ApiEndpoint);
            _facultyFormOpened = true;
            FacultyForm.Show();
            _facultyFormOpened = false;
        }

        private void преподавателиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTeacherForm();
        }

        private void ShowTeacherForm()
        {
            if (!AppPermissions.Check("TeacherForm"))
            {
                MessageBox.Show("У вас нет разрешения на использование этой части приложения.");

                return;
            }

            if (_teacherFormOpened)
            {
                TeacherForm.Activate();
                TeacherForm.Focus();
                return;
            }

            TeacherForm = new TeacherList(ApiEndpoint);
            _teacherFormOpened = true;
            TeacherForm.Show();
            _teacherFormOpened = false;
        }

        private void телефоныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPhoneForm();
        }

        private void кафедрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDepartmentForm();
        }

        private void ShowDepartmentForm()
        {
            if (!AppPermissions.Check("DepartmentForm"))
            {
                MessageBox.Show("У вас нет разрешения на использование этой части приложения.");

                return;
            }

            if (_departmentFormOpened)
            {
                DepartmentForm.Activate();
                DepartmentForm.Focus();
                return;
            }

            DepartmentForm = new DepartmentList(ApiEndpoint);
            _departmentFormOpened = true;
            DepartmentForm.Show();
            _departmentFormOpened = false;
        }

        private void заметкиAltNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNoteForm();
        }

        private void ShowNoteForm()
        {
            if (!AppPermissions.Check("NoteForm"))
            {
                MessageBox.Show("У вас нет разрешения на использование этой части приложения.");

                return;
            }

            if (_noteFormOpened)
            {
                NoteForm.Activate();
                NoteForm.Focus();
                return;
            }

            NoteForm = new NoteList(ApiEndpoint);
            _noteFormOpened = true;
            NoteForm.Show();
            _noteFormOpened = false;
        }

        private void учебныеПланыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLearningPlanForm();
        }

        private void ShowLearningPlanForm()
        {
            if (!AppPermissions.Check("LearningPlanForm"))
            {
                MessageBox.Show("У вас нет разрешения на использование этой части приложения.");

                return;
            }

            if (_learningPlanFormOpened)
            {
                LearningPlanForm.Activate();
                NoteForm.Focus();
                return;
            }

            LearningPlanForm = new LearningPlanList(ApiEndpoint);
            _learningPlanFormOpened = true;
            LearningPlanForm.Show();
            _learningPlanFormOpened = false;
        }

        private void учебныеПланыСтудентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowStudentLearningPlanForm();
        }

        private void карточкиУчебныхПорученийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTeacherCardsForm();
        }
    }
}
