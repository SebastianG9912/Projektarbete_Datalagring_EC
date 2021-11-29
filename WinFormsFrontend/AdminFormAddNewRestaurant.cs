using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Backend.Data;

namespace WinFormsFrontend
{
    public partial class AdminFormAddNewRestaurant : Form
    {
        public AdminFormAddNewRestaurant()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Försöker lägga till ny restaurang till databasen
        /// </summary>
        /// <param name="sender">Referens till knappen som blivit tryckt</param>
        /// <param name="e">Flaggar för att knappen blivit tryckt</param>
        private void btnAddRestaurant_Click(object sender, EventArgs e)
        {
            string name = txtBoxName.Text;
            string location = txtBoxLocation.Text;
            string phoneNmbr = txtBoxPhone.Text;
            bool restaurantDoesNotExists = AdminBackend.AddNewRestaurant(name, location, phoneNmbr);

            if (!restaurantDoesNotExists)
                MessageBox.Show("Restaurant with supplied information already exists!\n" +
                                "Please try again.","Already exists!",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                MessageBox.Show("Restaurant successfully added!", "Restaurant added", MessageBoxButtons.OK);
                txtBoxName.Text = "";
                txtBoxLocation.Text = "";
                txtBoxPhone.Text = "";
            }
        }
    }
}
