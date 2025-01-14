using Bogus;
using ReqnrollProject.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject.Helper
{
    public static class DataHelper
    {

        public static AccountRequest CreateAccount()
        {
            var faker = new Faker("en");
            var birthDate = faker.Date.Past(faker.Random.Number(18, 99));
            var gender = faker.PickRandom<Bogus.DataSets.Name.Gender>();
            var title = gender == Bogus.DataSets.Name.Gender.Male ? "Mr" : "Miss";

            var account = new AccountRequest()
            {
                name = faker.Internet.UserName(),
                email = faker.Internet.Email(),
                password = faker.Internet.Password(),
                title = title,
                birth_date = Convert.ToDateTime(birthDate).Day.ToString(),
                birth_month = Convert.ToDateTime(birthDate).Month.ToString(),
                birth_year = Convert.ToDateTime(birthDate).Year.ToString(),
                firstname = faker.Name.FirstName(gender),
                lastname = faker.Name.LastName(gender),
                company = faker.Company.CompanyName(),
                address1 = faker.Address.StreetAddress(),
                address2 = faker.Address.SecondaryAddress(),
                country = faker.Address.Country(),
                zipcode = faker.Address.ZipCode(),
                state = faker.Address.State(),
                city = faker.Address.City(),
                mobile_number = faker.Phone.PhoneNumber()
            };
            
            return account;
        }
    }
}
