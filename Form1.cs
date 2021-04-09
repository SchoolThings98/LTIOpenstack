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
    public partial class Form1 : Form
    {
        public String authToken = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Login
            var username=textBoxUsername.Text;
            var password= textBoxPassword.Text;
            OpenstackAPI openstack = new OpenstackAPI();
            var response = openstack.openstackLogin(username, password);
            if (response==null)
            {

            }

            authToken = response;

        }
    }
}
