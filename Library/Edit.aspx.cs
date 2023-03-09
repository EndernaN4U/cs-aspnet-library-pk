using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Library
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["connstr"] == null) Response.Redirect("Connection.aspx");
            if (Session["logged"] == null || !(bool)(Session["logged"])) Response.Redirect("login.aspx");
            if (Session["editid"] == null) Response.Redirect("ViewBooks.aspx");

            if (IsPostBack) return;

            MySqlConnection conn = Global.MakeConnSingle(Session["connstr"].ToString());
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = $"SELECT * FROM books WHERE id='{Session["editid"]}'";
            
            MySqlDataReader reader = comm.ExecuteReader();
            reader.Read();

            string author = reader.GetString("author"),
                title = reader.GetString("title"),
                date = reader.GetString("date"),
                isbn = reader.GetString("isbn"),
                format = reader.GetString("format"),
                pages = reader.GetString("pages"),
                description = reader.GetString("description");


            Author.Text = author;
            Title.Text = title;
            Date.Text = date;
            ISBN.Text = isbn;
            Format.Text = format;
            Pages.Text = pages;   
            Description.Text = description;

            conn.Close();

        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = Global.MakeConnSingle(Session["connstr"].ToString());
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = $"UPDATE books" +
                $" SET author='{Author.Text}' , " +
                $"title='{Title.Text}' , " +
                $"date='{Date.Text}' , " +
                $"isbn='{ISBN.Text}' , " +
                $"format='{Format.Text}' , " +
                $"pages='{Pages.Text}' , " +
                $"description='{Description.Text}'" +
                $" WHERE id='{Session["editid"]}'";
            comm.ExecuteNonQuery();
            Response.Redirect("ViewBooks.aspx");
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBooks.aspx");
        }
    }
}