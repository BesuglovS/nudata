using nudata.nubackRepos;
using nudata.Properties;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nudata.Forms
{
    public partial class AuthForm : Form
    {
        string ApiEndpoint;

        public AuthForm(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
            InitializeComponent();
        }

        private void showpassinclertext_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPassInCleartext.Checked)
            {
                PasswordText.PasswordChar = '\0';
            }
            else
            {
                PasswordText.PasswordChar = '*';                
            }
        }

        private void DismissButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void OKButton_Click(object sender, EventArgs e)
        {
            StartupForm.username = LoginText.Text;
            StartupForm.password = PasswordText.Text;
            OKButton.Text = "";
            OKButton.Enabled = false;
            OKButton.Image = Resources.Loading;

            var authFailed = false;

            await Task.Run(() => { 
                var upRepo = new UserPermissionRepo(ApiEndpoint);
                try
                {
                    StartupForm.Permissions = upRepo.getByName(StartupForm.username);
                }
                catch (Exception exc)
                {
                    if (exc.Message == "Запрос был прерван: Соединение было неожиданно закрыто.")
                    {
                        MessageBox.Show("Комбинация логина и пароля неверна.", "Ошибка");
                        authFailed = true;
                    }
                    else
                    {
                        MessageBox.Show(exc.Message, "Ошибка");
                        authFailed = true;
                    }
                }                
            });

            if (!authFailed)
            {
                Close();
            }
            else
            {
                OKButton.Image = null;                
                OKButton.Enabled = true;
                OKButton.Text = "OK";
            }
        }

        private void PasswordText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                OKButton.PerformClick();
            }
        }
    }
}
