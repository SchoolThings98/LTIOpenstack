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
        public string openstackLogin(string username, string password)
        {
            var ticketURL = new RestClient("http://192.168.113.110/identity/v3/auth/tokens");
            var postRequest = new RestRequest("/", Method.POST);

            var json = "{\"auth\": {\"identity\": {\"methods\": [\"password\"],\"password\": {\"user\": {\"name\": \""+username+"\",\"domain\": {\"name\": \"Default\"},\"password\": \""+password+"\"}}}}}";
            //var json = "{\"auth\": {\"identity\": {\"methods\": [\"password\"],\"password\": {\"user\": {\"name\": \"demo\",\"domain\": {\"name\": \"Default\"},\"password\": \"devstack\"}}}}}";
            postRequest.AddJsonBody(json);

            IRestResponse ticketResponse = ticketURL.Execute(postRequest);
            string getTicket = ticketResponse.Headers[0].ToString();
            getTicket = getTicket.Substring(getTicket.IndexOf("=") + 1);
     

            Console.WriteLine(ticketResponse);
            Console.WriteLine(ticketResponse.Headers[0].ToString());
            Console.WriteLine(getTicket);

            return getTicket;
        }
    }
}
