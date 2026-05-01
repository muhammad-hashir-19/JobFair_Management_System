using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace i233047_i233091_ilteration2
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void Profile_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a User ID.");
                return;
            }

            int userId;
            if (!int.TryParse(textBox1.Text, out userId))
            {
                MessageBox.Show("Invalid User ID. Please enter a number.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-LQMAJHF\\SQLEXPRESS;Initial Catalog=JobFairManagement;Integrated Security=True"))
                {
                    conn.Open();

                    string query = "SELECT Name FROM Users WHERE userId = @UserID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        textBox2.Text = reader["Name"].ToString();

                        //string role = reader["Role"].ToString();
                        //// You can set Radio Buttons or TextBox based on role
                        //if (role == "Student") radioButton1.Checked = true;
                        //else if (role == "Recruiter") radioButton2.Checked = true;
                        //else if (role == "Booth Coordinator") radioButtonBoot.Checked = true;
                        //else if (role == "TPO") radioButtonTPO.Checked = true;
                    }
                    else
                    {
                        MessageBox.Show("User not found with given ID.");
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching user: " + ex.Message);
            }
        }
    }
}
