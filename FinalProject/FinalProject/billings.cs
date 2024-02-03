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
    public partial class billings : Form
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
        public billings()
        {
            InitializeComponent();
            StyleDataGridView(dataGridView2);
            StyleDataGridView(dataGridView1);
            d1();
            d2();
        }
        private void d2() {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    string query = "SELECT * from billings_table";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(dt);
                    }
                }
                dataGridView1.DataSource = dt;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.Width = 100;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void d1()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    string query = "SELECT c.CustName, i.ItName AS Product, b.Quantity, b.TotalPrice\r\n                             FROM customers_table c\r\n                             INNER JOIN billings_table b ON c.CustomerId = b.CustomerId\r\n                             INNER JOIN items_table i ON b.ItemId = i.ItemId";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(dt);
                    }
                }
                dataGridView2.DataSource = dt;
                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {
                    column.Width = 100;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
      
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            // itself
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Close();
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

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            customers f3 = new customers();
            f3.ShowDialog();
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            // itself
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int BillingId = int.Parse(t1.Text);
                int ItemId = int.Parse(t2.Text);
                int CustomerId = int.Parse(t3.Text);
                int quantity = int.Parse(t4.Text);

                decimal totalPrice = 0; // Initialize total price

                // Retrieve the price of the product or cake
                decimal price = 0; // Initialize price
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Price FROM items_table WHERE ItemId = @ItemId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemId", ItemId);
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            price = Convert.ToDecimal(result);
                        }
                    }
                }

                // Calculate the total price
                totalPrice = quantity * price;

                // Determine the payment method based on the selected radio button
                string paymentMethod = "";
                if (r1.Checked)
                {
                    paymentMethod = "Cash on Delivery";
                }
                else if (r2.Checked)
                {
                    paymentMethod = "E-Wallet";
                }
                else if (r3.Checked)
                {
                    paymentMethod = "Online Banking";
                }

                // Establish connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define SQL query with parameters for insert
                    string query = "INSERT INTO billings_table (BillingId, ItemId, CustomerId, Quantity, TotalPrice, PaymentMethod) " +
                                   "VALUES (@BillingId, @ItemId, @CustomerId, @Quantity, @TotalPrice, @PaymentMethod)";

                    // Create command with parameters
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BillingId", BillingId);
                        command.Parameters.AddWithValue("@ItemId", ItemId);
                        command.Parameters.AddWithValue("@CustomerId", CustomerId);
                        command.Parameters.AddWithValue("@Quantity", quantity);
                        command.Parameters.AddWithValue("@TotalPrice", totalPrice);
                        command.Parameters.AddWithValue("@PaymentMethod", paymentMethod);

                        // Execute the command
                        command.ExecuteNonQuery();

                        // Display success message
                        MessageBox.Show("Billing record inserted successfully");
                        d1();
                        StyleDataGridView(dataGridView2);
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
            t1.Clear();
            t2.Clear();
            t3.Clear();
            t4.Clear();
        }

        private void billings_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row index is clicked
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                t1.Text = row.Cells["BillingId"].Value.ToString();
                t2.Text = row.Cells["ItemId"].Value.ToString();
                t3.Text = row.Cells["CustomerId"].Value.ToString();
                t4.Text = row.Cells["Quantity"].Value.ToString();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                int BillingId = int.Parse(t1.Text);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define SQL query with parameters for delete
                    string query = "DELETE FROM billings_table WHERE BillingId = @BillingId";

                    // Create command with parameters
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BillingId", BillingId);

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected
                        if (rowsAffected > 0)
                        {
                            // Display success message
                            MessageBox.Show("Billing record deleted successfully");
                            d1();
                            d2();
                        }
                        else
                        {
                            MessageBox.Show("No rows deleted. Billing record not found.");
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
            try
            {
                int BillingId = int.Parse(t1.Text);
                int ItemId = int.Parse(t2.Text);
                int CustomerId = int.Parse(t3.Text);
                int quantity = int.Parse(t4.Text);

                decimal totalPrice = 0; // Initialize total price

                // Retrieve the price of the product or cake
                decimal price = 0; // Initialize price
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Price FROM items_table WHERE ItemId = @ItemId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemId", ItemId);
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            price = Convert.ToDecimal(result);
                        }
                    }
                }

                // Calculate the total price
                totalPrice = quantity * price;

                // Determine the payment method based on the selected radio button
                string paymentMethod = "";
                if (r1.Checked)
                {
                    paymentMethod = "Cash on Delivery";
                }
                else if (r2.Checked)
                {
                    paymentMethod = "E-Wallet";
                }
                else if (r3.Checked)
                {
                    paymentMethod = "Online Banking";
                }

                // Establish connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define SQL query with parameters for update
                    string query = "UPDATE billings_table SET ItemId = @ItemId, CustomerId = @CustomerId, " +
                                   "Quantity = @Quantity, TotalPrice = @TotalPrice, PaymentMethod = @PaymentMethod " +
                                   "WHERE BillingId = @BillingId";

                    // Create command with parameters
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BillingId", BillingId);
                        command.Parameters.AddWithValue("@ItemId", ItemId);
                        command.Parameters.AddWithValue("@CustomerId", CustomerId);
                        command.Parameters.AddWithValue("@Quantity", quantity);
                        command.Parameters.AddWithValue("@TotalPrice", totalPrice);
                        command.Parameters.AddWithValue("@PaymentMethod", paymentMethod);

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected
                        if (rowsAffected > 0)
                        {
                            // Display success message
                            MessageBox.Show("Billing record updated successfully");
                            d1();
                            d2();
                        }
                        else
                        {
                            MessageBox.Show("No rows updated. Billing record not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}
