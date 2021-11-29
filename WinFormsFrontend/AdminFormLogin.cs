using System.Runtime.CompilerServices;
using Backend.Data;

namespace WinFormsFrontend
{
    /// <summary>
    /// Inloggningsf�nstret f�r admin UI
    /// </summary>
    public partial class AdminFormLogin : Form
    {
        public AdminFormLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// F�rs�ker logga in admin och byta till nytt f�nster
        /// </summary>
        /// <param name="sender">Referens till knappen som blivit tryckt</param>
        /// <param name="e">Flaggar f�r att knappen blivit tryckt</param>
        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            if (!AdminBackend.LogIn(username, password))
            {
                lblInfo.Text = "Wrong username or password! Please try again";
                return;
            }

            //Swap winforms window (Go to menu)
            var menu = new AdminFormMenu();
            menu.Location = Location;
            menu.StartPosition = FormStartPosition.Manual;
            menu.FormClosing += delegate
            {
                Show();
                tbUsername.Text = "";
                tbPassword.Text = "";
                lblInfo.Text = "Please enter username and password below";
            };
            menu.Show();
            Hide();
        }
    }
}