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
    public partial class Instance : Form
    {
        public String serverIP = "";
        public String scopeToken = "";
        public JArray imageList = null;
        public JArray flavorsList = null;
        public JArray networksList = null;
        public Instance(string ip, string token)
        {
            InitializeComponent();
            serverIP = ip;
            scopeToken = token;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenstackAPI openstack = new OpenstackAPI();
            var name = textBoxName.Text;
            var selImage = comboBoxImages.Text;
            var imageid = "";
            var selFlavor = comboBoxFlavor.Text;
            var flavorid = "";
            var selNetwork = comboBoxNetwork.Text;
            var networkid = "";
            foreach (JToken image in imageList)
            {
                //comboBoxImages.Items.Add((string)image.SelectToken("name"));
                if ((string)image.SelectToken("name") == selImage)
                {
                    imageid = (string)image.SelectToken("id");
                    break;
                }

            }
            foreach (JToken flavor in flavorsList)
            {
                //comboBoxImages.Items.Add((string)image.SelectToken("name"));
                if ((string)flavor.SelectToken("name") == selFlavor)
                {
                    flavorid = (string)flavor.SelectToken("id");
                    break;
                }

            }
            foreach (JToken network in networksList)
            {
                //comboBoxImages.Items.Add((string)image.SelectToken("name"));
                if ((string)network.SelectToken("name") == selNetwork)
                {
                    networkid = (string)network.SelectToken("id");
                    break;
                }

            }
            openstack.createInstance(serverIP,scopeToken,name,imageid,flavorid,networkid);

        }

        private void Instance_Load(object sender, EventArgs e)
        {
            OpenstackAPI openstack = new OpenstackAPI();
            var images = openstack.imageList(serverIP,scopeToken);
            var flavors = openstack.flavorList(serverIP, scopeToken);
            var networks = openstack.networksList(serverIP, scopeToken);
            imageList = images;
            flavorsList = flavors;
            networksList = networks;
            foreach (JToken image in images)
            {
                comboBoxImages.Items.Add((string)image.SelectToken("name"));

            }
            foreach (JToken flavor in flavors)
            {
                comboBoxFlavor.Items.Add((string)flavor.SelectToken("name"));

            }
            foreach (JToken network in networks)
            {
                comboBoxNetwork.Items.Add((string)network.SelectToken("name"));

            }
            //comboBoxImages.Items
        }
    }
}
