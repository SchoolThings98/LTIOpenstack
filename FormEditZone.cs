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
    public partial class FormEditZone : Form
    {
        public string serverIP = "";
        public string scopeToken = "";
        public string zoneID = "";
        public FormEditZone(string ip, string token, string id)
        {
            InitializeComponent();
            serverIP = ip;
            scopeToken = token;
            zoneID = id;
        }

        private void FormEditZone_Load(object sender, EventArgs e)
        {
            OpenstackAPI openstack = new OpenstackAPI();

            var response = openstack.getZone(serverIP, scopeToken, zoneID);
            JObject zone = JObject.Parse(response.Content);
            textBoxName.Text = (string)zone.SelectToken("email");
            textBoxTTL.Text = (string)zone.SelectToken("ttl");
            richTextBoxDesc.Text = (string)zone.SelectToken("description");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OpenstackAPI openstack = new OpenstackAPI();
            openstack.editZone(serverIP, scopeToken, zoneID, textBoxName.Text, textBoxTTL.Text, richTextBoxDesc.Text);
        }
    }
}
