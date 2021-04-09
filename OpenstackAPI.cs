using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTIOpenstackProject
{
    class OpenstackAPI
    {
        public void openstackLogin(string username, string password)
        {
            var ticketURL = new RestClient("http://192.168.113.110/identity/v3/auth/tokens");
            var postRequest = new RestRequest("/", Method.POST);

            var json = "{\"auth\": {\"identity\": {\"methods\": [\"password\"],\"password\": {\"user\": {\"name\": \""+username+"\",\"domain\": {\"name\": \"Default\"},\"password\": \""+password+"\"}}}}}";
            //var json = "{\"auth\": {\"identity\": {\"methods\": [\"password\"],\"password\": {\"user\": {\"name\": \"demo\",\"domain\": {\"name\": \"Default\"},\"password\": \"devstack\"}}}}}";
            postRequest.AddJsonBody(json);

            IRestResponse ticketResponse = ticketURL.Execute(postRequest);
            Console.WriteLine(ticketResponse);
        }
    }
}
