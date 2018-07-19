using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class SampleData
    {
        public static DataTable GetPeople()
        {
            Person[] people = new Person[]
            {
                new Person("정우성", 36, true)
                , new Person("고소영", 32, false)
                , new Person("배용준", 37, true)
                , new Person("김태희", 29, false)
            };

            return GetPeople(people);
        }

        public static DataTable GetPeople(Person[] people)
        {
            DbSample data = new DbSample();
            return data.GetPeopleTable(people);
        }

        public static DataTable GetSale()
        {
            DbSample data = new DbSample();
            return data.GetSaleTable();
        }

        public static string GetConnectionString()
        {
            DbConn db = new DbConn();
            return db.GetConnectionString();
        }

        public static string GetMySqlConnectionString()
        {
            MySqlDbConn db = new MySqlDbConn();
            return db.GetConnectionString();
        }

        public static string GetOleDbConnectionString(string connectionName)
        {
            OleDbConn db = new OleDbConn();
            return db.GetOleDbConnectionString(connectionName);
        }

        public static string GetOleDbConnectionString(string applicationStartupPath, string folder, string accessFileName)
        {
            OleDbConn db = new OleDbConn();
            return db.GetOleDbConnectionString(applicationStartupPath, folder, accessFileName);
        }
    }
}
