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
    public partial class SigningUp : Form
    {
        public SigningUp()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Credentials CheckThis = new Credentials(txtUsername.Text, txtPassword.Text);
            Credentials user = CredentialDL.signIn(CheckThis);
            if(user!=null)
            {
                MessageBox.Show("Signed in successfully");
            }
            else
            {
                MessageBox.Show("Signed in failfully");
            }
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
