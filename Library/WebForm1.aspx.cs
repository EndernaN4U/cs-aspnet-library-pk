using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Library
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logged"] == null || !(bool)(Session["logged"])) Response.Redirect("login.aspx");

            MySqlConnection conn = Global.MakeConn();

            if (conn == null) return;

            DataTable dt = new DataTable();
            dt.Columns.Add("id",typeof(int));
            dt.Columns.Add("nick",typeof(string));
            dt.Columns.Add("password",typeof(string));  

            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "SELECT * FROM users";

            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                DataRow row = dt.NewRow();
                row["id"] = reader.GetString("id");
                row["nick"] = reader.GetString("nick");
                row["password"] = reader.GetString("password");
                dt.Rows.Add(row);
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}