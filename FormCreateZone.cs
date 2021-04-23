using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTIOpenstackProject
{
    public partial class FormCreateZone : Form
    {
        public String serverIP = "";
        public String scopeToken = "";
        public FormCreateZone(string ip, string token)
        {
            InitializeComponent();
            serverIP = ip;
            scopeToken = token;
        }

        private void FormCreateZone_Load(object sender, EventArgs e)
        {
           
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            OpenstackAPI openstack = new OpenstackAPI();
            var name = textBoxName.Text;
            var email = textBoxEmail.Text;
            //var description = textBoxDescription.Text;
            if (name != null && email != null)
            {
                openstack.createZone(serverIP, scopeToken, name, email);
            }
            else
            {
                MessageBox.Show("Valores obrigatórios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
    }
}
