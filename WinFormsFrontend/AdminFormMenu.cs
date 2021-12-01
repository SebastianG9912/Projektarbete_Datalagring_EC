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
    /// <summary>
    /// Huvudmeny för admin UI
    /// </summary>
    public partial class AdminFormMenu : Form
    {
        public AdminFormMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Resetar och potentiellt seedar databasen
        /// </summary>
        /// <param name="sender">Referens till knappen som blivit tryckt</param>
        /// <param name="e">Flaggar för att knappen blivit tryckt</param>
        private void btnResetDB_Click(object sender, EventArgs e)
        {
            AdminBackend.InitializeDatabase();

            txtBoxInfo.Text = "Database reset!";

            string msgTxt = "Do you want to seed database with testdata?";
            string caption = "Seed database";
            var buttons = MessageBoxButtons.YesNo;
            var msgIcon = MessageBoxIcon.Question;
            var result = MessageBox.Show(msgTxt, caption, buttons, msgIcon);

            if (result == DialogResult.Yes)
            {
                AdminBackend.Seed();
                txtBoxInfo.AppendText("\r\nDatabase seeded!");//Tydligen använder textboxes det gamla new line skrivsättet (\r\n)
            }
                
        }

        /// <summary>
        /// Visar alla användare
        /// </summary>
        /// <param name="sender">Referens till knappen som blivit tryckt</param>
        /// <param name="e">Flaggar för att knappen blivit tryckt</param>
        private void btnViewUsers_Click(object sender, EventArgs e)
        {
            txtBoxInfo.Text = "";
            var customers = AdminBackend.GetAllCustomers();
            
            if (customers.Count > 0)
                foreach (var c in customers)
                    txtBoxInfo.AppendText(
                        $"#{c.Id} {c.CustomerPrivateInfo.First_Name} {c.CustomerPrivateInfo.Last_Name}, Email: {c.CustomerPrivateInfo.UserEmail}\r\n");
            else
                txtBoxInfo.Text = "There are no users in the database!";
        }

        /// <summary>
        /// Visar alla restauranger
        /// </summary>
        /// <param name="sender">Referens till knappen som blivit tryckt</param>
        /// <param name="e">Flaggar för att knappen blivit tryckt</param>
        private void btnViewRestaurants_Click(object sender, EventArgs e)
        {
            txtBoxInfo.Text = "";
            var restaurants = AdminBackend.GetAllRestaurants();

            if (restaurants.Count > 0)
                foreach (var r in restaurants)
                    txtBoxInfo.AppendText(
                        $"#{r.Id} {r.Name}, Phone number: {r.Phone_number}, Location: {r.Location}\r\n");
            else
                txtBoxInfo.Text = "There are no restaurants in the database!";
        }

        /// <summary>
        /// Försöker byta fönster för att kunna lägga till ny användare
        /// </summary>
        /// <param name="sender">Referens till knappen som blivit tryckt</param>
        /// <param name="e">Flaggar för att knappen blivit tryckt</param>
        private void btnAddRestaurant_Click(object sender, EventArgs e)
        {
            txtBoxInfo.Text = "";

            //byta till forms för att lägga till restaurant
            var addRestaurant = new AdminFormAddNewRestaurant();
            addRestaurant.Location = Location;
            addRestaurant.StartPosition = FormStartPosition.CenterParent;
            addRestaurant.Show();
        }
    }
}
