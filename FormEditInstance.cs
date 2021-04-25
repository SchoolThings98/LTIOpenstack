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
    public partial class FormEditInstance : Form
    {
        public string serverIP="";
        public string scopeToken = "";
        public string instanceID = "";
        public FormEditInstance(string ip,string token,string id)
        {
            InitializeComponent();
            serverIP = ip;
            scopeToken = token;
            instanceID = id;
        }

        private void FormEditInstance_Load(object sender, EventArgs e)
        {
            OpenstackAPI openstack = new OpenstackAPI();
            
            var response = openstack.getInstance(serverIP,scopeToken,instanceID);
            JObject instance = JObject.Parse(response.Content);
            textBoxName.Text = (string)instance["server"].SelectToken("name");
            richTextBoxDesc.Text= (string)instance["server"].SelectToken("description");

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            OpenstackAPI openstack = new OpenstackAPI();
            openstack.EditInstance(serverIP,scopeToken,instanceID,textBoxName.Text,richTextBoxDesc.Text);
        }
    }
}
