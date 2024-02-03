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

namespace FinalProject
{
    public partial class dashboard : Form
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
        private static string connectionString = "Data Source=DESKTOP-2DKQGSL\\SQLEXPRESS;Initial Catalog=Joenell;Integrated Security=True";
        public dashboard()
        {
            InitializeComponent();
            d1();
            d2();
            d3();
            d4();
            d5();
            StyleDataGridView(dataGridView1);
            StyleDataGridView(dataGridView2);
        }
        private void d5() {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    string query = "SELECT c.CustName AS CustomerName, \r\n       i.ItName AS ItemName, \r\n       ct.CategoryName AS CategoryName,\r\n       b.TotalPrice AS TotalPrice\r\nFROM customers_table c\r\nJOIN billings_table b ON c.CustomerId = b.CustomerId\r\nJOIN items_table i ON b.ItemId = i.ItemId\r\nJOIN categories_table ct ON i.CategoryId = ct.CategoryId;";
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
        private void d4() {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    string query = "SELECT ItName AS ItemName, Stocks\r\nFROM items_table;\r\n";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(dt);
                    }
                }
                dataGridView2.DataSource = dt;
                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {
                    column.Width = 139;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void d3() {
            try
            {
                // Establish connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define SQL query to calculate the total price of all items
                    string query = "SELECT SUM(Price * Stocks) FROM items_table";

                    // Create command
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the query and retrieve the result
                        object result = command.ExecuteScalar();

                        // Check if the result is not null
                        if (result != null && result != DBNull.Value)
                        {
                            // Convert the result to a decimal
                            decimal totalItemsPrice = Convert.ToDecimal(result);

                            // Display the total items price on the label
                            l3.Text = totalItemsPrice.ToString();
                        }
                    }
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
                // Establish connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define SQL query to get the total price of all customers' purchases
                    string query = "SELECT SUM(TotalPrice) FROM billings_table";

                    // Create command
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the query and retrieve the result
                        object result = command.ExecuteScalar();

                        // Check if the result is not null
                        if (result != null && result != DBNull.Value)
                        {
                            // Convert the result to a decimal
                            decimal totalPrice = Convert.ToDecimal(result);

                            // Display the total price on the label
                            l2.Text = totalPrice.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void d1() {
            try
            {
                // Establish connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define SQL query to get the total number of customers
                    string query = "SELECT COUNT(*) FROM customers_table";

                    // Create command
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the query and retrieve the result
                        object result = command.ExecuteScalar();

                        // Check if the result is not null
                        if (result != null && result != DBNull.Value)
                        {
                            // Convert the result to an integer
                            int customerCount = Convert.ToInt32(result);

                            // Display the customer count on the label
                            l1.Text = customerCount.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void dashboard_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            items f3 = new items();
            f3.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            category f3 = new category();
            f3.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            customers f3 = new customers();
            f3.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            billings f3 = new billings();
            f3.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            // itself
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            login f1 = new login();
            f1.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void l2_Click(object sender, EventArgs e)
        {

        }
    }
}
