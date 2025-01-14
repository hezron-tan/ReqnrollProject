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
        /// <summary>
        /// Call the Login API
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="password">password</param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates New User
        /// </summary>
        /// <param name="account">Account Object</param>
        /// <returns></returns>
        public async Task<AccountResponse> CreateUser(AccountRequest account) 
        {
            var request = new RestRequest("/createAccount");
            request.AddObject<AccountRequest>(account);

            var response = await Client.PostAsync<AccountResponse>(request);
            return response;
        }

        /// <summary>
        /// Deletes User Account
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<AccountResponse> DeleteUser(string email, string password)
        {
            var request = new RestRequest("/deleteAccount");
            request.AddHeader("Accept", "*/*");
            request.AddParameter("email", email);
            request.AddParameter("password", password);

            var response = await Client.DeleteAsync<AccountResponse>(request);
            return response;
        }
    }
}
