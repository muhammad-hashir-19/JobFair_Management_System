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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace i233047_i233091_ilteration2
{
    public partial class Signupfrom : Form
    {
        public Signupfrom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                GetSelectedRole() == "")
            {
                MessageBox.Show("Please fill all fields properly!");
                return;
            }

            string name = textBox4.Text.Trim();
            string password = textBox3.Text.Trim();
            string role = GetSelectedRole();

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-LQMAJHF\\SQLEXPRESS;Initial Catalog=JobFairManagement;Integrated Security=True"))
                {
                    conn.Open();

                    string query = "INSERT INTO Users (Name, Password, Role, IsApproved) VALUES (@Name, @Password, @Role, 0)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Signup successful! Waiting for admin approval.");

                    Form1 tf = new Form1();
                    tf.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during signup: " + ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private string GetSelectedRole()
        {
            if (radioButton1.Checked)
                return "Student";
            else if (radioButton4.Checked)
                return "Recruiter";
            else if (radioButton3.Checked)
                return "Booth Coordinator";
            else if (radioButton2.Checked)
                return "TPO";
            else
                return "";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 tf = new  Form1();
            tf.Show();
            this.Hide();
        }
    }
}
