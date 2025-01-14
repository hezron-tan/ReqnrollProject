using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject.Database
{
    public static class DBConnection
    {
        public static string DbFile
        {
            get { return Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\net8.0","\\Database") + "\\Reqnroll.sqlite"; }
        }

        public static SQLiteConnection SqliteDbConnection()
        {
            return new SQLiteConnection("Data Source=" + DbFile);
        }
    }
}
