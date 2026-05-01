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
    public partial class Studentform : Form
    {
        private string connectionString = "Data Source=DESKTOP-LQMAJHF\\SQLEXPRESS;Initial Catalog=JobFairManagement;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

        public Studentform()
        {
            InitializeComponent();
        }
        private void Studentform_Load(object sender, EventArgs e)
        {

            // Set default selection
            comboBox1.SelectedIndex = 0;
            dataGridView1.Visible = false;
            comboBox1.Visible = false;
            textBox1.Visible = false;
            button1.Visible = false;
        }
        private void LoadAllJobs()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM JobPostings";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

      

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click1(object sender, EventArgs e)
        {
            string column = comboBox1.SelectedItem.ToString();
            string keyword = textBox1.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = $"SELECT * FROM JobPostings WHERE {column} LIKE @keyword";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Visible = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            textBox1.Visible = true;
            button1.Visible = true;

            // Load comboBox options once
            if (comboBox1.Items.Count == 0)
            {
                comboBox1.Items.Add("Title");
                comboBox1.Items.Add("Company");
                comboBox1.Items.Add("Location");
                comboBox1.SelectedIndex = 0;
            }
        }
        private void Back_Click(object sender, EventArgs e)
        {
            Profile signupfrom = new Profile();
            signupfrom.Show();
            this.Hide();
        }
    }
}
