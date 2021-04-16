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
        
        public IRestResponse openstackScopeTicket(string token, string projid, string ip)
        {
            var ticketURL = new RestClient("http://" + ip + "/identity/v3/auth/tokens");
            var postRequest = new RestRequest("/", Method.POST);

            var json = "{\"auth\": {\"identity\": {\"methods\": [\"token\"],\"token\": {\"id\": \"" + token + "\"}},\"scope\": {\"project\": {\"id\": \"" + projid + "\"}}}}";
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
    }
}
