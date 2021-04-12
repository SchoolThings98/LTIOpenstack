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
    public partial class FormProjects : Form
    {
        public String authToken = "";
        public String serverIP = "";
        public FormProjects(string token, string ip)
        {
            InitializeComponent();
            authToken = token;
            serverIP = ip;
        }

        private void FormProjects_Load(object sender, EventArgs e)
        {

            Console.WriteLine(authToken);
            Console.WriteLine(serverIP);
            OpenstackAPI openstack = new OpenstackAPI();
            openstack.projectList(authToken, serverIP);
        }
    }
}
