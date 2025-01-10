using ReqnrollProject.DataModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject.StepDefinitions
{
    public class BaseStepDefinition : APIRestSharp
    {
        public async Task<LoginResponse> Login(string email, string password)
        {
            var request = new RestRequest("/verifyLogin");
            
            if (email != string.Empty)
            {
                request.AddParameter("email", email);
            }
            
            request.AddParameter("password", password);
            
            var response = await Client.PostAsync<LoginResponse>(request);
            return response;
        }
    }
}
