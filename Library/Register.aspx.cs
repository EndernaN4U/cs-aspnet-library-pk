using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Library
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["connstr"] == null) Response.Redirect("Connection.aspx");
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string nick = Nick.Text,
                email = Email.Text,
                password = Password.Text;

            if(nick == "" || email == "" || password == "" )
            {
                Errors.Text = "You need to fill text boxes!";
                return;
            }

            if(!new Regex(@"^.*@.*[.].*$").IsMatch(email))
            {
                Errors.Text = "That's kinda bad looking email";
                return;
            }

            SHA256 sha256 = SHA256.Create();
            string hash = Global.GetHash(sha256, password);

            MySqlConnection conn = Global.MakeConnSingle(Session["connstr"].ToString());
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = $"SELECT COUNT(*) AS 'count', id FROM users WHERE nick='{nick}' OR email='{email}'";
            MySqlDataReader reader = comm.ExecuteReader();
            reader.Read();

            int accs = Convert.ToInt32(reader.GetString("count"));
            if(accs > 0)
            {
                Errors.Text = "Email or nickname already in use!";
                return;
            }
            reader.Close();

            comm = conn.CreateCommand();
            comm.CommandText = $"INSERT INTO users VALUES(NULL, '{nick}', '{hash}', '{email}', 'user')";
            comm.ExecuteNonQuery();
            Response.Redirect("login.aspx");
        }

        
    }
}