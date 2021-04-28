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
    public partial class FormProjects : Form
    {
        public String authToken = "";
        public String serverIP = "";
        public String scopeToken = "";
        public String projectID = "";
        public JArray projects = null;
        public JArray instancesList = null;
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
            var projetos = openstack.projectList(authToken, serverIP);
            projects = projetos;
            comboBox1.SelectedItem = null;
            comboBox1.SelectedText = "Selecione um Projeto";
            foreach (JToken project in projetos)
            {
                //comboBox1.Items.Add((string)project.SelectToken("name")+"("+(string)project.SelectToken("domain_id")+")-"+(string)project.SelectToken("id"));
                comboBox1.Items.Add((string)project.SelectToken("name") + "-" + (string)project.SelectToken("domain_id"));
                /*Console.WriteLine((string)project.SelectToken("id"));
                Console.WriteLine((string)project.SelectToken("name"));
                Console.WriteLine((string)project.SelectToken("domain_id"));*/
            }
            listBox1.Hide();
            listView1.Hide();
            label2.Hide();
            label3.Hide();
            buttonCreateInstance.Hide();
            buttonDNS.Hide();
            buttonEdit.Hide();
            buttonAccessInstance.Hide();
            buttonRemoveInstance.Hide();
            buttonVolumes.Hide();
            buttonImages.Hide();
            buttonNetwork.Hide();
            
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text== "Selecione um Projeto")
            {
                MessageBox.Show("Selecione um projeto");
            }
            else
            {
                //var projID = comboBox1.Text.Substring(comboBox1.Text.LastIndexOf("-") + 1);
                listBox1.Items.Clear();
                var domain = comboBox1.Text.Substring(comboBox1.Text.LastIndexOf("-") + 1);
                var name = comboBox1.Text.Substring(0,comboBox1.Text.LastIndexOf("-"));
                Console.WriteLine(domain);
                Console.WriteLine(name);
                //MessageBox.Show(projID);
                OpenstackAPI openstack = new OpenstackAPI();
                var newTicket = openstack.openstackScopeTicket(authToken, name,domain, serverIP);
                HttpStatusCode statusCode = newTicket.StatusCode;
                int numericStatusCode = (int)statusCode;
                //Console.WriteLine(numericStatusCode);
                if (numericStatusCode != 201)
                {
                    MessageBox.Show(newTicket.StatusCode.ToString());
                    return;
                }
                string responseTicket = newTicket.Headers[0].ToString();
                scopeToken = responseTicket.Substring(responseTicket.IndexOf("=") + 1);
                Console.WriteLine(authToken);
                Console.WriteLine(scopeToken);
                listBox1.Show();
                listView1.Show();
                label2.Hide();
                label3.Hide();
                buttonCreateInstance.Show();
                buttonDNS.Show();
                buttonEdit.Show();
                buttonAccessInstance.Show();
                buttonRemoveInstance.Show();
                buttonVolumes.Show();
                buttonImages.Show();
                buttonNetwork.Show();
                var instances = openstack.instanceList(scopeToken,serverIP);
                instancesList = instances;
                foreach(JToken intance in instances)
                {
                    listBox1.Items.Add((string)intance.SelectToken("name"));
                }
            }
        }

        private void buttonVolumes_Click(object sender, EventArgs e)
        {
            var projID = comboBox1.Text.Substring(comboBox1.Text.LastIndexOf("-") + 1);
            var domain = comboBox1.Text.Substring(comboBox1.Text.LastIndexOf("-") + 1);
            var name = comboBox1.Text.Substring(0, comboBox1.Text.LastIndexOf("-"));
            foreach (JToken project in projects)
            {
                if ((string)project.SelectToken("name") == name)
                {
                    projID = (string)project.SelectToken("id");
                    break;
                }

            }
            FormVolume formVolume = new FormVolume(serverIP,projID,scopeToken);
            formVolume.ShowDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string instance = listBox1.SelectedItem.ToString();
            //listView1.Items.Add(instance);
        }

        private void buttonImages_Click(object sender, EventArgs e)
        {
            FormImage formImage = new FormImage(serverIP,scopeToken);
            formImage.ShowDialog();
        }

        private void buttonNetwork_Click(object sender, EventArgs e)
        {
            FormNetwork formNetwork = new FormNetwork(serverIP, scopeToken);
            formNetwork.ShowDialog();
        }

        private void buttonCreateInstance_Click(object sender, EventArgs e)
        {
            var projID = comboBox1.Text.Substring(comboBox1.Text.LastIndexOf("-") + 1);
            var domain = comboBox1.Text.Substring(comboBox1.Text.LastIndexOf("-") + 1);
            var name = comboBox1.Text.Substring(0, comboBox1.Text.LastIndexOf("-"));
            foreach (JToken project in projects)
            {
                if ((string)project.SelectToken("name") == name)
                {
                    projID = (string)project.SelectToken("id");
                    break;
                }

            }
            Instance formInstance = new Instance(serverIP,projID,scopeToken);
            formInstance.ShowDialog();
        }

        private void buttonRemoveInstance_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma instancia para remover");
                return;
            }
            var instanceName = listBox1.SelectedItem.ToString();
            var instanceID = "";
            foreach (JToken instance in instancesList)
            {
                if ((string)instance.SelectToken("name") == instanceName)
                {
                    instanceID = (string)instance.SelectToken("id");
                    break;
                }

            }
            OpenstackAPI openstack = new OpenstackAPI();
            var response = openstack.removeInstance(serverIP,scopeToken,instanceID);
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
            Console.WriteLine(numericStatusCode);
            if (numericStatusCode != 204)
            {
                MessageBox.Show(response.StatusCode.ToString());
                return;
            }
            else
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void buttonDNS_Click(object sender, EventArgs e)
        {
            FormDNS formDNS = new FormDNS(serverIP, scopeToken);
            formDNS.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var instanceName = listBox1.SelectedItem.ToString();
            var instanceID = "";
            foreach (JToken instance in instancesList)
            {
                if ((string)instance.SelectToken("name") == instanceName)
                {
                    instanceID = (string)instance.SelectToken("id");
                    break;
                }

            }
            FormEditInstance formEditInstance = new FormEditInstance(serverIP,scopeToken,instanceID);
            formEditInstance.Show();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma instancia para iniciar");
                return;
            }
            var instanceName = listBox1.SelectedItem.ToString();
            var instanceID = "";
            foreach (JToken instance in instancesList)
            {
                if ((string)instance.SelectToken("name") == instanceName)
                {
                    instanceID = (string)instance.SelectToken("id");
                    break;
                }

            }
            OpenstackAPI openstack = new OpenstackAPI();
            var response = openstack.startInstance(serverIP,scopeToken,instanceID);
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
            if (numericStatusCode != 202)
            {
                MessageBox.Show(response.StatusCode.ToString());
                return;
            }
            else
            {
                MessageBox.Show(response.StatusCode.ToString());
                return;
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma instancia para parar");
                return;
            }
            var instanceName = listBox1.SelectedItem.ToString();
            var instanceID = "";
            foreach (JToken instance in instancesList)
            {
                if ((string)instance.SelectToken("name") == instanceName)
                {
                    instanceID = (string)instance.SelectToken("id");
                    break;
                }

            }
            OpenstackAPI openstack = new OpenstackAPI();
            var response = openstack.stopInstance(serverIP, scopeToken, instanceID);
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
            if (numericStatusCode != 202)
            {
                MessageBox.Show(response.StatusCode.ToString());
                return;
            }
            else
            {
                MessageBox.Show(response.StatusCode.ToString());
                return;
            }
        }

        private void buttonAccessInstance_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma instancia para aceder");
                return;
            }
            var instanceName = listBox1.SelectedItem.ToString();
            var instanceID = "";
            foreach (JToken instance in instancesList)
            {
                if ((string)instance.SelectToken("name") == instanceName)
                {
                    instanceID = (string)instance.SelectToken("id");
                    break;
                }

            }
            OpenstackAPI openstack = new OpenstackAPI();
            var response = openstack.accessInstance(serverIP, scopeToken, instanceID);
            System.Diagnostics.Process.Start(response);
        }
    }
}
