using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Library
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["connstr"] == null) Response.Redirect("Connection.aspx");
            if (Session["logged"] != null && (bool)(Session["logged"])) Response.Redirect("ViewBooks.aspx");
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string nick = LoginTxt.Text,
                password = PasswordTxt.Text;
            password = Global.GetHash(SHA256.Create(), password);

            if(nick == "" || password == "")
            {
                ErrorsTxt.Text = "Login and password need some values";
                return;
            }

            MySqlConnection conn = Global.MakeConnSingle(Session["connstr"].ToString());
            if (conn == null) 
            {
                ErrorsTxt.Text = "Connection Error";
                return;
            };

            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = $"SELECT COUNT(*) AS 'count', id, type FROM users WHERE nick LIKE '{nick}' AND password LIKE '{password}'";
            MySqlDataReader reader = comm.ExecuteReader();
            reader.Read();

            int loged = Convert.ToInt32(reader.GetString("count"));

            if (loged != 0)
            {
                Session["logged"] = true;
                Session["uid"] = reader.GetString("id");
                Session["type"] = reader.GetString("type");
                Response.Redirect("ViewBooks.aspx");
                return;
            }
            ErrorsTxt.Text = "There's no account with these informations.";    

        }

        protected void Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void BackConn_Click(object sender, EventArgs e)
        {
            Session["connstr"] = null;
            Response.Redirect("Connection.aspx");
        }
    }
}