using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Antonio
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "alyra" && textBox2.Text == "alyra")
            {
                this.Hide();
                Form1 form = new Form1();
                form.ShowDialog();
            }
            else if (textBox1.Text != "alyra" && textBox2.Text == "alyra")
            {
                MessageBox.Show("Wrong Username!");
            }
            else if (textBox1.Text == "alyra" && textBox2.Text != "alyra")
            {
                MessageBox.Show("Wrong Password!");
            }
            else {
                MessageBox.Show("Wrong Username and Password!");
            }
        }
    }
}
