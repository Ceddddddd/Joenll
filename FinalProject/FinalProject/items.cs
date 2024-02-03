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
    public partial class items : Form
    {
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
        public items()
        {
            InitializeComponent();
            d2();
            d1();
            StyleDataGridView(dataGridView1);
            StyleDataGridView(dataGridView2);
        }
        private static string connectionString = "Data Source=DESKTOP-2DKQGSL\\SQLEXPRESS;Initial Catalog=Joenell;Integrated Security=True";
        private void d1()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    string query = "SELECT * FROM items_table";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(dt);
                    }
                }
                dataGridView1.DataSource = dt;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.Width = 139;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void d2() {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    string query = "SELECT * FROM categories_table";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(dt);
                    }
                }
                dataGridView2.DataSource = dt;
                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {
                    column.Width = 131;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void items_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // itself 
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Parse values from textboxes
                int itemid = int.Parse(t1.Text);
                string manufacturer = t2.Text;
                decimal price = decimal.Parse(t3.Text);
                string itemname = t4.Text;
                int categoryid = int.Parse(t5.Text);
                int stocks = int.Parse(t6.Text);

                // Establish connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define SQL query with parameters
                    string query = "INSERT INTO items_table (ItemId, ItName, Manufacturer, Price, Stocks, CategoryId) " +
                                   "VALUES (@ItemId, @ItemName, @Manufacturer, @Price, @Stocks, @CategoryId)";

                    // Create command with parameters
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemId", itemid);
                        command.Parameters.AddWithValue("@ItemName", itemname);
                        command.Parameters.AddWithValue("@Manufacturer", manufacturer);
                        command.Parameters.AddWithValue("@Price", price);
                        command.Parameters.AddWithValue("@Stocks", stocks);
                        command.Parameters.AddWithValue("@CategoryId", categoryid);

                        // Execute the command
                        command.ExecuteNonQuery();

                        // Display success message
                        MessageBox.Show("Item inserted successfully");
                        d2();
                        d1();
                        StyleDataGridView(dataGridView1);
                        StyleDataGridView(dataGridView2);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            // itself
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            category f3 = new category();
            f3.ShowDialog();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            customers f3 = new customers();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Parse values from textboxes
                int itemid = int.Parse(t1.Text);
                string manufacturer = t2.Text;
                decimal price = decimal.Parse(t3.Text);
                string itemname = t4.Text;
                int categoryid = int.Parse(t5.Text);
                int stocks = int.Parse(t6.Text);

                // Establish connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define SQL query with parameters for update
                    string query = "UPDATE items_table SET ItName = @ItemName, Manufacturer = @Manufacturer, " +
                                   "Price = @Price, CategoryId = @CategoryId, Stocks = @Stocks " +
                                   "WHERE ItemId = @ItemId";

                    // Create command with parameters
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemId", itemid);
                        command.Parameters.AddWithValue("@ItemName", itemname);
                        command.Parameters.AddWithValue("@Manufacturer", manufacturer);
                        command.Parameters.AddWithValue("@Price", price);
                        command.Parameters.AddWithValue("@CategoryId", categoryid);
                        command.Parameters.AddWithValue("@Stocks", stocks);

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected
                        if (rowsAffected > 0)
                        {
                            // Display success message
                            MessageBox.Show("Item updated successfully");
                            d2();
                            d1();
                            StyleDataGridView(dataGridView1);
                            StyleDataGridView(dataGridView2);
                        }
                        else
                        {
                            MessageBox.Show("No rows updated. Item not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Parse the item ID to be deleted
                int itemid = int.Parse(t1.Text);

                // Establish connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define SQL query with parameters for delete
                    string query = "DELETE FROM items_table WHERE ItemId = @ItemId";


                    // Create command with parameters
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemId", itemid);

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected
                        if (rowsAffected > 0)
                        {
                            // Display success message
                            MessageBox.Show("Item deleted successfully");
                            d2();
                            d1();
                            StyleDataGridView(dataGridView1);
                            StyleDataGridView(dataGridView2);
                        }
                        else
                        {
                            MessageBox.Show("No rows deleted. Item not found.");
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
            t3.Clear();
            t4.Clear();
            t5.Clear();
            t6.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.RowIndex >= 0) // Ensure a valid row index is clicked
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    t1.Text = row.Cells["ItemId"].Value.ToString();
                    t2.Text = row.Cells["Manufacturer"].Value.ToString();
                    t3.Text = row.Cells["price"].Value.ToString();
                    t4.Text = row.Cells["ItName"].Value.ToString();
                    t6.Text = row.Cells["stocks"].Value.ToString();
                    t5.Text = row.Cells["CategoryId"].Value.ToString();
                }
            }
        }
    }
}
