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

namespace FinalProject
{
    public partial class customers : Form
    {
        private static string connectionString = "Data Source=DESKTOP-2DKQGSL\\SQLEXPRESS;Initial Catalog=Joenell;Integrated Security=True";
        public static void StyleDataGridView(DataGridView dataGridView)
        {
            dataGridView.BackgroundColor = Color.White;
            dataGridView.GridColor = Color.White;
            dataGridView.RowHeadersDefaultCellStyle.BackColor = Color.White;

            // Set header style
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.White;
            headerStyle.ForeColor = Color.Black;
            dataGridView.ColumnHeadersDefaultCellStyle = headerStyle;

            // Set cell style
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.DefaultCellStyle = cellStyle;
            dataGridView.RowTemplate.Height = 40;


        }
        public customers()
        {
            InitializeComponent();
            d1();
            StyleDataGridView(dataGridView1);
        }
        private void d1()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    string query = "SELECT * FROM customers_table";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(dt);
                    }
                }
                dataGridView1.DataSource = dt;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.Width = 209;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void label11_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // itself
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            items f3 = new items();
            f3.ShowDialog();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            category f3 = new category();
            f3.ShowDialog();
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            billings f3 = new billings();
            f3.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
            dashboard f1 = new dashboard();
            f1.ShowDialog();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            login f1 = new login();
            f1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Parse values from textboxes
                int CustomerId = int.Parse(t1.Text);
                string CustName = t2.Text;
                string gender = t3.Text;
                string phone = t4.Text;

                // Establish connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define SQL query with parameters
                    string query = "INSERT INTO customers_table VALUES (@CustomerId,@CustName, @Gender, @Phone)";

                    // Create command with parameters
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", CustomerId);
                        command.Parameters.AddWithValue("@CustName", CustName);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Phone", phone);

                        // Execute the command
                        command.ExecuteNonQuery();

                        // Display success message
                        MessageBox.Show("Customer inserted successfully");
                        d1();
                        StyleDataGridView(dataGridView1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int CustomerId = int.Parse(t1.Text);
            string CustName = t2.Text;
            string gender = t3.Text;
            string phone = t4.Text;
            try
            {
                // Establish connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define SQL query with parameters for update
                    string query = "UPDATE customers_table SET CustName =@CustName, Gender = @Gender, Phone = @Phone " +
                                   "WHERE CustomerId = @CustomerId";

                    // Create command with parameters
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", CustomerId);
                        command.Parameters.AddWithValue("@CustName", CustName);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Phone", phone);

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected
                        if (rowsAffected > 0)
                        {
                            // Display success message
                            MessageBox.Show("Customer updated successfully");
                            d1();
                            StyleDataGridView(dataGridView1);
                        }
                        else
                        {
                            MessageBox.Show("No rows updated. Customer not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            t1.Clear();
            t2.Clear();
            t4.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int CustomerId = int.Parse(t1.Text);
            try
            {
                // Establish connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define SQL query with parameters for delete
                    string query = "DELETE FROM customers_table WHERE CustomerId = @CustomerId";

                    // Create command with parameters
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", CustomerId);

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected
                        if (rowsAffected > 0)
                        {
                            // Display success message
                            MessageBox.Show("Customer deleted successfully");
                            d1();
                            StyleDataGridView(dataGridView1);
                        }
                        else
                        {
                            MessageBox.Show("No rows deleted. Customer not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
                if (e.RowIndex >= 0) // Ensure a valid row index is clicked
                {
                    // Get the DataGridViewRow corresponding to the clicked cell
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    // Fill the textboxes with the values from the selected row
                    t1.Text = row.Cells["CustomerId"].Value.ToString();
                    t2.Text = row.Cells["CustName"].Value.ToString();
                    t3.Text = row.Cells["Gender"].Value.ToString();
                    t4.Text = row.Cells["Phone"].Value.ToString(); 
            }
        }
    }
}
