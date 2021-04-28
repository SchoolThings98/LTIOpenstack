using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LTIOpenstackProject
{
    public partial class Instance : Form
    {
        public String serverIP = "";
        public String scopeToken = "";
        public String projectID = "";
        public JArray imageList = null;
        public JArray flavorsList = null;
        public JArray networksList = null;
        public JArray volumesList = null;
        public Instance(string ip,string projID ,string token)
        {
            InitializeComponent();
            serverIP = ip;
            scopeToken = token;
            projectID = projID;
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
            var selVolume = comboBoxVolume.Text;
            var volumeid = "";
            var count = textBoxCount.Text;
            if(radioButtonISO.Checked==true){
                foreach (JToken image in imageList)
                {
                    //comboBoxImages.Items.Add((string)image.SelectToken("name"));
                    if ((string)image.SelectToken("name") == selImage)
                    {
                        imageid = (string)image.SelectToken("id");
                        volumeid = null;
                        break;
                    }

                }
            }
            if (radioButtonVolume.Checked == true)
            {
                foreach(JToken volume in volumesList)
                {
                    if ((string)volume.SelectToken("name") == selVolume)
                    {
                        volumeid = (string)volume.SelectToken("id");
                        imageid = null;
                        break;
                    }
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
            var code =openstack.createInstance(serverIP,scopeToken,name,imageid,volumeid,flavorid,networkid,count);
            HttpStatusCode statusCode = code.StatusCode;
            int numericStatusCode = (int)statusCode;
            //Console.WriteLine(numericStatusCode);
            if (numericStatusCode != 202)
            {
                MessageBox.Show(code.StatusCode.ToString());
                return;
            }
            else
            {
                MessageBox.Show(code.StatusCode.ToString());
                this.Close();
            }

        }

        private void Instance_Load(object sender, EventArgs e)
        {
            OpenstackAPI openstack = new OpenstackAPI();
            radioButtonISO.Checked = true;
            comboBoxVolume.Hide();
            labelVolume.Hide();
            var images = openstack.imageList(serverIP,scopeToken);
            var flavors = openstack.flavorList(serverIP, scopeToken);
            var networks = openstack.networksList(serverIP, scopeToken);
            var volumes = openstack.volumeList(serverIP,projectID,scopeToken);
            imageList = images;
            flavorsList = flavors;
            networksList = networks;
            volumesList = volumes;
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
            foreach (JToken volume in volumes)
            {
                comboBoxVolume.Items.Add((string)volume.SelectToken("name"));

            }



            //comboBoxImages.Items
        }

        private void buttonCreateTemplate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTemplateName.Text))
            {
                MessageBox.Show("Insira um nome para o Template de configuraçao");
                return;

            }
            if (File.Exists("templates/" + textBoxTemplateName.Text + ".xml"))
            {
                DialogResult result = MessageBox.Show("Do you want to replace " + textBoxTemplateName.Text + ".xml file?", "File already exist", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    XmlWriter template = XmlWriter.Create("templates/" + textBoxTemplateName.Text + ".xml");
                    template.WriteStartElement("Template");
                    if (radioButtonISO.Checked==true)
                    {
                        template.WriteElementString("ISO", "true");
                        template.WriteElementString("Image", comboBoxImages.Text);
                    }
                    else
                    {
                        template.WriteElementString("Vol", "true");
                        template.WriteElementString("Volume", comboBoxVolume.Text);
                    }
                    
                    template.WriteElementString("Flavor", comboBoxFlavor.Text);
                    template.WriteElementString("Network", comboBoxNetwork.Text);
                    template.WriteEndElement();
                    template.Flush();
                    MessageBox.Show("Template"+textBoxTemplateName.Text+".Xml");
                }
                else
                {
                    MessageBox.Show("Insert a different name.");
                    return;
                }
            }
            else
            {
                XmlWriter template = XmlWriter.Create("templates/" + textBoxTemplateName.Text + ".xml");
                template.WriteStartElement("Template");
                if (radioButtonISO.Checked == true)
                {
                    template.WriteElementString("ISO", "true");
                    template.WriteElementString("Image", comboBoxImages.Text);
                }
                else
                {
                    template.WriteElementString("Vol", "true");
                    template.WriteElementString("Volume", comboBoxVolume.Text);
                }
                template.WriteElementString("Flavor", comboBoxFlavor.Text);
                template.WriteElementString("Network", comboBoxNetwork.Text);
                template.WriteEndElement();
                template.Flush();
                MessageBox.Show("Template" + textBoxTemplateName.Text + ".Xml");
            }
        }

        private void buttonSelectTemplate_Click(object sender, EventArgs e)
        {
            var fileName = "";
            openFileDialogTemplate.InitialDirectory = Application.StartupPath + @"\templates";
            openFileDialogTemplate.Filter = "xml files (*.xml)|*.xml";

            if (openFileDialogTemplate.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialogTemplate.FileName;
                MessageBox.Show("Ficheiro"+openFileDialogTemplate.SafeFileName+" open with SUCCESS! ");
            }
            else
            {
                MessageBox.Show("Erro trying to open the selected file!!!");
                return;
            }

            XmlDocument templateDoc = new XmlDocument();
            templateDoc.Load(fileName);

            XmlElement inputImageStatus = (XmlElement)templateDoc.SelectSingleNode("/Template/ISO");
            XmlElement inputImage = (XmlElement)templateDoc.SelectSingleNode("/Template/Image");
            XmlElement inputVolumeStatus = (XmlElement)templateDoc.SelectSingleNode("/Template/Vol");
            XmlElement inputVolume = (XmlElement)templateDoc.SelectSingleNode("/Template/Volume");
            XmlElement inputFlavor = (XmlElement)templateDoc.SelectSingleNode("/Template/Flavor");
            XmlElement inputNetwork = (XmlElement)templateDoc.SelectSingleNode("/Template/Network");

            if (inputImageStatus!=null)
            {
                radioButtonISO.Checked = true;
                if (inputImage != null)
                {
                    comboBoxImages.SelectedIndex = comboBoxImages.FindStringExact(inputImage.InnerText);
                }
                if (inputFlavor != null)
                {
                    comboBoxFlavor.SelectedIndex = comboBoxFlavor.FindStringExact(inputFlavor.InnerText);
                }
                if (inputNetwork != null)
                {
                    comboBoxNetwork.SelectedIndex = comboBoxNetwork.FindStringExact(inputNetwork.InnerText);
                }

            }
            if (inputVolumeStatus!=null)
            {
                radioButtonVolume.Checked = true;
                if (inputVolume != null)
                {
                    comboBoxVolume.SelectedIndex = comboBoxVolume.FindStringExact(inputVolume.InnerText);
                }
                if (inputFlavor != null)
                {
                    comboBoxFlavor.SelectedIndex = comboBoxFlavor.FindStringExact(inputFlavor.InnerText);
                }
                if (inputNetwork != null)
                {
                    comboBoxNetwork.SelectedIndex = comboBoxNetwork.FindStringExact(inputNetwork.InnerText);
                }
            }
   
        }

        private void radioButtonVolume_CheckedChanged(object sender, EventArgs e)
        {
 
            comboBoxImages.Hide();
            labelISO.Hide();
            comboBoxVolume.Show();
            labelVolume.Show();
        }

        private void radioButtonISO_CheckedChanged(object sender, EventArgs e)
        {

            comboBoxImages.Show();
            labelISO.Show();
            comboBoxVolume.Hide();
            labelVolume.Hide();
        }
    }
}
