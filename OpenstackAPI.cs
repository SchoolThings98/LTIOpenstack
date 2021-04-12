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

        public void projectList(string token, string ip)
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
            foreach(JToken project in projects)
            {
                Console.WriteLine((string)project.SelectToken("id"));
                Console.WriteLine((string)project.SelectToken("name"));
                Console.WriteLine((string)project.SelectToken("domain_id"));
            }
            Console.WriteLine(projects);
        }
    }
}
