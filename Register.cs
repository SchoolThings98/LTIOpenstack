using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTIOpenstackProject
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text != string.Empty || textBoxPassword.Text != string.Empty || textBoxConfirmPassword.Text != string.Empty)
            {
                if (textBoxPassword.Text == textBoxConfirmPassword.Text)
                {

                }
                else
                {
                    MessageBox.Show("Password tem de ser iguais", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
