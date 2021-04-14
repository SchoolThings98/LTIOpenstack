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
            comboBox1.SelectedItem = null;
            comboBox1.SelectedText = "Select a Project";
            foreach (JToken project in projetos)
            {
                comboBox1.Items.Add((string)project.SelectToken("name")+"("+(string)project.SelectToken("domain_id")+")-"+(string)project.SelectToken("id"));
                /*Console.WriteLine((string)project.SelectToken("id"));
                Console.WriteLine((string)project.SelectToken("name"));
                Console.WriteLine((string)project.SelectToken("domain_id"));*/
            }
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text== "Select a Project")
            {
                MessageBox.Show("Selecione um projeto");
            }
            else
            {
                var projID = comboBox1.Text.Substring(comboBox1.Text.LastIndexOf("-") + 1);
                //MessageBox.Show(projID);
                OpenstackAPI openstack = new OpenstackAPI();
                var newTicket = openstack.openstackScopeTicket(authToken, projID, serverIP);
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
            }
        }
    }
}
