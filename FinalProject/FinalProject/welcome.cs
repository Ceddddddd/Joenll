using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class welcome : Form
    {
        public welcome()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
               
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //form transition enable hehe
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Close();
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
            this.Hide();
            billings f3 = new billings();
            f3.ShowDialog();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            login f1 = new login();
            f1.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
            dashboard f1 = new dashboard();
            f1.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
