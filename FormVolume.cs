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
    public partial class FormVolume : Form
    {
        public String serverIP = "";
        public String projectID = "";
        public String scopeToken = "";


        public FormVolume(string ip, string projID, string token)
        {
            InitializeComponent();
            serverIP = ip;
            projectID = projID;
            scopeToken = token;
        }

        private void FormVolume_Load(object sender, EventArgs e)
        {
            OpenstackAPI openstack = new OpenstackAPI();
            var volumes = openstack.volumeList(serverIP,projectID,scopeToken);
            //Console.WriteLine(volumes);
            foreach (JToken volume in volumes)
            {
                listBox1.Items.Add((string)volume.SelectToken("name"));
                
            }

        }

        private void buttonCreateVolume_Click(object sender, EventArgs e)
        {
            FormCreateVolume formCreateVolume = new FormCreateVolume(serverIP,projectID,scopeToken);
            formCreateVolume.Show();
        }
    }
}
