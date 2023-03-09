using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
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
            string author = Author.Text,
               title = Title.Text,
               date = Date.Text,
               isbn = ISBN.Text,
               format = Format.Text,
               pages = Pages.Text,
               description = Description.Text;

            if (author == "" || title == "" || date == "" || isbn == "" || format == "" || pages == "" || description == "")
            {
                Errors.Text = "You need to fill text fields to continue!";
                return;
            }
            if (!new Regex(@"^[0-9]{2}[-][0-9]{2}[-][0-9]{4}$").IsMatch(date))
            {
                Errors.Text = "Date should be in format dd-mm-yyyy";
                return;
            }
            if (format.Length > 3)
            {
                Errors.Text = "Format shouldn't be longer than 3 chars!";
                return;
            }
            if (!new Regex(@"^[0-9]*$").IsMatch(pages))
            {
                Errors.Text = "Pages should be a number!";
                return;
            }

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