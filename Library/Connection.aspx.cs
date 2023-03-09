using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Library
{
    public partial class Connection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["connstr"] != null) Response.Redirect("login.aspx");
        }

        protected void Connect_Click(object sender, EventArgs e)
        {
            string server = ServerTxt.Text;
            string database = DatabaseTxt.Text;
            string user =   UserTxt.Text;
            string pass = PasswordTxt.Text;

            if( server == "" || database == "" || user == "")
            {
                ErrorLabel.Text = "Nalezy cos wpisać do srodka :D";
                return;
            }

            if(Global.MakeConn(server,database,user,pass) != null)
            {
                Session["connstr"] = $"Server={server};" +
                $"Database={database};" +
                $"User={user};" +
                $"Password={pass};";

                Response.Redirect("login.aspx");
            }
            else
            {
                ErrorLabel.Text = "Connection Error";
                return;
            }


        }
    }
}