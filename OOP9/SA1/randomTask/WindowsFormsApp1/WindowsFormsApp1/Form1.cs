using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = "name";
            dataGridView1.Rows[0].Cells[1].Value = "author";
            dataGridView1.Rows[0].Cells[2].Value = "genre";
            dataGridView1.Rows[0].Cells[3].Value = "233";
            dataGridView1.Rows[0].Cells[4].Value = "affan";
        }
    }
}
