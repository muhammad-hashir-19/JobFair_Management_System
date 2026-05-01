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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-LQMAJHF\\SQLEXPRESS;Initial Catalog=JobFairManagement;Integrated Security=True"))
            {
                conn.Open();

                string Name = textBox1.Text;
                string password = textBox2.Text;

                string query = "SELECT Role FROM Users WHERE Name = @Name AND Password = @Password AND IsApproved = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Password", password);

                object roleObj = cmd.ExecuteScalar();

                if (roleObj != null)
                {
                    string role = roleObj.ToString();
                    MessageBox.Show("Login Successful!");

                    // Open respective form
                    switch (role)
                    {
                        case "Student":
                            Studentform sf = new Studentform();
                            sf.Show();
                            break;
                        case "Recruiter":
                            Recuiterform rf = new Recuiterform();
                            rf.Show();
                            break;
                        case "Booth Coordinator":
                            DPO bf = new DPO();
                            bf.Show();
                            break;
                        case "TPO":
                            TPOfrom tf = new TPOfrom();
                            tf.Show();
                            break;
                        default:
                            MessageBox.Show("Unknown role!");
                            break;
                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid credentials or not approved yet.");
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Signupfrom tf = new Signupfrom();
            //tf.Show();
            //this.Hide();

            Studentform signupfrom = new Studentform();
            signupfrom.Show();
            this.Hide();
        }
    }
}
