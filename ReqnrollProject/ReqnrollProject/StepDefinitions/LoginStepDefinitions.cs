using System;
using System.Net;
using Reqnroll;
using ReqnrollProject.DataModel;
using RestSharp;

namespace ReqnrollProject.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions : BaseStepDefinition
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public LoginResponse Response { get; set; }


        [Given("I have login with email {string}")]
        public async Task GivenIHaveLoginWithEmail(string email)
        {
            Email = email;
        }

        [Given("used password {string}")]
        public async Task GivenUsedPassword(string password)
        {
            Password = password;
        }

        [Given("I have login with empty email")]
        public void GivenIHaveLoginWithEmptyEmail()
        {
            Email = string.Empty;
        }


        [When("I verify the the login credentials")]
        public async Task WhenIVerifyTheTheLoginCredentials()
        {
           Response  = await this.Login(Email, Password);
        }

        [Then("the user exists")]
        public async Task ThenTheUserExists()
        {
            int expectedResponseCode = 200;
            string expectedMessage = "User exists!";
            VerifyReponse(expectedResponseCode, expectedMessage);
        }       

        [Then("the user is not found")]
        public void ThenTheUserIsNotFound()
        {
            int expectedResponseCode = 404;
            string expectedMessage = "User not found!";
            VerifyReponse(expectedResponseCode, expectedMessage);
        }

        [Then("the bad request is returned")]
        public void ThenTheBadRequestIsReturned()
        {
            int expectedResponseCode = 400;
            string expectedMessage = "Bad request, email or password parameter is missing in POST request.";
            VerifyReponse(expectedResponseCode, expectedMessage);
        }

        private void VerifyReponse(int expectedResponseCode, string expectedMessage)
        {
            Assert.AreEqual(expectedResponseCode, Response.responseCode,
                            $"Expected response code: {expectedMessage} does not match actual: {Response.responseCode}");
            Assert.AreEqual(expectedMessage, Response.message,
                $"Expected response message: {expectedMessage} does not match actual: {Response.responseCode}");
        }
    }
}
