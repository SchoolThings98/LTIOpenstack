using Newtonsoft.Json.Linq;
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
    public partial class FormNetwork : Form
    {
        public String serverIP = "";
        public String scopeToken = "";
        public FormNetwork(string ip, string token)
        {
            InitializeComponent();
            serverIP = ip;
            scopeToken = token;
        }

        private void FormNetwork_Load(object sender, EventArgs e)
        {
            OpenstackAPI openstack = new OpenstackAPI();
            var networks = openstack.networksList(serverIP, scopeToken);
            //Console.WriteLine(networks);
            foreach (JToken network in networks)
            {
                listBox1.Items.Add((string)network.SelectToken("name"));

            }

        }
    }
}
