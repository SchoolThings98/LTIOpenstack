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
    public partial class FormDNS : Form
    {
        public String serverIP = "";
        public String scopeToken = "";
        public JArray zonesList = null;
        public FormDNS(string ip, string token)
        {
            InitializeComponent();
            serverIP = ip;
            scopeToken = token;
        }

        private void FormDNS_Load(object sender, EventArgs e)
        {
            
            OpenstackAPI openstack = new OpenstackAPI();
            var zones = openstack.zonesList(serverIP, scopeToken);
            zonesList = zones;
            //Console.WriteLine(zones);
            foreach (JToken zone in zones)
            {
                listBox1.Items.Add((string)zone.SelectToken("name"));
            }
        }

        private void btnCreateZone_Click(object sender, EventArgs e)
        {
            FormCreateZone formCreateZone = new FormCreateZone(serverIP, scopeToken);
            formCreateZone.ShowDialog();
        }

        //FALTA TESTAR
        private void btnDeleteZone_Click(object sender, EventArgs e)
        {
            var zoneNme = listBox1.SelectedItem.ToString();
            var zoneID = "";
            foreach (JToken zone in zonesList)
            {
                if ((string)zone.SelectToken("name") == zoneNme)
                {
                    zoneID = (string)zone.SelectToken("id");
                    break;
                }
            }
            OpenstackAPI openstack = new OpenstackAPI();
            var response = openstack.removeZone(serverIP, scopeToken, zoneID);
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
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void btnUpdateZone_Click(object sender, EventArgs e)
        {
            var zoneNme = listBox1.SelectedItem.ToString();
            var zoneID = "";
            foreach (JToken zone in zonesList)
            {
                if ((string)zone.SelectToken("name") == zoneNme)
                {
                    zoneID = (string)zone.SelectToken("id");
                    break;
                }
            }
            FormEditZone formEditZone = new FormEditZone(serverIP, scopeToken, zoneID);
            formEditZone.Show();
        }
    }
}
