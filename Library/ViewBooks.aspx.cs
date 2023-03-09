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
    public partial class WebForm3 : System.Web.UI.Page
    {
        private DataTable dt;

        protected void ChangeRows(object sender, EventArgs e)
        {
            MySqlConnection conn = Global.MakeConnSingle(Session["connstr"].ToString());
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = $"SELECT * FROM books WHERE " +
                $"author LIKE '%{Author.Text}%' AND "+
                $"title LIKE '%{Title.Text}%' AND " +
                $"date LIKE '%{Date.Text}%' AND " +
                $"description LIKE '%{Description.Text}%' AND " +
                $"isbn LIKE '%{ISBN.Text}%' ";

            dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("author", typeof(string));
            dt.Columns.Add("title", typeof(string));
            dt.Columns.Add("date", typeof(string));
            dt.Columns.Add("isbn", typeof(string));
            dt.Columns.Add("format", typeof(string));
            dt.Columns.Add("pages", typeof(int));
            dt.Columns.Add("description", typeof(string));

            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                DataRow row = dt.NewRow();
                row["id"] = reader.GetString("id");
                row["author"] = reader.GetString("author");
                row["title"] = reader.GetString("title");
                row["date"] = reader.GetString("date");
                row["isbn"] = reader.GetString("isbn");
                row["format"] = reader.GetString("format");
                row["pages"] = reader.GetString("pages");
                row["description"] = reader.GetString("description");
                dt.Rows.Add(row);
            }

            BooksGrid.DataSource = dt;
            BooksGrid.DataBind();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["connstr"] == null) Response.Redirect("Connection.aspx");
            if (Session["logged"] == null || !(bool)(Session["logged"])) Response.Redirect("login.aspx");

            string type = Session["type"].ToString();
            if (type != "admin" && type != "mod")
            {
                BooksGrid.Columns.Clear();
                Addnew.Visible = false;          
            }
            if (type != "admin") Users.Visible = false;

            MySqlConnection conn = Global.MakeConnSingle(Session["connstr"].ToString());

            if (conn == null) return;

            ChangeRows(sender, e);
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
            

            if (e.CommandName == "DeleteRow")
            {
                MySqlConnection conn = Global.MakeConnSingle(Session["connstr"].ToString());
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = $"DELETE FROM books WHERE id='{id}'";
                comm.ExecuteNonQuery();
                Response.Redirect("ViewBooks.aspx");
            }
            if (e.CommandName == "EditRow")
            {
                Session["editid"] = id;
                Response.Redirect("Edit.aspx");
            }
        }

        protected void Addnew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNew.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["logged"] = false;
            Response.Redirect("login.aspx");
        }

        protected void Users_Click(object sender, EventArgs e)
        {
            Response.Redirect("Users.aspx");
        }
    }
}