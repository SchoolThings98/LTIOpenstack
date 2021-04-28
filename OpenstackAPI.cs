using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public JArray zonesList(string serverIP, string scopeToken)
        {
            var projectsURI = new RestClient("http://" + serverIP + "/dns/v2/zones");
            var getRequest = new RestRequest("/", Method.GET);

            getRequest.AddHeader("x-auth-token", scopeToken);
            IRestResponse getResponse = projectsURI.Execute(getRequest);
            JObject jObject = JObject.Parse(getResponse.Content);
            JArray zones = (JArray)jObject.SelectToken("zones");
            Console.WriteLine(getResponse);
            return zones;

        }

        public IRestResponse createZone(string serverIP, string scopeToken, string name, string email)
        {
            var createZone = new RestClient("http://" + serverIP + "/dns/v2/zones");
            var postRequest = new RestRequest("/", Method.POST);
            postRequest.AddHeader("x-auth-token", scopeToken);
            var json = "{\"name\":\"" + name + "\",\"email\":\"" + email + "\"}";
            postRequest.AddJsonBody(json);
            IRestResponse ticketResponse = createZone.Execute(postRequest);
            Console.WriteLine(ticketResponse);
            return ticketResponse;

        }

        public IRestResponse createInstance(string serverIP,string scopeToken,string name, string imageID,string volumeID,string flavorID, string networkID,string count)
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
            return ticketResponse;
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

        public JArray volumeTypeList(string serverIP, string projID, string scopeToken)
        {
            var projectsURI = new RestClient("http://" + serverIP + "/volume/v3/" + projID + "/types");
            var getRequest = new RestRequest("/", Method.GET);

            getRequest.AddHeader("x-auth-token", scopeToken);

            IRestResponse getResponse = projectsURI.Execute(getRequest);
            JObject jObject = JObject.Parse(getResponse.Content);
            JArray volumesTypes = (JArray)jObject.SelectToken("volume_types");

            return volumesTypes;
        }

        public string volumeSize(string serverIP, string projID, string scopeToken,string volID)
        {
            var projectsURI = new RestClient("http://" + serverIP + "/volume/v3/" + projID + "/volumes/"+volID);
            var getRequest = new RestRequest("/", Method.GET);

            getRequest.AddHeader("x-auth-token", scopeToken);

            IRestResponse getResponse = projectsURI.Execute(getRequest);
            JObject jObject = JObject.Parse(getResponse.Content);
            //JArray volume = (JArray)jObject.SelectToken("volume");
            string size = (string)jObject["volume"].SelectToken("size");
            return size;
        }

        public IRestResponse createVolume(string serverIP, string projID, string scopeToken, string name, string size,string volID,string imageID,string type)
        {
            var createVolume = new RestClient("http://" + serverIP + "/volume/v3/" + projID + "/volumes");
            var postRequest = new RestRequest("/", Method.POST);
            postRequest.AddHeader("x-auth-token", scopeToken);
            var json= "";
            if (volID!=null)
            {
                json = "{\"volume\": {\"size\":" + size + ",\"availability_zone\": \"nova\",\"source_volid\": \""+volID+"\",\"description\": null,\"multiattach\": false,\"snapshot_id\": null,\"backup_id\": null,\"name\":\"" + name + "\",\"imageRef\": null,\"volume_type\":\"" + type + "\"}}";
            }
            else if (imageID!=null)
            {
                json = "{\"volume\": {\"size\":" + size + ",\"availability_zone\": \"nova\",\"source_volid\": null,\"description\": null,\"multiattach\": false,\"snapshot_id\": null,\"backup_id\": null,\"name\":\"" + name + "\",\"imageRef\": \""+imageID+"\",\"volume_type\":\"" + type + "\"}}";
            }
            else
            {
                json = "{\"volume\": {\"size\":" + size + ",\"availability_zone\": \"nova\",\"source_volid\": null,\"description\": null,\"multiattach\": false,\"snapshot_id\": null,\"backup_id\": null,\"name\":\"" + name + "\",\"imageRef\": null,\"volume_type\":\"" + type + "\"}}";
            }
            
            postRequest.AddJsonBody(json);
            IRestResponse ticketResponse = createVolume.Execute(postRequest);
            Console.WriteLine(ticketResponse);
            return ticketResponse;
        }

        public void createImage(string serverIP, string scopeToken, string path)
        {
            var createImg = new RestClient("http://" + serverIP + "/image/v2/images");
            var postRequest = new RestRequest("/", Method.POST);
            postRequest.AddHeader("x-auth-token", scopeToken);
            //string beforeFormat = path.Substring(0, path.LastIndexOf("."));
            string name = path.Substring(path.LastIndexOf("\\") + 1);
            string nameNoFormat = name.Substring(0,name.LastIndexOf("."));
            string format = path.Substring(path.LastIndexOf(".") + 1);
            Console.WriteLine(name + "  Formato: " + format);
            var json = "{\"container_format\":\"bare\",\"disk_format\": \"" + format + "\",\"name\": \"" + nameNoFormat + "\",\"visibility\": \"shared\"}";
            postRequest.AddJsonBody(json);
            IRestResponse createResponse = createImg.Execute(postRequest);
            JObject reservedImg = JObject.Parse(createResponse.Content);
            var imgID = (string)reservedImg.SelectToken("id");
            Console.WriteLine(imgID);
            var uploadImg = new RestClient("http://" + serverIP + "/image/v2/images/" + imgID + "/file");
            var putRequest = new RestRequest("/", Method.PUT);
            putRequest.AddHeader("x-auth-token", scopeToken);
            putRequest.AddFile(name, path, "application/octet-stream");

            IRestResponse uploadResponse = uploadImg.Execute(putRequest);
            Console.WriteLine(uploadResponse);
        }

        public IRestResponse getInstance(string serverIP, string scopeToken, string serverID)
        {
            var instanceURI = new RestClient("http://" + serverIP + "/compute/v2.1/servers/" + serverID);
            var getRequest = new RestRequest("/", Method.GET);

            getRequest.AddHeader("x-auth-token", scopeToken);

            IRestResponse getResponse = instanceURI.Execute(getRequest);
            return getResponse;
        }

        public void EditInstance(string serverIP, string scopeToken, string serverID, string name,string desc)
        {
            var instanceURI = new RestClient("http://" + serverIP + "/compute/v2.1/servers/" + serverID);
            var putRequest = new RestRequest("/", Method.PUT);

            //var json = "{\"server\": {\"name\": \""+name+ "\",\"description\": \"Sample description\"}}";
            var json = "{\"server\": {\"name\": \"" + name + "\"}}";
            putRequest.AddHeader("x-auth-token", scopeToken);
            putRequest.AddJsonBody(json);

            IRestResponse getResponse = instanceURI.Execute(putRequest);
            Console.WriteLine(getResponse);
        }

        public IRestResponse startInstance(string serverIP, string scopeToken, string serverID)
        {
            var instanceURI = new RestClient("http://" + serverIP + "/compute/v2.1/servers/"+ serverID+"/action");
            var postRequest = new RestRequest("/", Method.POST);

            var json = "{\"os-start\": null}";
            postRequest.AddHeader("x-auth-token", scopeToken);
            postRequest.AddJsonBody(json);

            IRestResponse getResponse = instanceURI.Execute(postRequest);
            return getResponse;
        }

        public IRestResponse stopInstance(string serverIP, string scopeToken, string serverID)
        {
            var instanceURI = new RestClient("http://" + serverIP + "/compute/v2.1/servers/" + serverID + "/action");
            var postRequest = new RestRequest("/", Method.POST);

            var json = "{\"os-stop\": null}";
            postRequest.AddHeader("x-auth-token", scopeToken);
            postRequest.AddJsonBody(json);

            IRestResponse getResponse = instanceURI.Execute(postRequest);
            return getResponse;
        }

        public string accessInstance(string serverIP, string scopeToken,string serverID)
        {
            var instanceURI = new RestClient("http://" + serverIP + "/compute/v2.1/servers/" + serverID + "/remote-consoles");
            var postRequest = new RestRequest("/", Method.POST);

            var json = "{\"remote_console\": {\"protocol\": \"vnc\",\"type\": \"novnc\"}}";
            postRequest.AddHeader("x-auth-token", scopeToken);
            postRequest.AddJsonBody(json);

            IRestResponse getResponse = instanceURI.Execute(postRequest);
            JObject Url = JObject.Parse(getResponse.Content);
            string url = (string)Url["remote_console"].SelectToken("url");
            Console.WriteLine(url);
            //string urlTemp = "http://192.168.113.110:6080/vnc_lite.html?path=%3Ftoken%3D91bd5d0b-9f48-4471-a2ce-8f57c20fc862";
            return url;
        }
    }
}
