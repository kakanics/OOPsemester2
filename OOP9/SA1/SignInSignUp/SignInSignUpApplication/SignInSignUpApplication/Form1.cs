using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignInSignUpApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                this.Hide();
                SignIn window = new SignIn();
                window.Show();
            }
            else if (cBoxSignIn.Checked)
            {
                this.Hide();
                SigningUp window = new SigningUp();
                window.Show();
            }
        }

        private void cBoxSignIn_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
