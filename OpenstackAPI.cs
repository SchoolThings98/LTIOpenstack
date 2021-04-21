using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LTIOpenstackProject
{
    class OpenstackAPI
    {
        public IRestResponse openstackLogin(string username, string password, string ip)
        {
            var ticketURL = new RestClient("http://"+ip+"/identity/v3/auth/tokens");
            var postRequest = new RestRequest("/", Method.POST);

            var json = "{\"auth\": {\"identity\": {\"methods\": [\"password\"],\"password\": {\"user\": {\"name\": \""+username+"\",\"domain\": {\"name\": \"Default\"},\"password\": \""+password+"\"}}}}}";
            //var json = "{\"auth\": {\"identity\": {\"methods\": [\"password\"],\"password\": {\"user\": {\"name\": \"demo\",\"domain\": {\"name\": \"Default\"},\"password\": \"devstack\"}}}}}";
            postRequest.AddJsonBody(json);

            IRestResponse ticketResponse = ticketURL.Execute(postRequest);
     
            Console.WriteLine(ticketResponse.StatusCode);
            

            return ticketResponse;
        }
        
        public IRestResponse openstackScopeTicket(string token, string name,string domain, string ip)
        {
            var ticketURL = new RestClient("http://" + ip + "/identity/v3/auth/tokens");
            var postRequest = new RestRequest("/", Method.POST);

            var json = "{\"auth\": {\"identity\": {\"methods\": [\"token\"],\"token\": {\"id\": \"" + token + "\"}},\"scope\": {\"project\": {\"domain\":{\"id\":\""+domain+"\"},\"name\":\""+name+"\"}}}}";
            postRequest.AddJsonBody(json);

            IRestResponse ticketResponse = ticketURL.Execute(postRequest);

            //Console.WriteLine(ticketResponse);
            return ticketResponse;
        }
        public JArray projectList(string token, string ip) 
        {
            var projectsURI = new RestClient("http://" +ip+"/identity/v3/auth/projects");
            var getRequest = new RestRequest("/", Method.GET);
            getRequest.AddHeader("x-auth-token",token);

            IRestResponse getResponse = projectsURI.Execute(getRequest);
            /*
            JsonDocument doc = JsonDocument.Parse(getResponse.Content);
            JsonElement root = doc.RootElement;*/
            JObject jObject = JObject.Parse(getResponse.Content);
            JArray projects = (JArray)jObject.SelectToken("projects");
            /*foreach(JToken project in projects)
            {
                Console.WriteLine((string)project.SelectToken("id"));
                Console.WriteLine((string)project.SelectToken("name"));
                Console.WriteLine((string)project.SelectToken("domain_id"));
            }*/
            Console.WriteLine(projects);
            return projects;
            
        }

        public JArray instanceList(string scopeToken,string ip)
        {
            var projectsURI = new RestClient("http://" + ip + "/compute/v2.1/servers");
            var getRequest = new RestRequest("/", Method.GET);

            getRequest.AddHeader("x-auth-token", scopeToken);

            IRestResponse getResponse = projectsURI.Execute(getRequest);
            JObject jObject = JObject.Parse(getResponse.Content);
            JArray instances = (JArray)jObject.SelectToken("servers");

            Console.WriteLine(getResponse);
            return instances;
        }


        public JArray volumeList(string serverIP,string projID,string scopeToken)
        {
            var projectsURI = new RestClient("http://" + serverIP + "/volume/v3/"+projID+"/volumes");
            var getRequest = new RestRequest("/", Method.GET);

            getRequest.AddHeader("x-auth-token", scopeToken);

            IRestResponse getResponse = projectsURI.Execute(getRequest);
            JObject jObject = JObject.Parse(getResponse.Content);
            JArray volumes = (JArray)jObject.SelectToken("volumes");
            Console.WriteLine(getResponse);

            return volumes;
        }

        public JArray imageList(string serverIP, string scopeToken)
        {
            
            var projectsURI = new RestClient("http://" + serverIP + "/image/v2/images");
            var getRequest = new RestRequest("/", Method.GET);

            getRequest.AddHeader("x-auth-token", scopeToken);
            IRestResponse getResponse = projectsURI.Execute(getRequest);
            JObject jObject = JObject.Parse(getResponse.Content);
            JArray images = (JArray)jObject.SelectToken("images");
            Console.WriteLine(getResponse);
            return images;
        }

        public JArray networksList(string serverIP, string scopeToken)
        {
            var projectsURI = new RestClient("http://" + serverIP + ":9696/v2.0/networks");
            var getRequest = new RestRequest("/", Method.GET);

            getRequest.AddHeader("x-auth-token", scopeToken);
            IRestResponse getResponse = projectsURI.Execute(getRequest);
            JObject jObject = JObject.Parse(getResponse.Content);
            JArray networks = (JArray)jObject.SelectToken("networks");
            Console.WriteLine(getResponse);
            return networks;
        }

        public JArray flavorList(string serverIP, string scopeToken)
        {
            var projectsURI = new RestClient("http://" + serverIP + "/compute/v2.1/flavors");
            var getRequest = new RestRequest("/", Method.GET);

            getRequest.AddHeader("x-auth-token", scopeToken);
            IRestResponse getResponse = projectsURI.Execute(getRequest);
            JObject jObject = JObject.Parse(getResponse.Content);
            JArray flavors = (JArray)jObject.SelectToken("flavors");
            Console.WriteLine(getResponse);
            return flavors;
        }

        public void createInstance(string serverIP,string scopeToken,string name, string imageID,string volumeID,string flavorID, string networkID,string count)
        {
            Console.WriteLine(imageID);
            Console.WriteLine(flavorID);
            Console.WriteLine(networkID);
            Console.WriteLine(volumeID);
            var ticketURL = new RestClient("http://" + serverIP + "/compute/v2.1/servers");
            var postRequest = new RestRequest("/", Method.POST);
            postRequest.AddHeader("x-auth-token", scopeToken);
            if (imageID!=null) {
                var json = "{\"server\":{\"name\":\"" + name + "\",\"imageRef\":\"" + imageID + "\",\"flavorRef\":\"http://openstack.example.com/flavors/" + flavorID + "\",\"networks\":[{\"uuid\":\"" + networkID + "\"}],\"min_count\":\""+count+"\"}}";
                postRequest.AddJsonBody(json);
            }
            if (volumeID != null)
            {
                var json = "{\"server\":{\"name\":\"" + name + "\",\"flavorRef\":\"http://openstack.example.com/flavors/" + flavorID + "\",\"networks\":[{\"uuid\":\"" + networkID + "\"}],\"block_device_mapping_v2\":[{\"boot_index\":\"-1\",\"uuid\":\""+volumeID+ "\",\"source_type\":\"volume\",\"destination_type\":\"volume\"}]}}";
                postRequest.AddJsonBody(json);
            }

            IRestResponse ticketResponse = ticketURL.Execute(postRequest);

            Console.WriteLine(ticketResponse.StatusCode);
        }

        public IRestResponse removeInstance(string serverIP, string scopeToken, string instanceID)
        {
            var ticketURL = new RestClient("http://" + serverIP + "/compute/v2.1/servers/"+instanceID);
            var deleteRequest = new RestRequest("/", Method.DELETE);
            deleteRequest.AddHeader("x-auth-token", scopeToken);

            IRestResponse ticketResponse = ticketURL.Execute(deleteRequest);
            Console.WriteLine(ticketResponse);
            return ticketResponse;
        }
    }
}
