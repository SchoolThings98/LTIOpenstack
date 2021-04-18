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
                var instances = openstack.instanceList(scopeToken,serverIP);
                foreach(JToken intance in instances)
                {
                    listBox1.Items.Add((string)intance.SelectToken("id"));
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
            string instance = listBox1.SelectedItem.ToString();
            listView1.Items.Add(instance);
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
    }
}
