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
    public partial class Form1 : Form
    {
        public String authToken = "";
        public String serverIP = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Login
            var username=textBoxUsername.Text;
            var password= textBoxPassword.Text;
            serverIP = textBoxIP.Text;
            OpenstackAPI openstack = new OpenstackAPI();
            var response = openstack.openstackLogin(username, password,serverIP);
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
            Console.WriteLine(numericStatusCode);
            if (numericStatusCode!=201)
            {
                MessageBox.Show(response.StatusCode.ToString());
                return;
            }
            string responseTicket = response.Headers[0].ToString();
            authToken = responseTicket.Substring(responseTicket.IndexOf("=") + 1);
            //Console.WriteLine(authToken);
            this.Hide();
            FormProjects formProjects = new FormProjects(authToken,serverIP);
            formProjects.ShowDialog();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
