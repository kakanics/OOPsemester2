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
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Credentials user = new Credentials(txtUsername.Text, txtPassword.Text, txtRole.Text);
            CredentialDL.addIntoList(user);
            CredentialDL.writeToFile(user);
            MessageBox.Show("Signed up successfully");
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void labelRole_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
