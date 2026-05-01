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
    public partial class TPOfrom : Form
    {

        public TPOfrom()
        {
            InitializeComponent();
            LoadPendingUsers();
            LoadApprovedUsers();
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView2.CellClick += dataGridView2_CellClick;
        }
        private void LoadPendingUsers()
        {
            string query = "SELECT UserID, Name FROM Users WHERE IsApproved = 0";

            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-LQMAJHF\\SQLEXPRESS;Initial Catalog=JobFairManagement;Integrated Security=True"))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;

                // Optional: add an Action button if not added yet
                if (!dataGridView1.Columns.Contains("Action"))
                {
                    DataGridViewButtonColumn actionButton = new DataGridViewButtonColumn();
                    actionButton.Name = "Action";
                    actionButton.Text = "Approve";
                    actionButton.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(actionButton);
                }
            }
        }

        private void LoadApprovedUsers()
        {
            try
            {
                string query = "SELECT UserID, name FROM Users WHERE IsApproved = 1";

                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-LQMAJHF\\SQLEXPRESS;Initial Catalog=JobFairManagement;Integrated Security=True"))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView2.DataSource = dt;

                    // ADD "Action" Button if not already added
                    if (!dataGridView2.Columns.Contains("Action"))
                    {
                        DataGridViewButtonColumn actionButton = new DataGridViewButtonColumn();
                        actionButton.Name = "Action";
                        actionButton.Text = "Disapprove";
                        actionButton.UseColumnTextForButtonValue = true;
                        dataGridView2.Columns.Add(actionButton);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void TPOfrom_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
        }

       

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = !dataGridView1.Visible;
            dataGridView2.Visible = !dataGridView2.Visible;
            label4.Visible = true;
            label5.Visible = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Action")
            {
                int userId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value);
                UpdateApprovalStatus(userId, true); // Approve them
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView2.Columns[e.ColumnIndex].Name == "Action")
            {
                int userId = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["UserID"].Value);
                UpdateApprovalStatus(userId, false); // Deactivate them
            }
        }
        private void UpdateApprovalStatus(int userId, bool approve)
        {
            string query = "UPDATE Users SET IsApproved = @IsApproved WHERE UserID = @UserId";

            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-LQMAJHF\\SQLEXPRESS;Initial Catalog=JobFairManagement;Integrated Security=True"))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@IsApproved", approve ? 1 : 0);
                cmd.Parameters.AddWithValue("@UserId", userId);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(approve ? "User Approved!" : "User Deactivated!");

                    // After approving/deactivating, reload both tables:
                    LoadPendingUsers();
                    LoadApprovedUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Do nothing or just handle if needed
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Do nothing or just handle if needed
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
