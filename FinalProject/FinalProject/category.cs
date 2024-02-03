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
    public partial class category : Form
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
        public category()
        {
            InitializeComponent();
            StyleDataGridView(dataGridView1);
        }
        public static string connectionString = "Data Source=DESKTOP-2DKQGSL\\SQLEXPRESS;Initial Catalog=Joenell;Integrated Security=True";
        private void label11_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // itself 
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string categoryName = CatName.Text;
            int catid = int.Parse(catbox1.Text);
            if (!string.IsNullOrEmpty(categoryName))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "INSERT INTO categories_table VALUES (@CategoryId,@CategoryName);";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@CategoryId", catid);
                            command.Parameters.AddWithValue("@CategoryName", categoryName);

                            // Get the inserted CategoryId
                            int categoryId = Convert.ToInt32(command.ExecuteScalar());

                            MessageBox.Show($"Category with ID {categoryId} saved successfully!");
                            LoadAllRecords();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter a category name.");
            }
        }

        void LoadAllRecords()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand com = new SqlCommand("Select * from categories_table", connection);
                com.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    // Set the width of each column
                    // You can adjust the width as needed
                    column.Width = 250; // Set the width to 150 pixels, for example
                }
            }
        }
        private void category_Load(object sender, EventArgs e)
        {
            LoadAllRecords();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int catid = int.Parse(catbox1.Text);
            string catname = CatName.Text;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE categories_table SET CategoryName = @catname WHERE CategoryID = @catid";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@catname", catname);
                        command.Parameters.AddWithValue("@catid", catid);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Updated successfully");
                        LoadAllRecords();
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
            int catid = int.Parse(catbox1.Text);
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = $"Delete from categories_table where CategoryId = {catid}";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@CategoryId", catid);

                            // Get the inserted CategoryId
                            int categoryId = Convert.ToInt32(command.ExecuteScalar());

                            MessageBox.Show($"Category with ID {categoryId} deleted successfully!");
                            LoadAllRecords();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            
         }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            items f3 = new items();
            f3.ShowDialog();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
           // itself
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

        private void CatName_TextChanged(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            catbox1.Clear();
            CatName.Clear();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.RowIndex >= 0) // Ensure a valid row index is clicked
                {
                    // Get the DataGridViewRow corresponding to the clicked cell
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    // Fill the textboxes with the values from the selected row
                    catbox1.Text = row.Cells["CategoryId"].Value.ToString();
                    CatName.Text = row.Cells["CategoryName"].Value.ToString();
                }
            }
        }
    }
    }







