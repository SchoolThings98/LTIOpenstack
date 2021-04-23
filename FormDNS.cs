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
    public partial class FormDNS : Form
    {
        public String serverIP = "";
        public String scopeToken = "";
        public JArray zonesList = null;
        public FormDNS(string ip, string token)
        {
            InitializeComponent();
            serverIP = ip;
            scopeToken = token;
        }

        private void FormDNS_Load(object sender, EventArgs e)
        {
            OpenstackAPI openstack = new OpenstackAPI();
            var zones = openstack.zonesList(serverIP, scopeToken);
            //Console.WriteLine(zones);
            foreach (JToken zone in zones)
            {
                listBox1.Items.Add((string)zone.SelectToken("name"));
            }
        }

        private void btnCreateZone_Click(object sender, EventArgs e)
        {
            FormCreateZone formCreateZone = new FormCreateZone(serverIP, scopeToken);
            formCreateZone.ShowDialog();
        }
    }
}
