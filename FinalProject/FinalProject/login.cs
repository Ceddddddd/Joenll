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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2DKQGSL\\SQLEXPRESS;Initial Catalog=Joenell;Integrated Security=True");
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username;
            string userpw;

            username = richTextBox1.Text;
            userpw = richTextBox2.Text;

            try
            {
                con.Open();
                string querry = "SELECT * FROM logintb where username = '" + username + "' AND pw = '" + userpw + "'";
                SqlDataAdapter da = new SqlDataAdapter(querry, con);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);

                if (dataTable.Rows.Count == 1)
                {
                    this.Hide();
                    welcome f2 = new welcome();
                    f2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid Login Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    richTextBox1.Clear();
                    richTextBox2.Clear();
                    richTextBox1.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
            finally
            { con.Close(); }
            








        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
