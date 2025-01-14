using System;
using Reqnroll;
using ReqnrollProject.DataModel;
using ReqnrollProject.Helper;

namespace ReqnrollProject.StepDefinitions
{
    [Binding]
    public class CreateAccountStepDefinitions : BaseStepDefinition
    {
        public AccountRequest Account { get; set; }

        public AccountResponse Response { get; set; }


        [Given("that user wants to create an account")]
        public async Task GivenThatUserWantsToCreateAnAccount()
        {
            // Prepare Test Data
            Account = DataHelper.CreateAccount();
        }

        [When("CreateAccount is invoked with all parameter populated")]
        public async Task WhenCreateAccountIsInvokedWithAllParameterPopulated()
        {
            await DBHelper.RecordAccountToDB(Account);
            Response = await CreateUser(Account);
        }

        [Then("user is created")]
        public async Task ThenUserIsCreated()
        {
            int expectedResponseCode = 201;
            string expectedMessage = "User created!";
            VerifyReponse(expectedResponseCode, expectedMessage);
        }

        [Given("that user wants to delete an account")]
        public async Task GivenThatUserWantsToDeleteAnAccount()
        {
            Account = await DBHelper.GetAccountFromDB();
        }

        [When("DeleteAccount is invoked with required parameters")]
        public async Task WhenDeleteAccountIsInvokedWithRequiredParameters()
        {
            Response = await DeleteUser(Account.email, Account.password);
        }

        [Then("account is deleted")]
        public void ThenAccountIsDeleted()
        {
            int expectedResponseCode = 200;
            string expectedMessage = "Account deleted!";
            VerifyReponse(expectedResponseCode, expectedMessage);
        }


        private void VerifyReponse(int expectedResponseCode, string expectedMessage)
        {
            Assert.AreEqual(expectedResponseCode, Response.responseCode,
                            $"Expected response code: {expectedMessage} does not match actual: {Response.responseCode}");
            Assert.AreEqual(expectedMessage, Response.message,
                $"Expected response message: {expectedMessage} does not match actual: {Response.message}");
        }
    }
}
