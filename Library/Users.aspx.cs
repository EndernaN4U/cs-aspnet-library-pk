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
    public partial class Users : System.Web.UI.Page
    {
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["connstr"] == null) Response.Redirect("Connection.aspx");
            if (Session["logged"] == null || !(bool)(Session["logged"])) Response.Redirect("login.aspx");

            MySqlConnection conn = Global.MakeConnSingle(Session["connstr"].ToString());
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = $"SELECT * FROM users";

            dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("nick", typeof(string));
            dt.Columns.Add("email", typeof(string));
            dt.Columns.Add("type", typeof(string));

            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                DataRow row = dt.NewRow();
                row["id"] = reader.GetString("id");
                row["nick"] = reader.GetString("nick");
                row["email"] = reader.GetString("email");
                row["type"] = reader.GetString("type");
                dt.Rows.Add(row);
            }

            UsersGrid.DataSource = dt;
            UsersGrid.DataBind();
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBooks.aspx");
        }

        protected void BooksGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id;
            try
            {
                id = dt?.Rows[Convert.ToInt32(e.CommandArgument)]["id"].ToString();
            }
            catch
            {
                return;
            }

            MySqlConnection conn = Global.MakeConnSingle(Session["connstr"].ToString());
            MySqlCommand comm = conn.CreateCommand();

            if (e.CommandName == "Delete")
            {
                comm.CommandText = $"DELETE FROM users WHERE id='{id}'";
                comm.ExecuteNonQuery();
            }
            else
            {
                comm.CommandText = $"SELECT type FROM users WHERE id='{id}'";
                MySqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                string type = reader.GetString("type");
                reader.Close();

                if (e.CommandName == "Promote")
                {
                    if (type == "admin") return;
                    if (type == "user") comm.CommandText = $"UPDATE users SET type='mod' WHERE id='{id}'";
                    if (type == "mod") comm.CommandText = $"UPDATE users SET type='admin' WHERE id='{id}'";
                }
                else if (e.CommandName == "Demote")
                {
                    if (type == "mod") comm.CommandText = $"UPDATE users SET type='user' WHERE id='{id}'";
                    else return;
                }

                comm.ExecuteNonQuery();
            }
            
            Response.Redirect("Users.aspx");
        }
    }
}