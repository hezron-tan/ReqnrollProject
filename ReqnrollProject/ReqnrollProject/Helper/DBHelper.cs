using Dapper;
using ReqnrollProject.Database;
using ReqnrollProject.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject.Helper
{
    public static class DBHelper
    {
        public static async Task RecordAccountToDB(AccountRequest account)
        {
            using (var conn = DBConnection.SqliteDbConnection())
            {
                conn.Open();
                var xx = conn.ConnectionString;
                var insertCmd = conn.CreateCommand();
                insertCmd.CommandText = "INSERT INTO Account " +
                    "(name, email, password, title, birth_date, birth_month, birth_year, firstname, lastname," +
                    "company, address1, address2, country, zipcode, state, city, mobile_number) VALUES " +
                    "(@name, @email, @password, @title, @birth_date, @birth_month, @birth_year, @firstname, @lastname, " +
                    "@company, @address1, @address2, @country, @zipcode, @state, @city, @mobile_number);";
                insertCmd.Parameters.AddWithValue("name", account.name);
                insertCmd.Parameters.AddWithValue("email", account.email);
                insertCmd.Parameters.AddWithValue("password", account.password);
                insertCmd.Parameters.AddWithValue("title", account.title);
                insertCmd.Parameters.AddWithValue("birth_date", account.birth_date);
                insertCmd.Parameters.AddWithValue("birth_month", account.birth_month);
                insertCmd.Parameters.AddWithValue("birth_year", account.birth_year);
                insertCmd.Parameters.AddWithValue("firstname", account.firstname);
                insertCmd.Parameters.AddWithValue("lastname", account.lastname);
                insertCmd.Parameters.AddWithValue("company", account.company);
                insertCmd.Parameters.AddWithValue("address1", account.address1);
                insertCmd.Parameters.AddWithValue("address2", account.address2);
                insertCmd.Parameters.AddWithValue("country", account.country);
                insertCmd.Parameters.AddWithValue("zipcode", account.zipcode);
                insertCmd.Parameters.AddWithValue("state", account.state);
                insertCmd.Parameters.AddWithValue("city", account.city);
                insertCmd.Parameters.AddWithValue("mobile_number", account.mobile_number);
                await insertCmd.ExecuteNonQueryAsync();
                conn.Close();
            }
        }

        public static async Task<AccountRequest> GetAccountFromDB()
        {
            AccountRequest query;

            using (var conn = DBConnection.SqliteDbConnection())
            {
                conn.Open();
                query = conn.QueryAsync<AccountRequest>("SELECT * FROM Account").Result.First();
                conn.Close();
            }
            
            return query;
        }
    }
}
