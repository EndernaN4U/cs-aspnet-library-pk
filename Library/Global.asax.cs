using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Library
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        static public MySqlConnection MakeConn(string server = "localhost", string database = "library", string user = "root", string password = "")
        {
            string myconn = $"Server={server};" +
                $"Database={database};" +
                $"User={user};" +
                $"Password={password};";
            MySqlConnection conn = new MySqlConnection(myconn);
            try
            {
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        static public MySqlConnection MakeConnSingle(string connString)
        {
            string myconn = connString;
            MySqlConnection conn = new MySqlConnection(myconn);
            try
            {
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        static public string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}