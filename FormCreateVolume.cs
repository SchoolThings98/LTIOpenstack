using Newtonsoft.Json.Linq;
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
    public partial class FormCreateVolume : Form
    {
        public String serverIP = "";
        public String projectID = "";
        public String scopeToken = "";
        public JArray volumesList = null;
        public JArray imagesList = null;
        public string volSize = "";
        public FormCreateVolume(string ip, string projID,string token)
        {
            InitializeComponent();
            serverIP = ip;
            projectID = projID;
            scopeToken = token;
        }

        private void FormCreateVolume_Load(object sender, EventArgs e)
        {
            OpenstackAPI openstack = new OpenstackAPI();
            radioButtonEmpty.Checked = true;
            var volumeTypes = openstack.volumeTypeList(serverIP,projectID,scopeToken);
            foreach (JToken volumeType in volumeTypes)
            {
               comboBoxVolType.Items.Add((string)volumeType.SelectToken("name"));

            }
            var images = openstack.imageList(serverIP,scopeToken);
            imagesList = images;
            foreach (JToken image in images)
            {
                comboBoxISO.Items.Add((string)image.SelectToken("name"));

            }

            var volumes = openstack.volumeList(serverIP,projectID,scopeToken);
            volumesList = volumes;
            foreach (JToken volume in volumes)
            {
                comboBoxVolume.Items.Add((string)volume.SelectToken("name"));

            }
        }

        private void radioButtonEmpty_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxISO.Hide();
            comboBoxVolume.Hide();
        }

        private void radioButtonISO_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxISO.Show();
            comboBoxVolume.Hide();
        }

        private void radioButtonVolume_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxISO.Hide();
            comboBoxVolume.Show();
        }

        private void buttonCreateVolume_Click(object sender, EventArgs e)
        {
            OpenstackAPI openstack = new OpenstackAPI();
            var volID = "";
            var imgID = "";
            if (radioButtonVolume.Checked) {
                if (Int32.Parse(textBoxSize.Text) < Int32.Parse(volSize))
                {
                    MessageBox.Show("Size must be bigger or equal to the volume selected");
                    return;
                }
                foreach (JToken vol in volumesList)
                {
                    if ((string)vol.SelectToken("name") == comboBoxVolume.Text)
                    {
                        volID = (string)vol.SelectToken("id");
                        break;
                    }
                }
                var response = openstack.createVolume(serverIP, projectID, scopeToken, textBox1.Text, textBoxSize.Text, volID, null, comboBoxVolType.Text);
                HttpStatusCode statusCode = response.StatusCode;
                int numericStatusCode = (int)statusCode;
                Console.WriteLine(numericStatusCode);
                if (numericStatusCode != 202)
                {
                    MessageBox.Show(response.StatusCode.ToString());
                    return;
                }
                else
                {
                    MessageBox.Show(response.StatusCode.ToString());
                    this.Close();
                }

            }
            else if (radioButtonEmpty.Checked)
            {
                var response = openstack.createVolume(serverIP, projectID, scopeToken, textBox1.Text, textBoxSize.Text, null, null, comboBoxVolType.Text);
                HttpStatusCode statusCode = response.StatusCode;
                int numericStatusCode = (int)statusCode;
                Console.WriteLine(numericStatusCode);
                if (numericStatusCode != 202)
                {
                    MessageBox.Show(response.StatusCode.ToString());
                    return;
                }
                else
                {
                    MessageBox.Show(response.StatusCode.ToString());
                    this.Close();
                }
            }
            else
            {
                foreach (JToken img in imagesList)
                {
                    if ((string)img.SelectToken("name") == comboBoxISO.Text)
                    {
                        imgID = (string)img.SelectToken("id");
                        break;
                    }
                }
                var response = openstack.createVolume(serverIP, projectID, scopeToken, textBox1.Text, textBoxSize.Text, null, imgID, comboBoxVolType.Text);
                HttpStatusCode statusCode = response.StatusCode;
                int numericStatusCode = (int)statusCode;
                Console.WriteLine(numericStatusCode);
                if (numericStatusCode != 202)
                {
                    MessageBox.Show(response.StatusCode.ToString());
                    return;
                }
                else
                {
                    MessageBox.Show(response.StatusCode.ToString());
                    this.Close();
                }
            }
            
        }

        private void comboBoxVolume_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxSize.Clear();
            OpenstackAPI openstack = new OpenstackAPI();
            string volID = "";
            foreach (JToken vol in volumesList)
            {
                if ((string)vol.SelectToken("name") == comboBoxVolume.Text)
                {
                    volID = (string)vol.SelectToken("id");
                    break;
                }
            }
            volSize = openstack.volumeSize(serverIP, projectID, scopeToken,volID);
            textBoxSize.Text = volSize;
        }
    }
}
