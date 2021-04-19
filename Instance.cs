using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
                    template.WriteElementString("Image", comboBoxImages.Text);
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
                template.WriteElementString("Image", comboBoxImages.Text);
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

            XmlElement inputImage = (XmlElement)templateDoc.SelectSingleNode("/Template/Image");
            XmlElement inputFlavor = (XmlElement)templateDoc.SelectSingleNode("/Template/Flavor");
            XmlElement inputNetwork = (XmlElement)templateDoc.SelectSingleNode("/Template/Network");

            if(inputImage != null)
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
    }
}
