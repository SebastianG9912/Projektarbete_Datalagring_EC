using System.Runtime.CompilerServices;
using Backend.Data;

namespace WinFormsFrontend
{
    public partial class AdminFormLogin : Form
    {
        public AdminFormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            /*bool couldLogIn = AdminBackend.LogIn(username, password);
            if (!couldLogIn)//TODO skippa couldLogin, använd methodcall direkt
            {
                infoLabel.Text = "Wrong username or password! Please try again";
                return;
            }*/

            //Swap winforms window (Go to menu)
            var menu = new AdminFormMenu();
            menu.Location = this.Location;
            menu.StartPosition = FormStartPosition.Manual;
            menu.FormClosing += delegate{this.Show();};
            menu.Show();
            this.Hide();
        }
    }
}