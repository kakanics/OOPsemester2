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
        int i = 0;
        Color[] color = new Color[] { Color.Red, Color.Green, Color.Blue};
        private void btnNext_Click(object sender, EventArgs e)
        {
            i++;
            if (i == 3) i = 0;
            txtColor.BackColor = color[i];
            txtColor2.BackColor = color[i];
        }

        private void previous_Click(object sender, EventArgs e)
        {
            i--;
            if (i == -1) i = 2;
            txtColor.BackColor = color[i];
            txtColor2.BackColor = color[i];
        }
    }
}
